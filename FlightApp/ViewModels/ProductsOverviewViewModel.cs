using FlightApp.DataService;
using FlightApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private readonly ProductService productService = new ProductService();

        public ProductsOverviewViewModel()
        {
            //TODO start with getAllProducts
        }

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
    }
}
