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
using Cliente_PANGEA.Controllers;
using DataAccess;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for ModifyAccount.xaml
    /// </summary>
    public partial class ModifyAccount : Page
    {
        Cuentas account = SingletonAccount.GetAccount();
        public ModifyAccount()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void LoadAccount()
        {
            txt_name.Text = account.Nombre;
            txt_lastname.Text = account.Apellido;
            txt_email.Text = account.Correo;
            txt_phone.Text = account.Telefono;
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private bool EmptyFields()
        {
            bool result = false;

            if (string.IsNullOrEmpty(txt_name.Text))
            {
                result = true;
            }
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                result = true;
            }

            return result;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {

            if (EmptyFields())
            {
                MessageBox.Show("Por favor ingresar todos lo campos");
                return;
            }
            


            if (AccountController.UpdateAccount(account.Id, txt_name.Text,txt_lastname.Text,txt_phone.Text))
            {
                MessageBox.Show("Se acuatlizo con éxito la cuenta");
                account = AccountController.GetAccount(account.Id);
                SingletonAccount.SetAccount(account);
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }
    }
}
