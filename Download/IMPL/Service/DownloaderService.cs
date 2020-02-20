using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DB.Extensions.Downloading.IMP
{
    public class DownloaderService : MonoBehaviour, IDownloadService
    {
        public string rootLocation;

        public void SetRootLocation(string rootLocation)
        {
            this.rootLocation = string.IsNullOrEmpty(rootLocation) ? Application.persistentDataPath : rootLocation;
        }

        public void DownloadAssets(string[] data, Action callback, string folder)
        {
            if (!Directory.Exists($"{rootLocation}/{folder}"))
            {
                Directory.CreateDirectory($"{rootLocation}/{folder}");
            }

            GameObject downloadManager = new GameObject("DownloadManager");
            DownloadManager manager = downloadManager.AddComponent<DownloadManager>();
            manager.Download(data, callback, folder, rootLocation);
        }


    }
}
