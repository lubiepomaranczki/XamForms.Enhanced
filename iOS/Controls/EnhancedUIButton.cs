using System;
using Foundation;
using UIKit;

namespace XamForms.Enhanced.iOS.Controls
{
    /// <summary>
    /// <see cref="T:XamForms.Enhanced.iOS.Controls.EnhancedUIButton"/> class is a button that let's you create fully custom Button with its own layout
    /// </summary>
    public class EnhancedUIButton : UIButton
    {
        private readonly UIView buttonView;
        private UIView overlay;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XamForms.Enhanced.iOS.Controls.EnhancedUIButton"/> class.
        /// </summary>
        [Export("init")]
        public EnhancedUIButton() : base(UIButtonType.Custom)
        {
            AddTarget(HandleTouchDown, UIControlEvent.TouchDown);
            AddManyTargets(RemoveOverlay, UIControlEvent.TouchUpInside, UIControlEvent.TouchUpOutside, UIControlEvent.TouchCancel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XamForms.Enhanced.iOS.Controls.EnhancedUIButton"/> class.
        /// </summary>
        /// <param name="buttonView">Custom view that will be used as a button layout.</param>
        public EnhancedUIButton(UIView buttonView) : this()
        {
            this.buttonView = buttonView;
        }

        /// <summary>
        /// Highlight color that indicates that button is being pressed
        /// </summary>
        public UIColor PressedOverlayColor { get; set; }

        /// <summary>
        /// If you don't apply <see cref="T:XamForms.Enhanced.iOS.Controls.EnhancedUIButton"/> with alpha you can do it here
        /// </summary>
        /// <value>The pressed overlay color opacity.</value>
        public float PressedOverlayColorOpacity { get; set; }

        [Export("drawLayer:inContext:")]
        public override void DrawLayer(CoreAnimation.CALayer layer, CoreGraphics.CGContext context)
        {
            AddView(buttonView);
        }

        /// <summary>
        /// Set the ButtonView layout to your UIView
        /// </summary>
        /// <param name="buttonView">Button view.</param>
        public virtual void AddView(UIView buttonView)
        {
            if (buttonView == null)
            {
                throw new ArgumentNullException($"{nameof(buttonView)} can't be null");
            }

            buttonView.UserInteractionEnabled = false;
            AddSubview(buttonView);
            buttonView.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            buttonView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            buttonView.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            buttonView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

            SetNeedsLayout();
            LayoutIfNeeded();
        }

        /// <summary>
        /// Handles the touch down events. 
        /// </summary>
        protected virtual void HandleTouchDown(object sender, EventArgs e)
        {
            var opacity = Math.Abs(PressedOverlayColorOpacity - default(nfloat)) < 0 ? PressedOverlayColorOpacity : 0.5f;

            overlay = new UIView
            {
                UserInteractionEnabled = false,
                BackgroundColor = PressedOverlayColor ?? UIColor.Gray.ColorWithAlpha(opacity),
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            AddSubview(overlay);

            var buttonCornerRadius = Layer.CornerRadius;
            if (buttonCornerRadius != default(int))
            {
                overlay.Layer.Opacity = opacity;
                overlay.Layer.BackgroundColor = (PressedOverlayColor ?? UIColor.Gray).CGColor;
                overlay.Layer.CornerRadius = buttonCornerRadius;
            }

            overlay.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            overlay.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            overlay.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            overlay.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
        }

        private void RemoveOverlay(object sender, EventArgs e)
        {
            overlay?.RemoveFromSuperview();
        }

        private void AddManyTargets(EventHandler eventHandler, params UIControlEvent[] forAction)
        {
            foreach (var action in forAction)
            {
                AddTarget(eventHandler, action);
            }
        }
    }
}
