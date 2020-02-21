using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class TextProvider : Provider
    {
        public void AddAsset(int _id, string _title, string _data)
        {
            if (!assets.ContainsKey(_id))
            {
                assets.Add(_id, new RequestedAsset(_id, _title, AssetTypes.Text, value: _data));
                refrence.Add(_title, _id);
            }
        }
    }
}
