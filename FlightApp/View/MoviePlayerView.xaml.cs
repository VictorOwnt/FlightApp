using FlightApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    public sealed partial class MoviePlayerView : Page
    {

        private Movie _movie;

        public MoviePlayerView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _movie = e.Parameter as Movie;
            DataContext = _movie;
            Console.WriteLine(_movie);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            MoviePlayer.Source = null;
        }

        private void MoviePlayer_Loaded(object sender, RoutedEventArgs e)
        {
            MoviePlayer.Source = MediaSource.CreateFromUri(
                new Uri($"ms-appx:///Assets/Files/Movies/{_movie.Source}"));
        }
    }
}
