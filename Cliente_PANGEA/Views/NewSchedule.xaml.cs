using Cliente_PANGEA.Controllers;
using DataAccess;
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

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for NewSchedule.xaml
    /// </summary>
    public partial class NewSchedule : Page
    {
        private int idActivity;
        private List<Horarios> scheduleList;
        public NewSchedule()
        {
            InitializeComponent();
            this.idActivity = ActivityController.GetLastActivity();
            this.scheduleList = new List<Horarios>();
        }


        private int SaveSchedules()
        {
            return ScheduleController.SaveSchedules(scheduleList);
        }

        private void RefreshTable()
        {
            ListView_schedules.ItemsSource = null;
            ListView_schedules.ItemsSource = scheduleList;
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
                scheduleList.Remove(scheduleSelected);
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Por favor seleccionar un horario de la tabla");
            }
        }

        private void AddSchedule()
        {


            Horarios hour = new Horarios
            {
                IdActividad = idActivity,
                Direccion = TextBox_address.Text,
                Lugar = TextBox_place.Text,
                FechaInicio = DateTime.Parse(DatePicker_initialDate.Text + " " + TimePicker_initialHour.Text),
                FechaFin = DateTime.Parse(DatePicker_endDate.Text + " " + TimePicker_endHour.Text),

            };

            scheduleList.Add(hour);
            RefreshTable();
            
        }

        public bool CorrectFields()
        {

            bool result = true;
            Regex regexName = new Regex(@"^[a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9 ]+$");
            if (!regexName.IsMatch(TextBox_address.Text))
            {
                result = false;
            }
            Regex regexDescription = new Regex(@"^[\r\n a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9 !@#\$%\&\*\?¿._~\/]+$");
            if (!regexDescription.IsMatch(TextBox_place.Text))
            {

                result = false;
            }
           
            return result;
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
            else if (!CorrectFields())
            {
                MessageBox.Show("Los campos contienen caracteres invalidos");
            } else 
            {
                AddSchedule();
                ClearFields();
                
            }
        }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            if (scheduleList.Count == 0)
            {
                MessageBox.Show("Por favor ingrese un horario");
            } else if (SaveSchedules() > 0)
            {
                MessageBox.Show("Horarios guardados correctamente", "Operación existosa");
                NavigationService.Navigate(new NewActivity());
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos", "Operación fallida");
            }
        }

        private void Button_quitar_Click(object sender, RoutedEventArgs e)
        {
            QuitSchedule();
        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Se cancelará el ingreso de los horarios para la actividad", "Adevertencia", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new NewActivity());
            }

        }
    }
}
