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
    /// Lógica de interacción para ShowCommittee.xaml
    /// </summary>
    public partial class ShowCommittee : Page
    {
        int IDEVENT = SingletonEvent.GetEvent().Id;
        string rolLeaderCommitee = "Lider Comite";
        public ShowCommittee()
        {
            InitializeComponent();
            if (SingletonPersonal.GetPersonal().Cargo == rolLeaderCommitee)
            {
                btn_newCommittee.Visibility = Visibility.Hidden;
                txt_nameCreateCommitte.Visibility = Visibility.Hidden;
            }
            showCommittee();
            
        }

        private void btn_newCommittee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CrearComite());
        }
        private void showCommittee()
        {
            List<Comites> listComites;
            if (SingletonPersonal.GetPersonal().Cargo == rolLeaderCommitee)
            {
                int idCommitte = SingletonPersonal.GetPersonal().IdComite.GetValueOrDefault(-1);
                listComites = new List<Comites>();
                Comites comites = ComiteController.GetCommitte(idCommitte);
                listComites.Add(comites);
            }
            else
            {
                listComites = ComiteController.GetAllCommitte(IDEVENT);
            }
            

            listViewCommittee.ItemsSource = listComites;


        }

        private void listViewCommittee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewCommittee.SelectedItems.Count > 0)
            {
                Comites commite = (Comites)listViewCommittee.SelectedItem;
                this.NavigationService.Navigate(new CrearComite(commite));
            }
        }
    }
}
