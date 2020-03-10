using DB.Extensions.AssetProcessing.API;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
using Robotlegs.Bender.Framework.API;
using System.Collections;
using System.Collections.Generic;
namespace DB.Extensions.AssetProcessing.IMPL
{
    public class HandleAssetRequesCommand : ICommand
    {
        [Inject]
        public IContext context;

        [Inject]
        public AssetRequestEvent evt;

        [Inject]
        public IAssetDatabaseModel model;

        RequestedAsset asset = null;

        AssetTypes requestType;

        public void Execute()
        {

            switch ((AssetRequestEvent.Type)evt.type)
            {
                case AssetRequestEvent.Type.SpriteRequest:
                    requestType = AssetTypes.Image;
                    break;
                case AssetRequestEvent.Type.PDFRequest:
                    requestType = AssetTypes.PDF;
                    break;
                case AssetRequestEvent.Type.VideoRequest:
                    requestType = AssetTypes.Video;
                    break;
                case AssetRequestEvent.Type.TextRequest:
                    requestType = AssetTypes.Text;
                    break;
                case AssetRequestEvent.Type.TextureRequest:
                    requestType = AssetTypes.Texture;
                    break;
            }

            if (!string.IsNullOrEmpty(evt.Title))
            {
                RequestByTitle();
            }
            else 
            {
                RequestById();
            }
        }

        private void RequestById() 
        {
            asset = model.GetAsset(evt.Id, requestType, evt.DatabaseName);
            SendAsset();
        }

        private void RequestByTitle()
        {
            asset = model.GetAsset(evt.Title, requestType, evt.DatabaseName);
            SendAsset();
        }

        private void SendAsset() 
        {
            if (asset != null)
            {
                Event gotevt = null;
                switch (requestType)
                {
                    case AssetTypes.Image:
                        gotevt = new GotAssetEvent(GotAssetEvent.Type.GotSprite, asset);
                        break;
                    case AssetTypes.Video:
                        gotevt = new GotAssetEvent(GotAssetEvent.Type.GotVideo, asset);
                        break;
                    case AssetTypes.Text:
                        gotevt = new GotAssetEvent(GotAssetEvent.Type.GotText, asset);
                        break;
                    case AssetTypes.PDF:
                        gotevt = new GotAssetEvent(GotAssetEvent.Type.GotPDF, asset);
                        break;
                    case AssetTypes.Texture:
                        gotevt = new GotAssetEvent(GotAssetEvent.Type.GotTexture, asset);
                        break;
                }

                context.injector.GetInstance<IEventDispatcher>().Dispatch(gotevt);
            }
#if UNITY_EDITOR
            Debug.Log("The requested asset was null.");
#endif
        }
    }
}