using Cliente_PANGEA.Controllers;
using DataAccess;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.Win32;
using System;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for EventProgram.xaml
    /// </summary>
    public partial class EventProgram : Page
        
    {
        List<Horarios> activities;
        
        public EventProgram()
        {
            InitializeComponent();
            LoadTable();
        }

        private void LoadTable()
        {
            activities = ActivityController.GetActivities(SingletonEvent.GetEvent().Id);
            ListView_eventProgram.ItemsSource = activities;
           
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainEvent());
        }

        private void Button_PDF_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            if (!String.IsNullOrEmpty(saveFileDialog.FileName))
            {



                FileStream fileStream = new FileStream(saveFileDialog.FileName + ".pdf", FileMode.Create);

                Document doc = new Document();
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();

                Paragraph title = new Paragraph();
                title.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18f, Color.BLACK);
                title.Add("Programa Del Evento: " + SingletonEvent.GetEvent().Nombre);
                title.Alignment = 1;
                doc.Add(title);

                foreach (Horarios horario in activities)
                {
                    Paragraph titleActivity = new Paragraph();
                    titleActivity.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f, Color.BLUE);
                    titleActivity.Add("\n" + horario.Actividades.Titulo);
                    doc.Add(titleActivity);

                    Paragraph infoActvity = new Paragraph();
                    infoActvity.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f, Color.BLACK);
                    infoActvity.Add("Fecha Inicio: " + horario.FechaInicio + "\nFecha fin: " + horario.FechaFin +
                        "\nLugar: " + horario.Lugar + "\nDirección: " + horario.Direccion + "\nDescripción: " +
                        horario.Actividades.Descripcion + "\nTipo: " + horario.Actividades.Tipo + "\nCosto: " +
                        horario.Actividades.Costo);
                    doc.Add(infoActvity);

                }



                doc.Close();
                System.Diagnostics.Process.Start(saveFileDialog.FileName + ".pdf");

            }

        }
    }
}
