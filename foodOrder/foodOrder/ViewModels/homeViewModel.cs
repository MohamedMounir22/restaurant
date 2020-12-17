using foodOrder.Models;
using foodOrder.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace foodOrder.ViewModels
{
  public  class homeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //props
        private ObservableCollection<category> _allCategories;
        public ObservableCollection<category> AllCategories
        {
            get
            {
                return _allCategories;
            }
            set
            {
                _allCategories = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AllCategories"));
                }
            }
        }

        private string _username;
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

        public homeViewModel ()
        {

            AllCategories = new ObservableCollection<category>();
            getcategories();
            Username = Preferences.Get("username", "Guest");
        }

   public async void getcategories ()
        {
            postCategoriesToFire postCategoriesToFire = new postCategoriesToFire();
            AllCategories = await postCategoriesToFire.getCategorFromFire();



        }














    }//end class
}
