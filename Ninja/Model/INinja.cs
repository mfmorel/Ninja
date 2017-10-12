using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.ViewModel;

namespace Ninja.Model
{
    interface INinja
    {
        List<Domain.Ninja> GetNinjas();
        void DeleteNinja(String name);
        Domain.Ninja GetNinja(String name);
    }
}
