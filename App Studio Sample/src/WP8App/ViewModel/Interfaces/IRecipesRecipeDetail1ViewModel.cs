using DoWapp;
using DoWapp.Services.Interfaces;
using DoWapp.ViewModel;
using DoWapp.ViewModel.Base;
using DoWapp.Data;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace DoWapp.ViewModel
{
    public interface IRecipesRecipeDetail1ViewModel
    {       
		void Load();	
    
        
        Recipe CurrentRecipe { get; set; }
        

		ICommand ShareRecipesRecipeDetail1StaticControlCommand { get; }
        
        ICommand PinToStartRecipesRecipeDetail1StaticControlCommand  { get; }
        
        ICommand ReadRecipesRecipeDetail1StaticControlCommand { get; }
        

		ICommand ShareRecipesRecipeIngredientsStaticControlCommand { get; }
        
        ICommand PinToStartRecipesRecipeIngredientsStaticControlCommand  { get; }
        
        ICommand ReadRecipesRecipeIngredientsStaticControlCommand { get; }
        
	}
}
