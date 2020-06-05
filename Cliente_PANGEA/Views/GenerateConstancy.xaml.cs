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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Lógica de interacción para GenerateConstancy.xaml
    /// </summary>
    public partial class GenerateConstancy : Page
    {
        AsistentesEvento assistantEvent;
        int idEvent = SingletonEvent.GetEvent().Id;
        List<IncripcionActividades> listIncriptionActivities = new List<IncripcionActividades>();
        public GenerateConstancy(AsistentesEvento asistentesEvento)
        {
            assistantEvent = asistentesEvento;
            InitializeComponent();
            LoadIncriptionActivitiesAssistant(assistantEvent.IdAsistente);
            LoadAssistantEvent(assistantEvent.IdAsistente);
        }
        private void LoadAssistantEvent(int idAssitant)
        {
            listView_Asistente.ItemsSource = AsistentesEventoController.GetEventAssistant(idAssitant);
        }
        private void LoadIncriptionActivitiesAssistant(int idAssistant)
        {
            listIncriptionActivities = GetListIncriptionActivitiesValidated(idAssistant);
            if (ValidateLoadAssistantEventActivities())
                listView_Activities.ItemsSource = AsistentesEventoController.GetAssistantActivitiesEvent(listIncriptionActivities);
            
        }

        private List<IncripcionActividades> GetListIncriptionActivitiesValidated(int idAssistant)
        {
            if (AsistentesEventoController.GetListEventIncriptionOfAssistantWithAssitanceValidate(idAssistant)!=null)
            {
                return AsistentesEventoController.GetListEventIncriptionOfAssistantWithAssitanceValidate(idAssistant);
            }
            MessageBox.Show("Error de conexión con la base de datos");
            return null;
        }
        private bool ValidateLoadAssistantEventActivities()
        {
            if (AsistentesEventoController.GetAssistantActivitiesEvent(listIncriptionActivities)!=null)
            {
                return true;
            }
            MessageBox.Show("Error de conexión con la base de datos.");
            return false;
        }
        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ValidateAssistance(assistantEvent));
        }
        private bool ValidateActivitySelection()
        {
            if (listView_Activities.SelectedItems.Count >0)
            {
                return true;
            }
            MessageBox.Show("Favor de seleccionar una actividad");
            return false;
        }
        private IncripcionActividades GetIncriptionActivitySelected()
        {
            IncripcionActividades incriptionActivity = (IncripcionActividades)listView_Activities.SelectedItem;
            return incriptionActivity;
        }
        private void btn_GenerateActivityConstancy_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateActivitySelection())
            {
                if (GetIncriptionActivitySelected()!=null)
                {
                    IncripcionActividades incripcionActividades = GetIncriptionActivitySelected();
                    Document document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                    PdfWriter.GetInstance(document, new FileStream("ConstanciaActividad" + assistantEvent.Asistentes.Nombre + assistantEvent.Asistentes.Apellido +incripcionActividades.Actividades.Titulo+ ".pdf", FileMode.Create));
                    document.Open();

                    iTextSharp.text.Paragraph assistantName = GetAssistantName();
                    iTextSharp.text.Paragraph titleUniversity = GetTititleUniversity();
                    iTextSharp.text.Paragraph constancy = GetConstnacyName();
                    iTextSharp.text.Image imageUv = GetImageLogUv();
                    iTextSharp.text.Image imagefei = GetImageFei();
                    iTextSharp.text.Paragraph description = GetAssistanceDescription();

                    iTextSharp.text.Paragraph activityName = new iTextSharp.text.Paragraph();
                    activityName.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 28f, iTextSharp.text.Color.BLACK);
                    activityName.Add("\n\n" + incripcionActividades.Actividades.Tipo + " " + incripcionActividades.Actividades.Titulo);
                    activityName.Alignment = 1;

                    iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph();
                    date.Font = FontFactory.GetFont(FontFactory.HELVETICA, 24f, iTextSharp.text.Color.BLACK);
                    date.Add("\n"+incripcionActividades.Actividades.FechaCreacion.ToShortDateString());
                    date.Alignment = 1;

                    document.Add(imageUv);
                    document.Add(imagefei);
                    document.Add(titleUniversity);
                    document.Add(constancy);
                    document.Add(assistantName);
                    document.Add(description);
                    document.Add(activityName);
                    document.Add(date);
                    
                    document.Close();

                    System.Diagnostics.Process.Start("ConstanciaActividad" + assistantEvent.Asistentes.Nombre + assistantEvent.Asistentes.Apellido + incripcionActividades.Actividades.Titulo + ".pdf");
                }
            }
        }

        private void btn_GenerateEventConstancy_Click(object sender, RoutedEventArgs e)
        {
            Document document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
            PdfWriter.GetInstance(document, new FileStream("ConstanciaEvento" + assistantEvent.Asistentes.Nombre + assistantEvent.Asistentes.Apellido + ".pdf", FileMode.Create));
            document.Open();

            iTextSharp.text.Paragraph assistantName = GetAssistantName();
            iTextSharp.text.Paragraph titleUniversity = GetTititleUniversity();
            iTextSharp.text.Paragraph constancy = GetConstnacyName();
            iTextSharp.text.Image imageUv = GetImageLogUv();
            iTextSharp.text.Image imagefei = GetImageFei();
            iTextSharp.text.Paragraph description = GetAssistanceDescription();

            iTextSharp.text.Paragraph nameEvent = new iTextSharp.text.Paragraph();
            nameEvent.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24f, iTextSharp.text.Color.BLACK);
            nameEvent.Add("\n"+SingletonEvent.GetEvent().Nombre);
            nameEvent.Alignment = 1;

            iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph();
            date.Font = FontFactory.GetFont(FontFactory.HELVETICA, 24f, iTextSharp.text.Color.BLACK);
            date.Add("\nDel " + SingletonEvent.GetEvent().FechaFin.ToShortDateString()+" al "+ SingletonEvent.GetEvent().FechaFin.ToShortDateString());
            date.Alignment = 1;

            document.Add(imageUv);
            document.Add(imagefei);
            document.Add(titleUniversity);
            document.Add(constancy);
            document.Add(assistantName);
            document.Add(description);
            document.Add(nameEvent);
            document.Add(date);
            document.Close();
            System.Diagnostics.Process.Start("ConstanciaEvento" + assistantEvent.Asistentes.Nombre +assistantEvent.Asistentes.Apellido +".pdf");
        }

        private iTextSharp.text.Paragraph GetAssistantName()
        {
            iTextSharp.text.Paragraph assistantName = new iTextSharp.text.Paragraph();
            assistantName.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 28f, iTextSharp.text.Color.BLACK);
            assistantName.Add("\n" + assistantEvent.Asistentes.Apellido + " " + assistantEvent.Asistentes.Nombre + " ");
            assistantName.Alignment = 1;
            return assistantName;
        }
        private iTextSharp.text.Paragraph GetTititleUniversity()
        {
            iTextSharp.text.Paragraph titleUniversity = new iTextSharp.text.Paragraph();
            titleUniversity.Font = FontFactory.GetFont(FontFactory.HELVETICA, 16f, iTextSharp.text.Color.BLACK);
            titleUniversity.Add("\nLa Universidad Veracruzana, a traves de la Facultad de Estadística e Informática" + "\nOtorga la presente ");
            titleUniversity.Alignment = 1;
            return titleUniversity;
        }
        private iTextSharp.text.Paragraph GetConstnacyName()
        {
            iTextSharp.text.Paragraph constancy = new iTextSharp.text.Paragraph();
            constancy.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 24f, iTextSharp.text.Color.BLACK);
            constancy.Add("\n\nCONSTANCIA " + "\n\n a: ");
            constancy.Alignment = 1;
            return constancy;
        }
        private iTextSharp.text.Image GetImageLogUv()
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"C:\Users\IvanGutru\Desktop\SextoSemestre\2.-DesarrolloDeSoftware\PANGEA\Cliente_PANGEA\Resources\img\logoUv.png");
            image.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            image.ScaleToFit(150, 150);
            return image;
        }
        private iTextSharp.text.Image GetImageFei()
        {
            iTextSharp.text.Image imagefei = iTextSharp.text.Image.GetInstance(@"C:\Users\IvanGutru\Desktop\SextoSemestre\2.-DesarrolloDeSoftware\PANGEA\Cliente_PANGEA\Resources\img\fei.png");
            imagefei.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            imagefei.ScaleToFit(150, 150);
            imagefei.SetAbsolutePosition(670, 450);
            return imagefei;
        }
        private iTextSharp.text.Paragraph GetAssistanceDescription()
        {
            iTextSharp.text.Paragraph description = new iTextSharp.text.Paragraph();
            description.Font = FontFactory.GetFont(FontFactory.HELVETICA, 20f, iTextSharp.text.Color.BLACK);
            description.Add("\n\nPor su asistencia a ");
            description.Alignment = 1;
            return description;
        }
    }
}
