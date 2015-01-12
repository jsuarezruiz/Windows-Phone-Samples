using Ejemplo_Detener_Flip.Ioc;

namespace Ejemplo_Detener_Flip.ViewModel
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
