using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
using System;

namespace DB.Extensions.Downloading.API {
    public class DownloadRequestEvent : Robotlegs.Bender.Extensions.EventManagement.Impl.Event
    {
        public enum Type 
        {
            DownloadRequest
        }

        public string URL { get; private set; }
        public string[] URLS { get; private set; }

        public string Folder { get; private set; }

        public Action OnDownloadComplete { get; private set; }
        public DownloadRequestEvent(Type type, string url, Action downloadComplete, string folder = "") : base(type)
        {
            URL = url;
            Folder = folder;
            OnDownloadComplete = downloadComplete;
        }

        public DownloadRequestEvent(Type type, string[] urls, Action downloadComplete, string folder = "") : base(type)
        {
            URLS = urls;
            Folder = folder;
            OnDownloadComplete = downloadComplete;
        }
    }
}
