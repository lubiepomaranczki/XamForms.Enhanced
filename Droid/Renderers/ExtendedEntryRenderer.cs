using System;
using System.ComponentModel;
using Android.Content;
using Android.Views.InputMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamForms.Enhanced.Views;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(XamForms.Enhanced.Droid.Renderers.ExtendedEntryRenderer))]
namespace XamForms.Enhanced.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        #region Fields

        private readonly Context context;

        #endregion

        #region Properties



        #endregion

        #region Constructor(s)

        public ExtendedEntryRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        #endregion

        #region Methods       

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            var element = (ExtendedEntry)Element;
            base.OnElementChanged(e);

            if (!((Control != null) & (e.NewElement != null)))
            {
                return;
            }

            var customEntry = (e.NewElement as ExtendedEntry);
            if (customEntry == null)
            {
                return;
            }

            Control.ImeOptions = customEntry.ReturnKeyType.GetValueFromDescription();
            Control.SetImeActionLabel(customEntry.ReturnKeyType.ToString(), Control.ImeOptions);

            if (element.ReturnKeyType == ReturnKeyTypes.Next)
            {
                Control.EditorAction += (sender, args) =>
                {
                    element.OnNext();
                    return;
                };
            }
            else if (element.ReturnKeyType == ReturnKeyTypes.Done)
            {
                Control.EditorAction += (sender, args) =>
                {
                    element.KeyboardDoneCommand?.Execute(null);

                    element.Unfocus();
                    return;
                };
            }
        }

        #endregion  
    }

    public static class EnumExtensions
    {
        public static ImeAction GetValueFromDescription(this ReturnKeyTypes value)
        {
            var type = typeof(ImeAction);
            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == value.ToString())
                    {
                        return (ImeAction)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == value.ToString())
                    {
                        return (ImeAction)field.GetValue(null);
                    }
                }
            }

            throw new NotSupportedException($"Not supported on Android: {value}");
        }
    }
}