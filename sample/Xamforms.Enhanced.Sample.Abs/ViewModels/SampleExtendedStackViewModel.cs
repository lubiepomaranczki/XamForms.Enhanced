using Xamarin.Forms;
using Xamforms.Enhanced.Sample.Models;
using XamForms.Enhanced.ViewModels;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleExtendedStackViewModel : BaseViewModel
    {
        #region Fields

        private ObservableModel model;

        #endregion

        #region Properties

        public ObservableModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        #endregion

        #region Commands

        private Command doNothingCmd;

        public Command DoNothingCmd => doNothingCmd ?? (doNothingCmd = new Command(DoNothing));

        #endregion

        #region Constructor(s)

        public SampleExtendedStackViewModel()
        {
            Title = "Binding Title";

            Model = new ObservableModel();
        }

        #endregion

        #region Methods

        private void DoNothing(object obj)
        {
            Model.Name.Value = "Date: " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            System.Diagnostics.Debug.WriteLine("I've just changed name");
        }

        #endregion
    }
}
