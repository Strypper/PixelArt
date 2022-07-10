using PixelArt.Models.DTO;
using PixelArt.Models.PageModels;

namespace PixelArt.ViewModels
{
    public class ArtPageViewModel
    {
        public ArtPageDTO PageInfo { get; set; } = new ArtPageDTO();
        public ArtPageViewModel(int ArtTypeKey)
        {
            PageInfo.ArtDesigns = DemoArtAssets.GetDemoArtAssets(ArtTypeKey);
        }
    }
}
