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
    }
}