using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninja.Enum;
using Ninja.Model.Interfaces;
using Ninja.ViewModel;
using Ninja = Domain.Ninja;

namespace Ninja.Model
{
    class NinjaRepository : INinja
    {
        public void DeleteNinja(int id)
        {
            Domain.Ninja ninjatodelete = GetNinja(id);

            IEquipment equipment = new EquipmentRepository();
            equipment.DeleteEquipmentByNinja(id);

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

        public void Reset(int ninjaId)
        {
            Domain.Ninja ninja = GetNinja(ninjaId);
            ninja.Head = null;
            ninja.Belt = null;
            ninja.Boots = null;
            ninja.Chest = null;
            ninja.Legs = null;
            ninja.Shoulder = null;
            UpdateNinja(ninja);
        }
    }
}
