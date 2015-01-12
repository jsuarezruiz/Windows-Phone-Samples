namespace BackgroundAudio.ViewModels.Base
{
    using Microsoft.Practices.Unity;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterType<PlayerViewModel>();
      }

        public PlayerViewModel PlayerViewModel
        {
            get { return _container.Resolve<PlayerViewModel>(); }
        }
    }
}
