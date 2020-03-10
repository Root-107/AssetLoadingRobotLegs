using DB.Extensions.AssetProcessing.API;
using Robotlegs.Bender.Bundles.MVCS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DB.Extensions.AssetProcessing.IMPL
{
    public class GotVideoMediator : Mediator
    {
        [Inject]
        public IVideoRequestor view;

        public override void Initialize()
        {
            base.Initialize();
            AddViewListener<AssetRequestEvent>(AssetRequestEvent.Type.VideoRequest, HandleRequest);
        }

        private void HandleRequest(AssetRequestEvent obj)
        {
            AddContextListener<GotAssetEvent>(GotAssetEvent.Type.GotVideo, HandleGotAssetEvent);
            Dispatch(obj);
        }

        private void HandleGotAssetEvent(GotAssetEvent obj)
        {
            RemoveContextListener<GotAssetEvent>(GotAssetEvent.Type.GotVideo, HandleGotAssetEvent);
            view.GotVideo(obj.Asset);
        }
    }
}
