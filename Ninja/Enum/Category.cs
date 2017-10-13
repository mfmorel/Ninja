using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.Enum
{
    public class Category
    {
        public enum ECategory
        {
            Head,
            Shoulder,
            Chest,
            Belt,
            Legs,
            Boots
        }

        public static ObservableCollection<string> GetCategories()
        {
            var cats = new ObservableCollection<string>();
            foreach (var cat in typeof(ECategory).GetEnumValues())
            {
                cats.Add(cat.ToString());
            }
            return cats;
        }
    }
}
