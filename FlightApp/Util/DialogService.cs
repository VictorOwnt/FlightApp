using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FlightApp.Util
{
    public static class DialogService
    {
        public static async Task ShowCustomMessageAsync(string message, string title)
        {
            MessageDialog messageDialog = new MessageDialog(message, title);
            await messageDialog.ShowAsync();
        }

        public static async Task ShowDefaultErrorMessageAsync()
        {
            MessageDialog messageDialog = new MessageDialog("Oups, something went wrong. Pease check your internet connection and try again", "Error");
            await messageDialog.ShowAsync();
        }
    }
}
