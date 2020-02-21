using DB.Extensions.AssetProcessing.IMPL;
using Robotlegs.Bender.Framework.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.API
{
    public class AssetProcessorConfig : IConfig
    {
        [Inject]
        public IContext context;

        private string rootLocation = "";

        private bool autoGenerate = false;

        public void Configure()
        {
            context.AfterInitializing(HandlePostInit);
        }

        private void HandlePostInit() 
        {
            GameObject go = new GameObject("ProcessingService");
            AssetProcessingService service = go.AddComponent<AssetProcessingService>();
            context.injector.Map<IAssetProcessingService>().ToValue(service);
            service.SetRootLocation(rootLocation);
            service.AutoGenerateComplete(autoGenerate);

            Debug.Log("Asset Processor Initalised");
        }

        public AssetProcessorConfig WithRootLocation(string path) 
        {
            rootLocation = path;
            return this;
        }

        public AssetProcessorConfig WithAutoGenerateComplete(bool autoGenerate) 
        {
            this.autoGenerate = autoGenerate;
            return this;
        }
    }
}