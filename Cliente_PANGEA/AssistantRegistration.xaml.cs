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
using System.Text.RegularExpressions;

namespace Cliente_PANGEA
{
    /// <summary>
    /// Lógica de interacción para AssistantRegistration.xaml
    /// </summary>
    public partial class AssistantRegistration : Page
    {
        public AssistantRegistration()
        {
            InitializeComponent();

        }


        private void btn_AssistantRegister_Click(object sender, RoutedEventArgs e)
        {
            String email = txt_email.Text;
            if (!ValidateEmptyFields())
            {
                if (ValidateEmail(email) == true)
                {
                    EqualEmails();
                }
            }      

        }

 
        private void Button_AssignActovity(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AssistantConsult());
            

        }

        private bool ValidateEmptyFields()
        {
            if (txt_AssistantName.Text == "" || txt_fatherLastName.Text == "" || txt_motherLastName.Text == "" || txt_email.Text =="" || txt_emailConfirmation.Text == "")
            {
                MessageBox.Show("Por favor ingresa información en todos los campos.");
                return true;
            }
            return false;
        }
        private bool EqualEmails()
        {
            String email = txt_email.Text;
            String emailConfirmation = txt_emailConfirmation.Text;

            if (email.Equals(emailConfirmation))
            {
                return true;
            }
            MessageBox.Show("Los correos electrónicos no coinciden, por favor inténtelo de nuevo.");
            return false;
        }

        private Boolean ValidateEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                    return true;
            }
            else
            {
                MessageBox.Show("Formato de correo inválido");
                return false;
            }
        }
        private void ValidateText(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                return;
            }
            if (!Regex.IsMatch(textbox.Text, @"[A-Za-z0-9\s]+$"))
            {
                MessageBox.Show("Por favor ingresa información válida en los campos.");
                textbox.Clear();
            }
        }
    }

}
