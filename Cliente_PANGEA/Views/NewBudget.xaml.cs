using Cliente_PANGEA.Controllers;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for NewBudget.xaml
    /// </summary>
    public partial class NewBudget : Page
    {

        private Presupuestos budgetObject;
        private List<ConceptosFinancieros> financialConcepts;
        public NewBudget()
        {
            
            InitializeComponent();
            HiddenButtons();
            LoadInformation();
            LoadFinancialConceptsTable();
            
            
            
        }

        public void LoadInformation()
        {
            budgetObject =  BudgetController.GetBudget(SingletonEvent.GetEvent().Id);
            String budget = budgetObject.Gasto_tentativo.ToString();
            
            if (budget == "-1")
            {
                budget = "0";
            }
            TextBox_tentativeExpense.Text = budget;
           
                      
        }

        public void LoadFinancialConceptsTable()
        {
            financialConcepts =  FinancialConceptController.GetFinancialConcepts(budgetObject.Id);
            ListView_concepts.ItemsSource = financialConcepts;
            TextBox_totalExpense.Text = CalculeExpense().ToString();
        }

        public double CalculeExpense()
        {
            double total = 0;

            foreach (var financialConcept in financialConcepts)
            {
                if (financialConcept.Tipo == "Egreso")
                {
                    total += financialConcept.Monto;
                }
                
            }

            return total;
        }


        public void HiddenButtons(){
            Button_editOff.Visibility = System.Windows.Visibility.Hidden;
            Button_save.Visibility = System.Windows.Visibility.Hidden;
            TextBox_tentativeExpense.IsEnabled = false;
            
        }

        private void Button_edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowButtons();
        }

        private void ShowButtons()
        {
            Button_editOff.Visibility = System.Windows.Visibility.Visible;
            Button_save.Visibility = System.Windows.Visibility.Visible;
            TextBox_tentativeExpense.IsEnabled = true;
        }

        private void Button_editOff_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HiddenButtons();
            TextBox_tentativeExpense.Text = String.Empty;
        }

        private void Button_save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            double budget;
            if (String.IsNullOrEmpty(TextBox_tentativeExpense.Text))
            {
                MessageBox.Show("Por favor ingresar información en el campo");
            } else if (!Double.TryParse(TextBox_tentativeExpense.Text,out budget))
            {
                MessageBox.Show("Por favor ingresar una cantidad correcta");
            }
            else if (AddBudget() == -1)
            {
                MessageBox.Show("Error en la conexión con la base de datos");
            }
            else
            {
                MessageBox.Show("Presupuesto guardado con éxito");
                HiddenButtons();
            }
            
        }

        private int AddBudget()
        {
            return BudgetController.UpdateBudget(budgetObject.Id, Double.Parse(TextBox_tentativeExpense.Text));

            
        }

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewFinancialConcept(budgetObject));
        }

       

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListView_concepts.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccionar un concepto de la tabla");
            } else if (!FinancialConceptController.DeleteConcept((ConceptosFinancieros)ListView_concepts.SelectedValue))
            {
                MessageBox.Show("Oucurrio un error al eliminar el concepto financiero");
            }else
            {
                MessageBox.Show("Se ha borrado el concepto financiero");
                LoadFinancialConceptsTable();

            }
        }

        
    }
}
