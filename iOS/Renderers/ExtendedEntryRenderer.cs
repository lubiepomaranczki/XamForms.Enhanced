using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamForms.Enhanced.Views;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(XamForms.Enhanced.iOS.Renderers.ExtendedEntryRenderer))]

namespace XamForms.Enhanced.iOS.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            var element = (ExtendedEntry)this.Element;
            base.OnElementChanged(e);

            if (!((Control != null) & (e.NewElement != null)))
            {
                return;
            }

            var customEntry = e.NewElement as ExtendedEntry;
            if (customEntry == null)
            {
                return;
            }

            Control.ReturnKeyType = (e.NewElement as ExtendedEntry).ReturnKeyType.GetValueFromDescription();

            if (element.ReturnKeyType == ReturnKeyTypes.Next)
            {
                Control.ShouldReturn += (field) =>
                {
                    element.OnNext();
                    return false;
                };
            }
            else if (element.ReturnKeyType == ReturnKeyTypes.Done)
            {
                Control.ShouldReturn += field =>
                {
                    element.KeyboardDoneCommand?.Execute(null);

                    return true;
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ExtendedEntry.ReturnKeyTypeProperty.PropertyName)
            {
                Control.ReturnKeyType = (sender as ExtendedEntry).ReturnKeyType.GetValueFromDescription();
            }
        }
    }

    public static class EnumExtensions
    {
        public static UIReturnKeyType GetValueFromDescription(this ReturnKeyTypes value)
        {
            var type = typeof(UIReturnKeyType);

            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == value.ToString())
                    {
                        return (UIReturnKeyType)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == value.ToString())
                    {
                        return (UIReturnKeyType)field.GetValue(null);
                    }
                }
            }
            throw new NotSupportedException($"Not supported on iOS: {value}");
        }
    }
}