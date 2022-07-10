using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using PixelArt.Models.DTO;
using PixelArt.Models.Enums;
using PixelArt.Models.PageModels;
using PixelArt.ViewModels;
using System;
using System.Linq;

namespace PixelArt.Pages
{
    public sealed partial class ArtPage : Page
    {
        public ArtPageViewModel artViewModel { get; set; }
        public ArtPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            artViewModel = new ArtPageViewModel((int)e.Parameter);
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
