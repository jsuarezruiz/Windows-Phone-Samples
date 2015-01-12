using Ejemplo_Xbox_Music.Model;
using Ejemplo_Xbox_Music.Services;
using Ejemplo_Xbox_Music.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Ejemplo_Xbox_Music.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private const string ClientId = "bda401f5-4049-4b56-8b1d-ee5c6af3a2fd";
        private const string ClientSecret = "vGE0xQV2RDEqdd2f0MSc68VHlv/PdnX6bO6U2udAl8Q=";

        private readonly IXboxMusic _xboxMusic;

        private string _searchParam;
        private List<XboxMusicItem> _items;

        public MainViewModel(IXboxMusic xboxMusic)
        {
            _xboxMusic = xboxMusic;
        }

        public string SearchParam
        {
            get { return _searchParam; }
            set
            {
                SetProperty(ref _searchParam, value);
            }
        }

        public List<XboxMusicItem> Items
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

            _xboxMusic.ClientId = ClientId;
            _xboxMusic.ClientSecret = ClientSecret;
            var result = await _xboxMusic.Find(SearchParam);

            Items = result.Albums.Items.Select(album => new XboxMusicItem
            {
                Title = album.Name,
                Type = XboxMusicItemType.Album
            }).ToList();
        }
    }
}
