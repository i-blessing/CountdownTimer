using CountdownTimer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items;

        public ItemRepository()
        {
            _items = new List<Item>();
            _items.Add(new Item { Id = 1, Count = 2, Description = "Table" });
            _items.Add(new Item { Id = 2, Count = 18, Description = "Chair" });
        }

        public Item GetItem(int id)
        {
            return _items.Find(x => x.Id == id);
        }

        public List<Item> GetAll()
        {
            return _items;
        }
    }
}
