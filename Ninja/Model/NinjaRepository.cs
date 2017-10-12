using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninja.ViewModel;

namespace Ninja.Model
{
    class NinjaRepository : INinja
    {
        public void DeleteNinja(string name)
        {
            Domain.Ninja ninjatodelete = GetNinja(name);

            using (var context2 = new NinjaEntities())
            {
                context2.Entry(ninjatodelete).State = System.Data.Entity.EntityState.Deleted;
                context2.SaveChanges();
            }
        }

        public Domain.Ninja GetNinja(string name)
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninjas.FirstOrDefault(s => s.Name == name);
            }
        }

        public List<Domain.Ninja> GetNinjas()
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninjas.ToList();
            }
        }

    }
}
