using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DB.Extensions.AssetProcessing.IMPL
{
    public class Provider
    {
        public Dictionary<int, RequestedAsset> assets = new Dictionary<int, RequestedAsset>();
        public Dictionary<string, int> refrence = new Dictionary<string, int>();

        public RequestedAsset GetAsset(string _title)
        {
            if (refrence.ContainsKey(_title))
            {
                return assets[refrence[_title]];
            }

            return null;
        }

        public RequestedAsset GetAsset(int _id)
        {
            if (assets.ContainsKey(_id))
            {
                return assets[_id];
            }

            return null;
        }

        public bool HasKey(int id)
        {
            return assets.ContainsKey(id);
        }
    }
}
