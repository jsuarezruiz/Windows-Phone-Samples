using System.Collections.ObjectModel;
using EjemploResolucion.Model;

namespace EjemploResolucion.ViewModel
{
    public class MainViewModel
    {
        private ObservableCollection<Item> _items;

        public MainViewModel()
        {
            LoadData();
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
        }

        private void LoadData()
        {
            _items = new ObservableCollection<Item>
            {
                new Item
                {
                    Title = "Forza Motorsport 5",
                    Image = "http://compass.xboxlive.com/assets/cd/33/cd33e4ec-5406-40d4-8129-b92504e877d3.jpg?n=Forza%205.jpg"
                },
                new Item
                {
                    Title = "Ryse: Son of Rome",
                    Image = "http://compass.xboxlive.com/assets/4a/8c/4a8cc02a-ed1a-432f-9fbd-42de90a4525e.jpg?n=Ryse.jpg"
                },
                new Item
                {
                    Title = "Kinect Sports Rivals",
                    Image = "http://compass.xboxlive.com/assets/95/1e/951e1851-a32b-4738-903a-ed58839cb0bc.jpg?n=KinectSportsRivals.jpg"
                },
                new Item
                {
                    Title = "Dead Rising 3",
                    Image = "http://compass.xboxlive.com/assets/bd/83/bd835a75-d7be-4134-b7c7-b9730f8b3dde.jpg?n=DeadRising3_hubhero.jpg"
                },
                new Item
                {
                    Title = "Halo para Xbox One",
                    Image = "http://compass.xboxlive.com/assets/17/69/1769a7af-4a9a-4b23-9ef7-ddb9dbdc10a3.jpg?n=HaloXboxOne-200x190.jpg"
                },
                new Item
                {
                    Title = "Sunset Overdrive",
                    Image = "http://compass.xboxlive.com/assets/f9/60/f9606a94-2318-4b8a-87b1-a387cfe96661.jpg?n=SunsetOverdrive.jpg"
                },
                new Item
                {
                    Title = "Quantum Break",
                    Image = "http://compass.xboxlive.com/assets/97/16/9716a7e4-62ed-403b-a2de-19aa9e34445a.jpg?n=Quantum%20Break.jpg"
                },
                new Item
                {
                    Title = "Killer Instinct",
                    Image = "http://compass.xboxlive.com/assets/07/1c/071c4e77-273e-45e2-84fd-2a0006eb582a.png?n=KillerInstinct200x190.png"
                },
                new Item
                {
                    Title = "Project: Spark",
                    Image = "http://compass.xboxlive.com/assets/ab/bf/abbfc373-38e0-4fe6-88a1-3d325ff571d0.png?n=ProjectSpark_banner_tree_200x190.png"
                },
                new Item
                {
                    Title = "Zoo Tycoon",
                    Image = "http://compass.xboxlive.com/assets/fb/df/fbdfa0e9-fc9b-4c38-a512-f6fb421e4924.jpg?n=Zoo_Tycoon_200x190.jpg"
                },
                new Item
                {
                    Title = "Titanfall",
                    Image = "http://compass.xbox.com/assets/8f/db/8fdb6276-3d2e-49e5-9ba6-76082d63e715.jpg?n=hero-titanfall-metro-200x190.jpg"
                },
                new Item
                {
                    Title = "Call of Duty: Ghosts",
                    Image = "http://compass.xboxlive.com/assets/c7/b9/c7b96d97-d1f7-4ffe-9d52-a29298383e3f.jpg?n=COD_Ghosts.jpg"
                }
            };
        }
    }
}
