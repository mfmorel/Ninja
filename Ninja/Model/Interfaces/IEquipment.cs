using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Ninja.Model.Interfaces
{
    interface IEquipment
    {
        List<Ninja_equipment> GetEquipments();
        List<Ninja_equipment> GetEquipment(int ninjaId);
        Ninja_equipment GetEquipment(int ninjaId, int armourId);
        void DeleteEquipment(int ninjaId, int armourId);
        List<Ninja_equipment> GetEquipmentByNinjaId(int ninjaId);
        void DeleteEquipmentByNinja(int ninjaId);
    }
}
