using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamForms.Enhanced.Views
{
    public class ExtendedEntry : Entry
    {
        #region Fields 

        public static BindableProperty ReturnKeyTypeProperty = BindableProperty.Create(
            propertyName: nameof(ReturnKeyType),
            returnType: typeof(ReturnKeyTypes),
            declaringType: typeof(ExtendedEntry),
            defaultValue: ReturnKeyTypes.Done);

        public static BindableProperty KeyboardDoneCommandProperty = BindableProperty.Create(
            propertyName: nameof(KeyboardDoneCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedEntry),
            defaultValue: null);

        public static BindableProperty NextViewProperty = BindableProperty.Create(
            propertyName: nameof(NextView),
            returnType: typeof(View),
            declaringType: typeof(ExtendedEntry),
            defaultValue: null);

        #endregion

        #region Properties

        public ReturnKeyTypes ReturnKeyType
        {
            get { return (ReturnKeyTypes)GetValue(ReturnKeyTypeProperty); }
            set { SetValue(ReturnKeyTypeProperty, value); }
        }

        public ICommand KeyboardDoneCommand
        {
            get { return (ICommand)GetValue(KeyboardDoneCommandProperty); }
            set { SetValue(KeyboardDoneCommandProperty, value); }
        }

        public View NextView
        {
            get { return (View)GetValue(NextViewProperty); }
            set { SetValue(NextViewProperty, value); }
        }

        #endregion

        #region Methods

        public void OnNext()
        {
            NextView?.Focus();
        }

        #endregion
    }

    public enum ReturnKeyTypes
    {
        Go,
        Next,
        Done,
        Send,
        Search
    }
}
