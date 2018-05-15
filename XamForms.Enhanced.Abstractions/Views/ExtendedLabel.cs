using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;

namespace XamForms.Enhanced.Views
{
    public class ExtendedLabel : Label
    {
        #region Fields

        public static BindableProperty TappedCommandProperty = BindableProperty.Create(
            propertyName: nameof(TappedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedLabel),
            defaultValue: null);

        public static BindableProperty CommandParameterProperty = BindableProperty.Create(
            propertyName: nameof(CommandParameter),
            returnType: typeof(object),
            declaringType: typeof(ExtendedLabel),
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
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public event EventHandler Tapped;

        #endregion

        #region Constructor(s)

        public ExtendedLabel()
        {
        }

        #endregion

        #region Overrides

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TappedCommandProperty.PropertyName || Tapped != null && !GestureRecognizers.Any())
            {
                var clickGesture = new TapGestureRecognizer();
                clickGesture.Tapped += ClickGesture_Tapped;
                GestureRecognizers.Add(clickGesture);
            }
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