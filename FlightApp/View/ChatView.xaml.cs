using FlightApp.Models;
using FlightApp.ViewModels;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace FlightApp.View
{

    public sealed partial class ChatView : Page
    {
        public ChatViewModel ViewModel { get; set; }
        private Passenger Contact { get; set; }
        private Passenger Passenger { get; set; }
        public ChatView()
        {
            ViewModel = new ChatViewModel();
            InitializeComponent();
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.SendMessage(Passenger.Email, Contact.Email, text.Text);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Contact = e.Parameter as Passenger;
            LocalObjectStorageHelper localObjectStorage = new LocalObjectStorageHelper();
            if (localObjectStorage.KeyExists("passenger"))
            {
                Passenger = localObjectStorage.Read<Passenger>("passenger");

            }
            ViewModel.Connect(Passenger.Email, Contact.Email);
            ViewModel.SetMessages(Contact.Email);
        }
    }
}
