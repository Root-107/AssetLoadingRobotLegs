using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public interface IAssetDatabaseModel
    {
        void CreateDatabase(string database);
        bool DatabaseExists(string name);

        void AssignPDF(int id, string key, Sprite value, string database, object payload = null);
        void AssignText(int id, string key, string value, string database, object payload = null);
        void AssignImage(int id, string key, Sprite value, string database, object payload = null);
        void AssignTexture(int id, string key, Texture2D value, string database, object payload = null);
        void AssingVideo(int id, string key, string value, string database, object payload = null);
    }
}