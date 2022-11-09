using CountdownTimer.Business.ApiResponses;
using System.Threading.Tasks;

namespace CountdownTimer.Services
{
    public interface IInventoryService
    {
        GetInventoryResponse GetInventory();
    }
}