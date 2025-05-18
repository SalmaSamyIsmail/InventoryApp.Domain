using InventoryApp.Domain.Models;
using InventoryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for DetailsInventoryView.xaml
    /// </summary>
    public partial class DetailsInventoryView : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly Inventory _inventory;
        public DetailsInventoryView(MainViewModel mainViewModel,Inventory inventory)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            _inventory = inventory;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Text = _inventory.Id.ToString();
            txtName.Text = _inventory.Name;
            txtCategory.Text = _inventory.Category;
            txtOrginalStock.Text = _inventory.OriginalStock.ToString();
            txtStock.Text = _inventory.Stock.ToString();
            txtDateModified.Text=_inventory.LastUpdatedDate.ToString();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Name and Category are required.");
                return;
            }

            int originalStock, stock;
            if (!int.TryParse(txtOrginalStock.Text, out originalStock) || !int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Invalid stock values. Please enter valid numbers.");
                return;
            }

            if (originalStock < 0 || stock < 0)
            {
                MessageBox.Show("Stock values cannot be negative.");
                return;
            }

            var inventory= new Inventory();

            inventory.Id = _inventory.Id;
            inventory.Name = txtName.Text;
            inventory.Category = txtCategory.Text;
             inventory.OriginalStock = int.Parse(txtOrginalStock.Text);
            inventory.Stock = int.Parse(txtStock.Text);
            inventory.LastUpdatedDate= DateTime.Now;

            _viewModel.Update(inventory);

            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Delete(_inventory.Id);
            this.Close();
        }
    }
}
