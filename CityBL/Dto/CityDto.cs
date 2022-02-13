using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CityBL.Dto
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
