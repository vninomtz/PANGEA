using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para ShowAssistants.xaml
    /// </summary>
    public partial class ShowAssistants : Page
    {
        int idEvent = SingletonEvent.GetEvent().Id;
        public ShowAssistants()
        {
            InitializeComponent();
            LoadAssistantsEvent();
        }

        private void LoadAssistantsEvent()
        {
            if (AsistentesEventoController.GetAllAssistantsEvent(idEvent) != null)
            {
                listViewAssistantsEvent.ItemsSource = AsistentesEventoController.GetAllAssistantsEvent(idEvent);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            string name = txt_lastName.Text;
            name = name.Trim();
            if (AsistentesEventoController.GetEventAssistantsByName(name,idEvent) != null)
            {
                listViewAssistantsEvent.ItemsSource =  AsistentesEventoController.GetEventAssistantsByName(name,idEvent);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }

        private void btn_RegisterAssistant_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AssistantRegister());
        }

        private void listViewAssistantsEvent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewAssistantsEvent.SelectedItems.Count>0)
            {
                AsistentesEvento asistentesEvento = (AsistentesEvento)listViewAssistantsEvent.SelectedItem;
                //this.NavigationService.Navigate(new RegisterActivityAssistant());
            }
        }
    }
}
