using Microsoft.UI.Xaml.Controls;
using PixelArt.Models.Enums;
using PixelArt.Pages;
using System.Collections.Generic;
using System.Linq;

namespace PixelArt
{
    public sealed partial class MainPage : Page
    {
        public List<NavigationItem> NavigationItems { get; set; } = new List<NavigationItem>();
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationItems = PixelArtNavigationItems.LoadNavigationItems();
            ArtCategories.SelectedItem = NavigationItems.FirstOrDefault(item => item.IsSelected == true);
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
        public bool IsSelected { get; set; }

        public NavigationItem(string imageIconSource, 
                              string content,
                              ArtType artType,
                              bool isSelected)
        {
            ImageIconSource = imageIconSource;
            Content = content;
            ArtType = artType;
            IsSelected = isSelected; 
        }
    }

    public class PixelArtNavigationItems
    {
        public static List<NavigationItem> LoadNavigationItems()
        {
            var items = new List<NavigationItem>();
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/DesktopSVG.svg", "Desktop - Web", ArtType.DesktopAndWeb, true));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/PhoneSVG.svg", "Mobile", ArtType.Mobile, false));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/DualScreenSVG.svg", "Dual Screen Device", ArtType.DualScreenDevice, false));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/WallpaperSVG.svg", "Wallpaper", ArtType.Wallpaper, false));
            items.Add(new NavigationItem("ms-appx:///Assets/Icons/TypoGraphySVG.svg", "Typography", ArtType.Typography, false));
            return items;
        }
    }
}
