using Cliente_PANGEA.Controllers;
using DataAccess;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Cliente_PANGEA.Views
{
    /// <summary>
    /// Interaction logic for TrackManagment.xaml
    /// </summary>
    public partial class TrackManagment : Page
    {
        public TrackManagment()
        {
            InitializeComponent();
            LoadTracksTable();
        }

        private void LoadTracksTable()
        {
            ListView_tracks.ItemsSource = TrackController.GetTracks(SingletonEvent.GetEvent().Id);
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (AreThereEmptyFields())
            {
                MessageBox.Show("Por favor ingresar información en todos los campos");
            }
            else if (SaveTrack() == -1)
            {
                MessageBox.Show("Error en la conexión con la base de datos");
            }
            else
            {
                MessageBox.Show("Track guardado correctamente");
                LoadTracksTable();
            }
        }

        private bool AreThereEmptyFields()
        {
            bool areThere = false;

            if (String.IsNullOrEmpty(TextBox_nombreTrack.Text))
            {
                areThere = true;
            }
            else if (String.IsNullOrEmpty(TextBox_descripcionTrack.Text))
            {
                areThere = true;
            }

            return areThere;
        }

        private int SaveTrack()
        {
            Tracks newTrack = new Tracks
            {
                Nombre = TextBox_nombreTrack.Text,
                Descripcion = TextBox_descripcionTrack.Text
            };

            return TrackController.AddTrack(newTrack);

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

            
            if (ListView_tracks.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Por favor confirme la operación", "Advertencia", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var track = (Tracks)ListView_tracks.SelectedItem;
                    if (TrackController.DeleteTrack(track.Id) == -1)
                    {
                        MessageBox.Show("Error en la conexión con la base de datos");
                    }
                    else
                    {
                        MessageBox.Show("Track elimnado correctamente");
                        LoadTracksTable();
                    }
                }

                

            }
        }
    }
}
