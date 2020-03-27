using Cliente_PANGEA.Controllers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


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
            ListView_events.ItemsSource = EventController.GetPersonalAndEvent(SingletonAccount.GetAccount().Id);
        }
    }
}
