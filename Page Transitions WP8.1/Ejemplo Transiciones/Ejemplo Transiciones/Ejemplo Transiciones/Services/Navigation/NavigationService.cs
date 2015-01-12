
namespace Ejemplo_Transiciones.Services.Navigation
{
    /// <summary>
    /// Navigation service contract implementation
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// 
        /// </summary>
        public void NavigateBack()
        {
            App.Frame.GoBack();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        public void NavigateTo<T>(object parameter = null)
        {
            if (parameter != null)
                App.Frame.Navigate(typeof(T), parameter);
            else
                App.Frame.Navigate(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearNavigationHistory()
        {
            App.Frame.BackStack.Clear();
        }
    }
}
