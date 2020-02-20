using DB.Extensions.Downloading.API;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.Downloading.IMP
{
    public class DownloadCommand : ICommand
    {
        [Inject]
        public IDownloadService serivce;

        [Inject]
        public DownloadRequestEvent evt;

        public void Execute()
        {
            string folder = string.IsNullOrEmpty(evt.Folder) ? "Assets" : evt.Folder;

            string[] urls = string.IsNullOrEmpty(evt.URL) ? evt.URLS : new string[] {evt.URL};

            serivce.DownloadAssets(urls, evt.OnDownloadComplete, folder);
        }
    }
}