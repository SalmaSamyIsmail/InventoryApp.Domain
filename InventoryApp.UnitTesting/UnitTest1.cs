using InventoryApp.Domain.Models;
using InventoryApp.EntityFramework;
using InventoryApp.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryApp.UnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                        .UseSqlServer("Server=DESKTOP-CJ2TM4F\\SQLEXPRESS;Database=InventoryDB;User Id=sa2;Password=1234567;Encrypt=True;TrustServerCertificate=True;")
                        .Options;

            using var context = new ApplicationDBContext(options);
            var viewModel = new MainViewModel(context);

            var inventory = new Inventory
            {
                Name = "Test Item",
                Stock = 10,
                Category = "Category 3",
                OriginalStock = 50,
                LastUpdatedDate = DateTime.Now
            };

            viewModel.Create(inventory);

            var existingInventory = context.Inventories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == inventory.Id);
            Assert.True(existingInventory != null);
        }

        [Fact]
        public void Test2()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                        .UseSqlServer("Server=DESKTOP-CJ2TM4F\\SQLEXPRESS;Database=InventoryDB;User Id=sa2;Password=1234567;Encrypt=True;TrustServerCertificate=True;")
                        .Options;

            using var context = new ApplicationDBContext(options);
            var viewModel = new MainViewModel(context);

            var inventory = new Inventory
            {
                Id=1,
                Name = "Test Item",
                Stock = 10,
                Category = "Category 2",
                OriginalStock = 50,
                LastUpdatedDate = DateTime.Now
            };

            viewModel.Update(inventory);

            var existingInventory = context.Inventories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == inventory.Id);
            Assert.True(existingInventory != null);
        }
    }
}
