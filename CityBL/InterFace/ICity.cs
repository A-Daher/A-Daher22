using CityDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBL.InterFace
{
    public interface ICity
    {

        IEnumerable<City> GetAllCities();
        City GetCity(int id);
        City AddCity(City c);
        City UpdateCity(City c);
         
        City DeleteCity(City c);
    }
}
