
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

        public AssetLoadEvent(Type type, Action callback, string folder = "") : base(type)
        {
            Callback = callback;
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