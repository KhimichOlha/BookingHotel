using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfases
{
    public interface IGuestRepository
    {
        Guest GetById(int id);
        void Add(Guest guest);
        void Update(Guest guest);
        IEnumerable<Guest> GetAll();
       

    }
}
