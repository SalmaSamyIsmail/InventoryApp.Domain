using InventoryApp.Domain.Models;
using InventoryApp.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WPF.ViewModels
{
    public class MainViewModel 
    {
        private readonly ApplicationDBContext _context;

        public MainViewModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Inventory> GetInventories()
        {
            return  _context.Inventories.Skip(0).Take(100).AsNoTracking().ToList();
        }

        public async Task<Inventory> Create(Inventory inventory)
        {
            await _context.Inventories.AddAsync(inventory);
            await _context.SaveChangesAsync();

            return inventory;
        }

        public async Task<Inventory> Update(Inventory entity)
        {
            await _context.Inventories.Where(u => u.Id == entity.Id)
        .ExecuteUpdateAsync(inv => inv
        .SetProperty(u => u.Name, entity.Name)
        .SetProperty(u => u.Category, entity.Category)
                .SetProperty(u => u.Stock, entity.Stock)
                .SetProperty(u => u.LastUpdatedDate, DateTime.Now));
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Inventories.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _context.Inventories.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
