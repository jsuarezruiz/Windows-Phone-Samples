using Cimbalino.Phone.Toolkit.Services;
using Ejemplo_Cimbalino.ViewModel;
using Microsoft.Practices.Unity;

namespace Ejemplo_Cimbalino.Ioc
{
    public class Container : IContainer
    {  
        private readonly IUnityContainer _currentContainer;

        public Container()
        {
            _currentContainer = new UnityContainer();

            _currentContainer.RegisterType<IMessageBoxService, MessageBoxService>();

            _currentContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
        }

        public T Resolve<T>()
        {
            return _currentContainer.Resolve<T>();
        }
    }
}
