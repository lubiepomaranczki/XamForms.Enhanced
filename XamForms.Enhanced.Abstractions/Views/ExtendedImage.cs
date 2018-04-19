using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamForms.Enhanced.Views
{
    public class ClickableImage : Image
    {
        #region Fields

        public static BindableProperty TappedCommandProperty = BindableProperty.Create(
            propertyName: nameof(TappedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ClickableImage),
            defaultValue: null);

        public static BindableProperty CommandParameterProperty = BindableProperty.Create(
            propertyName: nameof(CommandParameter),
            returnType: typeof(object),
            declaringType: typeof(ClickableImage),
            defaultValue: null);

        public static BindableProperty ItemSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemSource),
            returnType: typeof(object),
            declaringType: typeof(ClickableImage),
            defaultValue: null);

        #endregion

        #region Properties

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public object ItemSource
        {
            get { return GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public event EventHandler Tapped;

        #endregion

        #region Constructor(s)

        public ClickableImage()
        {
            var clickGesture = new TapGestureRecognizer();
            clickGesture.Tapped += ClickGesture_Tapped;
            GestureRecognizers.Add(clickGesture);
        }

        #endregion

        #region Methods

        private void ClickGesture_Tapped(object sender, EventArgs e)
        {
            Tapped?.Invoke(this, e);
            TappedCommand?.Execute(CommandParameter);
        }

        #endregion
    }
}