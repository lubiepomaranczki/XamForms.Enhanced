using Xamarin.Forms;
using XamForms.Enhanced.ViewModels;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleImageLoaderViewModel : BaseViewModel
    {
        public Command ToggleLoaderCmd => new Command(ToggleLoader);

        public SampleImageLoaderViewModel()
        {
           
        }

        private void ToggleLoader(object obj)
        {
            IsBusy = !IsBusy;
        }
    }
}

