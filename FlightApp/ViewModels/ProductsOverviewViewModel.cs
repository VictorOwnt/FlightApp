using FlightApp.DataService;
using FlightApp.Models;
using Prism.Mvvm;
using System.Collections.Generic;

namespace FlightApp.ViewModels
{
    public class ProductsOverviewViewModel : BindableBase
    {
        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }
        private double _totalCost;
        public double TotalCost
        {
            get { return _totalCost; }
            set { SetProperty(ref _totalCost, value); }
        }
        public HashSet<Product> SelectedProducts { get; set; } = new HashSet<Product>();

        private readonly ProductService productService = new ProductService();

        public async void SetProductsOfCategoryAsync(string categoryName)
        {
            Products = await productService.GetProductsOfCategory(categoryName);
        }

        public async void OrderProducts(List<Product> products)
        {
            await productService.OrderProductsAsync(products);
        }

        public async void GetOrderedProductsAsync()
        {
            Products = await productService.GetOrderedProductsAsync();

        }

        public async void SetAllProductsAsync()
        {
            Products = await productService.GetAllProductsAsync();
        }

        public string TotalCostToString(double totalCost)
        {
            return "Total cost:" + " €" + totalCost;
        }

        public void ChangeSelectedProducts(Product selectedProduct)
        {
            if (SelectedProducts.Contains(selectedProduct))
            {
                SelectedProducts.Remove(selectedProduct);
                TotalCost -= selectedProduct.Price;
            }
            else
            {
                SelectedProducts.Add(selectedProduct);
                TotalCost += selectedProduct.Price;
            }
        }
    }
}
