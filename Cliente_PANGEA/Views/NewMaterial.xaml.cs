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
    /// Interaction logic for NewMaterial.xaml
    /// </summary>
    public partial class NewMaterial : Page
    {
        int IDEVENT = SingletonEvent.GetEvent().Id;
        List<Actividades> listActivities = new List<Actividades>();
        Materiales materialUpdated;
        bool isNew = false;
        public NewMaterial()
        {
            InitializeComponent();
            btn_delete.Visibility = Visibility.Hidden;
            LoadActivities();
            isNew = true;

        }
        public NewMaterial(Materiales material)
        {
            InitializeComponent();
            materialUpdated = material;
            LoadMaterial();

        }

        private void LoadMaterial()
        {
            txt_name.Text = materialUpdated.Nombre;
            txt_description.Text = materialUpdated.Descripcion;
            txt_quantity.Text = materialUpdated.Cantidad.ToString();
            listActivities.Add(materialUpdated.Actividades);
            cb_activities.ItemsSource = listActivities;
            cb_activities.SelectedItem = listActivities[0];
            cb_activities.IsEditable = false;
            cb_activities.IsEnabled = false;

        }
        private void LoadActivities()
        {
            listActivities = ActivityController.GetAllActivities(IDEVENT);
            cb_activities.ItemsSource = listActivities;
        }
        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowMaterials());
        }

        private bool EmptyFields()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                result = true;
            }
            if (string.IsNullOrEmpty(txt_description.Text))
            {
                result = true;
            }
            if (string.IsNullOrEmpty(txt_quantity.Text))
            {
                result = true;
            }
            if (cb_activities.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccionar la actividad a la que pertenece la tarea");
                result = true;
            }

            return result;
        }
        private bool isNumber(string number)
        {
            bool result = true;
            if (!int.TryParse(number, out int num))
            {
                
                result = false;
            }

            return result;
        }
        private void SaveMaterial()
        {
            int quantity = int.Parse(txt_quantity.Text);
            Actividades act = (Actividades)cb_activities.SelectedItem;
            int result = MaterialsController.SaveMaterial(txt_name.Text, txt_description.Text, quantity, IDEVENT, act.Id);
            if (result >= 0)
            {
                MessageBox.Show("Se guardo con éxito el material");
                this.NavigationService.Navigate(new ShowMaterials());
            }
            else if (result == -1)
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }
        private void UpdateMaterial()
        {
            int quantity = int.Parse(txt_quantity.Text);
            int result = MaterialsController.UpdateMaterial(txt_name.Text, txt_description.Text, quantity, materialUpdated.Id);
            if (result >= 0)
            {
                MessageBox.Show("Se actualizo con éxito el material");
                this.NavigationService.Navigate(new ShowMaterials());
            }
            else
            {
                MessageBox.Show("Error en la conexión a la BD");
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (!EmptyFields())
            {
                if (isNumber(txt_quantity.Text))
                {
                    if (isNew)
                    {
                        SaveMaterial();
                    }
                    else
                    {
                        UpdateMaterial();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingresar solo números");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresar todos los campos");
            }
        }

        private void btn_goBack_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowMaterials());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = MessageBox.Show("¿Estás seguro de eliminar este material? ",
                "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (dialogResult == MessageBoxResult.Yes)
            {
                if (MaterialsController.DeleteMaterial(materialUpdated.Id))
                {
                    MessageBox.Show("Se eliminó el material con éxito");
                    this.NavigationService.Navigate(new ShowMaterials());
                }
                else
                {
                    MessageBox.Show("Error en la conexión a la BD");
                }
            }
        }
    }
}
