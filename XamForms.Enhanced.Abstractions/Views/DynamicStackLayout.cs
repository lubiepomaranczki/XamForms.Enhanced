using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamForms.Enhanced.Views
{
    public class DynamicStackLayout : StackLayout
    {
        #region Bindable Properties

        public static BindableProperty ItemTappedCommandProperty = BindableProperty.Create(
            propertyName: nameof(ItemTappedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(DynamicStackLayout),
            defaultValue: null);

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(IEnumerable),
            declaringType: typeof(DynamicStackLayout),
            defaultValue: default(IEnumerable),
            propertyChanged: ItemSourceChanged);

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            propertyName: nameof(ItemTemplate),
            returnType: typeof(DataTemplate),
            declaringType: typeof(DynamicStackLayout),
            defaultValue: default(DataTemplate));

        #endregion

        #region Public Properties

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public event EventHandler ItemTapped;

        #endregion

        #region Constructor(s)

        public DynamicStackLayout()
        {
            Spacing = 0;
        }

        #endregion

        #region ItemSourceChanged

        protected static void ItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((DynamicStackLayout)bindable).ItemsSourceChanged((IEnumerable)newValue);
        }

        public void ItemsSourceChanged(IEnumerable source)
        {
            Children.Clear();

            foreach (var item in source)
            {
                var view = (View)ItemTemplate.CreateContent();

                if (view is BindableObject bindableObject)
                {
                    bindableObject.BindingContext = item;
                }

                var clickGesture = new TapGestureRecognizer();
                clickGesture.Tapped += ClickGesture_Tapped;
                view.GestureRecognizers.Add(clickGesture);

                Children.Add(view);
            }
        }

        #endregion

        private void ClickGesture_Tapped(object sender, EventArgs e)
        {
            ItemTapped?.Invoke(sender, e);
            ItemTappedCommand?.Execute((sender as View).BindingContext);
        }
    }
}
