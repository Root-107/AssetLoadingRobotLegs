using Robotlegs.Bender.Bundles.MVCS;
using DB.Extensions.AssetProcessing.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class GotTextMediator : Mediator
    {
        [Inject]
        public ITextRequestor view;

        public override void Initialize()
        {
            base.Initialize();
            AddViewListener<AssetRequestEvent>(AssetRequestEvent.Type.TextRequest, HandleRequest);
        }

        private void HandleRequest(AssetRequestEvent obj)
        {
            AddContextListener<GotAssetEvent>(GotAssetEvent.Type.GotText, HandleGotAsset);
            Dispatch(obj);
        }

        private void HandleGotAsset(GotAssetEvent obj)
        {
           RemoveContextListener<GotAssetEvent>(GotAssetEvent.Type.GotText, HandleGotAsset);
            view.GotText(obj.Asset);
        }
    }
}