using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace DB.Extensions.Downloading.IMP
{
    public class Downloader : MonoBehaviour
    {
        public void Download(string url, Action<LoadedAsset> loadedData) 
        {
            StartCoroutine(RequestAssets(url, (bool successfull, LoadedAsset asset) =>
            {
                if (successfull)
                {
                    loadedData?.Invoke(asset);
                    RemoveDownloadManager();
                }
                else {
                    Debug.Log("Download failed:" + url);
                    loadedData?.Invoke(null);
                    RemoveDownloadManager();
                }
            }));
        }

        private IEnumerator RequestAssets(string url, Action<bool, LoadedAsset> loadComplete) 
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url)) 
            {
                yield return www.SendWebRequest();

                if (www.isHttpError || www.isNetworkError)
                {
                    loadComplete?.Invoke(false, null);
                }
                else {
                    loadComplete?.Invoke(true, new LoadedAsset(Path.GetFileName(url), www.downloadHandler.data));
                }
            }
        }

        private void RemoveDownloadManager()
        {
            Destroy(this);
        }
    }
}