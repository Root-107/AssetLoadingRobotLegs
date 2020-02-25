using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DB.Extensions.AssetProcessing.IMPL
{
    public class PdfProvider : Provider
    {
        public void AddAsset(int _id, string _title, Sprite _page, object _payload = null)
        {
            if (assets.ContainsKey(_id))
            {
                assets[_id].pdf.Add(_page);
            }
            else
            {
                List<Sprite> data = new List<Sprite>();
                data.Add(_page);
                assets.Add(_id, new RequestedAsset(_id, _title, AssetTypes.PDF, images: data, payload: _payload));
                refrence.Add(_title, _id);
            }
        }
    }
}