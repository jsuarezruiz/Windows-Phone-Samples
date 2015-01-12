using Ejemplo_Transiciones.Services.Navigation;
using Microsoft.Practices.Unity;

namespace Ejemplo_Transiciones.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterType<Pagina1ViewModel>();
            _container.RegisterType<Pagina2ViewModel>();
            _container.RegisterType<Pagina3ViewModel>();
            _container.RegisterType<Pagina4ViewModel>();

            _container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
        }

        public Pagina1ViewModel Pagina1ViewModel
        {
            get { return _container.Resolve<Pagina1ViewModel>(); }
        }

        public Pagina2ViewModel Pagina2ViewModel
        {
            get { return _container.Resolve<Pagina2ViewModel>(); }
        }

        public Pagina3ViewModel Pagina3ViewModel
        {
            get { return _container.Resolve<Pagina3ViewModel>(); }
        }

        public Pagina4ViewModel Pagina4ViewModel
        {
            get { return _container.Resolve<Pagina4ViewModel>(); }
        }
    }
}
