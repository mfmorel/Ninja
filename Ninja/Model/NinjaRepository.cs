using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninja.Enum;
using Ninja.ViewModel;

namespace Ninja.Model
{
    class NinjaRepository : INinja
    {
        public void DeleteNinja(int id)
        {
            Domain.Ninja ninjatodelete = GetNinja(id);

            using (var context = new NinjaEntities())
            {
                context.Entry(ninjatodelete).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Domain.Ninja GetNinja(int id)
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninjas.FirstOrDefault(s => s.Id == id);
            }
        }

        public bool UpdateNinja(Domain.Ninja ninja)
        {
            using (var context = new NinjaEntities())
            {
                context.Entry(ninja).State = EntityState.Modified;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public List<Domain.Ninja> GetNinjas()
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninjas.ToList();
            }
        }

        public void AddArmour(NinjaEquipmentViewModel armour, Category.ECategory category)
        {

        }
    }
}
