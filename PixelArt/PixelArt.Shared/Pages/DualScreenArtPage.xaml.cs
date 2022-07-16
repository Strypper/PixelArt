using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PixelArt.ContentDialogs;
using PixelArt.ViewModels;
using System;

namespace PixelArt.Pages
{
    public sealed partial class DualScreenArtPage : Page
    {
        public ArtPageViewModel artViewModel { get; set; }
        public DualScreenArtPage()
        {
            this.InitializeComponent();
            artViewModel = new ArtPageViewModel(0);
        }

        private async void Add_Art(object sender, RoutedEventArgs e)
        {
            var createArtContentDialog = new CreateArtDesignContentDialog();
            createArtContentDialog.XamlRoot = this.XamlRoot;
            createArtContentDialog.PrimaryButtonClick += CreateArtContentDialog_PrimaryButtonClick;
            await createArtContentDialog.ShowAsync();
        }

        private void CreateArtContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //var blob = artViewModel.BlobContainerClient.GetBlobClient("");
        }
    }
}
