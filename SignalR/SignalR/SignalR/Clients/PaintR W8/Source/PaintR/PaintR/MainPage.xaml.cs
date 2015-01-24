using System;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace PaintR
{
    /// <summary>
    ///     PaintR
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Members

        private readonly InkManager _mInkManager = new InkManager();

        private Point _previousContactPt;
        private Point _currentContactPt;

        private Color _mCurrentDrawingColor = Colors.Black;
        private const double MCurrentDrawingSize = 4;
        private uint _mPenId;

        private int _x1;
        private int _x2;
        private int _y1;
        private int _y2;

        #region SignalR

        IHubProxy _draw;
        HubConnection _hubConnection;

        #endregion

        #endregion

        public MainPage()
        {
            InitializeComponent();

            InkMode();

            InkCanvas.PointerPressed += OnCanvasPointerPressed;
            InkCanvas.PointerMoved += OnCanvasPointerMoved;
            InkCanvas.PointerReleased += OnCanvasPointerReleased;
            InkCanvas.PointerExited += OnCanvasPointerReleased;
        }

        #region Pointer Event Handlers

        public void OnCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId == _mPenId)
            {
                PointerPoint pt = e.GetCurrentPoint(InkCanvas);

                CurrentManager.ProcessPointerUp(pt);
            }

            _mPenId = 0;

            e.Handled = true;
        }

        private async void OnCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerId != _mPenId) return;
            PointerPoint pt = e.GetCurrentPoint(InkCanvas);
            _currentContactPt = pt.Position;
            _x1 = Convert.ToInt32(_previousContactPt.X);
            _y1 = Convert.ToInt32(_previousContactPt.Y);
            _x2 = Convert.ToInt32(_currentContactPt.X);
            _y2 = Convert.ToInt32(_currentContactPt.Y);

            Color color = _mCurrentDrawingColor;
            const double size = MCurrentDrawingSize;

            if (Distance(_x1, _y1, _x2, _y2) > 2.0)
            {
                var line = new Line
                {
                    X1 = _x1,
                    Y1 = _y1,
                    X2 = _x2,
                    Y2 = _y2,
                    StrokeThickness = size,
                    Stroke = new SolidColorBrush(color)
                };

                _previousContactPt = _currentContactPt;

                InkCanvas.Children.Add(line);

                // Send a message to the server
                await _draw.Invoke("BroadcastPoint", _x2, _y2);
            }

            CurrentManager.ProcessPointerUpdate(pt);
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            double d;
            d = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return d;
        }

        public void OnCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pt = e.GetCurrentPoint(InkCanvas);
            _previousContactPt = pt.Position;

            PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
            if (pointerDevType == PointerDeviceType.Pen ||
                pointerDevType == PointerDeviceType.Mouse &&
                pt.Properties.IsLeftButtonPressed)
            {
                CurrentManager.ProcessPointerDown(pt);

                _mPenId = pt.PointerId;

                e.Handled = true;
            }
        }

        #endregion

        #region Mode Functions

        private void SetDefaults(double strokeSize, Color color)
        {
            var newDrawingAttributes = new InkDrawingAttributes
            {
                Size = new Size(strokeSize, strokeSize),
                Color = color,
                FitToCurve = true
            };
            CurrentManager.SetDefaultDrawingAttributes(newDrawingAttributes);
        }

        private void InkMode()
        {
            _mInkManager.Mode = InkManipulationMode.Inking;
            SetDefaults(MCurrentDrawingSize, _mCurrentDrawingColor);
        }

        #endregion

        #region Flyout Context Menus

        private Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        private async void SelectColor(object sender, RoutedEventArgs e)
        {
            var menu = new PopupMenu();
            menu.Commands.Add(new UICommand("Black", null, 1));
            menu.Commands.Add(new UICommand("Red", null, 2));
            menu.Commands.Add(new UICommand("Green", null, 3));
            menu.Commands.Add(new UICommand("Blue", null, 4));
            menu.Commands.Add(new UICommand("Yellow", null, 5));
            menu.Commands.Add(new UICommand("Pink", null, 6));

            IUICommand chosenCommand = await menu.ShowForSelectionAsync(GetElementRect((FrameworkElement)sender));

            if (chosenCommand != null)
            {
                switch ((int)chosenCommand.Id)
                {
                    case 1:
                        _mCurrentDrawingColor = Colors.Black;
                        break;
                    case 2:
                        _mCurrentDrawingColor = Colors.Red;
                        break;
                    case 3:
                        _mCurrentDrawingColor = Colors.Green;
                        break;
                    case 4:
                        _mCurrentDrawingColor = Colors.Blue;
                        break;
                    case 5:
                        _mCurrentDrawingColor = Colors.Yellow;
                        break;
                    case 6:
                        _mCurrentDrawingColor = Colors.Pink;
                        break;
                }

                InkMode();
            }
        }

        #endregion

        #region SignalR

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            const double size = MCurrentDrawingSize;

            // Connect to the service
            _hubConnection = new HubConnection("http://localhost:9638/");

            // Create a proxy to the chat service
            _draw = _hubConnection.CreateHubProxy("DrawingBoard");

            // Print the message when it comes in
            _draw.On<int, int, string>("DrawPoint", (x, y, c) => Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                switch (c)
                {
                    case "black":
                        _mCurrentDrawingColor = Colors.Black;
                        break;
                    case "red":
                        _mCurrentDrawingColor = Colors.Red;
                        break;
                    case "green":
                        _mCurrentDrawingColor = Colors.Green;
                        break;
                    case "blue":
                        _mCurrentDrawingColor = Colors.Blue;
                        break;
                    case "yellow":
                        _mCurrentDrawingColor = Colors.Yellow;
                        break;
                    case "pink":
                        _mCurrentDrawingColor = Colors.Pink;
                        break;
                }

                Color color = _mCurrentDrawingColor;

                if (_x1 == 0 && _y1 == 0)
                {
                    _x1 = x;
                    _y1 = y;
                }

                var line = new Line
                {
                    X1 = _x1,
                    Y1 = _y1,
                    X2 = x,
                    Y2 = y,
                    StrokeThickness = size,
                    Stroke = new SolidColorBrush(color)
                };
                InkCanvas.Children.Add(line);

                _x1 = x;
                _y1 = y;
            }));

            // Start the connection            
            await _hubConnection.Start();
        }

        #endregion

        public InkManager CurrentManager
        {
            get { return _mInkManager; }
        }
    }
}