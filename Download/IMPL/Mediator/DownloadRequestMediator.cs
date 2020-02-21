using DB.Extensions.Downloading.API;
using Robotlegs.Bender.Bundles.MVCS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.Downloading.IMP
{
    public class DownloadRequestMediator : Mediator
    {
        public override void Initialize()
        {
            base.Initialize();
            AddViewListener<DownloadRequestEvent>(DownloadRequestEvent.Type.DownloadRequest, Dispatch);
        }
    }
}
