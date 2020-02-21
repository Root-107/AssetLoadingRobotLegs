using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DB.Extensions.AssetProcessing.IMPL
{
    public class TextureProvider : Provider
    {
        public void AddAsset(int _id, string _title, Texture2D _texture, object payload = null)
        {
            if (!assets.ContainsKey(_id))
            {
                assets.Add(_id, new RequestedAsset(_id, _title, AssetTypes.Texture, texture: _texture ,payload: payload));
                refrence.Add(_title, _id);
            }
        }
    }
}