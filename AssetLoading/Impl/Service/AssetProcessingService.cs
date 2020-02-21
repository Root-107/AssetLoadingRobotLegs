using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class AssetProcessingService : MonoBehaviour, IAssetProcessingService
    {
        [Inject]
        public IAssetDatabaseModel database;

        GenorateComplete genorator = new GenorateComplete();

        private bool autoGenorateCompete = false;
        private string rootLocation = "";

        public void AutoGenerateComplete(bool autoGenerate)
        {
            autoGenorateCompete = autoGenerate;
        }

        public void SetRootLocation(string path)
        {
            rootLocation = string.IsNullOrEmpty(path) ? Application.persistentDataPath : path;
        }

        public void ProcessAssets(Action onComplete, string folder = "", Assets data = null, bool lazyLoadDatabase = false)
        {
            folder = Createdatabase(folder);

            if (data == null) 
            {
                data = GenorateCompleteData(folder);
            }

            if (lazyLoadDatabase) 
            {
                throw new Exception("Lazy loading not yet implemented");
            }

            AssetProcessor processor = gameObject.AddComponent<AssetProcessor>();
            processor.InitaliseProcessor(onComplete, rootLocation + "/" + folder, database, folder);

            StartCoroutine(processor.Process(data));
        }

        private Assets GenorateCompleteData(string location) 
        {
            Assets data = null;

            string filePath = $"{rootLocation}/complete_{location}.json";
            FileInfo file = new FileInfo(filePath);

            if (file == null || file.Exists == false) 
            {
                Debug.Log("No complete, Genorating");
                data = genorator.Genorate(rootLocation + "/" + location, false);
                WriteComplete(filePath, data);
            }
            else
            {
                if (autoGenorateCompete)
                {
                    data = genorator.Genorate(rootLocation + "/" + location, false);
                    WriteComplete(filePath, data);
                }
                else
                {
                    data = JsonUtility.FromJson<Assets>(File.ReadAllText(filePath));
                }
            }

            return data;
        }

        private void WriteComplete(string location, Assets data) 
        {
            File.WriteAllText(location, JsonUtility.ToJson(data));
        }

        private string Createdatabase(string name) 
        {
            //Create new Datyabase
            name = string.IsNullOrEmpty(name) ? "Assets" : name;

            if (!database.DatabaseExists(name))
            {
                database.CreateDatabase(name);
            }

            return name;
        }
    }
}