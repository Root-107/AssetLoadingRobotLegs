using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DB.Extensions.AssetProcessing.IMPL
{
    public class SpriteProvider : Provider
    {
        public void AddAsset(int _id, string _title, Sprite _sprite, object _payload = null)
        {
            if (!assets.ContainsKey(_id))
            {
                assets.Add(_id, new RequestedAsset(_id, _title, AssetTypes.Text, img: _sprite, payload:_payload));
                refrence.Add(_title, _id);
            }
        }
    }
}