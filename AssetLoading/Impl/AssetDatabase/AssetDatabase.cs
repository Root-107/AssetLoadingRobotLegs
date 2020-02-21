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
        public void AddText()
        {
        }
        public void AddSprite()
        {
        }
        public void AddPdf()
        {
        }
    }
}