using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using PixelArt.ContentDialogs;
using PixelArt.Models.DTO;
using PixelArt.Models.Enums;
using PixelArt.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PixelArt.Pages
{
    public sealed partial class ArtPage : Page
    {
        public ArtPageViewModel artViewModel { get; set; }
        public ArtPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            artViewModel = new ArtPageViewModel((int)e.Parameter);

            //This is Uno Platform bug fail to bind
            ArtGridView.ItemsSource = artViewModel.PageInfo.ArtDesigns;
        }

        private async void Add_Art(object sender, RoutedEventArgs e)
        {
            var createArtContentDialog                 = new CreateArtDesignContentDialog();
            createArtContentDialog.XamlRoot            = this.XamlRoot;
            createArtContentDialog.PrimaryButtonClick += CreateArtContentDialog_PrimaryButtonClick;
            await createArtContentDialog.ShowAsync();
        }

        private void CreateArtContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var photosList = (sender as CreateArtDesignContentDialog).PhotosList;
            var imageUrlsList = new List<string>();
            var blob = artViewModel.BlobContainerClient.GetBlobContainerClient("pixelart");
            photosList.ToList().ForEach(async photo =>
            {
                if (photo != null & photo.IOStream != null)
                {
                    BlobClient blobClient = blob.GetBlobClient(photo.FileName);
                    imageUrlsList.Add(blobClient.Uri.AbsoluteUri);
                    photo.IOStream.Position = 0;
                    await blobClient.UploadAsync(photo.IOStream);
                }
            });
        }
    }

    public class ArtTemplateSelector : DataTemplateSelector
    {
        private DataTemplate phoneTemplate;

        public DataTemplate PhoneTemplate
        {
            get { return phoneTemplate; }
            set { phoneTemplate = value; }
        }

        private DataTemplate desktopAndWebTemplate;

        public DataTemplate DesktopAndWebTemplate
        {
            get { return desktopAndWebTemplate; }
            set { desktopAndWebTemplate = value; }
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var art = (ArtDesign)item;

            if (art.Type == ArtType.DesktopAndWeb)
            {
                return desktopAndWebTemplate;
            }
            else
            {
                return phoneTemplate;
            }
        }
    }
}
