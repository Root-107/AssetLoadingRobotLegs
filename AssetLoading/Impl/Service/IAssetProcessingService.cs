using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public interface IAssetProcessingService
    {
        //process, in this location, with this complete and add to this database
        void SetRootLocation(string path);
        void SetDatabase(IAssetDatabaseModel model);
        void AutoGenerateComplete(bool autoGenerate);
        void ProcessAssets(Action onComplete, string folder = "", Assets data = null, bool lazyLoadDatabase = false);
    }
}