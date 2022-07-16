using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PixelArt.Models.DTO;

namespace PixelArt.UserControls
{
    public sealed partial class Pixel2ArtFrameUserControl : UserControl
    {
        public ArtDesign ArtDesign
        {
            get { return (ArtDesign)GetValue(ArtDesignProperty); }
            set { SetValue(ArtDesignProperty, value); }
        }

        public static readonly DependencyProperty ArtDesignProperty =
            DependencyProperty.Register("ArtDesign", typeof(ArtDesign), typeof(Pixel2ArtFrameUserControl), new PropertyMetadata(null));


        public Pixel2ArtFrameUserControl()
        {
            this.InitializeComponent();
        }
    }
}
