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
        Comites comiteUpdate;
        List<Cuentas> listMembers = new List<Cuentas>();
        List<Cuentas> listLeader = new List<Cuentas>();
        bool isNew = true;
        int IDEVENT = SingletonEvent.GetEvent().Id;
        String rolLiderComitee = "Lider Comite";
        String rolMemberComitee = "Miembro";

        public CrearComite(Comites comite)
        {
            InitializeComponent();

            isNew = false;
            comiteUpdate = comite;
            LoadMembersCommittee(IDEVENT, comiteUpdate.Id);
            btn_eliminar.Visibility = Visibility.Visible;
            LoadFields();
            
        }
        public CrearComite()
        {
            InitializeComponent();
            btn_eliminar.Visibility = Visibility.Hidden;
        }

        public void LoadMembersCommittee(int idEvent, int idCommittee)
        {
            this.listMembers = PersonalController.GetMembersCommittee(idEvent, idCommittee, rolMemberComitee);
            this.listLeader = PersonalController.GetMembersCommittee(idEvent, idCommittee, rolLiderComitee);
            list_leader.ItemsSource = this.listLeader;
            list_members.ItemsSource = this.listMembers;

        }
        public void LoadFields()
        {
            txt_nombreComite.Text = comiteUpdate.Nombre;
            txt_descripcionComite.Text = comiteUpdate.Descripcion;
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

       public int UpdateCommittee(string name, string description)
       {
            int result = -1;
            comiteUpdate.Nombre = name;
            comiteUpdate.Descripcion = description;
            result = ComiteController.UpdateCommittee(comiteUpdate);
            return result;

       }

        public int SaveCommittee(string name, string description, int idEvent)
        {
            int result = -1;
            if (!ComiteController.ExistingCommittee(name))
            {
                DataAccess.Comites comite = new Comites
                {
                    Nombre = name,
                    Descripcion = description,
                    FechaCreacion = DateTime.Now,
                    IdEvento = idEvent
                };
                result = ComiteController.SaveCommittee(comite);
                if(result > 0)
                {
                    this.comiteUpdate = this.comiteUpdate = ComiteController.GetLastCommittee();
                    isNew = false;
                    btn_eliminar.Visibility = Visibility.Visible;
                }
                
            }
            else
            {
                result = -2;
            }

            return result;
        }
        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (!EmptyFields())
            {
                if (CorrectFields())
                {
                    if (isNew)
                    {
                        result = SaveCommittee(txt_nombreComite.Text, txt_descripcionComite.Text, IDEVENT);
                        if (result > 0)
                        {
                            isNew = false;
                            MessageBox.Show("Se guardo con éxito el comité");
                        }
                        else if (result == -2)
                        {
                            MessageBox.Show("Hay un comité registrado con el mismo nombre");
                        }
                        else if(result == -1)
                        {
                            MessageBox.Show("Error en la conexión a la BD");
                        }
                        
                    }
                    else
                    {
                        result = UpdateCommittee(txt_nombreComite.Text, txt_descripcionComite.Text);
                        if (result > 0)
                        {
                            isNew = false;
                            MessageBox.Show("Se actualizo con éxito el comité");
                        }
                        else
                        {
                            MessageBox.Show("Error en la conexión a la BD");
                        }
                    }
                }
            }
        }


        private void btn_gestionarMiembros_Click(object sender, RoutedEventArgs e)
        {
            if(!EmptyFields() && CorrectFields())
            {
                int result;
                if (isNew)
                {
                    result = SaveCommittee(txt_nombreComite.Text, txt_descripcionComite.Text, IDEVENT);
                }
                else
                {
                    result = UpdateCommittee(txt_nombreComite.Text, txt_descripcionComite.Text);
                }
                if(result > -1)
                {
                    this.NavigationService.Navigate(new GestionarMiembros(this.comiteUpdate));
                }
                else if (result == -2)
                {
                    MessageBox.Show("Hay un comité registrado con el mismo nombre");
                }
                else if(result == -1)
                {
                    MessageBox.Show("Error en la conexión a la BD");
                }

            }
            

        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowCommittee());
        }

        

        private void btn_eliminar_Click_1(object sender, RoutedEventArgs e)
        {
            
            var dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar el comité, " +
                "también se eliminaran las asignaciones del personal asociadas?", 
                "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if(dialogResult == MessageBoxResult.Yes)
            {
                if (PersonalController.DeleteAssignmetsByCommittee(this.comiteUpdate.Id))
                {
                    if (ComiteController.DeleteCommittee(this.comiteUpdate.Id))
                    {
                        MessageBox.Show("Se elimino el registro");
                        this.NavigationService.Navigate(new ShowCommittee());
                    }
                    else
                    {
                        MessageBox.Show("Error en la conexión a la BD");
                    }
                }
                else
                {
                    MessageBox.Show("Error en la conexión a la BD");
                }
            }

        }


    }
}
