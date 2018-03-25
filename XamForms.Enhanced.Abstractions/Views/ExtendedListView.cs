using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamForms.Enhanced.Views
{
    public class ExtendedListView : ListView
    {
        #region Fields

        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            propertyName: nameof(ItemSelectedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedListView),
            defaultValue: null);

        public static BindableProperty ShouldHiglightSelectedProperty = BindableProperty.Create(
            propertyName: nameof(ShouldHiglightSelected),
            returnType: typeof(bool),
            declaringType: typeof(ExtendedListView),
            defaultValue: true);

        #endregion

        #region Properties

        public ICommand ItemSelectedCommand
        {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        public bool ShouldHiglightSelected
        {
            get { return (bool)GetValue(ShouldHiglightSelectedProperty); }
            set { SetValue(ShouldHiglightSelectedProperty, value); }
        }

        public event EventHandler Tapped;

        #endregion

        #region Constructor(s)

        public ExtendedListView()
        {
            ItemTapped += Handle_ItemTapped;
            ItemSelected += CommandListView_ItemSelected;
        }

        #endregion

        #region Methods

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            Tapped?.Invoke(this, e);

            if (ItemSelectedCommand != null && ItemSelectedCommand.CanExecute(e.Item))
            {
                ItemSelectedCommand?.Execute(e.Item);
            }
        }

        private void CommandListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(!ShouldHiglightSelected)
            {
				SelectedItem = null;
            }
        }

        #endregion
    }
}
