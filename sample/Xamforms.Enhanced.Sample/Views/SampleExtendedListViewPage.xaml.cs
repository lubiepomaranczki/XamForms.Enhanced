using Xamarin.Forms;
using Xamforms.Enhanced.Sample.ViewModels;

namespace Xamforms.Enhanced.Sample.Views
{
    public partial class SampleExtendedListViewPage : ContentPage
    {
        public SampleExtendedListViewPage()
        {
            InitializeComponent();
            BindingContext = new SampleExtendedListViewViewModel();
        }
    }
}
