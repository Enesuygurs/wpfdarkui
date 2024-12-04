using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_Uygur_Theme
{
    /// <summary>
    /// DarkMessageBox.xaml etkileşim mantığı
    /// </summary>
    public partial class DarkMessageBox : Window
    {
        private string messageText;
        private int messageType;

        public DarkMessageBox(string message, int messagetype)
        {
            InitializeComponent();
            messageText = message;
            messageType = messagetype;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageTextBlock.Text = messageText;
            if (messageType == 1)
            {
                title.Content = "Information";
                title.Foreground = new SolidColorBrush(Color.FromRgb(0, 188, 212));
            }

            else if (messageType == 2)
            {
                title.Content = "Warning";
                title.Foreground = new SolidColorBrush(Color.FromRgb(255, 152, 0));
            }

            else if (messageType == 3)
            {
                title.Content = "Error";
                title.Foreground = new SolidColorBrush(Color.FromRgb(244, 67, 54));
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
