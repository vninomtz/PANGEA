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
    /// Lógica de interacción para RegisterActivityAssistant.xaml
    /// </summary>
    public partial class RegisterActivityAssistant : Page
    {
        public RegisterActivityAssistant()
        {
            InitializeComponent();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AssistantRegister());
        }
        private void btn_RegsiterActivityAssistant_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}
