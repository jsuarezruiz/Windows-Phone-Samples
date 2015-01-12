using Ejemplo_Cortana.Services.Standings;
using Microsoft.Practices.Unity;

namespace Ejemplo_Cortana.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterType<MainViewModel>();
            _container.RegisterType<SearchViewModel>();

            _container.RegisterType<IStandingService, StandingService>(new ContainerControlledLifetimeManager());
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public SearchViewModel SearchViewModel
        {
            get { return _container.Resolve<SearchViewModel>(); }
        }
    }
}
