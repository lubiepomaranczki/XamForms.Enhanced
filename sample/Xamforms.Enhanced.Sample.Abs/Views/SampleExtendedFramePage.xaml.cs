using Xamarin.Forms;

namespace Xamforms.Enhanced.Sample.Views
{
    public partial class SampleExtendedFramePage : ContentPage
    {
        #region Fields

        private Command navigateCmd;

        #endregion

        #region Commands

        public Command NavigateCmd => navigateCmd ?? (navigateCmd = new Command(Navigate));

        #endregion

        #region Constructor(s)

        public SampleExtendedFramePage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        #endregion

        #region Methods

        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            Navigation?.PopAsync();
        }

        private void Navigate(object obj)
        {
            Navigation?.PopAsync();
        }

        #endregion
    }
}
