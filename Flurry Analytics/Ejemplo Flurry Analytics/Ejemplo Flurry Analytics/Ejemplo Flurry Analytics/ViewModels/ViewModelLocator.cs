using Ejemplo_Flurry_Analytics.Ioc;

namespace Ejemplo_Flurry_Analytics.ViewModels
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

        public SecondaryViewModel SecondaryViewModel
        {
            get { return _container.Resolve<SecondaryViewModel>(); }
        }
    }
}
