using Cliente_PANGEA.Controllers;
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
using System.Windows.Shapes;

namespace Cliente_PANGEA
{
    /// <summary>
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : Window
    {
        public Events()
        {
            InitializeComponent();
            centralFrame.Navigate(new ShowEvents());
            centralFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Button_account.Content = SingletonAccount.GetAccount().Correo;
            Button_account.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            centralFrame.Navigate(new NewEvent());

        }

       

      

        
    }
}
