using Ejemplo_Detener_Flip.Services;
using Ejemplo_Detener_Flip.ViewModel;
using Microsoft.Practices.Unity;

namespace Ejemplo_Detener_Flip.Ioc
{
    public class Container : IContainer
    {  
        private readonly IUnityContainer _currentContainer;

        public Container()
        {
            _currentContainer = new UnityContainer();

            _currentContainer.RegisterType<ILiveTileService, LiveTileService>();

            _currentContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
        }

        public T Resolve<T>()
        {
            return _currentContainer.Resolve<T>();
        }
    }
}
