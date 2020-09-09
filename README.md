# RTL-helper-system
RTL helper system is a Unity package that helps you to manage RTL (Right To Left) in the UI.
This system is for addition to localization systems with languages that are written from right to left.

This package used [Arabic Letters Support For Unity](https://github.com/Konash/arabic-support-unity).
For automatic line drop, you need to use TMP insted of regular Unity's text component.

## How to bring it to your project

You can bring it to your project in three different ways: downloading this repository, adding it to your project's Package Manager manifest, or through the Package Manager window.

### Download

#### Setup
Download or clone this repository into your project in the folder `Packages/com.DrimiaInteractive.RTL-helper-system`.

### Package Manager Manifest \ Package Manager window

#### Requirements
[Git](https://git-scm.com/) must be installed and added to your path.

#### Setup - Package Manager Manifest
The following line needs to be added to your `Packages/manifest.json` file in your Unity Project under the `dependencies` section:

```json
"com.drimiainteractive.rtl-helper-system": "https://github.com/Drimia-Interactive/RTL-helper-system.git"
```

#### Setup - Package Manager window
From Unity 2019.3 we can [install packages from git](https://docs.unity3d.com/Manual/upm-ui-giturl.html "Installing from a Git URL")
Just add the following URL according to the manual:

```json
https://github.com/Drimia-Interactive/RTL-helper-system.git
```


## How to use it

### Components
we have several components that you can use
* __Text Rtl Helper__ - add this to gameobject with a regular Text component
* __Text Mesh Pro Rtl Helper__ - add this to gameobject with a TMP Text component
* __RectTransform Rtl Helper__ - add this to gameobject with a RectTransform component
* __RectTransform With Children Rtl Helper__ - add this to gameobject with a RectTransform component that you wish to convert RTL to it and all of it children gameobjects.

for the two Text component you can choose to change the text automaticly with the change of RTL or by using the function `OnTextChanged`

### Manager
To make all the UI move between Left to Right, you just need to change one boolean.
```csharp
RtlHelperSystemManager.Instance.isRightToLeft
```

For example, with using Unity's Localization package:
```csharp
using DrimiaInteractive.RtlHelperSystem;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class ChangeRtl : MonoBehaviour
{
	private void Start()
	{
		LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
	}

	private void LocalizationSettings_SelectedLocaleChanged(Locale locale)
	{
		RtlHelperSystemManager.Instance.isRightToLeft = locale.Identifier.CultureInfo.TextInfo.IsRightToLeft;
	}
}
```
