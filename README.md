# XamForms.Extended

XamForms.Extended is an open-source library created for my development purposes. It is en extension for Xamarin.Forms. Hope you will find it usefull!

### Currently suported platforms:
- Xamarin.iOS
- Xamarin.Android

### Setup
- Install into your PCL/.NET Standard project and Client projects.
- Nuget **NOT** available

### iOS
On iOS, in AppDelegate.cs, before ``Xamarin.Forms.Forms.Init()`` call:
```
XamForms.EnhancedControls.iOS.EnhancedControls.Init();
```
### Android
On Android, in MainActivity.cs, before ``Xamarin.Forms.Forms.Init()`` call:
```
XamForms.Enhanced.Droid.EnhancedControls.Init();
```

# Extended controls
- ExtendedListView,
- ExtendedStackLayout
- GradientView
  
# Other features
- BaseViewModel
