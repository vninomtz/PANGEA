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
    /// Lógica de interacción para ShowArticle.xaml
    /// </summary>
    public partial class ShowArticle : Page
    {
        int idEvent = SingletonEvent.GetEvent().Id;
        public ShowArticle()
        {
            InitializeComponent();
            LoadArticles();
        }

        private void LoadArticles()
        {
            if (ArticleController.GetArticlesEvent(idEvent)!=null)
            {
                listViewArticlesEvent.ItemsSource = ArticleController.GetArticlesEvent(idEvent);
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos");
            }
        }

        private void btn_RegisterArticle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterArticle());
        }

       
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            String articleName = txt_ArticleName.Text;
            if (ArticleController.GetArticlesByName(idEvent,articleName)!=null)
            {
                listViewArticlesEvent.ItemsSource = ArticleController.GetArticlesByName(idEvent,articleName);
            }
            else if(ArticleController.GetArticlesByName(idEvent, articleName).Count == 0)
            {
                MessageBox.Show("No existen artículos con el nombre ingresado");
            }
            else
            {
                MessageBox.Show("Error de conexión con la base de datos.");
            }
        }
        private void listViewArticlesEvent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewArticlesEvent.SelectedItems.Count > 0)
            {
                Actividades articleOfActivity = (Actividades)listViewArticlesEvent.SelectedItem;
                this.NavigationService.Navigate(new UpdateArticle(articleOfActivity));
            }
        }
      
    }
}
