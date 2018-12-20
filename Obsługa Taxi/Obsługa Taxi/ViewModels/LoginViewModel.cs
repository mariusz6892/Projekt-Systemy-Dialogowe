using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommand _AdresCommand;
        public RelayCommand AdresCommand
        {
            get
            {
                return _AdresCommand
                    ?? (_AdresCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("AdresView");
                    }));
            }
        }
       

        public LoginViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
