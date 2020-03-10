using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class AssetDatabaseModel : IAssetDatabaseModel
    {

        string defaultDatabase = "";

        Dictionary<string, AssetDatabase> MainDatabase = new Dictionary<string, AssetDatabase>();

        public void AssignImage(int id, string key, Sprite value, string database, object payload = null)
        {
            if (!DatabaseExists(database)) 
            {
                Debug.Log("Database dose not exist :" + database);
                return;
            }

            MainDatabase[database].AddSprite(id, key, value, payload);
        }

        public void AssignPDF(int id, string key, Sprite value, string database, object payload = null)
        {
            if (!DatabaseExists(database))
            {
                Debug.Log("Database dose not exist :" + database);
            }

            MainDatabase[database].AddPdf(id, key, value, payload);

        }

        public void AssignText(int id, string key, string value, string database, object payload = null)
        {
            if (!DatabaseExists(database))
            {
                Debug.Log("Database dose not exist :" + database);
                return;
            }

            MainDatabase[database].AddText(id, key, value, payload);

        }

        public void AssignTexture(int id, string key, Texture2D value, string database, object payload = null)
        {
            if (!DatabaseExists(database))
            {
                Debug.Log("Database dose not exist :" + database);
                return;
            }

            MainDatabase[database].AddTexture(id, key, value, payload);

        }

        public void AssingVideo(int id, string key, string value, string database, object payload = null)
        {
            if (!DatabaseExists(database))
            {
                Debug.Log("Database dose not exist :" + database);
                return;
            }

            MainDatabase[database].AddVideo(id, key, value, payload);

        }

        public void CreateDatabase(string databaseName)
        {
            if (MainDatabase.Count == 0) 
            {
                defaultDatabase = databaseName;
            }
            MainDatabase.Add(databaseName, new AssetDatabase());
        }

        public bool DatabaseExists(string name)
        {
            return MainDatabase.ContainsKey(name);
        }

        public RequestedAsset GetAsset(int id, AssetTypes type, string database = null)
        {
            database = CheckDatabaseName(database);
            if (DatabaseExists(database)) 
            {
                return MainDatabase[database].GetAsset(id, type);
            }

            Debug.LogWarning("You are trying to request from a database that has not been created.");

            return null;
        }

        public RequestedAsset GetAsset(string title, AssetTypes type, string database = null)
        {
            database = CheckDatabaseName(database);
            if (DatabaseExists(database))
            {
                return MainDatabase[database].GetAsset(title, type);
            }

            Debug.LogWarning("You are trying to request from a database that has not been created.");

            return null;
        }

        private string CheckDatabaseName(string value) 
        {
            return value = string.IsNullOrEmpty(value) ? defaultDatabase : value;
        }
    }
}