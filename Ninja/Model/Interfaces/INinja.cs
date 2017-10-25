using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.Enum;
using Ninja.ViewModel;

namespace Ninja.Model
{
    interface INinja
    {
        List<Domain.Ninja> GetNinjas();

        void DeleteNinja(int id);

        Domain.Ninja GetNinja(int id);

        bool UpdateNinja(Domain.Ninja ninja);

        void Reset(int ninjaId);
    }
}
