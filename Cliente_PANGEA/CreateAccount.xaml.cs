using Cliente_PANGEA.Controllers;
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
using System.Windows.Shapes;

namespace Cliente_PANGEA
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            if (CorrectFields())
            {
                if (CorrectPassword())
                {
                    if (!UserExist())
                    {
                        SaveAccount();
                    }
                }
            }
        }

        private void SaveAccount()
        {
            String passwordEncode = Encrypter.EncodePassword(txt_password.Password);
            bool result = AccountController.SaveUser
                (txt_name.Text, txt_lastname.Text, txt_email.Text, txt_phone.Text, passwordEncode);

            if (result)
            {
                MessageBox.Show("Registro exitoso");
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }
        private bool UserExist()
        {
            bool result = false;
            var exist = AccountController.UserExist(txt_email.Text);
            if(exist == 1)
            {
                result = true;
                MessageBox.Show("Ya hay un usuario existente con ese correo");
            }
            else if(exist == -1)
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
            return result;
        }

        private bool CorrectPassword()
        {
            if (txt_password.Password != txt_passwordConfim.Password)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return false;
            }
            else
            {
                return true;
            }
        }

        private  bool EmptyFields()
        {
            bool result = false;

            if (String.IsNullOrEmpty(txt_name.Text))
            {
                result = true;
            }
            if (String.IsNullOrEmpty(txt_lastname.Text))
            {
                result = true;
            }
            if (String.IsNullOrEmpty(txt_email.Text))
            {
                result = true;
            }
            if (String.IsNullOrEmpty(txt_password.Password))
            {
                result = true;
            }
            else if (String.IsNullOrEmpty(txt_passwordConfim.Password))
            {
                result = true;
            }
            return result;
        }
        private bool CorrectFields()
        {
            bool result = true;
            if (!EmptyFields())
            {
                if (!CorrectName(txt_name.Text))
                {
                    MessageBox.Show("Ingresar un nombre correcto");
                    result = false;
                }
                if (!CorrectName(txt_lastname.Text))
                {
                    MessageBox.Show("Ingresar un apellido correctos");
                    result = false;
                }
                if (!CorrectEmail(txt_email.Text))
                {
                    MessageBox.Show("Ingresar un email correcto");
                    result = false;
                }
                if (!CorrectPhone(txt_phone.Text))
                {
                    MessageBox.Show("Ingresar un teléfono correcto");
                    result = false;
                }

            }
            else
            {
                MessageBox.Show("Ingresar todos los campos");
                result = false;
            }

            return result;
        }

        private bool CorrectPhone(string number)
        {
            return Regex.Match(number, @"\A[0-9]{7,10}\z").Success;
        }

        private bool CorrectEmail(string email)
        {
            Regex expressionEmail = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            return expressionEmail.IsMatch(email);
        }

        private bool CorrectName(string text)
        {
            bool result = true;
            Regex rg = new Regex(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+$");
            if (!rg.IsMatch(text))
            {
                result = false;
            }

            return result;
        }
    }
}
