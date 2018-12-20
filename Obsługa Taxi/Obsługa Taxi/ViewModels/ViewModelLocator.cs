using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<AdresViewModel>();
            SimpleIoc.Default.Register<PodsumowanieViewModel>();
            SimpleIoc.Default.Register<ResignViewModel>();
            SimpleIoc.Default.Register<TaxiViewModel>();
            SimpleIoc.Default.Register<ThankYouViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            
            navigationService.Configure("LoginView", new Uri("../Views/LoginView.xaml", UriKind.Relative));
            navigationService.Configure("AdresView", new Uri("../Views/AdresView.xaml", UriKind.Relative));
            navigationService.Configure("PodsumowanieView", new Uri("../Views/PodsumowanieView.xaml", UriKind.Relative));
            navigationService.Configure("ResignView", new Uri("../Views/ResignView.xaml", UriKind.Relative));
            navigationService.Configure("TaxiView", new Uri("../Views/TaxiView.xaml", UriKind.Relative));
            navigationService.Configure("ThankYouView", new Uri("../Views/ThankYouView.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginViewModel LoginView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        public AdresViewModel AdresView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdresViewModel>();
            }
        }
        public PodsumowanieViewModel PodsumowanieView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PodsumowanieViewModel>();
            }
        }
        public ResignViewModel ResignView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ResignViewModel>();
            }
        }
        public TaxiViewModel TaxiView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TaxiViewModel>();
            }
        }

        public ThankYouViewModel ThankYouView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ThankYouViewModel>();
            }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
