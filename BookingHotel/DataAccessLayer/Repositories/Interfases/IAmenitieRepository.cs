using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfases
{
    public interface IAmenitieRepository
    {
        IEnumerable<Amenity> GetAll();
    }
}
