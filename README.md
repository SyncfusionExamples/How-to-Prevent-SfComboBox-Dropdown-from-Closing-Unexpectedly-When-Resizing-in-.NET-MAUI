# How-to-Prevent-SfComboBox-Dropdown-from-Closing-Unexpectedly-When-Resizing-in-.NET-MAUI
This repository contains a sample explaining how to Prevent SfComboBox Dropdown from Closing Unexpectedly When Resizing in .NET MAUI
## Solution
To prevent the dropdown from closing during resizing, use the following approach:

1. Track layout resizing using a flag.
2. Override `OnSizeAllocated` to detect when the layout is resized.
3. Handle the `DropDownClosing` event to prevent closing during resizing.

## Implementation

**C# Code**
```csharp
public partial class MainPage : ContentPage
{
    private bool isResizing; // Flag to track resizing

    public MainPage()
    {
        InitializeComponent();
        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        isResizing = true;
    }

    private async void SfComboBox_DropDownClosing(object sender, Syncfusion.Maui.Core.DropDownCancelEventArgs e)
    {
        if (isResizing)
        {
            e.Cancel = true; // Prevent closing during resizing
        }

        await Task.Delay(400); // Short delay to update UI after resizing
        isResizing = false;
    }
}
```

**XAML**
```xml
<ScrollView>
    <VerticalStackLayout>
        <editors:SfComboBox x:Name="comboBox"
                            Placeholder="Select an item"
                            DropDownClosing="SfComboBox_DropDownClosing">
            <editors:SfComboBox.ItemsSource>
                <x:Array Type="{x:Type x:String}">
                    <x:String>Apple</x:String>
                    <x:String>Banana</x:String>
                    <x:String>Cherry</x:String>
                </x:Array>
            </editors:SfComboBox.ItemsSource>
        </editors:SfComboBox>
    </VerticalStackLayout>
</ScrollView>
```

