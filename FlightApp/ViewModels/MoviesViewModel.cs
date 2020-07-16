using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FlightApp.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        private IList<Movie> _movies;

        public IList<Movie> Movies {
            get { return _movies; }
            set { _movies = value; RaisePropertyChanged(); }
        }

        public MoviesViewModel()
        {

        }

        private async void LoadMovies()
        {
            try
            {
                //Movies = await EntertainmentRepository.GetAllMoviesAsync();
            }
            catch (Exception e)
            {
                MessageDialog messageDialog = new MessageDialog($"Couldn't establish a connection to the database. \n{e.Message}");
                messageDialog.Commands.Add(new UICommand("Try again", new UICommandInvokedHandler(this.CommandInvokedHandler)));
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
                    LoadMovies();
                    break;
            }
        }
    }
}
