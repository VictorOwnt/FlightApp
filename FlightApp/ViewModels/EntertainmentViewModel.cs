using FlightApp.DataService;
using FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FlightApp.ViewModels
{
    public class EntertainmentViewModel : ViewModelBase
    {
        #region Properties
        private IList<Movie> _movies;
        private IList<Music> _music;
        public IList<Movie> Movies {
            get => _movies;
            set { _movies = value; RaisePropertyChanged(); }
        }
        public IList<Music> Music {
            get => _music;
            set { _music = value; RaisePropertyChanged(); }
        }
        #endregion

        public EntertainmentViewModel()
        {
            LoadEntertainment();
        }

        private async void LoadEntertainment()
        {
            try
            {
                Movies = await EntertainmentService.GetAllMoviesAsync();
                Music = await EntertainmentService.GetAllMusicAsync();
            }
            catch (Exception e)
            {
                MessageDialog messageDialog = new MessageDialog($"Couldn't establish a connection to the database. \n{e.Message}");
                messageDialog.Commands.Add(new UICommand("Try again", new UICommandInvokedHandler(CommandInvokedHandler)));
                messageDialog.Commands.Add(new UICommand("Close"));
                messageDialog.DefaultCommandIndex = 0;
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
            }
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            switch (command.Label)
            {
                case "Try again":
                    LoadEntertainment();
                    break;
            }
        }
    }
}
