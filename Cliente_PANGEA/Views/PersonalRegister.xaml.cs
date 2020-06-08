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
        private List<Cuentas> listAccounts;
        private int idEvent = SingletonEvent.GetEvent().Id;
        public PersonalRegister()
        {
            InitializeComponent();
            this.listAccounts = new List<Cuentas>();
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
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            String email = txt_email.Text;
            if (!EmptyFields(email))
            {
                if (CorrectEmail(email))
                {
                    ShowAccounts(email);
                }
                else
                {
                    MessageBox.Show("El formato del correo no es válido, por favor vuelva a intentarlo");
                }
            }
        }
        private bool ValidateSelectedPersonal()
        {
            bool isSelected = true;
            if (listViewAccounts.SelectedValue == null)
            {
                 isSelected = false;
            }
            return isSelected;
        }
        private void btn_addPersonal_Click(object sender, RoutedEventArgs e)
        {
            Cuentas cuentaSelected = (Cuentas)listViewAccounts.SelectedItem;
            if (ValidateSelectedPersonal())
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("¿Está seguro de registar al personal?", "Agregar cuenta como personal", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    if (PersonalController.AssignPersonal(cuentaSelected, idEvent) > 0)
                    {
                        MessageBox.Show("Personal registrado con éxito");
                        RefreshTableAccounts();
                    }
                    else if (PersonalController.AssignPersonal(cuentaSelected, idEvent) == 0)
                    {
                        MessageBox.Show("La cuenta ya está registrada en el evento como personal");
                    }
                    else
                    {
                        MessageBox.Show("Error en la conexión con la base de datos.");
                    }
                }
        
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Cuenta");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeletePersonal());
        }
        private Boolean EmptyFields(String email)
        {
            if (email == "")
            {
                MessageBox.Show("Por favor ingresa información en todos los campos");
                return true;
            }
            return false;
        }
        private void RefreshTableAccounts()
        {
            listViewAccounts.ItemsSource = null;
            listViewAccounts.ItemsSource = listAccounts;
        }
        private bool CorrectEmail(string email)
        {
            Regex expressionEmail = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            return expressionEmail.IsMatch(email);
        }

    }

}
