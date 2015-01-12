using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Cimbalino.Phone.Toolkit.Helpers;
using Cimbalino.Phone.Toolkit.Services;
using Ejemplo_MarketplaceInformationService.ViewModel.Base;

namespace Ejemplo_MarketplaceInformationService.ViewModel
{
    public class MainViewModel
    {
        private const string ProductId = "2d3063c2-4b29-4e69-9c03-50b67b0e6aec";

        private readonly IMarketplaceInformationService _marketplaceInformationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IMarketplaceDetailService _marketplaceDetailService;

        public MainViewModel(IMarketplaceInformationService marketplaceInformationService, IMessageBoxService messageBoxService,
            IMarketplaceDetailService marketplaceDetailService)
        {
            _marketplaceInformationService = marketplaceInformationService;
            _messageBoxService = messageBoxService;
            _marketplaceDetailService = marketplaceDetailService;
        }

        private ICommand _chechForUpdatesCommand;

        public ICommand ChechForUpdatesCommand
        {
            get { return _chechForUpdatesCommand = _chechForUpdatesCommand ?? new DelegateCommand(ChechForUpdatesCommandDelegate); }
        }

        public void ChechForUpdatesCommandDelegate()
        {
            _marketplaceInformationService.GetAppInformation(ProductId, delegate(MarketplaceAppNode node, Exception exception)
            {
                var data = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
                var currentVersion = data.Version;
                Version updatedVersion;
                Version.TryParse(node.Entry.Version, out updatedVersion);

                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    //Verificamos si existe una versión mas actual
                    if (updatedVersion > currentVersion
                        && _messageBoxService.Show(Resources.AppResources.DownloadUpdate, Resources.AppResources.UpdateAvalaible, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        //Abrir la Store para actualizar
                        _marketplaceDetailService.Show(ProductId);
                    }
                });
            });
        }
    }
}
