using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumPrzyklad2.App
{
    internal class AlbumDbContext: DbContext
    {
        public DbSet<Album> Albumy { get; set; }
        public DbSet<Artysta> Artysci { get; set; }

        public AlbumDbContext() : base()
        {
            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Borys\\source\\repos\\KolokwiumPrzyklad2\\KolokwiumPrzyklad2.App\\Datebase\\Database1.mdf;Integrated Security=True";
            Database.Connection.ConnectionString= connection;
        }
    }
}
