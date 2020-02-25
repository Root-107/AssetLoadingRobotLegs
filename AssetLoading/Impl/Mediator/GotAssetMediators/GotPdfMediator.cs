using Robotlegs.Bender.Bundles.MVCS;
using DB.Extensions.AssetProcessing.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class GotPdfMediator : Mediator
    {
        [Inject]
        public IPdfRequestor view;

        public override void Initialize()
        {
            //AddContextListener<GotPdfEvent>(GotPdfEvent.Type.GotAsset, HandleGotPDF);
            base.Initialize();
            AddViewListener<AssetRequestEvent>(AssetRequestEvent.Type.PDFRequest, HandleRequest);
        }

        private void HandleRequest(AssetRequestEvent evt)
        {
            AddContextListener<GotAssetEvent>(GotAssetEvent.Type.GotPDF, HandleGotAsset);
            Dispatch(evt);
        }

        private void HandleGotAsset(GotAssetEvent obj)
        {
            RemoveContextListener<GotAssetEvent>(GotAssetEvent.Type.GotPDF, HandleGotAsset);
            view.GotPDF(obj.Asset);
        }
    }
}