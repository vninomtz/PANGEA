using Cliente_PANGEA.Controllers;
using Cliente_PANGEA.Views;
using DataAccess;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace Cliente_PANGEA
{
    /// <summary>
    /// Interaction logic for MainEvent.xaml
    /// </summary>
    public partial class MainEvent : Page

    {
      
        public MainEvent(DataAccess.Eventos evento)
        {
            InitializeComponent();
            DisableFields();            
            SingletonEvent.SetSingletonEvent(evento);
            LoadEventInformation();
            if(SingletonPersonal.GetPersonal() != null)
            {
                ValidateRol();
            }


           
            
        }

        public MainEvent()
        {
            InitializeComponent();
            DisableFields();
            LoadEventInformation();
           
            
        }
        private void ValidateRol()
        {
            switch (SingletonPersonal.GetPersonal().Cargo)
            {
                case "Líder Comité":
                case "Miembro Comité":
                    Button_edit.IsEnabled = false;
                    break;

            }
        }

        private void LoadEventInformation()
        {
            TextBlock_title.Text = SingletonEvent.GetEvent().Nombre;
            TextBox_eventName.Text = SingletonEvent.GetEvent().Nombre;
            TextBox_place.Text = SingletonEvent.GetEvent().Lugar;
            if (!SingletonEvent.GetEvent().Gratuito)
            {
                MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked = true;
                TextBox_cantidad.Text = SingletonEvent.GetEvent().Costo.ToString();
            }
            else
            {
                MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked = false;
            }

            TextBox_description.Text = SingletonEvent.GetEvent().Descripcion;
            DatePicker_initialDate.Text = SingletonEvent.GetEvent().FechaInicio.ToString();
            DatePicker_endDate.Text = SingletonEvent.GetEvent().FechaFin.ToString();
            Button_edit.Visibility = Visibility.Visible;
        }

        private void Button_edit_Click(object sender, RoutedEventArgs e)
        {
            EnableFields();
            Button_edit.Visibility = Visibility.Hidden;
           
          
        }

        public bool CorrectFields()
        {

            bool result = true;
            Regex regexName = new Regex(@"^[a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9 ]+$");
            if (!regexName.IsMatch(TextBox_eventName.Text))
            {
                result = false;
            }
            Regex regexDescription = new Regex(@"^[\r\n a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9 !@#\$%\&\*\?¿._~\/]+$");
            if (!regexDescription.IsMatch(TextBox_place.Text))
            {

                result = false;
            }
            if (!regexDescription.IsMatch(TextBox_description.Text))
            {

                result = false;
            }
            return result;
        }

        public void DisableFields()
        {
            TextBox_eventName.IsEnabled = false;
            TextBox_place.IsEnabled = false;
            MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsEnabled = false;
            TextBox_description.IsEnabled = false;
            TextBox_cantidad.IsEnabled = false;
            DatePicker_initialDate.IsEnabled = false;
            DatePicker_endDate.IsEnabled = false;
            Button_save.Visibility = Visibility.Hidden;
            Button_edit.Visibility = Visibility.Visible;
        }

        public void EnableFields()
        {
            TextBox_eventName.IsEnabled = true;
            TextBox_place.IsEnabled = true;
            MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsEnabled = true;
            TextBox_description.IsEnabled = true;
            TextBox_cantidad.IsEnabled = true;
            DatePicker_initialDate.IsEnabled = true;
            DatePicker_endDate.IsEnabled = true;
            Button_save.Visibility = Visibility.Visible;
            Button_editOff.Visibility = Visibility.Visible;
           

        }

        public bool ValidateEmptyFields()
        {
            bool validation = true;
            if (String.IsNullOrEmpty(TextBox_eventName.Text))
            {
                validation = false;
            }

            if (String.IsNullOrEmpty(TextBox_place.Text))
            {
                validation = false;
            }

            if (String.IsNullOrEmpty(TextBox_description.Text))
            {
                validation = false;
            }

            if ((String.IsNullOrEmpty(DatePicker_initialDate.Text) && !String.IsNullOrEmpty(DatePicker_endDate.Text)) || 
                !String.IsNullOrEmpty(DatePicker_initialDate.Text) && String.IsNullOrEmpty(DatePicker_endDate.Text))
            {
                validation = false;
            }
            if (String.IsNullOrEmpty(DatePicker_endDate.Text))
            {
                validation = false;
            }

            if ((bool)MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                if (String.IsNullOrEmpty(TextBox_cantidad.Text))
                {
                    validation = false;
                }
            }
            return validation;
        }
        private void Button_editOff_Click(object sender, RoutedEventArgs e)
        {
            DisableFields();
            Button_editOff.Visibility = Visibility.Hidden;
            LoadEventInformation();


        }

        private void MaterialDesignFilledTextFieldTextBoxEnabledComboBox_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value == false)
            {
                TextBox_cantidad.Text = String.Empty;
                TextBox_cantidad.IsEnabled = false;
            }
            else
            {
                TextBox_cantidad.IsEnabled = true;
                
            }
        }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Por favor ingrese información en todos los campos", "Campos vacios");
            }
            else if (!ValidateCost())
            {
                MessageBox.Show("Ingresa una cantidad correcta por favor");
            } else if (!CorrectFields())
            {
                MessageBox.Show("Los campos contienen caracteres invalidos");
            }
            else if (DatePicker_initialDate.SelectedDate.Value.CompareTo(DatePicker_endDate.SelectedDate.Value) > 0)
            {
                MessageBox.Show("Error con las fechas seleccionadas", "datos inconsistentes");
            }
            else
            {
                UpdateEvent();
               
            }      
        }

        private void UpdateEvent()
        {
            
            Eventos updatedEvento = new Eventos();
            updatedEvento.Id = SingletonEvent.GetEvent().Id;
            updatedEvento.Nombre = TextBox_eventName.Text;
            updatedEvento.Lugar = TextBox_place.Text;           
          
            
            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                updatedEvento.Gratuito = false;                   
                updatedEvento.Costo = Double.Parse(TextBox_cantidad.Text);
            }
            else
            {
                updatedEvento.Gratuito = true;
            }
            

            updatedEvento.Descripcion = TextBox_description.Text;
            updatedEvento.FechaFin = DateTime.Parse(DatePicker_endDate.Text).Date;
            updatedEvento.FechaInicio = DateTime.Parse(DatePicker_initialDate.Text).Date;

            if (EventController.UpdateEvent(updatedEvento) < 0)
            {
                MessageBox.Show("Error de conexión con la base de datos");
            } else
            {
                MessageBox.Show("Campos actualizados correctamente");
                SingletonEvent.SetSingletonEvent(EventController.GetEventById(SingletonEvent.GetEvent().Id));
                LoadEventInformation();
                DisableFields();

            }   







        }

        private bool ValidateCost()
        {
            bool validation = true;
            int result;
            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value && !Int32.TryParse(TextBox_cantidad.Text, out result))
            {
                validation = false;
            }          

            return validation;

        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            Events eventsWindow = new Events();
            eventsWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventProgram());
        }
    }
}
