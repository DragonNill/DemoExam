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
using ООО__Ткани_.Windows;
using ООО__Ткани_.Models;
using ООО__Ткани_.UserControls;

namespace ООО__Ткани_.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowListProducts.xaml
    /// </summary>
    public partial class ShowListProducts : Window
    {
        User currentUser;

        public ShowListProducts(User user)
        {
            InitializeComponent();

            currentUser = user;
        }

        private void FillComboBox()
        {
            FilterComboBox.Items.Add("Все производители");
            foreach(string ManufacturerName in TradeNerContext.DbContext.Manufacturers.Select(s => s.ManufacturerName).ToList())
            {
                FilterComboBox.Items.Add(ManufacturerName);
            }

            SortingComboBox.Items.Add("Без сортировки");
            SortingComboBox.Items.Add("↑ Цена");
            SortingComboBox.Items.Add("↓ Цена");
            SortingComboBox.Items.Add("↑ Наименования");
            SortingComboBox.Items.Add("↓ Наименования");

            SortingComboBox.SelectedIndex = 0;
            FilterComboBox.SelectedIndex = 0;
        }

        private void FillListView()
        {
            ProductsListView.Items.Clear();

            List<Product> listPrdoucts = TradeNerContext.DbContext.Products.ToList();

            if (!string.IsNullOrWhiteSpace(FindTextBox.Text))
            {
                listPrdoucts = listPrdoucts.Where(w => w.ProductName.ToLower().
                Contains(FindTextBox.Text.ToLower())).ToList();
            }

            switch (SortingComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    listPrdoucts = listPrdoucts.OrderBy(s => s.ProductCost).ToList();
                    break;
                case 2:
                    listPrdoucts = listPrdoucts.OrderByDescending(s => s.ProductCost).ToList();
                    break;
                case 3:
                    listPrdoucts = listPrdoucts.OrderBy(s => s.ProductName).ToList();
                    break;
                case 4:
                    listPrdoucts = listPrdoucts.OrderByDescending(s => s.ProductName).ToList();
                    break;
            }

            foreach (string ManufacturerName in TradeNerContext.DbContext.Manufacturers.Select(s => s.ManufacturerName).ToList())
            {
                if(FilterComboBox.SelectedIndex == 0)
                { }
                else
                {
                    listPrdoucts = listPrdoucts.Where(w => w.ProductManufacturer.ManufacturerName == FilterComboBox.SelectedItem).ToList();
                }
            }

            foreach (Product product in listPrdoucts)
            {
                ProductsListView.Items.Add(new ProductsControl(product)
                {
                    Width = GetOprimizedWidth()
                });
            }

            CountProductsLabel.Content = listPrdoucts.Count + " из " + TradeNerContext.DbContext.Products.Count();

            if (listPrdoucts.Count == 0)
            {
                MessageBox.Show("Товары по вашему запросу не найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private double GetOprimizedWidth()
        {
            if (WindowState == WindowState.Maximized)
            {
                return RenderSize.Width - 55;
            }
            else
            {
                return Width - 55;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillListView();

        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListView();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillListView();
        }

        private void SortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillListView();
        }
    }
}
