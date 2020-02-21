using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public interface IAssetDatabaseModel
    {
        void AddAsset(Asset asset, string database = "");
        void CreateDatabase(string database);
    }
}