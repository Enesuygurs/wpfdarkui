using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_Uygur_Theme
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            DarkMessageBox darkMessageBoxes;
            if ((username.Text == Properties.Settings.Default.username && passwordBox.Password == Properties.Settings.Default.password) || (username.Text == Properties.Settings.Default.username && passwordTextBox.Text == Properties.Settings.Default.password))
            {
                darkMessageBoxes = new DarkMessageBox("Login successful", 1);
            }
            else
            {
                darkMessageBoxes = new DarkMessageBox("Invalid username or password", 3);
            }
            darkMessageBoxes.Show();
        }

        private void changeRememberMe(Boolean remember)
        {
            if (remember == true && rememberMe.IsChecked == true)
            {
                Properties.Settings.Default.remember = true;
            }
            else
            {
                Properties.Settings.Default.remember = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rememberMe.IsChecked = Properties.Settings.Default.remember;
            if (Properties.Settings.Default.remember == true)
            {
                username.Text = Properties.Settings.Default.username;
                passwordBox.Password = Properties.Settings.Default.password;
            }
            else
            {
                username.Text = "Username";
                passwordBox.Password = "123456789";
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void username_GotFocus(object sender, RoutedEventArgs e)
        {
            username.Foreground = Brushes.White;
            if (username.Text == "Username") username.Text = string.Empty;
        }

        private void username_LostFocus(object sender, RoutedEventArgs e)
        {
            username.Foreground = Brushes.Gray;
            if (string.IsNullOrEmpty(username.Text)) username.Text = "Username";
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rememberMe.IsChecked = !rememberMe.IsChecked;
        }

        private void togglePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                passwordBox.Visibility = Visibility.Collapsed;
                passwordTextBox.Visibility = Visibility.Visible;
                togglePasswordButton.Content = "👁‍🗨";
                togglePasswordButton.Foreground = Brushes.Silver;
            }
            else
            {
                passwordTextBox.Visibility = Visibility.Collapsed;
                passwordBox.Visibility = Visibility.Visible;
                togglePasswordButton.Content = "👁";
                togglePasswordButton.Foreground = Brushes.Gray;

            }
        }
        private bool isSyncing = false;

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!isSyncing)
            {
                isSyncing = true;
                passwordTextBox.Text = passwordBox.Password;
                isSyncing = false;
            }
        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isSyncing)
            {
                isSyncing = true;
                passwordBox.Password = passwordTextBox.Text; 
                isSyncing = false;
            }
        }
        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Foreground = Brushes.White;
        }

        private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Foreground = Brushes.Gray;
        }

        private void rememberMe_Click(object sender, RoutedEventArgs e)
        {
            if (rememberMe.IsChecked == true)
            {
                changeRememberMe(true);
                MessageBox.Show("Remember Me is checked");
            }
            else
            {
                changeRememberMe(false);
                MessageBox.Show("Remember Me is unchecked");
            }
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox.Foreground = Brushes.White;
            if (passwordBox.Password == "123456789") passwordBox.Password = "";
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordBox.Foreground = Brushes.Gray;
            if (string.IsNullOrEmpty(passwordBox.Password)) passwordBox.Password = "123456789";
        }

        private void fullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (fullscreen.Content.ToString() == "1")
            {
                fullscreen.Content = "2";
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                fullscreen.Content = "1";
                this.WindowState = WindowState.Normal;
            }
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logInButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logInButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
