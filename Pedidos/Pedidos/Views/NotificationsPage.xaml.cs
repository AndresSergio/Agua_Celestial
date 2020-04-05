using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pedidos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationsPage : ContentPage
	{
		public NotificationsPage ()
		{
			InitializeComponent ();
		}

        private void Notificationbtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty (txtTitlebadge.Text) || string.IsNullOrEmpty(txtTextbadge.Text) || string.IsNullOrEmpty(txtTitlebadge.Text))
            {
                return;
            }

            Plugin.LocalNotifications.CrossLocalNotifications.Current.Show(txtTitlebadge.Text, txtTextbadge.Text,0,DateTime.Now.AddSeconds(double.Parse(txtTimebadge.Text)));
        }
    }
}