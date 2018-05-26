using Xamarin.Forms;
using Xamforms.Enhanced.Sample.ViewModels;

namespace Xamforms.Enhanced.Sample.Views
{
    public partial class SampleExtendedEntryPage : ContentPage
    {
        public SampleExtendedEntryPage()
        {
            InitializeComponent();
            BindingContext = new SampleExtendedEntryPageViewModel();
        }
    }
}
