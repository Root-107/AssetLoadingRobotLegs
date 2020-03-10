using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DB.Extensions.AssetProcessing.IMPL
{

    public class VideoProvider : Provider
    {
        public void AddAsset(int _id, string _title, string _path, object payload = null)
        {
            if (!assets.ContainsKey(_id))
            {
                assets.Add(_id, new RequestedAsset(_id, _title, AssetTypes.Text, value: _path, payload: payload));
                refrence.Add(_title, _id);
            }
        }
    }
}