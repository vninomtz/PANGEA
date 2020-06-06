using Microsoft.Win32;
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
    /// Lógica de interacción para RegisterArticle.xaml
    /// </summary>
    public partial class RegisterArticle : Page
    {
        int idEvent = SingletonEvent.GetEvent().Id;
        public RegisterArticle()
        {
            InitializeComponent();
            LoadTracks();
            LoadActivities();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Formato de archivos ¨(*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == true)
            {
                textblock_Archivo.Text = openFileDialog.FileName;
            }
        }

        private void LoadTracks()
        {
            if (ArticleController.GetEventTracks(idEvent) != null)
            {
                listView_Tracks.ItemsSource = ArticleController.GetEventTracks(idEvent);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }
        private void LoadActivities()
        {
            if (ActivityController.GetActivitiesWithNullArticle(idEvent)!=null)
            {
                listView_Activities.ItemsSource = ActivityController.GetActivitiesWithNullArticle(idEvent);
            }
            else
            {
                MessageBox.Show("Eror de conexión con la base de datos");
            }
        }
        private bool ValidateNotEmptyField()
        {
            if (txt_ArticleName.Text != "" && txt_ArticleAutor.Text !="" && TextBox_articleDescription.Text != "")
            {
                if (textblock_Archivo.Text == "")
                {
                    MessageBox.Show("Favor de adjuntar un archivo pdf");
                    return false;
                }
                return true;
            }
            MessageBox.Show("Por favor ingresa información en todos los campos");
            return false;
        }
        private bool ValidateSelectionTrack()
        {
            if (listView_Tracks.SelectedItems.Count >0)
            {
                return true;
            }
            MessageBox.Show("Por favor selecciona un track");
            return false;
        }
       private bool ValidateSelectionActivity()
        {
            if (listView_Activities.SelectedItems.Count>0)
            {
                return true;
            }
            MessageBox.Show("Por favor selecciona una actividad");
            return false;
        }
        private Articulos CreateArticle()
        {
            String articleAutor = txt_ArticleAutor.Text;
            String articleName = txt_ArticleName.Text;
            String articleDescripcion = TextBox_articleDescription.Text;
            String articleFile = textblock_Archivo.Text;

            Articulos articulos = new Articulos
            {
                nombre = articleName,
                autor = articleAutor,
                descripcion = articleDescripcion,
                archivo = articleFile,
                fecha_creacion = DateTime.Now,
                ultima_actualizacion = DateTime.Now
            };
            return articulos;
        }
        private int GetIdTrack()
        {
            Tracks tracks = (Tracks)listView_Tracks.SelectedItem;
            return tracks.Id;
        }
        private Actividades GetActivityOfTable()
        {
            Actividades activity = (Actividades)listView_Activities.SelectedItem;
            return activity;
        }
        private void SaveArticle(Articulos articulos, int idTrack)
        {
            if (ArticleController.SaveArticle(articulos,idTrack)<=0)
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }
        private int GetLastIdArticle()
        {
           int  idArticle = ArticleController.GetLastIdArticle();
            if (idArticle<=0)
            {
                
            }
            return idArticle;
        }
        private void SaveArticleInActivity(Actividades activity, int idArticle)
        {
            if (ArticleController.SaveArticleInActivity(activity,idArticle)>0)
            {
                MessageBox.Show("Artículo registrado con éxito");
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }
        private bool validateArticleRegisterIntracK(Articulos article, int idTrack)
        {
            if (ArticleController.ValidateRegisterArticleInTrack(article, idTrack))
            {
                MessageBox.Show("Artículo ya registrado en el track");
                return true;
            }
            return false;
        }
  
        private void CleanFlieds()
        {
            txt_ArticleName.Text = "";
            txt_ArticleAutor.Text = "";
            textblock_Archivo.Text = "";
            TextBox_articleDescription.Text = "";

        }
        private void btn_RegisterArticle_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateNotEmptyField() && ValidateSelectionTrack() && ValidateSelectionActivity())
            {
                Articulos article = CreateArticle();
                int idTrack = GetIdTrack();
                Actividades activity = GetActivityOfTable();

                if (!validateArticleRegisterIntracK(article,idTrack))
                {
                    SaveArticle(article, idTrack);
                    int idArticle = GetLastIdArticle();
                    SaveArticleInActivity(activity,idArticle);
                    CleanFlieds();
                }
               
            }
        }

        private void btn_TrackManage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TrackManagment());
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShowArticle());
        }

    }
}
