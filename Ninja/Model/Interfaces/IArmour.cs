using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.Model.Interfaces
{
    interface IArmour
    {
        List<Domain.Armour> GetArmours();

        void DeleteArmour(int id);

        Domain.Armour GetArmour(int id);

        bool UpdateArmour(Domain.Armour armour);
    }
}
