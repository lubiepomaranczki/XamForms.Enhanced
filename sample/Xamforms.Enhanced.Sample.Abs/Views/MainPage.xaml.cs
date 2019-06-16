using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamforms.Enhanced.Sample.ViewModels;

namespace Xamforms.Enhanced.Sample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            (BindingContext as MainPageViewModel).Navigation = Navigation;
        }
    }
}