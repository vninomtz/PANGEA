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

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para UpdateArticle.xaml
    /// </summary>
    public partial class UpdateArticle : Page
    {
        public UpdateArticle()
        {
            InitializeComponent();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterArticle());
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
