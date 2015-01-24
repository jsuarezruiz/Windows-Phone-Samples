using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Phone.Controls;

namespace TalkR
{
    public partial class ChatPage : PhoneApplicationPage
    {
        IHubProxy _chat;
        HubConnection _hubConnection;

        public ChatPage()
        {
            InitializeComponent();
        }

        private async void sendChatBtn_Click(object sender, EventArgs e)
        {
            // Send a message to the server
            await _chat.Invoke("Send", chatTextbox.Text).ContinueWith(task =>
            {
                if (!task.IsFaulted && task.Exception == null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() => { chatTextbox.Text = string.Empty; });
                }
            });
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Connect to the service
            _hubConnection = new HubConnection("http://169.254.80.80:48037/");

            // Create a proxy to the chat service
            _chat = _hubConnection.CreateHubProxy("ChatHub");

            // Print the message when it comes in
            _chat.On<string>("Message", message => Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                chatDialog.Text += "\n" +  message;
            }));

            // Start the connection            
            await _hubConnection.Start();
        }
    }
}