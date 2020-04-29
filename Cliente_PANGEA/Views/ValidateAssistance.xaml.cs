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
using DataAccess;
using Cliente_PANGEA.Controllers;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para ValidateAssistance.xaml
    /// </summary>
    public partial class ValidateAssistance : Page
    {
        private int idEvent = SingletonEvent.GetEvent().Id;
        public ValidateAssistance(AsistentesEvento asistenteEvento)
        {
            InitializeComponent();
            LoadEventAssistant(asistenteEvento.IdAsistente);
            LoadAssistantActivities(asistenteEvento.IdAsistente);
        }
        private void LoadEventAssistant(int idAssistant)
        {
            listView_Asistente.ItemsSource = AsistentesEventoController.GetEventAssistant(idAssistant);
        }
        private void LoadAssistantActivities(int idAssistant)
        {
            if (AsistentesEventoController.GetAssistantActivitiesEvent(idAssistant)!= null)
            {
                listView_Activities.ItemsSource = AsistentesEventoController.GetAssistantActivitiesEvent(idAssistant);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos.");
            }
            
        }
        private bool ValidateSelectionActivity()
        {
            if (listView_Activities.SelectedItems.Count>0)
            {
                return true;
            }
            MessageBox.Show("Favor de seleccionar una Actividad");
            return false;
        }
        private IncripcionActividades GetIncriptionActivityInList()
        {
            IncripcionActividades incriptionActivity = (IncripcionActividades)listView_Activities.SelectedItem;
            return incriptionActivity;
        }
        private bool ValidateSelectionAssistant()
        {
            if (listView_Asistente.SelectedItems.Count>0)
            {
                return true;
            }
            MessageBox.Show("Favor de seleccionar al asistente");
            return false;
        }
       
        private void btn_ValidateAssistance_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelectionActivity() && ValidateSelectionAssistant())
            {
                if (GetIncriptionActivityInList()!=null)
                {
                    IncripcionActividades incriptionActivity = GetIncriptionActivityInList();
                    if (AsistentesEventoController.ValidateAssistanceInActivity(incriptionActivity.id) >0)
                    {
                        MessageBox.Show("Asistencia en actividad registrada");
                        AsistentesEvento eventAssistant = (AsistentesEvento)listView_Asistente.SelectedItem;
                        LoadAssistantActivities(eventAssistant.IdAsistente);
                    }
                    else
                    {
                        MessageBox.Show("Error de conexión con la base de datos");
                    }                
                }
            }
        }
        private void btn_RegisterActivityAssistant_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelectionAssistant())
            {
                AsistentesEvento eventAssistant = (AsistentesEvento)listView_Asistente.SelectedItem;
                Asistentes assistant = AsistenteController.GetEventAssistantsById(eventAssistant.IdAsistente);
                this.NavigationService.Navigate(new RegisterActivityAssistant(assistant));
            }
            
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowAssistants());
        }
    }
}
