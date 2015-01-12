using Ejemplo_ActionCenter.Services.Notification;
using Microsoft.Practices.Unity;

namespace Ejemplo_ActionCenter.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterType<MainViewModel>();
            _container.RegisterType<ToastViewModel>();
            _container.RegisterType<GhostViewModel>();
            _container.RegisterType<QueueViewModel>();
            _container.RegisterType<EditViewModel>();

            _container.RegisterType<ILocalNotificationService, LocalNotificationService>(new ContainerControlledLifetimeManager());
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public ToastViewModel ToastViewModel
        {
            get { return _container.Resolve<ToastViewModel>(); }
        }

        public GhostViewModel GhostViewModel
        {
            get { return _container.Resolve<GhostViewModel>(); }
        }

        public QueueViewModel QueueViewModel
        {
            get { return _container.Resolve<QueueViewModel>(); }
        }

        public EditViewModel EditViewModel
        {
            get { return _container.Resolve<EditViewModel>(); }
        }
    }
}
