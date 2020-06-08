using Cliente_PANGEA.Controllers;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewFinancialConcept.xaml
    /// </summary>
    public partial class NewFinancialConcept : Page
    {
        Presupuestos budget;
        public NewFinancialConcept(Presupuestos budget)
        {
            this.budget = budget;
            InitializeComponent();
            LoadComboBoxActivities();
        }

        private void LoadComboBoxActivities()
        {
            ComboBox_activities.ItemsSource = ActivityController.GetAllActivities(SingletonEvent.GetEvent().Id);
        }

        private void Button_save_click(object sender, RoutedEventArgs  e)
        {
            if (!ValidateEmptyFields())
            {
                MessageBox.Show("Por favor ingrese información en todos los campos");
            }
            else if (!ValidateTotal())
            {
                MessageBox.Show("Por favor ingrese una cantidad correcta");
            } else if (!CorrectFields()){
                MessageBox.Show("El campo concepto contienen caracteres invalidos");
            }
            else if (AddConcept() < 0)
            {
                MessageBox.Show("Error al conextarse con la base de datos");
            } else
            {
                MessageBox.Show("Concepto financiero agregado con exito");
                ClearFields();
            }


        }

        public bool CorrectFields()
        {

            bool result = true;
            Regex regexName = new Regex(@"^[a-zA-ZÁáÀàÉéÈèÍíÌìÓóÒòÚúÙùÑñüÜ0-9-,-. ]+$");
            if (!regexName.IsMatch(TextBox_concept.Text))
            {
                result = false;
            }
           
            return result;
        }

        private void ClearFields()
        {
            TextBox_concept.Text = String.Empty;
            TextBox_total.Text = String.Empty;
            ComboBox_activities.Text = String.Empty;
            ComboBox_type.Text = String.Empty;
        }

        private int AddConcept()
        {
   
            ConceptosFinancieros concept = new ConceptosFinancieros();
            Actividades activity = (Actividades)ComboBox_activities.SelectedItem;
            concept.IdActividad = activity.Id;
            concept.Tipo = ComboBox_type.Text;
            concept.Monto = Double.Parse(TextBox_total.Text);
            concept.IdPresupuesto = budget.Id;
            concept.Fecha_creacion = DateTime.Now;
            concept.Concepto = TextBox_concept.Text;

            return FinancialConceptController.NewFinancialConcept(concept);

        }
        private bool ValidateTotal()
        {
            double total = 0;
            bool isValid = true;
            if (!Double.TryParse(TextBox_total.Text, out total))
            {
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateEmptyFields()
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(TextBox_concept.Text))
            {
                isValid = false;
            } else if(String.IsNullOrEmpty(TextBox_total.Text))
            {
                isValid = false;
            } else if(ComboBox_type.SelectedItem == null)
            {
                isValid = false;
            }else if(ComboBox_activities.SelectedItem == null)
            {
                isValid = false;
            }

            return isValid;
        }

        private void Button_regresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewBudget());
        }
    }
}
