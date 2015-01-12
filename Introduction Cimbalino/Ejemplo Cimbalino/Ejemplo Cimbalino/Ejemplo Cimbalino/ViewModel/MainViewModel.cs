using System.Windows.Input;
using Cimbalino.Phone.Toolkit.Services;
using Ejemplo_Cimbalino.ViewModel.Base;

namespace Ejemplo_Cimbalino.ViewModel
{
    public class MainViewModel
    {
        private readonly IMessageBoxService _messageBoxService;

        public MainViewModel(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        }

        private ICommand _showMessageCommand;

        public ICommand ShowMessageCommand
        {
            get { return _showMessageCommand = _showMessageCommand ?? new DelegateCommand(ShowMessageCommandDelegate); }
        }

        public void ShowMessageCommandDelegate()
        {
            _messageBoxService.Show(Resources.AppResources.Cimbalino);
        }
    }
}
