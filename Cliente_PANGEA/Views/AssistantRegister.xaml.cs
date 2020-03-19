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
using System.Text.RegularExpressions;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para AssistantRegister.xaml
    /// </summary>
    public partial class AssistantRegister : Page
    {
        public AssistantRegister()
        {
            InitializeComponent();
        }

        private void btn_AssistantRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_AssignActovity(object sender, RoutedEventArgs e)
        {

        }
        private void ValidateText(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text == "")
            {
                return;
            }
            if (!Regex.IsMatch(textbox.Text, @"[A-Za-z0-9\s]+$"))
            {
                MessageBox.Show("Por favor ingresa información válida en los campos.");
                textbox.Clear();
            }
        }
    }
}
