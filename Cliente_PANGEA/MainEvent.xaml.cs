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
    /// Interaction logic for MainEvent.xaml
    /// </summary>
    public partial class MainEvent : Page
    {
        public MainEvent()
        {
            InitializeComponent();
            DisableFields();
        }

        private void Button_edit_Click(object sender, RoutedEventArgs e)
        {
            EnableFields();
            Button_edit.Visibility = Visibility.Hidden;
           
          
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

            if (String.IsNullOrEmpty(DatePicker_initialDate.Text))
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
        private void Button_editOff_Click(object sender, RoutedEventArgs e)
        {
            DisableFields();
            Button_editOff.Visibility = Visibility.Hidden;

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
                MessageBox.Show("Campos vacios");
            }
            else if (!ValidateCost())
            {
                MessageBox.Show("Ingresa una cantidad correcta por favor");
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

      
    }
}
