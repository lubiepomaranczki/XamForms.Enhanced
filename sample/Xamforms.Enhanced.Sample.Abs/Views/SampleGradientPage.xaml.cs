using Xamarin.Forms;

namespace Xamforms.Enhanced.Sample.Views
{
    public partial class SampleGradientPage : ContentPage
    {
        public SampleGradientPage()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SampleExtendedFramePage());
        }
    }
}
