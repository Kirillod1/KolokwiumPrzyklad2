using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace KolokwiumPrzyklad2.App
{
    /// <summary>
    /// Logika interakcji dla klasy AddAlbumWindow.xaml
    /// </summary>
    public partial class AddAlbumWindow : Window
    {
        public Album Album { get; set; }

        public AddAlbumWindow(Album album=null)
        {

            InitializeComponent();
            if (album != null)
            {
                Album = album;
                NameTB.Text = album.Nazwa;
                GenreTB.Text = album.Gatunek;
                YearTB.Text = album.Data.ToString();

            }
            else
            {
                Album = new Album();
                Album.Artysci = new List<Artysta>();
            };
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            if (
                 NameTB.Text != null ||
                 !Regex.IsMatch(GenreTB.Text, @"^\p{Lu}\p{Ll}{1,20}$") ||
                 YearTB.SelectedDate > DateTime.Now
                 )
            {
                MessageBox.Show("Wprowadzone dane są niepoprawne.");
                return;
            };
            Album.Nazwa = NameTB.Text;
            Album.Gatunek = GenreTB.Text;
            Album.Data = YearTB.SelectedDate.Value;
            using (AlbumDbContext db = new AlbumDbContext())
            {
                db.Albumy.Add(Album);
                db.SaveChanges();
            }
                
                DialogResult = true; 
        }
    }
}
