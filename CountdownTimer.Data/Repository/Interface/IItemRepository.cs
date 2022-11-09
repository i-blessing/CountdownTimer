using CountdownTimer.Data.Entities;
using System.Collections.Generic;

namespace CountdownTimer.Data.Repository
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetItem(int id);
    }
}