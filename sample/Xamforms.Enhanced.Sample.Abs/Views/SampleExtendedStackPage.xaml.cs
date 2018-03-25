using Xamarin.Forms;

namespace Xamforms.Enhanced.Sample.Views
{
    public partial class SampleExtendedStackPage : ContentPage
    {
        public SampleExtendedStackPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.SampleExtendedStackViewModel();
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation?.PushAsync(new SampleExtendedListViewPage());
        }
    }
}
