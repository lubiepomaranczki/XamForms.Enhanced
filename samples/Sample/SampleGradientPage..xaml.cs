using Xamarin.Forms;

namespace Sample
{
    public partial class SampleGradientPage : ContentPage
    {
        public SampleGradientPage()
        {
            InitializeComponent();
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new BoostedStackExamplePage());
        }
    }
}