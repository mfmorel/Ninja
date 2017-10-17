using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninja.Model.Interfaces;

namespace Ninja.Model
{
    class EquipmentRepository : IEquipment
    {
        public List<Ninja_equipment> GetEquipment(int ninjaId)
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninja_equipment.Where(n => n.NinjaId.Equals(ninjaId)).ToList();
            }
        }

        public List<Ninja_equipment> GetEquipments()
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninja_equipment.ToList();
            }
        }

        public void DeleteEquipment(int ninjaId, int armourId)
        {
            Ninja_equipment equipmentToDelete = GetEquipment(ninjaId, armourId);

            using (var context = new NinjaEntities())
            {
                context.Entry(equipmentToDelete).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Ninja_equipment GetEquipment(int ninjaId, int armourId)
        {
            using (var context = new NinjaEntities())
            {
                return context.Ninja_equipment.First(n => n.NinjaId.Equals(ninjaId) && n.ArmourId.Equals(armourId));
            }
        }
    }
}
