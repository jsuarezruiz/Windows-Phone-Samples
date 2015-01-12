using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Ejemplo_ActionCenter.ViewModels.Base;
using Ejemplo_ActionCenter.Views;

namespace Ejemplo_ActionCenter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _ghostCommand;
        private ICommand _queueCommand;
        private ICommand _editCommand;
        private ICommand _toastCommand;

        public ICommand GhostCommand
        {
            get { return _ghostCommand = _ghostCommand ?? new DelegateCommand(GhostCommandDelegate); }
        }

        public ICommand QueueCommand
        {
            get { return _queueCommand = _queueCommand ?? new DelegateCommand(QueueCommandDelegate); }
        }

        public ICommand EditCommand
        {
            get { return _editCommand = _editCommand ?? new DelegateCommand(EditCommandDelegate); }
        }

        public ICommand ToastCommand
        {
            get { return _toastCommand = _toastCommand ?? new DelegateCommand(ToastCommandDelegate); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public void GhostCommandDelegate()
        {
            AppFrame.Navigate(typeof (GhostView));
        }

        public void QueueCommandDelegate()
        {
            AppFrame.Navigate(typeof (QueueView));
        }

        public void EditCommandDelegate()
        {
            AppFrame.Navigate(typeof (EditView));
        }

        public void ToastCommandDelegate()
        {
            AppFrame.Navigate(typeof(ToastView));
        }
    }
}