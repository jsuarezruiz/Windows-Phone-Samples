// Template: PageCS.tt

using System.Linq;
using DoWapp;
using DoWapp.ViewModel;
using DoWapp.Data;
using Microsoft.Phone.Controls;

namespace DoWapp.View
{
    public partial class RecipesRecipeDetail1 : PhoneApplicationPage
    {        
        public RecipesRecipeDetail1()
        {
            InitializeComponent();
        }

        private void btnShareRecipesRecipeDetail1StaticControl_Click(object sender, System.EventArgs e)
        {
            (this.DataContext as IRecipesRecipeDetail1ViewModel).ShareRecipesRecipeDetail1StaticControlCommand.Execute(null);
        }

        private void btnPinToStartRecipesRecipeDetail1StaticControl_Click(object sender, System.EventArgs e)
        {
            (this.DataContext as IRecipesRecipeDetail1ViewModel).PinToStartRecipesRecipeDetail1StaticControlCommand.Execute(null);
        }

        private void btnReadRecipesRecipeDetail1StaticControl_Click(object sender, System.EventArgs e)
        {
            (this.DataContext as IRecipesRecipeDetail1ViewModel).ReadRecipesRecipeDetail1StaticControlCommand.Execute(null);
        }
				
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string currentID = string.Empty;

            if (NavigationContext.QueryString.TryGetValue("currentID", out currentID))
            {
                var dataSource = new RecipeDataSource();
				
				(this.DataContext as RecipesRecipeDetail1ViewModel).CurrentRecipe  = dataSource.GetData().FirstOrDefault(x => x.Id.ToString().Equals(currentID));
            }
        }
    }
}

