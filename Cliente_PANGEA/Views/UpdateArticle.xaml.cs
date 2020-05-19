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
using Microsoft.Win32;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para UpdateArticle.xaml
    /// </summary>
    public partial class UpdateArticle : Page
    {
        private List<Actividades> listActivities = new List<Actividades>();
        Actividades activityUpdate; 
        
        
        public UpdateArticle(Actividades activityOfArticle)
        {
            activityUpdate = activityOfArticle;
            InitializeComponent();
            LoadFields(activityUpdate);
            int idTrack = activityUpdate.Articulos.idTrack;
            listActivities.Add(activityUpdate);
            LoadTrack(idTrack);
            LoadActivity(listActivities);
            DisableFields();

        }
        private void LoadFields(Actividades activity)
        {
            txt_ArticleName.Text = activity.Articulos.nombre;
            txt_ArticleAutor.Text = activity.Articulos.autor;
            TextBox_articleDescription.Text = activity.Articulos.descripcion;
            textblock_Archivo.Text = activity.Articulos.archivo;
            btn_guardar.IsEnabled = false;
        }
        private void LoadActivity(List<Actividades> activities)
        {
            listView_Activities.ItemsSource = activities;
        }
        private void LoadTrack(int idTrack)
        {
            if (ArticleController.GetTrackById(idTrack) != null)
            {
                listView_Tracks.ItemsSource = ArticleController.GetTrackById(idTrack);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }
        private void DisableFields()
        {
            txt_ArticleName.IsEnabled = false;
            txt_ArticleAutor.IsEnabled = false;
            TextBox_articleDescription.IsEnabled = false;
            subirArchivo.IsEnabled = false;
            Button_edit.Visibility = Visibility.Visible;
        }
        private void EnableFields()
        {
            subirArchivo.IsEnabled = true;
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowArticle());
        }
        private bool ValidateUpdate(Actividades actividades)
        {
            if (ArticleController.UpdateArticleInActivity(actividades)>0)
            {
                return true;
            }
            MessageBox.Show("Error de conexión con la base de datos");
            return false;
        }
        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
          
            String file = textblock_Archivo.Text;
            activityUpdate.Articulos.archivo = file;
            if (ValidateUpdate(activityUpdate))
            {
                MessageBox.Show("Articulo actualizado con éxito");
                LoadFields(activityUpdate);
                DisableFields();
            }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Formato de archivos ¨(*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                textblock_Archivo.Text = openFileDialog.FileName;
            }
        }
        private void Button_edit_Click(object sender, RoutedEventArgs e)
        {
            EnableFields();
            Button_edit.Visibility = Visibility.Hidden;
            btn_guardar.IsEnabled = true;
        }
    }
}
