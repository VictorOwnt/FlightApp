using FlightApp.Models;
using FlightApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactsOverview : Page
    {
        public ContactsOverviewViewModel ViewModel { get; set; }
        public ContactsOverview()
        {
            ViewModel = new ContactsOverviewViewModel();
            InitializeComponent();
        }

        private void Contact_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Passenger contact = ((Passenger)button.DataContext);
            Frame.Navigate(typeof(ChatView), contact);
        }
    }
}
