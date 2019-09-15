using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class RepositoryDBInitializer : CreateDatabaseIfNotExists<RepositoryContext>
    {
        protected override void Seed(RepositoryContext context)
        {
            IList<Door> doors = new List<Door>();

            doors.Add(new Door() { Name = "Door A" });
            doors.Add(new Door() { Name = "Door B" });
            doors.Add(new Door() { Name = "Door C" });
            doors.Add(new Door() { Name = "Door D" });
            doors.Add(new Door() { Name = "Door E" });

            context.Doors.AddRange(doors);

            base.Seed(context);
        }
    }
}
