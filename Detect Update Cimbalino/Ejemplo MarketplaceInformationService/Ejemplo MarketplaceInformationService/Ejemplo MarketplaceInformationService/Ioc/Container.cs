using Cimbalino.Phone.Toolkit.Services;
using Ejemplo_MarketplaceInformationService.ViewModel;
using Microsoft.Practices.Unity;

namespace Ejemplo_MarketplaceInformationService.Ioc
{
    public class Container : IContainer
    {  
        private readonly IUnityContainer _currentContainer;

        public Container()
        {
            _currentContainer = new UnityContainer();

            //Servicios
            _currentContainer.RegisterType<IMarketplaceInformationService, MarketplaceInformationService>();
            _currentContainer.RegisterType<IMessageBoxService, MessageBoxService>();
            _currentContainer.RegisterType<IMarketplaceDetailService, MarketplaceDetailService>();

            //Vistas
            _currentContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
        }

        public T Resolve<T>()
        {
            return _currentContainer.Resolve<T>();
        }
    }
}
