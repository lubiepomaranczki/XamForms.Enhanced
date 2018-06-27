using System;
using XamForms.Enhanced.ViewModels;
using XamForms.Enhanced.Observable;
using Xamarin.Forms;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleExtendedEntryPageViewModel : BaseViewModel
    {
        #region Fields

        private Command onDoneCmd;

        #endregion

        #region Properties

        public ObservableProperty<string> FirstName { get; set; } = new ObservableProperty<string>();

        public ObservableProperty<string> LastName { get; set; } = new ObservableProperty<string>();

        public ObservableProperty<string> Email { get; set; } = new ObservableProperty<string>();

        #endregion

        #region Commands

        public Command OnDoneCmd => onDoneCmd ?? (onDoneCmd = new Command(OnDone));

        #endregion

        #region Constructor(s)

        public SampleExtendedEntryPageViewModel()
        {
            Title = "Sample Extended Entry";
        }

        #endregion

        #region Methods

        private void OnDone(object obj)
        {
            Console.WriteLine("Cmd tapped");
        }

        #endregion
    }
}
