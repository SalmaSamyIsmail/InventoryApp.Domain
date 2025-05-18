using InventoryApp.Domain.Models;
using InventoryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NewInventoryView.xaml
    /// </summary>
    public partial class NewInventoryView : Window
    {
        public ObservableCollection<Inventory> inventories { get; set; }
        private readonly MainViewModel _viewModel;

        public NewInventoryView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
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

            var inventory = new Inventory
            {
                Name = txtName.Text,
                OriginalStock = int.Parse(txtOrginalStock.Text),
                Stock = int.Parse(txtStock.Text),
                LastUpdatedDate = DateTime.Now,
                Category = txtCategory.Text
            };

            _viewModel.Create(inventory);
            ClearControls();
            this.Close();
        }

        private void ClearControls()
        {
            txtName.Text = string.Empty;
            txtOrginalStock.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCategory.Text = string.Empty;
        }


    }
}
