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
    /// Interaction logic for ShowMaterials.xaml
    /// </summary>
    public partial class ShowMaterials : Page
    {
        int IDEVENT = SingletonEvent.GetEvent().Id;
        List<Materiales> listMaterials = new List<Materiales>(); 
        public ShowMaterials()
        {
            InitializeComponent();
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            listMaterials = MaterialsController.GetMaterials(IDEVENT);
            listView_Materials.ItemsSource = listMaterials;
        }

        private void btn_newMaterial_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NewMaterial());
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            List<Materiales> listAux = new List<Materiales>();

            string findWord = txt_search.Text;
            if (findWord == "")
            {
                listView_Materials.ItemsSource = null;
                listView_Materials.ItemsSource = listMaterials;
            }
            else
            {
                listAux.Clear();
                foreach (var item in listMaterials)
                {
                    bool containsActivity = item.Actividades.Titulo.Contains(findWord);
                    bool containsMaterial = item.Nombre.Contains(findWord);
                    if (containsActivity | containsMaterial)
                    {
                        listAux.Add(item);
                    }
                }
                listView_Materials.ItemsSource = null;
                listView_Materials.ItemsSource = listAux;
            }

        }

        private void listView_Materials_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listView_Materials.SelectedItems.Count > 0)
            {
                Materiales material = (Materiales)listView_Materials.SelectedItem;
                this.NavigationService.Navigate(new NewMaterial(material));
                
            }
        }
    }
}
