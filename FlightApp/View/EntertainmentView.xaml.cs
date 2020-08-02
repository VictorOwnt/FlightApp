using FlightApp.Models;
using FlightApp.ViewModels;
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
    public sealed partial class EntertainmentView : Page
    {
        public EntertainmentViewModel viewModel { get; set; }

        public EntertainmentView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            viewModel = new EntertainmentViewModel();
            DataContext = viewModel;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            MusicPlayer.Source = null;
        }

        private void Music_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Music music = (sender as ListView).SelectedItem as Music;
            MusicPlayer.Source = MediaSource.CreateFromUri(
                new Uri($"ms-appx:///Assets/Files/{music.Source}"));
        }

        private void Movie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MainPage.Instance.NavigateToMoviePlayer((sender as ListView).SelectedItem as Movie);
        }
    }
}