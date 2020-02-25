using Robotlegs.Bender.Bundles.MVCS;
using DB.Extensions.AssetProcessing.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class GotSpriteMediator : Mediator
    {
        [Inject]
        public ISpriteRequestor view;

        public override void Initialize()
        {
            base.Initialize();
            AddViewListener<AssetRequestEvent>(AssetRequestEvent.Type.SpriteRequest, HandleRequest);
        }

        private void HandleRequest(AssetRequestEvent obj)
        {
            AddContextListener<GotAssetEvent>(GotAssetEvent.Type.GotSprite, HandleGotAsset);
            Dispatch(obj);
        }

        private void HandleGotAsset(GotAssetEvent obj)
        {
            RemoveContextListener<GotAssetEvent>(GotAssetEvent.Type.GotSprite, HandleGotAsset);
            view.GotSprite(obj.Asset);
        }
    }
}
