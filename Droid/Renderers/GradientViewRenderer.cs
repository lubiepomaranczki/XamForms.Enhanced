using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamForms.EnhancedControls.Views;

[assembly: ExportRenderer(typeof(GradientView), typeof(XamForms.EnhancedControls.Droid.Renderers.GradientViewRenderer))]
namespace XamForms.EnhancedControls.Droid.Renderers
{
    public class GradientViewRenderer : ViewRenderer
    {
        #region Fields

        private readonly Context context;

        #endregion

        #region Properties

        #endregion

        #region Constructor(s)

        public GradientViewRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new Android.Views.View(Context));
            }

            if (e.OldElement == null)
            {
                if (!(e.NewElement is GradientView view))
                {
                    return;
                }

                var gradientLayer = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] {
                    view.StartColor.ToAndroid().ToArgb(), 
                    view.EndColor.ToAndroid().ToArgb() 
                });

                if (view.Orientation == StackOrientation.Vertical)
                {
                    gradientLayer = new GradientDrawable(GradientDrawable.Orientation.TopBottom, new int[] { 
                        view.StartColor.ToAndroid().ToArgb(), 
                        view.EndColor.ToAndroid().ToArgb() 
                    });
                }

                Control.SetBackground(gradientLayer);
            }
        }

        #endregion
    }
}
