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
using Cliente_PANGEA.Controllers;
using DataAccess;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para PersonalRegister.xaml
    /// </summary>
    public partial class PersonalRegister : Page
    {
        public PersonalRegister()
        {
            InitializeComponent();
        }

        private void ShowAccounts(String correo)
        {
            if (PersonalController.GetAccountsEvent(correo).Count()>0)
            {
                listViewAccounts.ItemsSource = PersonalController.GetAccountsEvent(correo);
            }
            else
            {
                MessageBox.Show("No se han encontrado registros con el correo ingresado");
            }

        }

        private Boolean EmptyFields()
        {
            if (txt_email.Text == "")
            {
                MessageBox.Show("Por favor ingresa información en todos los campos");
                return true;
            }
            return false;
        }

        private void CorrectEmail(object sender, RoutedEventArgs e)
        {
            String expresion;
            String email = txt_email.Text;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("El formato del correo no es válido, porfavor vuelva a intentarlo");
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                string correo = txt_email.Text;
                ShowAccounts(correo);
            }
        }

        private void btn_addPersonal_Click(object sender, RoutedEventArgs e)
        {
            foreach (Cuentas cuentas in listViewAccounts.SelectedItems)
            {
                if (PersonalController.AssignPersonal(cuentas)>0)
                {
                    MessageBox.Show("Personal registrado con éxito");
                }else if (PersonalController.AssignPersonal(cuentas) == 0)
                {
                    MessageBox.Show("La cuenta ya está registrada en el evento como personal");
                }
                else
                {
                    MessageBox.Show("Error en la conexión con la base de datos.");
                }
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeletePersonal());
        }
    }
}
