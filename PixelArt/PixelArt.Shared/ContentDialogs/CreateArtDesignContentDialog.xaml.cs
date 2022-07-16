using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage;

namespace PixelArt.ContentDialogs
{
    public sealed partial class CreateArtDesignContentDialog : ContentDialog, INotifyPropertyChanged
    {
        public ObservableCollection<string> ColorsPallete { get; set; } = new ObservableCollection<string>();

        private BitmapImage previewImage = new BitmapImage();

        public BitmapImage PreviewImage
        {
            get { return previewImage; }
            set { previewImage = value; OnPropertyChanged(); }
        }


        public CreateArtDesignContentDialog()
		{
			this.InitializeComponent();
        }

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private async void OpenFile_Clicked(object sender, RoutedEventArgs e)
		{
#if WINDOWS
            var window = new Microsoft.UI.Xaml.Window();
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.FileTypeFilter.Add("*");
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

#else
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".png");

#endif
            var photo = await filePicker.PickSingleFileAsync();
            if (photo != null)
            {
                var filestream = await photo.OpenAsync(FileAccessMode.Read);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(filestream);
                DesktopPreview.Source = bitmapImage;
            }
        }

        private void AddColor_Clicked(object sender, RoutedEventArgs e)
        {
            var color = ThemeColorPicker.Color;
            var colorHex = $"{color.R:X2}{color.G:X2}{color.B:X2}";
            if (!ColorsPallete.Any(existingColor => existingColor == colorHex))
            {
                ColorPalleteStatus.Text = "";
                ColorsPallete.Add(colorHex);
            }
            else
            {
                ColorPalleteStatus.Text = "Duplicated color try another one";
                Fade_Animation.Begin();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
