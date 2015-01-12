
namespace Ejemplo_Transiciones.Services.Navigation
{
    /// <summary>
    /// Navigation service contract definition
    /// </summary>
    public interface INavigationService
    {/// <summary>
        /// This method performs a navigate back to the last page in the navigation stack.
        /// </summary>
        void NavigateBack();

        /// <summary>
        /// This method navigates to the specified Page
        /// </summary>
        /// <typeparam name="T">Page type</typeparam>
        /// <param name="parameter">optional, a parameter can be send with the navigation</param>
        void NavigateTo<T>(object parameter = null);

        /// <summary>
        /// This method clears the navigation backstack.
        /// </summary>
        void ClearNavigationHistory();
    }
}
