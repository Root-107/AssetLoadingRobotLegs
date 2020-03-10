
using Robotlegs.Bender.Extensions.EventManagement.Impl;
using System;

namespace DB.Extensions.AssetProcessing.API
{
    public class AssetRequestEvent : Event
    {
        public enum Type 
        {
            SpriteRequest,
            PDFRequest,
            VideoRequest,
            TextRequest,
            TextureRequest
        }

        public string DatabaseName { get; private set; }
        public int Id { get; private set; }
        public string Title { get; private set; }

        public AssetRequestEvent(Type type, int id, string databaseName = "") : base(type)
        {
            DatabaseName = databaseName;
            Title = "";
            Id = id;
        }

        public AssetRequestEvent(Type type, string title, string databaseName = "") : base(type)
        {
            DatabaseName = databaseName;
            Id = -1;
            Title = title;
        }
    }
}