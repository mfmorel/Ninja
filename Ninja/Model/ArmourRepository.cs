using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninja.Model.Interfaces;
using Ninja.ViewModel;

namespace Ninja.Model
{
    class ArmourRepository : IArmour
    {
        public List<Domain.Armour> GetArmours()
        {
            using (var context = new NinjaEntities())
            {
                return context.Armours.ToList();
            }
        }

        public void DeleteArmour(int id)
        {
            Domain.Armour ninjatodelete = GetArmour(id);

            using (var context = new NinjaEntities())
            {
                context.Entry(ninjatodelete).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Domain.Armour GetArmour(int id)
        {
            using (var context = new NinjaEntities())
            {
                return context.Armours.FirstOrDefault(s => s.Id == id);
            }
        }

        public bool UpdateArmour(Domain.Armour armour)
        {
            using (var context = new NinjaEntities())
            {
                context.Entry(armour).State = EntityState.Modified;
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static List<Domain.Armour> GetArmourByCategory(Enum.Category.ECategory category)
        {
            using (var context = new NinjaEntities())
            {
                return context.Armours.Where(c => c.Category == category.ToString()).ToList();
            }
        }
    }
}
