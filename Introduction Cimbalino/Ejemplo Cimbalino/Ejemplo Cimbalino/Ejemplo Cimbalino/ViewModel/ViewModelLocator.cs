using Ejemplo_Cimbalino.Ioc;

namespace Ejemplo_Cimbalino.ViewModel
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
