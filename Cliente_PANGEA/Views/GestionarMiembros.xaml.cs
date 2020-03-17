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
using DataAccess;
using Cliente_PANGEA.Controllers;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for GestionarMiembros.xaml
    /// </summary>
    public partial class GestionarMiembros : Page
    {
        CrearComite pageCrearComite;
        List<Cuentas> listMembers = new List<Cuentas>();
        List<Cuentas> listleaderCommittee = new List<Cuentas>();
        List<Cuentas> listStaff;
        int IdCommittee;
        public GestionarMiembros(CrearComite crearComite, int Id, List<Cuentas> listleader, List<Cuentas> listMembers)
        {
            InitializeComponent();
            this.pageCrearComite = crearComite;
            this.IdCommittee = Id;
            this.listleaderCommittee = listleader;
            this.listMembers = listMembers;
            GetStaffAvailable();
            LoadStaffAvailable();
            LoadStaffCommittee();
            LoadLeaderCommittee();
        }

        public void GetStaffAvailable()
        {
            listStaff = PersonalController.GetAvailableStaff(1);
            
        }
        public void LoadStaffAvailable()
        {
            list_personal.ItemsSource = null;
            list_personal.ItemsSource = listStaff;
        }
        public void LoadStaffCommittee()
        {
            list_miembrosComite.ItemsSource = null;
            list_miembrosComite.ItemsSource = listMembers;

        }
        public void LoadLeaderCommittee()
        {
            list_liderComite.ItemsSource = null;
            list_liderComite.ItemsSource = listleaderCommittee;
        }
        

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this.pageCrearComite);
            //UpdatePageCrearComite();
        }

        private void btn_agregarMiembro_Click(object sender, RoutedEventArgs e)
        {
            if(list_personal.SelectedItems.Count > 0)
            {
                Cuentas cuenta = (Cuentas)list_personal.SelectedItem;
                listMembers.Add(cuenta);
                listStaff.Remove(cuenta);
                LoadStaffCommittee();
                LoadStaffAvailable();
                Console.WriteLine($"Miembros del comité: {listMembers.Count}");
                
            }
            else
            {
                MessageBox.Show("Selecciona a un personal antes de agregarlo");
            }
           
        }

        private void btn_agregarLider_Click(object sender, RoutedEventArgs e)
        {
            if (list_personal.SelectedItems.Count > 0)
            {
                if (listleaderCommittee.Count < 1)
                {
                    Cuentas cuenta = (Cuentas)list_personal.SelectedItem;
                    listleaderCommittee.Add(cuenta);
                    listStaff.Remove(cuenta);
                    LoadLeaderCommittee();
                    LoadStaffAvailable();
                }
                else
                {
                    MessageBox.Show("Solo puede haber un líder de comité al mismo tiempo");
                }
                

            }
            else
            {
                MessageBox.Show("Selecciona a un personal antes de agregarlo");
            }
        }

        private void btn_eliminarMiembro_Click(object sender, RoutedEventArgs e)
        {
            if (list_miembrosComite.SelectedItems.Count > 0)
            {
                Cuentas cuenta = (Cuentas)list_miembrosComite.SelectedItem;
                listMembers.Remove(cuenta);
                listStaff.Add(cuenta);
                LoadStaffCommittee();
                LoadStaffAvailable();

            }
            else
            {
                MessageBox.Show("Selecciona a un miembro antes de quitarlo");
            }
        }

        private void btn_eliminarLider_Click(object sender, RoutedEventArgs e)
        {
            if (list_liderComite.SelectedItems.Count > 0)
            {
                Cuentas cuenta = (Cuentas)list_liderComite.SelectedItem;
                listleaderCommittee.Remove(cuenta);
                listStaff.Add(cuenta);
                LoadLeaderCommittee();
                LoadStaffAvailable();

            }
            else
            {
                MessageBox.Show("Selecciona al lider antes de quitarlo");
            }
        }
        public bool UpdateListMembersCommittee()
        {

            int result = PersonalController.UpdateAssignmentsStaff(this.listleaderCommittee, true, "Líder", this.IdCommittee);
            if(result > -1)
            {
                result = PersonalController.UpdateAssignmentsStaff(this.listMembers, true, "Miembro", this.IdCommittee);
                if(result > -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool UpdateListStaff()
        {
            int result = PersonalController.UpdateAssignmentsStaff(this.listStaff, false, null, 0);
            if (result > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdatePageCrearComite()
        {
            this.pageCrearComite.list_leader.ItemsSource = null;
            this.pageCrearComite.list_leader.ItemsSource = this.listleaderCommittee;
            this.pageCrearComite.list_members.ItemsSource = null;
            this.pageCrearComite.list_members.ItemsSource = this.listMembers;
        }
        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if(UpdateListMembersCommittee() && UpdateListStaff())
            {
                MessageBox.Show("Se guardaron con éxito las asignaciones");
                UpdatePageCrearComite();
                this.NavigationService.Navigate(this.pageCrearComite);
            }
            else
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }
    }
}
