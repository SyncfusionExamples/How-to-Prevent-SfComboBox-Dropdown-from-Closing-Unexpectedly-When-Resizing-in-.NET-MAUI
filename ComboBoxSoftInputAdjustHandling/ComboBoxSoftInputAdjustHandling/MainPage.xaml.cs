
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace ComboBoxSoftInputAdjustHandling
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

        }

        private bool isResizing; // Flag to track resizing

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

}
