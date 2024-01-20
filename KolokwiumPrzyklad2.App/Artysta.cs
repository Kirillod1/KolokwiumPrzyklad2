using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumPrzyklad2.App
{
    public class Artysta
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AlbumId { get; set; }
        private static int Count = 0;

        public Artysta()
        {
            Id = ++Count;
        }
            

    }
}
