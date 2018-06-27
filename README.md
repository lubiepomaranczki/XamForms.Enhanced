# XamForms.Extended

XamForms.Extended is an open-source library created for my development purposes. It is en extension for Xamarin.Forms. Hope you will find it useful!

### Currently supported platforms:
- Xamarin.iOS
- Xamarin.Android

### Setup
- Install into your PCL/.NET Standard project and Client projects.
- Nuget available [here](https://www.nuget.org/packages/XamForms.Enhanced) 

#### iOS
On iOS, in AppDelegate.cs, after ``Xamarin.Forms.Forms.Init()`` call:
```xml
XamForms.EnhancedControls.iOS.EnhancedControls.Init();
```
#### Android
On Android, in MainActivity.cs, after ``Xamarin.Forms.Forms.Init()`` call:
```xml
XamForms.Enhanced.Droid.EnhancedControls.Init();
```

### Extended controls
- DynamicStackLayout
- ExtendedEntry
- ExtendedFrame
- ExtendedImage
- ExtendedLabel
- ExtendedListView
- ExtendedStackLayout
- ExtendedToolbarItem
- GradientView
  
### Other features
- BaseViewModel
- RelayCommand
- InputRelayCommand
- OutputRelayCommand
- ToObservable extension for IList
- ObservableProperty

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

## Contributing

Please read [CONTRIBUTING.md](https://github.com/lubiepomaranczki/XamForms.Enhanced) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. 

## Authors

* **Łukasz Ławicki** - [lubiepomaranczki](https://github.com/lubiepomaranczki)

See also the list of project [contributors](https://github.com/lubiepomaranczki/XamForms.Enhanced/contributors)

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/lubiepomaranczki/XamForms.Enhanced/blob/master/LICENSE) file for details
