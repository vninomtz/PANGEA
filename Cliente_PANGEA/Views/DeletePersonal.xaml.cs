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
    /// Lógica de interacción para DeletePersonal.xaml
    /// </summary>
    public partial class DeletePersonal : Page
    {
        int idEvent = SingletonEvent.GetEvent().Id;
        public DeletePersonal()
        {
            InitializeComponent();
            ShowPersonal();
        }

        private void btn_RegisterPersonal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PersonalRegister());
        }
 
        private void ShowPersonal()
        {
            if (PersonalController.GetPersonals(idEvent) != null)
            {
                listViewAccountsPersonal.ItemsSource = PersonalController.GetPersonals(idEvent);
            }
            else
            {
                MessageBox.Show("Error en la base de datos");
            }
           
        }
 
        private bool ValidateSelectedPersonal()
        {
            bool isSelected = true;
            if (listViewAccountsPersonal.SelectedValue == null)
            {
                isSelected = false;
            }
            return isSelected;
        }
        private void btn_DeletePersonal_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSelectedPersonal())
            {
                Personal personalSelected = (Personal)listViewAccountsPersonal.SelectedItem;
                MessageBoxResult messageBoxResult = MessageBox.Show("¿Está seguro de eliminar al personal seleccionado?", "Eliminar personal de evento", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    if (PersonalController.DeletePersonal(personalSelected.Id)>0)
                    {
                        MessageBox.Show("Personal eliminado con éxito","Operación exitosa");
                        ShowPersonal();
                    }
                    else
                    {
                        MessageBox.Show("Error en la conexión con la base de datos","Operación fallida");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un Personal");
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                string lastName = txt_lastName.Text;
                if (PersonalController.GetPersonalByLastName(lastName,idEvent).Count()>0)
                {
                    listViewAccountsPersonal.ItemsSource = PersonalController.GetPersonalByLastName(lastName,idEvent);     
                }
                else
                {
                    MessageBox.Show("No se encontraron registros con el apellido ingresado");
                }
            }
            
        }

        private Boolean EmptyFields()
        {
            if (txt_lastName.Text == "")
            {
                MessageBox.Show("Por favor ingresa los apellidos");
                ShowPersonal();
                return true;
            }
            return false;
        }
    }
}
