using NUnit.Framework;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Bundles.Test;
using UnityEngine;
using System;

namespace DB.Extensions.TemplateExtension
{
    public class TemplateExtensionExtensionTest
    {
        #region Private Properties

        private Context context;        
        #endregion

        #region Setup & Teardown
        [SetUp]
        public void Setup()
        {
            context = new Context();
            context.Install(typeof(NUnitTestBundle));

            //Required Extensions
            //context.Install<CallbackTimerExtension>();
        }

        [TearDown]
        public void TearDown()
        {
            if (context.Initialized)
            {
                context.Destroy();
            }
            context = null;
        }
        #endregion

        #region Tests   
        [Test]
        public void Template_Extension_Doesnt_Error_On_Install()
        {
            Assert.DoesNotThrow(new TestDelegate(() =>
            {
                context.Install<TemplateExtension>();
                context.Initialize();
            }));

        }

        #endregion
    }
}