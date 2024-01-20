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
using System.Windows.Shapes;

namespace KolokwiumPrzyklad2.App
{
    /// <summary>
    /// Logika interakcji dla klasy AddArtistWindow.xaml
    /// </summary>
    public partial class AddArtistWindow : Window
    {
        public Album WybranyAlbum { get; set; }
        public AddArtistWindow(Album album = null)
        {
            WybranyAlbum = album;
            InitializeComponent();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            if (
                 !Regex.IsMatch(FirstNameTB.Text, @"^\p{Lu}\p{Ll}{1,20}$") ||
                 !Regex.IsMatch(LastNameTB.Text, @"^\p{Lu}\p{Ll}{1,20}$") 
                 
                 )
            {
                MessageBox.Show("Wprowadzone dane są niepoprawne.");
                return;
            };
            Artysta artysta = new Artysta
            {
                FirstName = FirstNameTB.Text,
                LastName = LastNameTB.Text,
                AlbumId=WybranyAlbum.Id,
            };
            using (AlbumDbContext db = new AlbumDbContext())
            {
                db.Artysci.Add(artysta);
                db.SaveChanges();
            }
                
                DialogResult = true; 
        }
    }
}
