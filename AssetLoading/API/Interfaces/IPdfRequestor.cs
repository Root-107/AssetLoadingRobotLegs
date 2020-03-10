using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.API
{
    public interface IPdfRequestor
    {
        void GotPDF(RequestedAsset asset);
    }
}