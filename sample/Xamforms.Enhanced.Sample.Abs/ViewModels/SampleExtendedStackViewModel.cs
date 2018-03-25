using Xamarin.Forms;
using XamForms.Enhanced.ViewModels;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleExtendedStackViewModel : BaseViewModel
    {
        #region Commands

        private Command doNothingCmd;
        public Command DoNothingCmd => doNothingCmd ?? (doNothingCmd = new Command(DoNothing));

        #endregion

        #region Constructor(s)

        public SampleExtendedStackViewModel()
        {
            Title = "Binding Title";
        }

        #endregion

        #region Methods

        private void DoNothing(object obj)
        {
            System.Diagnostics.Debug.WriteLine("I've just did nothing");
        }

        #endregion
    }
}
