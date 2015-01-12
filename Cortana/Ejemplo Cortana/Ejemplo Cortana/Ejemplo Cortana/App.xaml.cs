using Ejemplo_Cortana.Views;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Ejemplo_Cortana
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        public static Frame Frame { get; private set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (Frame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                Frame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                Frame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = Frame;
            }

            if (Frame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (Frame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in Frame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                Frame.ContentTransitions = null;
                Frame.Navigated += this.Frame_FirstNavigated;

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!Frame.Navigate(typeof(MainView), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void Frame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            Frame = sender as Frame;
            Frame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            Frame.Navigated -= this.Frame_FirstNavigated;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            if (args.Kind == ActivationKind.VoiceCommand)
            {
                var voiceArgs = (IVoiceCommandActivatedEventArgs)args;
                var result = voiceArgs.Result;

                Frame = Window.Current.Content as Frame;
                Frame.Navigate(typeof(SearchView), result);
                Window.Current.Content = Frame;

                // Ensure the current window is active
                Window.Current.Activate();
            }

            base.OnActivated(args);
        }
    }
}