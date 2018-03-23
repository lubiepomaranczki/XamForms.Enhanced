using System;

using Xamarin.Forms;
using XamForms.EnhancedControls.ViewModels;

namespace Sample
{
    public class BoostedStackExampleViewModel : BaseViewModel
    {
        private Command doNothingCmd;
        public Command DoNothingCmd => doNothingCmd ?? (doNothingCmd = new Command(DoNothing));

        private void DoNothing(object obj)
        {
            
        }
    }
}

