using System;
using System.Windows.Input;
using Ejemplo_Flurry_Analytics.ViewModels.Base;

namespace Ejemplo_Flurry_Analytics.ViewModels
{
    public class SecondaryViewModel
    {
        private ICommand _exceptionCommand;

        public SecondaryViewModel()
        {

        }

        public ICommand ExceptionCommand
        {
            get { return _exceptionCommand = _exceptionCommand ?? new DelegateCommand(ExceptionCommandDelegate); }
        }

        public void ExceptionCommandDelegate()
        {
            throw new Exception("Test Flurry Exception Tracking!");
        }
    }
}
