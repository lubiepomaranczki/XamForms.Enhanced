using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamForms.EnhancedControls.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool isBusy;
        private string title;

        #endregion

        #region Properties

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region Constructor(s)

        protected BaseViewModel()
        {
        }

        #endregion

        #region INotifyPropertyChanged

        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Methods

        #endregion
    }
}
