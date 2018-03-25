using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamForms.EnhancedControls.iOS.Extensions;
using XamForms.Enhanced.Views;

[assembly: ExportRenderer(typeof(GradientView), typeof(XamForms.Enhanced.iOS.Renderers.GradientViewRenderer))]
namespace XamForms.Enhanced.iOS.Renderers
{
    public class GradientViewRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                UIView myView = new UIView();
                SetNativeControl(myView);
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (!(Element is Views.GradientView gradientView))
            {
                return;
            }

            var gradientLayer = new CAGradientLayer
            {
                Frame = Control.Bounds,
                Colors = new CGColor[] { gradientView.StartColor.TosRGBCGColor(), gradientView.EndColor.TosRGBCGColor() }
            };

            if (gradientView.Orientation == StackOrientation.Vertical)
            {
                gradientLayer.StartPoint = new CGPoint(0.5, 0);
                gradientLayer.EndPoint = new CGPoint(0.5, 1);
            }
            else
            {
                gradientLayer.StartPoint = new CGPoint(0, 0.5);
                gradientLayer.EndPoint = new CGPoint(1, 0.5);
            }

            Control.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
