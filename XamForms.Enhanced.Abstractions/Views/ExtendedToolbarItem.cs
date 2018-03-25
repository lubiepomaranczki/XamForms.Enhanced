using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamForms.Enhanced.Views
{
    public class ExtendedToolbarItem : ToolbarItem
    {
        #region Fields

        public static BindableProperty TappedCommandProperty = BindableProperty.Create(
            propertyName: nameof(TappedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedToolbarItem),
            defaultValue: null);

        #endregion

        #region Properties

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        #endregion

        #region Constructor(s)

        public ExtendedToolbarItem()
        {
            Clicked += ToolbarItem_Clicked;
        }

        #endregion

        #region Methods

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            TappedCommand?.Execute(CommandParameter);
        }

        #endregion
    }
}
