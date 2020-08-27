using FlightApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChangeSeatsView : Page
    {
        public ChangeSeatsViewModel ViewModel { get; set; }
        public ChangeSeatsView()
        {
            InitializeComponent();
            ViewModel = new ChangeSeatsViewModel();
        }

        private void Change_Seats_Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO Check if non digit chars
            ViewModel.ChangeSeatsAsync(int.Parse(PassengerSeat1.Text), int.Parse(PassengerSeat2.Text));
        }
    }
}
