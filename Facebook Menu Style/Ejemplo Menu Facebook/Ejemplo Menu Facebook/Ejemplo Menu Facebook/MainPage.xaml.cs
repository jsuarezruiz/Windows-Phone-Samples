using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;

namespace Ejemplo_Menu_Facebook
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool _isSettingsOpen = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void GestureListener_OnDragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange > 0 && !_isSettingsOpen)
                OpenSettings();

            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange < 0 && _isSettingsOpen)
                CloseSettings();
        }

        private void GestureListener_OnDragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange > 0 && !_isSettingsOpen)
                    OpenSettings();

            if (e.Direction == System.Windows.Controls.Orientation.Horizontal && e.HorizontalChange < 0 && _isSettingsOpen)
                    CloseSettings();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isSettingsOpen)
                CloseSettings();
            else
                OpenSettings();
        }

        private void OpenSettings()
        {
            ((Storyboard)Canvas.Resources["MoveAnimation"]).SkipToFill();
            ((DoubleAnimation)((Storyboard)Canvas.Resources["MoveAnimation"]).Children[0]).To = -20;
            ((Storyboard)Canvas.Resources["MoveAnimation"]).Begin();
            _isSettingsOpen = true;
        }

        private void CloseSettings()
        {
            ((Storyboard)Canvas.Resources["MoveAnimation"]).SkipToFill();
            ((DoubleAnimation)((Storyboard)Canvas.Resources["MoveAnimation"]).Children[0]).To = -420;
            ((Storyboard)Canvas.Resources["MoveAnimation"]).Begin();
            _isSettingsOpen = false;
        }
    }
}