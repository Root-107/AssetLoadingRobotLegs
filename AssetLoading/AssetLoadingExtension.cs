using DB.Extensions.AssetProcessing;
using DB.Extensions.AssetProcessing.API;
using DB.Extensions.AssetProcessing.IMPL;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Framework.API;

namespace DB.Extensions.TemplateExtension
{
    public class AssetLoadingExtension : IExtension
    {
        public void Extend(IContext context)
        {
            IMediatorMap mediatorMap = context.injector.GetInstance<IMediatorMap>();
            IEventCommandMap commandMap = context.injector.GetInstance<IEventCommandMap>();

            mediatorMap.Map<IAssetLoadRequest>().ToMediator<AssetLoadRequestMediator>();

            mediatorMap.Map<IPdfRequestor>().ToMediator<GotPdfMediator>();
            mediatorMap.Map<ITextureRequestor>().ToMediator<GotTextureMediator>();
            mediatorMap.Map<ITextRequestor>().ToMediator<GotTextMediator>();
            mediatorMap.Map<IVideoRequestor>().ToMediator<GotVideoMediator>();
            mediatorMap.Map<ISpriteRequestor>().ToMediator<GotSpriteMediator>();

            commandMap.Map(AssetRequestEvent.Type.PDFRequest).ToCommand<HandleAssetRequesCommand>();
            commandMap.Map(AssetRequestEvent.Type.SpriteRequest).ToCommand<HandleAssetRequesCommand>();
            commandMap.Map(AssetRequestEvent.Type.TextRequest).ToCommand<HandleAssetRequesCommand>();
            commandMap.Map(AssetRequestEvent.Type.TextureRequest).ToCommand<HandleAssetRequesCommand>();
            commandMap.Map(AssetRequestEvent.Type.VideoRequest).ToCommand<HandleAssetRequesCommand>();

            commandMap.Map(AssetLoadEvent.Type.AssetProcessEvent).ToCommand<HandleAssetProcessCommand>();

            context.injector.Map<IAssetDatabaseModel>().ToSingleton<AssetDatabaseModel>();
        }
    }
}