using Xamarin.Forms;

namespace XamForms.Enhanced.Views
{
    public class ExtendedWebView : WebView
    {
        public static BindableProperty HtmlStringProperty = BindableProperty.Create(
               propertyName: nameof(HtmlString),
               returnType: typeof(string),
               declaringType: typeof(ExtendedWebView),
               defaultValue: string.Empty);

        public string HtmlString
        {
            get { return (string)GetValue(HtmlStringProperty); }
            set { SetValue(HtmlStringProperty, value); }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == HtmlStringProperty.PropertyName)
            {
                Source = new HtmlWebViewSource
                {
                    Html = HtmlString
                };
            }
        }
    }
}

