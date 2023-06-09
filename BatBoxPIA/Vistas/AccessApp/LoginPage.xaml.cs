﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BatBoxPIA.ViewModels;

namespace BatBoxPIA.Vistas.AccessApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }


        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Menu());

        }

    }
}
