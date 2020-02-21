using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.Downloading.IMP
{
    public interface IDownloadService
    {
        void SetRootLocation(string rootLocation);

        void DownloadAssets(string[] data, Action callback, string folder);
    }
}
