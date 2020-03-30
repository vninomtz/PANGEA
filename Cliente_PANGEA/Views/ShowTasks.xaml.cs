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
using DataAccess;
using Cliente_PANGEA.Controllers;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for ShowTasks.xaml
    /// </summary>
    public partial class ShowTasks : Page
    {
        List<Tareas> listTasks = new List<Tareas>();
        int IDEVENT = SingletonEvent.GetEvent().Id;
        public ShowTasks()
        {
            InitializeComponent();
            LoadTasks();
        }

        public void LoadTasks()
        {
            listTasks = TaskController.GetAllTasks(IDEVENT);
            listView_tasks.ItemsSource = this.listTasks;
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            List<Tareas> listAux = new List<Tareas>();
            
            string findWord = txt_search.Text;
            if(findWord == "")
            {
                listView_tasks.ItemsSource = null;
                listView_tasks.ItemsSource = listTasks;
            }
            else
            {
                listAux.Clear();
                foreach (var item in listTasks)
                {
                    bool contains = item.Actividades.Titulo.Contains(findWord);
                    if (contains)
                    {
                        listAux.Add(item);
                    }
                }
                listView_tasks.ItemsSource = null;
                listView_tasks.ItemsSource = listAux;
            }
            

        }
    }
}
