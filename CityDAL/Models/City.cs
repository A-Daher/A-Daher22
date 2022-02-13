using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityDAL.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
