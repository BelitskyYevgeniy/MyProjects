using System;
using System.Windows;
using System.Collections.Generic;
using wcf_chat;
using ChatClient.ServiceChatWPF;

namespace ChatClient
{
    public partial class ChatWindow : Window
    {
        public int UserId { get; set; }
        public List<ServerUser> Users { get; set; }
        public ServiceChatClient client { get; set; }
        public ChatWindow(string userName)
        {

            InitializeComponent();

            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            UserId = client.Connect(userName);
            if (UserId == 0)
            {
                ErrorWindow errorWindow = new ErrorWindow("Connection error!");
                errorWindow.ShowDialog();
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                Close();
            }
            DataContext = this;
        }


        private void usersBox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
        }
    }
}
