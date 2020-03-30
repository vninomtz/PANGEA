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
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewTask : Page
    {
        int IDEVENT = SingletonEvent.GetEvent().Id;
        List<Actividades> listActivities;
        public NewTask()
        {
            InitializeComponent();
            HideLabels();
            LoadActivities();
        }

        private void HideLabels()
        {
            stp_dates.Visibility = Visibility.Hidden;
            cb_finished.Visibility = Visibility.Hidden;
        }
        private void LoadActivities()
        {
            listActivities = ActivityController.GetAllActivities(IDEVENT);
            cb_activities.ItemsSource = listActivities;
        }
        private bool EmptyFields()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                result = true;
            }
            if (string.IsNullOrEmpty(txt_description.Text))
            {
                result = true;
            }
            if (string.IsNullOrEmpty(txt_inCharge.Text))
            {
                result = true;
            }
            if(cb_activities.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccionar la actividad a la que pertenece la tarea");
                result = true;
            }

            return result;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                Actividades act = (Actividades)cb_activities.SelectedItem;
                int result = TaskController.SaveTask(txt_name.Text, txt_description.Text, txt_inCharge.Text, act.Id);
                if(result > 0)
                {
                    MessageBox.Show("Se guardo con éxito la tarea");
                    this.NavigationService.Navigate(new ShowTasks());
                }
                else if (result == -1)
                {
                    MessageBox.Show("Error en la conexión a la BD");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresar todos los campos");
            }
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowTasks());
        }
    }
}
