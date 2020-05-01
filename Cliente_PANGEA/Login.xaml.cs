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

        private bool ExistUser()
        {
            bool exist = false;

            int result = AccountController.UserExist(txt_email.Text);
            if(result == 1)
            {
                exist = true;
            }else if(result == 0)
            {
                exist = false;
            }


            return exist;
            
        }

        private bool ValidateLogin()
        {
            bool isValid = false;
           

            if (ValidateEmptyFields())
            {
                if (ExistUser())
                {
                    account = AccountController.Login(txt_email.Text, txt_password.Password);
                    if (account == null)
                    {
                        MessageBox.Show("Contraseña incorrecta", "Datos invalidos");
                    }
                    else if (account.Id == -1)
                    {
                        MessageBox.Show("Error en la conexión a la base de datos", "Error en la conexión");
                    }
                    else if (account.Id > 0)
                    {
                        isValid = true;
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ingresado no está registrado", "Usuario no existente");
                }
                
            }
            else
            {
                MessageBox.Show("Por favor ingresar información en todos los campos", "Datos invalidos");
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

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ir a ventana Crear cuenta");
        }

        private void url_recover_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ir a ventana recuperar contraseña");
        }
    }
}
