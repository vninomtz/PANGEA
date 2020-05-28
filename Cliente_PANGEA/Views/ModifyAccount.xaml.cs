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
    /// Interaction logic for ModifyAccount.xaml
    /// </summary>
    public partial class ModifyAccount : Page
    {
        public ModifyAccount()
        {
            InitializeComponent();
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
