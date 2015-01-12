using Cimbalino.Phone.Toolkit.Services;
using Ejemplo_Flurry_Analytics.ViewModels;
using Microsoft.Practices.Unity;

namespace Ejemplo_Flurry_Analytics.Ioc
{
    public class Container : IContainer
    {
        private readonly IUnityContainer _currentContainer;

        public Container()
        {
            _currentContainer = new UnityContainer();

            //Services
            _currentContainer.RegisterType<INavigationService, NavigationService>();

            //ViewModels
            _currentContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            _currentContainer.RegisterType<SecondaryViewModel>(new ContainerControlledLifetimeManager());
        }

        public T Resolve<T>()
        {
            return _currentContainer.Resolve<T>();
        }
    }
}
