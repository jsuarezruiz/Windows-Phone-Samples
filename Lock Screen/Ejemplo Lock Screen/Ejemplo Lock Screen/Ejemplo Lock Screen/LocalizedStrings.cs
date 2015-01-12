using Ejemplo_Lock_Screen.Resources;

namespace Ejemplo_Lock_Screen
{
    /// <summary>
    /// Proporciona acceso a los recursos de cadena.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}