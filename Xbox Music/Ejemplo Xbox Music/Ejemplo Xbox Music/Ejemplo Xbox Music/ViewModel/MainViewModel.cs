using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Ejemplo_Xbox_Music.Helpers;
using Ejemplo_Xbox_Music.Model;
using Ejemplo_Xbox_Music.ViewModel.Base;
using Xbox.Music;

namespace Ejemplo_Xbox_Music.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private const string ClientId = "Inserta tu ClientId";
        private const string ClientSecret = "Inserta tu ClientSecret";

        private readonly MusicClient _client;
        private string _searchParam;
        private List<Group<XboxMusicItem>> _items;

        public MainViewModel()
        {
            _client = new MusicClient(ClientId, ClientSecret);
        }

        public string SearchParam
        {
            get { return _searchParam; }
            set
            {
                SetProperty(ref _searchParam, value);
            }
        }

        public List<Group<XboxMusicItem>> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        private ICommand _searchCommand;

        public ICommand SearchCommand
        {
            get { return _searchCommand = _searchCommand ?? new DelegateCommand(SearchCommandDelegate); }
        }

        public async void SearchCommandDelegate()
        {
            if (string.IsNullOrEmpty(SearchParam)) return;

            var result = await _client.Find(SearchParam);

            var items = result.Albums.Items.Select(album => new XboxMusicItem
            {
                Title = album.Name,
                Image = album.GetImage(100, 100),
                Link = album.GetDeepLink(),
                Type = XboxMusicItemType.Album
            }).ToList();

            items.AddRange(result.Artists.Items.Select(artist => new XboxMusicItem
            {
                Title = artist.Name, 
                Image = artist.GetImage(100, 100),
                Link = artist.GetDeepLink(),
                Type = XboxMusicItemType.Artist
            }));

            items.AddRange(result.Tracks.Items.Select(track => new XboxMusicItem
            {
                Title = track.Name, 
                Image = track.GetImage(100, 100),
                Link = track.GetDeepLink(),
                Type = XboxMusicItemType.Track
            }));

            IEnumerable<Group<XboxMusicItem>> groupList = from item in items
                                                      group item by item.Type into g
                                                      orderby g.Key
                                                      select new Group<XboxMusicItem>(g.Key.ToString(), g);

            Items = groupList.ToList();
        }
    }
}
