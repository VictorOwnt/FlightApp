using FlightApp.Models;
using FlightApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenuPassenger : Page
    {

        public MainMenuPassengerViewModel ViewModel { get; set; }
        public MainMenuPassenger()
        {
            InitializeComponent();
            ViewModel = new MainMenuPassengerViewModel();
            navigationViewPassengerMenu.SelectedItem = navigationViewPassengerMenu.MenuItems[0]; // Set to flight info
            if (_instance is null) _instance = this;
        }

        private static MainMenuPassenger _instance;
        public static MainMenuPassenger Instance { get { return _instance; } }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(EntertainmentView));
                navigationViewPassenger.Header = "Settings";
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;




                switch (item.Tag.ToString())
                {
                    case "ProductsOverview":
                        PageFrame.Navigate(typeof(ProductsOverview));
                        break;
                    case "ContactsOverview":
                        PageFrame.Navigate(typeof(ContactsOverview));
                        break;
                    case "PassengerOrdersOverview":
                        PageFrame.Navigate(typeof(PassengerOrdersOverview));
                        break;
                }
            }
        }
                    case "Entertainment":
                        ContentFrame.Navigate(typeof(EntertainmentView));
                        // navigationViewPassenger.Header = "Music";
                        break;
                }
            }
        }
        public  void NavigateToMoviePlayer(Movie movie)
        {
            ContentFrame.Navigate(typeof(MoviePlayerView), movie, new EntranceNavigationTransitionInfo());
            navigationViewPassenger.Header = "Movie Player";
        }
    }
}