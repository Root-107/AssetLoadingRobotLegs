using Robotlegs.Bender.Bundles.MVCS;
using DB.Extensions.AssetProcessing.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class GotTextureMediator : Mediator
    {
        [Inject]
        public ITextureRequestor view;
        public override void Initialize()
        {
            base.Initialize();
            AddViewListener<AssetRequestEvent>(AssetRequestEvent.Type.TextureRequest, HandleRequest);
        }

        private void HandleRequest(AssetRequestEvent obj)
        {
            AddContextListener<GotAssetEvent>(GotAssetEvent.Type.GotTexture, HandleGotAsset);
            Dispatch(obj);
        }

        private void HandleGotAsset(GotAssetEvent obj)
        {
            RemoveContextListener<GotAssetEvent>(GotAssetEvent.Type.GotTexture, HandleGotAsset);
            view.GotTexture(obj.Asset);
        }
    }
}