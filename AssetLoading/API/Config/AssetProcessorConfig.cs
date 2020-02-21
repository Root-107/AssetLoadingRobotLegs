using Robotlegs.Bender.Framework.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing
{
    public class AssetProcessorConfig : IConfig
    {

        [Inject]
        public IContext context;

        private string rootLocation = "";

        public void Configure()
        {
            context.AfterInitializing(HandlePostInit);
        }

        private void HandlePostInit() 
        {
            Debug.Log("Asset Processor Initalised");
        }

        public AssetProcessorConfig WithRootLocation(string path) 
        {
            rootLocation = path;
            return this;
        }
    }
}