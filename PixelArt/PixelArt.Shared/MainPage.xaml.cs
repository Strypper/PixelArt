using Microsoft.UI.Xaml.Controls;
using PixelArt.Models.Enums;
using PixelArt.Pages;
using System.Collections.Generic;

namespace PixelArt
{
    public sealed partial class MainPage : Page
    {
        public List<NavigationItem> NavigationItems { get; set; } = new List<NavigationItem>();
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationItems = PixelArtNavigationItems.LoadNavigationItems();
        }

        private void ArtCategories_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationItem item = args.SelectedItem as NavigationItem;
            MainFrame.Navigate(typeof(ArtPage), (int)item.ArtType);
        }
    }

    public class NavigationItem
    {
        public string ImageIconSource { get; set; }
        public string Content { get; set; }
        public ArtType ArtType { get; set; }

        public NavigationItem(string imageIconSource, 
                              string content,
                              ArtType artType)
        {
            ImageIconSource = imageIconSource;
            Content = content;
            ArtType = artType;
        }
    }

    public class PixelArtNavigationItems
    {
        public static List<NavigationItem> LoadNavigationItems()
        {
            var items = new List<NavigationItem>();
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/DesktopSVG.svg", "Desktop - Web", ArtType.DesktopAndWeb));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/PhoneSVG.svg", "Mobile", ArtType.Mobile));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/DualScreenSVG.svg", "Dual Screen Device", ArtType.DualScreenDevice));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/WallpaperSVG.svg", "Wallpaper", ArtType.Wallpaper));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/TypoGraphySVG.svg", "Typography", ArtType.Typography));
            return items;
        }
    }
}
