
using Robotlegs.Bender.Extensions.EventManagement.Impl;
using System;

namespace DB.Extensions.AssetProcessing.API
{
    public class AssetLoadEvent : Event
    {
        public enum Type
        {
            AssetProcessEvent
        }

        public string Folder { get; private set; }
        public Action Callback { get; private set; }
        public Assets AssetData { get; private set; }
        public bool LazyLoad { get; private set; }

        public AssetLoadEvent(Type type, Action callback, Assets assetData = null, string folder = "", bool lazyLoad = false) : base(type)
        {
            Callback = callback;
            AssetData = assetData;
            LazyLoad = lazyLoad;
            if (string.IsNullOrEmpty(folder))
            {
                Folder = "Assets";
            }
            else
            {
                Folder = folder;
            }
        }
    }
}