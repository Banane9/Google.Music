﻿using System;
using System.Windows;
using System.Windows.Controls;
using GoogleMusicApi;
using GooglePlayMusic.Desktop.Managers;

namespace GooglePlayMusic.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoadingOverlay.Visibility = Visibility.Visible;
            SessionManager.MobileSession = new MobileSession();

            if (await SessionManager.MobileSession.LoginAsync(TextBoxUsername.Text, TextBoxPassword.Password))
            {

                WindowManager.NavigateToPage(new Uri("/Pages/Test.xaml", UriKind.Relative));
                LoadingOverlay.Visibility = Visibility.Hidden;
            }
            else
            {
                LoadingOverlay.Visibility = Visibility.Hidden;
                MessageBox.Show("Login Failed!");

            }
        }
    }
}
