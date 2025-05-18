using InventoryApp.Domain.Models;
using InventoryApp.EntityFramework;
using InventoryApp.EntityFramework.Services;
using InventoryApp.WPF.ViewModels;
using InventoryApp.WPF.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Inventory> inventories { get; set; }
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            inventories = new ObservableCollection<Inventory>(_viewModel.GetInventories().ToList());

        }

        private void btnNewInventory_Click(object sender, RoutedEventArgs e)
        {
            NewInventoryView newWindow = new NewInventoryView(_viewModel);
            newWindow.Show();
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            InvetoryListView.ItemsSource = inventories;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetAllInvetories();
            txtSearchName.Text = string.Empty;

            cmbStock.SelectedValue = 0;
        }

        private void GetAllInvetories()
        {
            inventories = new ObservableCollection<Inventory>(_viewModel.GetInventories().ToList());
            InvetoryListView.ItemsSource = inventories;
        }

        private void InvetoryListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (InvetoryListView.SelectedItem is Inventory selectedInventory)
            {
                DetailsInventoryView newWindow = new DetailsInventoryView(_viewModel, selectedInventory);
                newWindow.Show();
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedId = cmbStock.SelectedValue?.ToString() ?? "0";

            Func<Inventory, bool> filter = selectedId switch
            {
                "1" => x => x.Stock > 0,
                "2" => x => x.Stock < x.OriginalStock / 2,
                "3" => x => x.Stock == 0,
                _ => x => true // Default case
            };

            inventories = new ObservableCollection<Inventory>(
                _viewModel.GetInventories().Where(x => filter(x) &&
                (string.IsNullOrEmpty(txtSearchName.Text) || x.Name.Contains(txtSearchName.Text)))
            );

            InvetoryListView.ItemsSource = inventories;
        }

    }
}