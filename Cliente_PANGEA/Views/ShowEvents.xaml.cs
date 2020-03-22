using Cliente_PANGEA.Controllers;
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
    /// Interaction logic for ShowEvents.xaml
    /// </summary>
    public partial class ShowEvents : Page
    {
        public ShowEvents()
        {
            InitializeComponent();
            LoadEventsTable();
           

          
        }

        private void ListView_events_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           DataAccess.Personal eventSelected = (DataAccess.Personal)ListView_events.SelectedItem;

           MainWindow ventana =  new MainWindow(eventSelected.Eventos);
           ventana.Show();
           Window.GetWindow(this).Close();

        }

        private void LoadEventsTable()
        {
            /*List<DataAccess.Eventos> eventList = EventController.GetEventsByUser(1);
            foreach (var item in eventList)
            {
                item.FechaInicio = item.FechaInicio.Date;
            }
            ListView_events.ItemsSource = eventList;*/

            
            ListView_events.ItemsSource = EventController.GetPersonalAndEvent(1);


        }
    }
}
