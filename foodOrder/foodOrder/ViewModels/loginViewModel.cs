using foodOrder.services;
using foodOrder.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace foodOrder.ViewModels
{
    class loginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //props
        private  string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Username"));
                }
            }
        }

        private string _userpass;
        public string Userpass
        {
            get
            {
                return _userpass;
            }
            set
            {
                _userpass = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Userpass"));
                }
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Userpass"));
                }
            }
        }


        //commands
        public Command loginCommand { get; set; }
        public Command registerCommand { get; set; }


        //ctor
        public loginViewModel ()
        {
            loginCommand = new Command (async () => await loginasync());
            registerCommand = new Command(async () => await registerasync());
        }






        //methods

        private async Task registerasync ()
        {
            if (IsBusy)
                return;
            try {
                IsBusy = true;
               
            userService userService = new userService();
            var newUser = await userService.registerNewUser(Username, Userpass);
            if (newUser)
              await App.Current.MainPage.DisplayAlert("success", "register successed", "ok");
            else
              await App.Current.MainPage.DisplayAlert("user exists", "register failed beacause user exist ", "ok");
            }
            catch(Exception m)
            {
                await App.Current.MainPage.DisplayAlert("failed tp register", m.Message, "cancel");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task loginasync ()
        {
            if (IsBusy)
                return;
            try {
                IsBusy = true;

                userService userService = new userService();
            var olduser = await userService.loginUser(Username, Userpass);
                if (olduser) { 
                    Preferences.Set("username", Username);
                    await App.Current.MainPage.Navigation.PushModalAsync(new homePage());}
                else
                    await App.Current.MainPage.DisplayAlert("failed", "failed user doesnt exist please register", "cancel"); }
            catch(Exception m)
            {
                await App.Current.MainPage.DisplayAlert("failed to login", m.Message, "cancel");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
