using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TimeTrackerApp.PageModels.Base
{
    public class ExtendedBindableObject : BindableObject
    {
        //Simplies the process of updating a Bindable Property and calling INotifyPropertyChanged

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
