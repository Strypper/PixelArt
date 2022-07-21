using Azure.Storage.Blobs;
using PixelArt.Constants;
using PixelArt.Models.DTO;
using PixelArt.Models.PageModels;

namespace PixelArt.ViewModels
{
    public class ArtPageViewModel
    {
        public ArtPageDTO          PageInfo            { get; set; } = new ArtPageDTO();
        public BlobServiceClient   BlobContainerClient { get; set; } = new BlobServiceClient(AppConstants.PixelArtContainerConnectionString);
        public ArtPageViewModel(int ArtTypeKey)
        {
            PageInfo.ArtDesigns = DemoArtAssets.GetDemoArtAssets(ArtTypeKey);
        }
    }
}
