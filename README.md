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
```xml
XamForms.EnhancedControls.iOS.EnhancedControls.Init();
```
### Android
On Android, in MainActivity.cs, before ``Xamarin.Forms.Forms.Init()`` call:
```xml
XamForms.Enhanced.Droid.EnhancedControls.Init();
```

### Extended controls
- ExtendedListView
- ExtendedStackLayout
- GradientView
  
### Other features
- BaseViewModel

### XAML

First add the xmlns namespace:
```xml
xmlns:views="clr-namespace:XamForms.Enhanced.Views;assembly=XamForms.Enhanced"
```

Then add the xaml:

```xml
<views:ExtendedStackLayout Grid.Row="1" TappedCommand="{Binding DoNothingCmd}" BackgroundColor="#Fuchsia">
```

You can find samples of all controls in the sample folder.

### Contributors
* [lubiepomaranczki](https://github.com/lubiepomaranczki)

### License
https://github.com/lubiepomaranczki/XamForms.Enhanced/blob/master/LICENSE
