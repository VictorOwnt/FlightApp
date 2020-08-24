using FlightApp.Models;
using FlightApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace FlightApp.View
{
    public sealed partial class SendAnnouncementView : Page
    {
        public AnnouncementViewModel ViewModel;

        public SendAnnouncementView()
        {
            this.InitializeComponent();
            ViewModel = new AnnouncementViewModel();
        }

        private async void Send_Announcement_Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}
