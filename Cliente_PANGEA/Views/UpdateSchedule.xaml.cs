using Cliente_PANGEA.Controllers;
using DataAccess;
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

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for UpdateSchedule.xaml
    /// </summary>
    public partial class UpdateSchedule : Page
    {
        private int idActivity;
        private List<Horarios> scheduleList;
        public UpdateSchedule()
        {
            InitializeComponent();
            this.idActivity = ActivityController.GetLastActivity();
            this.scheduleList = new List<Horarios>();
            ShowScheduleSelected();
        }

        private void ShowScheduleSelected()
        {
            ListView_schedules.ItemsSource = ScheduleController.GetSchedules(idActivity);

        }

        public bool ValidateSelectedSchedule()
        {
            bool isValid = true;
            if (ListView_schedules.SelectedValue == null)
            {
                isValid = false;
            }

            return isValid;
        }

        private void QuitSchedule()
        {
            if (ValidateSelectedSchedule())
            {
                Horarios scheduleSelected = (Horarios)ListView_schedules.SelectedItem;
                ScheduleController.DeleteSchedule(scheduleSelected.Id);
                ShowScheduleSelected();
            }
            else
            {
                MessageBox.Show("Por favor seleccionar un horario de la tabla");
            }
        }

        private int AddSchedule()
        {
            Horarios hour = new Horarios
            {
                IdActividad = idActivity,
                Direccion = TextBox_address.Text,
                Lugar = TextBox_place.Text,
                FechaInicio = DateTime.Parse(DatePicker_initialDate.Text + " " + TimePicker_initialHour.Text),
                FechaFin = DateTime.Parse(DatePicker_endDate.Text + " " + TimePicker_endHour.Text),

            };
            return ScheduleController.SaveSchedule(hour);
        }

        private bool ValidateEmptyFields()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(TextBox_address.Text))
            {
                isValid = false;
            }
            else if (String.IsNullOrEmpty(TextBox_place.Text))
            {
                isValid = false;
            }
            else if (String.IsNullOrEmpty(DatePicker_initialDate.Text))
            {
                isValid = false;
            }
            else if (String.IsNullOrEmpty(TimePicker_initialHour.Text))
            {
                isValid = false;
            }
            else if (String.IsNullOrEmpty(DatePicker_endDate.Text))
            {
                isValid = false;
            }
            else if (String.IsNullOrEmpty(TimePicker_endHour.Text))
            {
                isValid = false;
            }

            return isValid;
        }

        private void ClearFields()
        {
            TextBox_address.Text = String.Empty;
            TextBox_place.Text = String.Empty;
            DatePicker_initialDate.Text = String.Empty;
            TimePicker_initialHour.Text = String.Empty;
            DatePicker_endDate.Text = String.Empty;
            TimePicker_endHour.Text = String.Empty;

        }

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Por favor Ingresar información en todos los campos");
            }
            else
            {
                if (AddSchedule()>0)
                {
                    ShowScheduleSelected();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error en la conexión con la base de datos");
                }
                
            }
        }

        private void Button_quitar_Click(object sender, RoutedEventArgs e)
        {
            QuitSchedule();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Se guardaran los horarios de la tabla", "Confirmación", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {

                Actividades activity = ActivityController.GetActivityForUpdate(idActivity);
                NavigationService.Navigate(new UpdateActivity(activity));
            }

        }

    }
}
