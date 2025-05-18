using InventoryApp.Domain.Models;
using InventoryApp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.EntityFramework.Services
{
    public class GenericDataServices : IDataService<Inventory>
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericDataServices(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Inventory> Create(Inventory entity)
        {
            await _dbContext.Inventories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity =await _dbContext.Inventories.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _dbContext.Inventories.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<Inventory> Get(int id)
        {
            var entity= await _dbContext.Inventories.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<List<Inventory>> GetAll()
        {
            var entity = await _dbContext.Inventories.ToListAsync();
            return entity;
        }

        public async Task<Inventory> Update(int id, Inventory entity)
        {
            _dbContext.Inventories.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
