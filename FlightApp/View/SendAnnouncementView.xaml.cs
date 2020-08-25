using FlightApp.Models;
using FlightApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SendAnnouncementView : Page
    {
        public SendAnnouncementViewModel ViewModel { get; set; }
        public SendAnnouncementView()
        {
            ViewModel = new SendAnnouncementViewModel();
            this.InitializeComponent();
        }

        private void Send_Announcement_Button_Click(object sender, RoutedEventArgs e)
        {
            Passenger selectedPassenger = Receiver_Selection_Combobox.SelectedItem as Passenger;
            ViewModel.SendAnnouncementAsync(Announcement_Title.Text, Announcement_Content.Text, selectedPassenger, (bool)Send_All_Checkbox.IsChecked);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Connect();
        }


    }
}
