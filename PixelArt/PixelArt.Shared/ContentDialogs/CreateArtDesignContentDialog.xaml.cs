using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage;

namespace PixelArt.ContentDialogs
{
    public sealed partial class CreateArtDesignContentDialog : ContentDialog, INotifyPropertyChanged
    {
        public ObservableCollection<string> ColorsPallete { get; set; }   = new ObservableCollection<string>();
        public ObservableCollection<FlipViewDTO> PhotosList { get; set; } = new ObservableCollection<FlipViewDTO>() { new FlipViewDTO() { IsButton = true } };


        public CreateArtDesignContentDialog()
		{
			this.InitializeComponent();
            //PhotosViews.ItemsSource = PhotosList;
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
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

#else
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;

#endif
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".png");
            var files = await filePicker.PickMultipleFilesAsync();
            //if (photo != null)
            //{
            //    var filestream = await photo.(FileAccessMode.Read);
            //    BitmapImage bitmapImage = new BitmapImage();
            //    bitmapImage.SetSource(filestream);
            //    DesktopPreview.Source = bitmapImage;
            //}
            foreach (var file in files)
            {
                var stream = (await file.OpenStreamForReadAsync()).AsRandomAccessStream();//await file.GetScaledImageAsThumbnailAsync(ThumbnailMode.PicturesView, 300);
                var imageSource = new BitmapImage();
                await imageSource.SetSourceAsync(stream);
                PhotosList.Add(new FlipViewDTO()
                {
                    FileName = file.Name,
                    Image = imageSource,
                    IsButton = false,
                    IOStream = stream.AsStream()
                });
            }
            PhotosViews.SelectedIndex = PhotosList.Count > 0 ? 1 : 0 ;
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

    public class FlipViewDTO
    {
        public string FileName { get; set; }
        public BitmapImage Image { get; set; }
        public bool IsButton { get; set; } = true;
        public Stream IOStream { get; set; }
    }

    public class FlipViewTemplateSelector : DataTemplateSelector
    {
        private DataTemplate addButtonTemplate;

        public DataTemplate AddButtonTemplate
        {
            get { return addButtonTemplate; }
            set { addButtonTemplate = value; }
        }

        private DataTemplate imageTemplate;

        public DataTemplate ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value; }
        }

        protected override DataTemplate? SelectTemplateCore(object item)
        {
            var flipViewItem = (FlipViewDTO)item;
            return flipViewItem.IsButton == true ? addButtonTemplate : imageTemplate;
        }
    }
}
