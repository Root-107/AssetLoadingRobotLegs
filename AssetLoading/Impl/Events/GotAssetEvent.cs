using Robotlegs.Bender.Extensions.EventManagement.Impl;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DB.Extensions.AssetProcessing.API
{
    public class GotAssetEvent : Event
    {
        public enum Type
        {
            GotPDF,
            GotTexture,
            GotText,
            GotSprite,
            GotVideo
        }

        public RequestedAsset Asset { get; private set; }

        public GotAssetEvent(Type type, RequestedAsset asset) : base(type)
        {
            Asset = asset;
        }
    }
}