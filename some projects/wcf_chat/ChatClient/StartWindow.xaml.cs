using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {

        public StartWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ErrorWindow ew = new ErrorWindow("Input NickName");
                ew.ShowDialog();
                return;
            }

            new ChatWindow(textBox.Text).Show();
            Close();

        }
    }
}

