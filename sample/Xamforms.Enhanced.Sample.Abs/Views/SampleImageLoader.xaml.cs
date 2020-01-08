using Xamarin.Forms;
using Xamforms.Enhanced.Sample.ViewModels;

namespace Xamforms.Enhanced.Sample.Views
{
    public partial class SampleImageLoader : ContentPage
    {
        public SampleImageLoader()
        {
            InitializeComponent();
            BindingContext = new SampleImageLoaderViewModel();
        }
    }
}
