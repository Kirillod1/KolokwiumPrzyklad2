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

namespace KolokwiumPrzyklad2.App
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataGridAlbumy.AutoGenerateColumns = false;
            WczytajAlbumy();
        }

        public void WczytajAlbumy()
        {
            using(AlbumDbContext db = new AlbumDbContext())
            {
                var Albumy = db.Albumy.Include("Artysci").ToList();
                DataGridAlbumy.ItemsSource = Albumy;
            }
        }

        private void addAlbumBT_Click(object sender, RoutedEventArgs e)
        {
            AddAlbumWindow addAlbumWindow=new AddAlbumWindow();
            if(addAlbumWindow.ShowDialog()==true)
            {
                WczytajAlbumy();
            }
        }

        private void addArtistBT_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAlbumy.SelectedItem is Album wybranyAlbum)
            {
                AddArtistWindow addArtistWindow = new AddArtistWindow(wybranyAlbum);
                if (addArtistWindow.ShowDialog() == true)
                {
                    WczytajAlbumy();
                }


            }
            else
                MessageBox.Show("Album nie został wybrany");
        }

        private void DeleteAlbumBT_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAlbumy.SelectedItem is Album wybranyAlbum)
            {
                using (AlbumDbContext db = new AlbumDbContext())
                {
                    var albumToRemove = db.Albumy.Include("Artysci").Single(f => f.Id == wybranyAlbum.Id);

                    if (albumToRemove != null)
                    {
                        if (albumToRemove.HasArtists())
                        {
                            foreach (var artysta in albumToRemove.Artysci.ToList())
                            {
                                db.Artysci.Remove(artysta);
                            }
                        }

                        db.Albumy.Remove(albumToRemove);
                        db.SaveChanges();
                        WczytajAlbumy();
                    }
                }
            }

            else
            {
                MessageBox.Show("Album nie został wybrany!");
                return;
            }
        }
    }

}
