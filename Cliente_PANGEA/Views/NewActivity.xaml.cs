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
            }
            else
            {
                activity.Gratuito = true;
                activity.Costo = 0;
            }

            return ActivityController.SaveActivity(activity);
        
        }

        public void ClearFields()
        {
            TextBox_activityTitle.Text = String.Empty;
            TextBox_activityDescription.Text = String.Empty;
            TextBox_cantidad.Text = String.Empty;
            TextBox_activityType.Text = String.Empty;
        }

        public void ClearCostField()
        {
            if (MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value == false)
            {
                TextBox_cantidad.Text = String.Empty;
            }
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
            }
            return isValid;
         }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Por favor ingrese información en todos los campos", "Campos vacios");
            }
            else if (!ValidateCost() && MaterialDesignFilledTextFieldTextBoxEnabledComboBox.IsChecked.Value)
            {
                MessageBox.Show("Por favor ingrese una cantidad correcta ", "Campo incorrecto");
            } else if (SaveActivity() > 0)
            {
                MessageBox.Show("Actividad guardada", "Operación exitosa");
                NavigationService.Navigate(new NewSchedule());
            }
        }

 

        private void MaterialDesignFilledTextFieldTextBoxEnabledComboBox_Click(object sender, RoutedEventArgs e)
        {
            ClearCostField();
        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
    }
    }

