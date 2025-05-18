using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services
{
    public interface IDataService<Inventory>
    {
        Task<List<Inventory>> GetAll();
        Task<Inventory> Get(int id);

        Task<bool> Delete(int id);
        Task<Inventory> Create(Inventory entity);
        Task<Inventory> Update(int id, Inventory entity);
    }
}
