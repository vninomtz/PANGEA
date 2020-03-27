using Cliente_PANGEA.Controllers;
using DataAccess;
using System;
using System.Windows;


namespace Cliente_PANGEA
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private Cuentas account;
        public Login()
        {
            InitializeComponent();
        }

        private bool ValidateEmptyFields()
        {
            bool isValid = true;
            if(String.IsNullOrEmpty(txt_email.Text) || String.IsNullOrEmpty(txt_password.Password))
            {
                isValid = false;
            }
            return isValid;
        }


        private bool ValidateLogin()
        {
            bool isValid = false;
            account = AccountController.Login(txt_email.Text, txt_password.Password);

            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Por favor ingresar información en todos los campos", "Datos invalidos");
            } else if (account == null)
            {
                MessageBox.Show("Usuario o contraseña incorrecto","Datos invalidos");
            }else if (account.Id == -1)
            {
                MessageBox.Show("Error en la conexión a la base de datos", "Error en la conexión");
            } else if (account.Id > 0) 
            {
                isValid = true;
            }

            return isValid;
        }
        private void btn_iniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            
            if (ValidateLogin())
            {
                SingletonAccount.SetAccount(account);
                Events mainWindow = new Events();
                mainWindow.Show();
                this.Close();
               
            }
            
        }
    }
}
