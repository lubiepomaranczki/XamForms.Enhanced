using System;
using Xamarin.Forms;

namespace Sample
{
    public partial class BoostedStackExamplePage : ContentPage
    {
        public BoostedStackExamplePage()
        {
            InitializeComponent();
            BindingContext = new BoostedStackExampleViewModel();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}