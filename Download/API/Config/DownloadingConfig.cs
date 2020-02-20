using DB.Extensions.Downloading.IMP;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Framework.API;
using System;
using UnityEngine;


namespace DB.Extensions.Downloading.API
{
    public class DownloadingConfig : IConfig
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
            GameObject downloadService = new GameObject("DownloadService");
            DownloaderService service = downloadService.AddComponent<DownloaderService>();
            context.injector.Map<IDownloadService>().ToValue(service);

            service.SetRootLocation(rootLocation);

            Debug.Log("Downloader Initalised");
        }

        public DownloadingConfig WithRootDownloadLocation(string path) 
        {
            rootLocation = path;
            return this;
        }

    }
}