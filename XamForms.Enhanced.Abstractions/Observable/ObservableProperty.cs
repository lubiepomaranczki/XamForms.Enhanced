using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamForms.Events.Shared;

namespace XamForms.Enhanced.Observable
{
    public class ObservableProperty<T> : object, INotifyPropertyChanged
    {
        #region Fields

        private T value;

        #endregion

        #region Properties

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;

                DataChanged?.Invoke(this, new DataEventArgs
                {
                    Parameter = value
                });

                OnPropertyChanged(nameof(Value));
            }
        }

        #endregion

        #region Events

        public event EventHandler DataChanged;

        #endregion

        #region Constructor(s)

        public ObservableProperty()
        {
            Value = default(T);
        }

        public ObservableProperty(T initValue)
        {
            Value = initValue;
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
