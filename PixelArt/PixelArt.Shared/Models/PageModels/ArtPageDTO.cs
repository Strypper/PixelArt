using PixelArt.Models.DTO;
using System.Collections.ObjectModel;

namespace PixelArt.Models.PageModels
{
    public class ArtPageDTO
    {
        public string PageTile { get; set; }
        public ObservableCollection<ArtDesign> ArtDesigns { get; set; } = new ObservableCollection<ArtDesign>();
    }
}
