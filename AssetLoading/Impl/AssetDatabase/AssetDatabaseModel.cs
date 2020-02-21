using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class AssetDatabaseModel : IAssetDatabaseModel
    {
        Dictionary<string, AssetDatabase> database = new Dictionary<string, AssetDatabase>();

        public void AddAsset(Asset asset, string database = "")
        {
            
        }

        public void CreateDatabase(string database)
        {
            
        }
    }
}