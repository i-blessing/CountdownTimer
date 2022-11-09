using CountdownTimer.Business.ApiResponses;
using CountdownTimer.Data;
using CountdownTimer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IItemRepository _repo;

        public InventoryService(IItemRepository repository)
        {
            _repo = repository;
        }

        public GetInventoryResponse GetInventory()
        {
            var response = new GetInventoryResponse();

            response.Inventory = new Business.Dto.Inventory();
            response.Inventory.Items = _repo.GetAll().Select(i => new Business.Dto.Item { Id = i.Id, Count = i.Count, Description = i.Description }).ToList();

            return response;
        }
    }
}
