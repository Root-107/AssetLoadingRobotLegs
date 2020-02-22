using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class AssetProcessor : MonoBehaviour
    {
        Action compleatCallback;

        IAssetDatabaseModel database;

        string readLocation;

        string databaseName;


        int assetsToLoad = 0;
        int assetsLoaded = 0;

        public void InitaliseProcessor(Action callback, string readLocation, IAssetDatabaseModel model, string databaseName) 
        {
            database = model;
            this.databaseName = databaseName;
            compleatCallback = callback;
            this.readLocation = readLocation;
        }

        void UpdateLoadedAssets() 
        {
            assetsLoaded++;

            Debug.Log($"Proccessed:{assetsLoaded}/{assetsToLoad}");

            if (assetsToLoad == assetsLoaded) 
            {
                compleatCallback?.Invoke();
            }
        }

        public IEnumerator Process(Assets assets)
        {
            assetsLoaded = 0;
            assetsToLoad = GetTotalAssets(assets);

            for (int i = 0; i < assets.assets.Length; i++)
            {
                Asset asset = assets.assets[i];

                switch (asset.assetType)
                {
                    case AssetTypes.Image:
                        yield return StartCoroutine(GetFileBytes(asset.filePath, (bool success, LoadedAsset _asset) =>
                        {
                            if (success)
                            {
                                ProcessImage(_asset, asset.title, asset.id, asset.payload);
                            }
                            else
                            {
                                UpdateLoadedAssets();
                            }
                        }));
                        break;
                    case AssetTypes.PDF:
                        //Maybe do a for eahc asset in folder location ?
                        for (int j = 0; j < asset.pages; j++)
                        {
                            //TODO need to do a check on the extention type and the file existing
                            yield return StartCoroutine(GetFileBytes($"{asset.filePath}/a-{j}.png", (bool success, LoadedAsset _asset) =>
                            {
                                if (success)
                                {
                                    ProcessPDF(_asset, asset.title, asset.id, asset.payload);
                                }
                                else
                                {
                                    UpdateLoadedAssets();
                                }
                            }));
                        }
                        break;
                    case AssetTypes.Text:
                        yield return StartCoroutine(GetFileBytes(asset.filePath, (bool success, LoadedAsset _asset) =>
                        {
                            if (success)
                            {
                                ProcessText(_asset, asset.title, asset.id, asset.payload);
                            }
                            else
                            {
                                UpdateLoadedAssets();
                            }
                        }));
                        break;
                    case AssetTypes.Texture:
                        yield return StartCoroutine(GetFileBytes(asset.filePath, (bool success, LoadedAsset _asset) =>
                        {
                            if (success)
                            {
                                ProcessTexture(_asset, asset.title, asset.id, asset.payload);
                            }
                            else
                            {
                                UpdateLoadedAssets();
                            }
                        }));
                        break;
                    case AssetTypes.Video:
                        //ajust the file path here ?
                        //also need to get its file extention
                        ProcessVideo(asset.filePath, asset.title, asset.id);
                        break;
                }

            }
        }
        public void ProcessPDF(LoadedAsset asset, string key, int id, object payload = null)
        {
            if (database == null || asset == null)
            {
                UpdateLoadedAssets();
                return;
            }

            database.AssignPDF(id, key, GetSpirite(asset), databaseName, payload);

            UpdateLoadedAssets();
        }

        public void ProcessText(LoadedAsset asset, string key, int id, object payload = null)
        {
            string fileText = System.Text.Encoding.UTF8.GetString(asset.AssetBytes);

            if (database == null || asset == null)
            {
                UpdateLoadedAssets();
                return;
            }

            database.AssignText(id, key, fileText, databaseName, payload);
            UpdateLoadedAssets();
        }

        public void ProcessImage(LoadedAsset asset, string key, int id, object payload = null)
        {
            if (database == null || asset == null)
            {
                UpdateLoadedAssets();
                return;
            }

            database.AssignImage(id, key, GetSpirite(asset), databaseName, payload);

            UpdateLoadedAssets();
        }

        public void ProcessTexture(LoadedAsset asset, string key, int id, object payload = null)
        {
            if (database == null || asset == null)
            {
                UpdateLoadedAssets();
                return;
            }

            database.AssignTexture(id, key, GetTexture(asset), databaseName, payload);
            UpdateLoadedAssets();
        }

        public void ProcessVideo(string filePath, string key, int id, object payload = null)
        {
            if (database == null || string.IsNullOrEmpty(filePath))
            {
                UpdateLoadedAssets();
                return;
            }

            database.AssingVideo(id, key, readLocation + "/" + filePath, databaseName, payload);
            UpdateLoadedAssets();
        }

        private int GetTotalAssets(Assets assets)
        {
            int assetsCount = 0;

            for (int i = 0; i < assets.assets.Length; i++)
            {
                if (assets.assets[i].assetType == AssetTypes.PDF)
                {
                    assetsCount += assets.assets[i].pages;
                }
                else
                {
                    assetsCount++;
                }
            }

            return assetsCount;
        }

        public IEnumerator GetFileBytes(string _fileLocation, Action<bool, LoadedAsset> _asset)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(readLocation + "/" + _fileLocation))
            {
                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isNetworkError)
                {
                    _asset?.Invoke(false, null);
                    Debug.Log("Error trying to process:" + readLocation + "/" + _fileLocation);
                }
                else
                {
                    _asset?.Invoke(true, new LoadedAsset(Path.GetFileName(readLocation + "/" + _fileLocation), request.downloadHandler.data));
                }
            }
        }

        private Texture2D GetTexture(LoadedAsset asset)
        {
            Texture2D texture;

#if UNITY_IOS
           texture = new Texture2D(1, 1, TextureFormat.PVRTC_RGBA4, false);
#else
            texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
#endif
            texture.LoadImage(asset.AssetBytes);
            texture.Apply();

            return texture;
        }

        private Sprite GetSpirite(LoadedAsset asset)
        {
            Texture2D texture = GetTexture(asset);

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}