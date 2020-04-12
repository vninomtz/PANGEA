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
using Cliente_PANGEA.Controllers;
using DataAccess;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para ShowActivity.xaml
    /// </summary>
    public partial class ShowActivity : Page
    {
        private int idEvento = SingletonEvent.GetEvent().Id;
        public ShowActivity()
        {
            InitializeComponent();
            ShowActivities();
        }

        private void ShowActivities()
        {
           listViewActivities.ItemsSource =  ActivityController.GetEventActivities(idEvento);
        }
        private void btn_UpdateActivity_Click(object sender, RoutedEventArgs e)
        {
            if (listViewActivities.SelectedItems.Count >0)
            {
                Actividades activity = (Actividades)listViewActivities.SelectedItem;
                this.NavigationService.Navigate(new UpdateActivity(activity));
            }
        }

        private void btn_RegisterActivity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewActivity());
        }
    }
}
