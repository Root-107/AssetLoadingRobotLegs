using DB.Extensions.AssetProcessing;
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

            context.injector.Map<IAssetDatabaseModel>().ToSingleton<AssetDatabaseModel>();
        }
    }
}