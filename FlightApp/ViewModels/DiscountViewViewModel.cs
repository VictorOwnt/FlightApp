using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class DiscountViewViewModel : BindableBase
    {
        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        private readonly ProductService productService = new ProductService();
        private Dictionary<int, Product> changedProducts = new Dictionary<int, Product>();

        public DiscountViewViewModel()
        {
            SetAllProductsAsync();
        }
        public async void SetAllProductsAsync()
        {
            try
            {
                Products = await productService.GetAllProductsAsync();
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }

        }

        public void SetDiscountPercentage(Product product, double discountPercentage)
        {
            Product ProductToChange = Products.FirstOrDefault(p => p == product);
            ProductToChange.DiscountPercentage = discountPercentage;
            if (!changedProducts.ContainsKey(ProductToChange.ProductId))
            {
                changedProducts.Add(ProductToChange.ProductId, ProductToChange);
            }
            else
            {
                changedProducts[ProductToChange.ProductId] = ProductToChange;
            }

        }

        public async void SaveDiscountChanges()
        {
            if (changedProducts.Count() != 0)
            {
                try
                {
                    productService.SaveDiscountChanges(changedProducts.Values.ToList());
                }
                catch
                {
                    await DialogService.ShowCustomMessageAsync("Could not save your changes. Please check your internet connection and try again.", "Error saving changes");
                }

            }

        }
    }
}
