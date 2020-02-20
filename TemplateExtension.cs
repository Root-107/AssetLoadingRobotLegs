﻿using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Framework.API;

namespace DB.Extensions.TemplateExtension
{
    public class TemplateExtension : IExtension
    {
        public void Extend(IContext context)
        {
            IMediatorMap mediatorMap = context.injector.GetInstance<IMediatorMap>();
            IEventCommandMap commandMap = context.injector.GetInstance<IEventCommandMap>();
        }
    }
}