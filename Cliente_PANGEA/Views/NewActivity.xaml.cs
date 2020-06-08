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
    /// Interaction logic for NewActivity.xaml
    /// </summary>
    public partial class NewActivity : Page
    {
        public NewActivity()
        {
            InitializeComponent();
        }



        public int SaveActivity()
        {
            Actividades activity = new Actividades
            {
                IdEvento = SingletonEvent.GetEvent().Id,
                Titulo = TextBox_activityTitle.Text,
                Descripcion = TextBox_activityDescription.Text,
                Tipo = TextBox_activityType.Text,
                FechaCreacion = DateTime.Now
            };

            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                activity.Gratuito = false;
                activity.Costo = Double.Parse(TextBox_cantidad.Text);
            }else
            {
                activity.Gratuito = true;
                activity.Costo = 0;
            }

            if(MaterialDesignFilled.IsChecked.Value)
            {
                activity.Cupo = Int32.Parse(TextBox_capacity.Text);
            }

            return ActivityController.SaveActivity(activity);
        
        }

        public void ClearFields()
        {
            TextBox_activityTitle.Text = String.Empty;
            TextBox_activityDescription.Text = String.Empty;
            TextBox_cantidad.Text = String.Empty;
            TextBox_activityType.Text = String.Empty;
            TextBox_capacity.Text = String.Empty;
        }

        public void ClearCapacityField()
        {
            if (MaterialDesignFilled.IsChecked.Value == false)
            {
                TextBox_capacity.Text = String.Empty;
            }
        }

        public void ClearCostField()
        {
            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value == false)
            {
                TextBox_cantidad.Text = String.Empty;
            }
        }

        public bool CorrectFields()
        {

            bool result = true;
            Regex regexName = new Regex(@"^[a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9-,-. ]+$");
            if (!regexName.IsMatch(TextBox_activityDescription.Text))
            {
                result = false;
            }
            Regex regexDescription = new Regex(@"^[\r\n a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9-,-. !@#\$%\&\*\?¿._~\/]+$");
            if (!regexDescription.IsMatch(TextBox_activityTitle.Text))
            {

                result = false;
            }
            if (!regexDescription.IsMatch(TextBox_activityType.Text))
            {

                result = false;
            }
            return result;
        }

        private bool ValidateCost()
        {
            double result;
            bool isValid = true;
            if (!Double.TryParse(TextBox_cantidad.Text, out result))
            {
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateCapacity()
        {
            int result;
            bool isValid = true;

            if (!Int32.TryParse(TextBox_capacity.Text, out result))
            {
                isValid = false;
            }

            return isValid;
        }
        private bool ValidateEmptyFields()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(TextBox_activityTitle.Text))
            {
                isValid = false;
            }
            else if (String.IsNullOrEmpty(TextBox_activityDescription.Text))
            {
                isValid = false;
            } else if (String.IsNullOrEmpty(TextBox_activityType.Text))
            {
                isValid = false;
            } else if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                if (String.IsNullOrEmpty(TextBox_cantidad.Text))
                {
                    isValid = false;
                }
            }else if (MaterialDesignFilled.IsChecked.Value)
            {
                if (String.IsNullOrEmpty(TextBox_capacity.Text))
                {
                    isValid = false;
                }
            }
            return isValid;
         }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Por favor ingrese información en todos los campos", "Campos vacios");
            } else if (!CorrectFields())
            {
                MessageBox.Show("Los campos contienen datos invalidos");
            }
            else if (!ValidateCost() && MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                MessageBox.Show("Por favor ingrese una cantidad correcta ", "Campo incorrecto");
            }
            else if (!ValidateCapacity() && MaterialDesignFilled.IsChecked.Value)
            {
                MessageBox.Show("Por favor ingrese un cupo correcto", "Campo incorrecto");
            }
            else if (SaveActivity() > 0)
            {
                MessageBox.Show("Actividad guardada", "Operación exitosa");
                NavigationService.Navigate(new NewSchedule());
            }
        }

 

        private void MaterialDesignFilledTextFieldTextBoxEnabledComboBox_Click(object sender, RoutedEventArgs e)
        {
            ClearCostField();
        }

        private void MaterialDesignFilledTextField_Click(object sender, RoutedEventArgs e)
        {
            ClearCapacityField();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowActivity());
        }

       
    }
    }

