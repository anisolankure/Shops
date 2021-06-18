using System;

namespace Shops.Core.Modules
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual int ShopId { get; set; }
        public DateTime ExpiryDateTime { get; set; }
    }
}