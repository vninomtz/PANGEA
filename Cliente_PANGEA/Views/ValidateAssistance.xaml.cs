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
        
        List<IncripcionActividades> idIncription = new List<IncripcionActividades>();
        AsistentesEvento assistantEvent;
        public ValidateAssistance(AsistentesEvento asistenteEvento)
        {
            assistantEvent = asistenteEvento;
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
            idIncription = GetIncriptionAsistant(idAssistant);
            if (ValidateGetAsistants())
                listView_Activities.ItemsSource = AsistentesEventoController.GetAssistantActivitiesEvent(idIncription);

        }
        private bool ValidateGetAsistants()
        {
            if (AsistentesEventoController.GetAssistantActivitiesEvent(idIncription) != null)
            {
                return true;
            }
            MessageBox.Show("Error de conexión con la base de datos.");
            return false;
        }
        private List<IncripcionActividades> GetIncriptionAsistant(int idAsistant)
        {
            if (AsistentesEventoController.GetIdEventIncriptionOfAssistant(idAsistant)!=null)
            {
                idIncription = AsistentesEventoController.GetIdEventIncriptionOfAssistant(idAsistant);
                return idIncription;
            }
            return null;
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
        private IncripcionActividades GetIncriptionActivityOfList()
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
        private bool ValidateAssistanceInActivity(IncripcionActividades incriptionActivity)
        {
            if (AsistentesEventoController.ValidateAssistanceInActivity(incriptionActivity.id) > 0)
            {
                return true;
            }else if (AsistentesEventoController.ValidateAssistanceInActivity(incriptionActivity.id) == 0)
            {
                MessageBox.Show("La asistencia a la actividad seleccionada ya fue registrada");
                return false;
            }
            MessageBox.Show("Error de conexión con la base de datos");
            return false;
        }
       
        private void btn_ValidateAssistance_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelectionActivity() && ValidateSelectionAssistant())
            {
                if (GetIncriptionActivityOfList()!=null)
                {
                    IncripcionActividades incriptionActivity = GetIncriptionActivityOfList();
                    if (ValidateAssistanceInActivity(incriptionActivity))
                    {
                        MessageBox.Show("Asistencia en actividad registrada");
                        AsistentesEvento eventAssistant = (AsistentesEvento)listView_Asistente.SelectedItem;
                        LoadAssistantActivities(eventAssistant.IdAsistente);
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

        private void btn_GenerateConstancy_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GenerateConstancy(assistantEvent));
        }
    }
}
