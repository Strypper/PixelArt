using Azure.Storage.Blobs;
using PixelArt.Constants;
using PixelArt.Models.DTO;
using PixelArt.Models.PageModels;

namespace PixelArt.ViewModels
{
    public class ArtPageViewModel
    {
        public ArtPageDTO          PageInfo          { get; set; } = new ArtPageDTO();
        public BlobContainerClient BlobContainerClient { get; set; } = new BlobContainerClient(AppConstants.PixelArtContainerConnectionString, 
                                                                                             AppConstants.PixelArtContainerName);
        public ArtPageViewModel(int ArtTypeKey)
        {
            PageInfo.ArtDesigns = DemoArtAssets.GetDemoArtAssets(ArtTypeKey);
        }
    }
}
