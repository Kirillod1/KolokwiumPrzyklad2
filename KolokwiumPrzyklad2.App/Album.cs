using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumPrzyklad2.App
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa {  get; set; }
        public string Gatunek {  get; set; }
        public DateTime Data { get; set; }
        public string Year => Data.Year.ToString();
        public string Artists=> string.Join(",", Artysci.Select(a=>$"{a.FirstName} {a.LastName}"));

        public List<Artysta> Artysci { get; set; }
        public Album()
        {
            Artysci = new List<Artysta>();
        }
        public bool HasArtists() { return Artysci != null && Artysci.Any(); }
    }
}
