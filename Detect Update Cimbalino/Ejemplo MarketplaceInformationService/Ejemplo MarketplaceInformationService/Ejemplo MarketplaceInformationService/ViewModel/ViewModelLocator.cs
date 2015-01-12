using Ejemplo_MarketplaceInformationService.Ioc;

namespace Ejemplo_MarketplaceInformationService.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator()
        {
            _container = new Container();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}
