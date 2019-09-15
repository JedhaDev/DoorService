using Repository.Context;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class DoorRepository : BaseRepository<Door>, IDoorRepository
    {
        public DoorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public Door GetById(int id)
        {
            return FindByCondition(door => door.Id == id)
                .FirstOrDefault();
        }

        public void UpdateById(int id, bool status)
        {
            Door door = GetById(id);

            door.Status = status;
            Update(door);
        }
    }
}
