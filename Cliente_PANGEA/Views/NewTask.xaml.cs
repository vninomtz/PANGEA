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
        List<Actividades> listActivities = new List<Actividades>();
        Tareas taskUpdated;
        bool isNew = false;
        public NewTask()
        {
            InitializeComponent();
            HideLabels();
            LoadActivities();
            isNew = true;
        }
        public NewTask(Tareas task)
        {
            InitializeComponent();
            this.taskUpdated = task;
            LoadTask();
        }

        private void LoadTask()
        {
            txt_name.Text = taskUpdated.Nombre;
            txt_description.Text = taskUpdated.Descripcion;
            txt_inCharge.Text = taskUpdated.Responsable;
            lbl_dateCreation.Text = $"Creación: {taskUpdated.FechaCreacion}";
            lbl_lastUpdate.Text = $"Última actualización: {taskUpdated.UltimaModificacion}";
            cb_finished.IsChecked = taskUpdated.Finalizada;
            listActivities.Add(taskUpdated.Actividades);
            cb_activities.ItemsSource = listActivities;
            cb_activities.SelectedItem = listActivities[0];
            
            cb_activities.IsEditable = false;
        }

        private void HideLabels()
        {
            stp_dates.Visibility = Visibility.Hidden;
            cb_finished.Visibility = Visibility.Hidden;
            btn_delete.Visibility = Visibility.Hidden;
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

        private void SaveTask()
        {
            Actividades act = (Actividades)cb_activities.SelectedItem;
            int result = TaskController.SaveTask(txt_name.Text, txt_description.Text, txt_inCharge.Text, act.Id);
            if (result > 0)
            {
                MessageBox.Show("Se guardo con éxito la tarea");
                this.NavigationService.Navigate(new ShowTasks());
            }
            else if (result == -1)
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }
        private void UpdateTask()
        {
            taskUpdated.Nombre = txt_name.Text;
            taskUpdated.Descripcion = txt_description.Text;
            taskUpdated.Responsable = txt_inCharge.Text;
            taskUpdated.Finalizada = (bool)cb_finished.IsChecked;

            int result = TaskController.UpdateTask(taskUpdated);
            if(result > 0)
            {
                MessageBox.Show("Se actualizo con éxito la tarea");
                this.NavigationService.Navigate(new ShowTasks());
            }
            else
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                if (isNew)
                {
                    SaveTask();
                }
                else
                {
                    UpdateTask();
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

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = MessageBox.Show("¿Estás seguro de eliminar esta tarea? ",
                "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (dialogResult == MessageBoxResult.Yes)
            {
                if (TaskController.DeleteTask(taskUpdated.Id))
                {
                    MessageBox.Show("Se eliminó la tarea con éxito");
                    this.NavigationService.Navigate(new ShowTasks());
                }
                else
                {
                    MessageBox.Show("Error en la conexión a la BD");
                }
            }
        }
    }
}
