﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using BatBoxPIA.Models;
using BatBoxPIA.Vistas.AccessApp;
//using System.IO;
//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;
//using YoutubeSolution.Database;
//using YoutubeSolution.Views.AccessApp;
//using YoutubeSolution.Views.DynamicListView;
//using YoutubeSolution.Views.MasterDetail;
//using YoutubeSolution.Views.Tabbed;


namespace BatBoxPIA.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        #region Attributes
        public string email;
        public string password;
        public string name;
        public string age;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public string NameTxt
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string AgeTxt
        {
            get { return this.age; }
            set { SetValue(ref this.age, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        #endregion

        #region Commands
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        }
        #endregion

        #region Methods
        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar tu correo.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar tu contraseña.",
                    "Aceptar");
                return;
            }

            string WebAPIkey = "AIzaSyBfW_qJ83Gxsvz85yEZ-AWHgp6_zuRNB40";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
                string gettoken = auth.FirebaseToken;

                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Valida la longitud de la contraseña", "OK");
            }

            /*
            if (string.IsNullOrEmpty(this.name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a name.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.age))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an age.",
                    "Accept");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;


            var user = new UserModel
            {
                EmailField = email,
                PasswordField = password,
                NamesField = name,
                AgeField = age,
                Creation_Date = DateTime.Now,
            };

            await App.Database.SaveUserModelAsync(user);

            await Application.Current.MainPage.DisplayAlert("Successfully", "Welcome " + name.ToString() + " to your app", "Ok");

            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;

            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            */
        }
        #endregion

        #region Constructor
        public RegisterViewModel()
        {
            IsEnabledTxt = true;
        }
        #endregion

    }
}
