using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IDoorRepository : IBaseRepository<Door>
    {
        Door GetById(int id);
        void UpdateById(int id, bool status);
    }
}
