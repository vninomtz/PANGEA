
using Cliente_PANGEA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cliente_PANGEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DataAccess.Eventos evento)
        {
            InitializeComponent();
            centralFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            Button_account.Content = SingletonAccount.GetAccount().Correo;
            txt_UserName.Text = SingletonAccount.GetAccount().Nombre + " " + SingletonAccount.GetAccount().Apellido;
            Button_account.Visibility = Visibility.Visible;
            centralFrame.Navigate(new MainEvent(evento));
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemCommittee":
                   centralFrame.Navigate(new ShowCommittee());
                    break;
                case "ItemHome":
                    centralFrame.Navigate(new MainEvent());
                    break;
                case "ItemActivities":
                    centralFrame.Navigate(new NewActivity());

                    break;
                case "ItemSales":

                    break;
                default:
                    break;
            }
        }


    }
}
