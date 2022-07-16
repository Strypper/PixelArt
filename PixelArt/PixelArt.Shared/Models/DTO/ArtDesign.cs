using PixelArt.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PixelArt.Models.DTO
{
    public class ArtDesign
    {
        public string Title { get; set; }
        public string MediaAssetsUrl { get; set; }
        public int Love { get; set; }
        public int Seen { get; set; }
        public ArtType Type { get; set; } = ArtType.DesktopAndWeb;
    }


    public class DemoArtAssets
    {
        public static ObservableCollection<ArtDesign> GetDemoArtAssets(int artKey)
        {
            var random = new Random();
            var artList = new List<ArtDesign>();
            artList.Add(new ArtDesign()
            {
                Title = "Xbox Redesign",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/Design1.jpg",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000)
            }) ;
            artList.Add(new ArtDesign()
            {
                Title = "Xbox Redesign Dark Mode",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/Design2.jpg",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000)
            });
            artList.Add(new ArtDesign()
            {
                Title = "Microsoft Store",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/Design3.jpg",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000)
            });
            artList.Add(new ArtDesign()
            {
                Title = "Microsoft Store Home Page",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/Design4.jpg",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000)
            });
            artList.Add(new ArtDesign()
            {
                Title = "Microsoft Store Most Popular Games",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/Design5.jpg",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000)
            });
            artList.Add(new ArtDesign()
            {
                Title = "Core Games",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/Design6.jpg",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000)
            });
            artList.Add(new ArtDesign()
            {
                Title = "Stuhub Subject Request",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/PhoneDesign1.png",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000),
                Type = ArtType.Mobile
            });
            artList.Add(new ArtDesign()
            {
                Title = "Stuhub Subject Detail",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/PhoneDesign2.png",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000),
                Type = ArtType.Mobile
            });
            artList.Add(new ArtDesign()
            {
                Title = "Stuhub",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/PhoneDesign3.png",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000),
                Type = ArtType.Mobile
            });
            artList.Add(new ArtDesign()
            {
                Title = "Stuhub",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/PhoneDesign4.png",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000),
                Type = ArtType.Mobile
            });
            artList.Add(new ArtDesign()
            {
                Title = "Petaverse Breeds",
                MediaAssetsUrl = "ms-appx:///Assets/DemoArts/PhoneDesign5.png",
                Love = random.Next(0, 10000),
                Seen = random.Next(0, 10000),
                Type = ArtType.Mobile
            });

            var artObservableCollection = new ObservableCollection<ArtDesign>();

            artList.Where(art => (int)art.Type == artKey)
                   .ToList()
                   .ForEach(art => artObservableCollection.Add(art));
            return artObservableCollection;
        }
    }
}
