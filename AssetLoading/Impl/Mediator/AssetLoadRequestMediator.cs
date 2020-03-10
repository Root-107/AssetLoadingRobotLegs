using DB.Extensions.AssetProcessing.API;
using Robotlegs.Bender.Bundles.MVCS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DB.Extensions.AssetProcessing.IMPL
{
    public class AssetLoadRequestMediator : Mediator
    {
        public override void Initialize()
        {
            AddViewListener(AssetLoadEvent.Type.AssetProcessEvent, Dispatch);
            base.Initialize();
        }
    }
}