using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamForms.EnhancedControls
{
    public class BoostedStackLayout : StackLayout
    {
        #region Fields

        //public static BindableProperty StartColorProperty = BindableProperty.Create(
        //     propertyName: nameof(StartColor),
        //     returnType: typeof(Color),
        //    declaringType: typeof(BoostedStackLayout),
        //     defaultValue: Color.Transparent);

        //public static BindableProperty EndColorProperty = BindableProperty.Create(
            // propertyName: nameof(EndColor),
            // returnType: typeof(Color),
            //declaringType: typeof(BoostedStackLayout),
             //defaultValue: Color.Transparent);

        //public static BindableProperty GriadentOrientationProperty = BindableProperty.Create(
            //propertyName: nameof(GrardientOrientation),
            //returnType: typeof(StackOrientation),
            //declaringType: typeof(BoostedStackLayout),
            //defaultValue: StackOrientation.Horizontal);

        public static BindableProperty TappedCommandProperty = BindableProperty.Create(
            propertyName: nameof(TappedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(BoostedStackLayout),
            defaultValue: null);

        public static BindableProperty CommandParameterProperty = BindableProperty.Create(
            propertyName: nameof(CommandParameter),
            returnType: typeof(object),
            declaringType: typeof(BoostedStackLayout),
            defaultValue: null);

        #endregion

        #region Properties

        //public Color StartColor
        //{
        //    get { return (Color)GetValue(StartColorProperty); }
        //    set { SetValue(StartColorProperty, value); }
        //}

        //public Color EndColor
        //{
        //    get { return (Color)GetValue(EndColorProperty); }
        //    set { SetValue(EndColorProperty, value); }
        //}

        //public StackOrientation GrardientOrientation
        //{
        //    get { return (StackOrientation)GetValue(OrientationProperty); }
        //    set { SetValue(OrientationProperty, value); }
        //}

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

        public event EventHandler Clicked;

        #endregion

        #region Constructor(s)

        #endregion

        #region Overrides

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TappedCommandProperty.PropertyName && !GestureRecognizers.Any())
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
            Clicked?.Invoke(this, e);

            if (TappedCommand != null && TappedCommand.CanExecute(CommandParameter))
            {
                TappedCommand?.Execute(CommandParameter);
            }
        }

        #endregion
    }
}