using Ejemplo_Xbox_Music.Ioc;

namespace Ejemplo_Xbox_Music.ViewModel
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
