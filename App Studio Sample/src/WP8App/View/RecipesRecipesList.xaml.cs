// Template: PageCS.tt

using System.Linq;
using DoWapp;
using DoWapp.ViewModel;
using DoWapp.Data;
using Microsoft.Phone.Controls;

namespace DoWapp.View
{
    public partial class RecipesRecipesList : PhoneApplicationPage
    {        
        public RecipesRecipesList()
        {
            InitializeComponent();
        }
		//Lock
        private void btnPinToSetLockScreen_Click(object sender, System.EventArgs e)
        {
            (this.DataContext as IRecipesRecipesListViewModel).SetLockScreenCommand.Execute(null);
        }

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
			
			//Fix for navigation
            this.RecipesRecipesListLisControl.SelectedItem = null;
        }
    }
}

