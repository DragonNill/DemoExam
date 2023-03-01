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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ООО__Ткани_.Models;

namespace ООО__Ткани_.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        Product currentProduct;

        public ProductsControl(Product product)
        {
            InitializeComponent();
            currentProduct = product;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ProductNameLabel.Content = currentProduct.ProductName;
            ProdutDescriptionLabel.Content = currentProduct.ProductDescription;
            ProductManufacturerLabel.Content = "Производитель: " + currentProduct.ProductManufacturer;

            ProductCostLabel.Content = "Цена: " + currentProduct.ProductCost.ToString();

            ProductDiscountLabel.Content = "Наличие: " + currentProduct.ProductQuantityInStock;

            LoadImage();
        }
        
        private void LoadImage()
        {
            if (!string.IsNullOrWhiteSpace(currentProduct.ProductPhoto) && currentProduct.ProductPhoto != null)
            {
                ProductImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                    "Images/", currentProduct.ProductPhoto), UriKind.Absolute));
            }
            else
            {
                ProductImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                    "Images/picture.png"), UriKind.Absolute));
            }
        }
    }
}
