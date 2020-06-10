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
using DataAccess;
using Cliente_PANGEA.Controllers;
using System.Net.Mail;

namespace Cliente_PANGEA
{
    /// <summary>
    /// Lógica de interacción para RecoverPassword.xaml
    /// </summary>
    public partial class RecoverPassword : Window
    {
        public RecoverPassword()
        {
            InitializeComponent();
            txt_password.Visibility = Visibility.Hidden;
            txt_confirmPassword.Visibility = Visibility.Hidden;
            Button_ConfirmPassword.Visibility = Visibility.Hidden;
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        private bool ValidateEmailRegister(String email)
        {
            if (AccountController.UserExist(email)>0)
            {
                return true;
            }
            return false;
        }
        private bool SaveToken(String email, String token)
        {
            if (AccountController.SaveTokenInAccount(email,token)>0)
            {
                return true;
            }
            MessageBox.Show("Error en la conexión con la base de datos.");
            return false;
        }
        private void Button_sendCode_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            if (CorrectEmail(email) && ValidateEmailRegister(email))    
            {
                String token = GenerateCode();
                if (SaveToken(email,token))
                {
                    SendEmail(email, token);
                    MessageBox.Show("Correo enviado exitosamente");
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar un correo registrado");
            }
        }
    

        private void Button_forwardCode_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            if (CorrectEmail(email) && ValidateEmailRegister(email))
            {
                String token = GenerateCode();
                if (SaveToken(email, token))
                {
                    SendEmail(email, token);
                    MessageBox.Show("Correo enviado exitosamente");
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar un correo registrado");
            }
        }
        private bool ValidateCodes(String email,String codeEntered)
        {
            if (AccountController.GetTokenAccount(email, codeEntered)!=null)
            {
                return true;
            }
            MessageBox.Show("Los códigos no coinciden, vuelve a intentarlo");
            return false;
        }
        private bool UpdatePassword(String email, String password)
        {
            if (AccountController.UpdatePassword(email, password) > 0)
            {
                return true;
            }
            else if (AccountController.UpdatePassword(email,password) == 0)
            {
                MessageBox.Show("Por seguridad ingresa una contraseña diferente.");
                return false;
            }
            MessageBox.Show("Error en la conexión con la base de datos.");
            return false;
   
        }
        private void Button_ValidateCode_Click(object sender, RoutedEventArgs e)
        {
            String email = txt_email.Text;
            String code = txt_Code.Text;
            if (CorrectEmail(email) && ValidateEmailRegister(email))
            {
                if (ValidateCodes(email, code))
                {
                    DisablePrincipalFields();
                    EnablePasswordFields();
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar un correo registrado");
            }
      
        }
        private bool EqualsPasswords(String password, String confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            MessageBox.Show("Las contraseñas no coinciden, vuelve a intentarlo");
            return false;
        }
        private void DisablePrincipalFields()
        {
            emailDescription.Visibility = Visibility.Hidden;
            codeDescription.Visibility = Visibility.Hidden;
            txt_email.Visibility = Visibility.Hidden;
            txt_Code.Visibility = Visibility.Hidden;
            Button_forwardCode.Visibility = Visibility.Hidden;
            Button_ValidateCode.Visibility = Visibility.Hidden;
            Button_sendCode.Visibility = Visibility.Hidden;

        }
        private void EnablePasswordFields()
        {
            txt_password.Visibility = Visibility.Visible;
            txt_confirmPassword.Visibility = Visibility.Visible;
            Button_ConfirmPassword.Visibility = Visibility.Visible;
           
        }
        private void SendEmail(String destinationEmail, String token)
        {
            String originEmail = "pangeasystem@gmail.com";
            String passwordEmail = "Pangea12345678";
            String subjectEmail = "Código de verificación para recuperar la contraseña";
            String bodyEmail = "Este es tu código de verificación: ";

            MailMessage mailMessage = new MailMessage(originEmail, destinationEmail, subjectEmail, bodyEmail + "<br>" + token);
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(originEmail, passwordEmail);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
        }
        private bool CorrectEmail(string email)
        {
            Regex expressionEmail = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            return expressionEmail.IsMatch(email);
        }
        private String GenerateCode()
        {
            Random random = new Random();
            String token = random.Next().ToString();
            return token;
        }

        private void Button_ConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            String password = txt_password.Password;
            String confirmPassword = txt_confirmPassword.Password;
            String email = txt_email.Text;
            if (EqualsPasswords(password, confirmPassword))
            {
                if (UpdatePassword(email,Encrypter.EncodePassword(confirmPassword)))
                {
                    MessageBox.Show("Contraseña actualizada correctamente");
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                {
                    
                }
            }
        }
    }
}
