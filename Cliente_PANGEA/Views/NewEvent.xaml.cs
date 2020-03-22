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

namespace Cliente_PANGEA
{
    /// <summary>
    /// Interaction logic for NewEvent.xaml
    /// </summary>
    public partial class NewEvent : Page
    {
        public NewEvent()
        {
            InitializeComponent();
        }


        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Campos vacios");
            }
            else if (!ValidateCost())
            {
                MessageBox.Show("Ingresa una cantidad correcta por favor");
            }
            else
            {
                if (SaveEvent() > 0)
                {
                    MessageBox.Show("Se ha creado el evento con éxito");
                }
                
            }

        }

        public int SaveEvent()
        {
            DataAccess.Eventos evento = new Eventos
            {
                CodigoEvento = "1234",
                Nombre = TextBox_nombreEvento.Text,
                Lugar = TextBox_Lugar.Text,
                Gratuito = !MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value,
                Descripcion = TextBox_description.Text,
                FechaInicio = DateTime.Parse(DatePicker_initDate.Text),
                FechaFin = DateTime.Parse(DatePicker_endDate.SelectedDate.ToString())
            };

            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                evento.Costo = Double.Parse(TextBox_cantidad.Text);
            }

            return EventController.SaveEvent(evento);
        }

        public bool ValidateEmptyFields()
        {
            bool validation = true;
            if (String.IsNullOrEmpty(TextBox_nombreEvento.Text))
            {
                validation = false;
            }

            if (String.IsNullOrEmpty(TextBox_Lugar.Text))
            {
                validation = false;
            }

            if (String.IsNullOrEmpty(TextBox_description.Text))
            {
                validation = false;
            }

            if (String.IsNullOrEmpty(DatePicker_initDate.Text))
            {
                validation = false;
            }
            if (String.IsNullOrEmpty(DatePicker_endDate.Text))
            {
                validation = false;
            }

            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                if (String.IsNullOrEmpty(TextBox_cantidad.Text))
                {
                    validation = false;
                }
            }


            return validation;
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

        private void MaterialDesignFilledTextFieldTextBoxEnabledComboBox_Click(object sender, RoutedEventArgs e)
        {

            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked == false )
            {
                TextBox_cantidad.Text = "";
            }

        }
    }
}
