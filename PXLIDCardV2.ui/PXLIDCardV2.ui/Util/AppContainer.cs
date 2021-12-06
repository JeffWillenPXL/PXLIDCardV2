using Autofac;
using PXLIDCardV2.ui.Services;
using PXLIDCardV2.ui.ViewModels;
using PXLIDCardV2.ui.ViewModels.OptViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PXLIDCardV2.ui.Util
{
    public class AppContainer
    {
        private static IContainer _container;
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels


            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<OptionsViewModel>().SingleInstance();
            builder.RegisterType<OptWelcomeViewModel>().SingleInstance();
            builder.RegisterType<OptLoginViewModel>().SingleInstance();
            builder.RegisterType<OptEvaluationsViewModel>().SingleInstance();
            builder.RegisterType<OptQRCodeViewModel>().SingleInstance();


            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>();






            _container = builder.Build();

        }
        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
