using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class AssetDatabase
    {
        TextureProvider textureProvider;
        VideoProvider videoProvider;
        PdfProvider pdfProvider;
        SpriteProvider spriteProvider;
        TextProvider textProvider;

        public RequestedAsset GetAsset(int id, AssetTypes type) 
        {
            switch (type)
            {
                case AssetTypes.Image:
                    return spriteProvider.GetAsset(id);
                case AssetTypes.Video:
                    return videoProvider.GetAsset(id);
                case AssetTypes.Text:
                    return textProvider.GetAsset(id);
                case AssetTypes.PDF:
                    return pdfProvider.GetAsset(id);
                case AssetTypes.Texture:
                    return textureProvider.GetAsset(id);
            }

            return null;
        }

        public RequestedAsset GetAsset(string title, AssetTypes type)
        {
            switch (type)
            {
                case AssetTypes.Image:
                    return spriteProvider.GetAsset(title);
                case AssetTypes.Video:
                    return videoProvider.GetAsset(title);
                case AssetTypes.Text:
                    return textProvider.GetAsset(title);
                case AssetTypes.PDF:
                    return pdfProvider.GetAsset(title);
                case AssetTypes.Texture:
                    return textureProvider.GetAsset(title);
            }

            return null;
        }

        public void AddVideo(int id, string title, string path, object payload = null)
        {
            if (videoProvider == null) 
            {
                videoProvider = new VideoProvider();
            }
            videoProvider.AddAsset(id, title, path, payload);
        }

        public void AddTexture(int id, string title, Texture2D texture, object payload = null)
        {
            if (textureProvider == null) 
            {
                textureProvider = new TextureProvider();
            }
            textureProvider.AddAsset(id, title, texture, payload);
        }

        public void AddText(int id, string title, string value, object payload = null)
        {
            if (textProvider == null) 
            {
                textProvider = new TextProvider();
            }
            textProvider.AddAsset(id, title, value, payload);
        }

        public void AddSprite(int id, string title, Sprite image, object payload = null)
        {
            if (spriteProvider == null) 
            {
                spriteProvider = new SpriteProvider();
            }
            spriteProvider.AddAsset(id, title, image, payload);
        }

        public void AddPdf(int id, string title, Sprite image, object payload = null)
        {
            if (pdfProvider == null) 
            {
                pdfProvider = new PdfProvider();
            }
            pdfProvider.AddAsset(id, title, image, payload);
        }
    }
}