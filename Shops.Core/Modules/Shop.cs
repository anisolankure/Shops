using System.Collections.Generic;

namespace Shops.Core.Modules
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Item> Items { get; set; }
    }
}