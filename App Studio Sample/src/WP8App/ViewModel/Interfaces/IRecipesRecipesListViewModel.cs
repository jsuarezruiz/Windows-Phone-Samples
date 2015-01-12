using DoWapp;
using DoWapp.Services.Interfaces;
using DoWapp.ViewModel;
using DoWapp.ViewModel.Base;
using DoWapp.Data;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace DoWapp.ViewModel
{
    public interface IRecipesRecipesListViewModel
    {       
		void Load();	
        //LockScreen hack
        ICommand SetLockScreenCommand { get; }		
    
	}
}
