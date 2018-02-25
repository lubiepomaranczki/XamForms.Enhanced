using System;
using CoreGraphics;
using Xamarin.Forms;

namespace XamForms.EnhancedControls.iOS.Extensions
{
    public static class ColorExtensions
    {
        public static CGColor TosRGBCGColor(this Color color)
        {
            return new CGColor(CGColorSpace.CreateSrgb(), new nfloat[] { (float)color.R, (float)color.G, (float)color.B, (float)color.A });
        }
    }
}
