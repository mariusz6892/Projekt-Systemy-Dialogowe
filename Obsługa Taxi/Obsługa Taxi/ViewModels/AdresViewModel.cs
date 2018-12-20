using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi.ViewModels
{
    public class AdresViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommand _TaxiCommand;
        public RelayCommand TaxiCommand
        {
            get
            {
                return _TaxiCommand
                    ?? (_TaxiCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("TaxiView");
                    }));
            }
        }

        private RelayCommand _GoBackCommand;
        public RelayCommand GoBackCommand
        {
            get
            {
                return _GoBackCommand
                    ?? (_GoBackCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.GoBack();
                    }));
            }
        }

        public AdresViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
