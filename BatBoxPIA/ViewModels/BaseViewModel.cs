using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    public class BaseViewModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


        protected void SetValue<T>(ref T backingFieled, T value, [CallerMemberName] string propertyName = null)

        {

            if (EqualityComparer<T>.Default.Equals(backingFieled, value))

            {

                return;

            }

            backingFieled = value;

            OnPropertyChanged(propertyName);

        }



        protected virtual void OnPropertyChangeds([CallerMemberName] string propertyName = null)

        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)

            {

                handler(this, new PropertyChangedEventArgs(propertyName));

            }

        }
    }
}
