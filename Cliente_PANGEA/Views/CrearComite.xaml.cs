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
using DataAccess;
using Cliente_PANGEA.Controllers;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for CrearComite.xaml
    /// </summary>
    public partial class CrearComite : Page
    {
        public CrearComite()
        {
            InitializeComponent();
            
        }

        public void ShowMessageError(string type, string message)
        {
            MessageBox.Show($"{type}: por favor corregir el campo {message}");
        }
        public bool EmptyFields()
        {
            string errorType = "Campos vacíos";
            bool result = false;
            if (string.IsNullOrEmpty(txt_nombreComite.Text))
            {
                ShowMessageError(errorType, "Nombre de comité");
                result = true;
            }
            if (string.IsNullOrEmpty(txt_descripcionComite.Text))
            {
                ShowMessageError(errorType, "Descripción de comité");
                result = true;
            }

            return result;
        }

        public bool CorrectFields()
        {
            string typeError = "Campo inválido";
            bool result = true;
            Regex regexName = new Regex(@"^[a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9 ]+$");
            if (!regexName.IsMatch(txt_nombreComite.Text))
            {
                ShowMessageError(typeError, "Nombre comité");
                result = false;
            }
            Regex regexDescription = new Regex(@"^[\r\n a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9 !@#\$%\&\*\?¿._~\/]+$");
            if (!regexDescription.IsMatch(txt_descripcionComite.Text))
            {
                ShowMessageError(typeError, "Descripción comité");
                result = false;
            }
            return result;
        }

       


        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                if (CorrectFields())
                {
                    if (!ComiteController.ExistingCommittee(txt_nombreComite.Text))
                    {
                        DataAccess.Comites comite = new Comites
                        {
                            Nombre = txt_nombreComite.Text,
                            Descripcion = txt_descripcionComite.Text,
                            FechaCreacion = DateTime.Now
                        };
                        int result = ComiteController.SaveCommittee(comite);
                        if(result > 0)
                        {
                            MessageBox.Show("Se guardo con éxito el Comité");

                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el comité");
                        }
                    }
                }
            }
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowCommittee());
        }
    }
}
