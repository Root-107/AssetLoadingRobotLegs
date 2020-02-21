using DB.Extensions.AssetProcessing.API;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class HandleAssetProcessCommand : ICommand
    {
        [Inject]
        public IAssetProcessingService service;

        [Inject]
        public IAssetDatabaseModel database;

        [Inject]
        public AssetLoadEvent evt;
        public void Execute()
        {
            service.SetDatabase(database);
            service.ProcessAssets(evt.Callback, evt.Folder, evt.AssetData, evt.LazyLoad);
        }
    }
}