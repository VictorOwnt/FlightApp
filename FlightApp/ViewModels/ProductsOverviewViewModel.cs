using FlightApp.DataService;
using FlightApp.Models;
using FlightApp.Util;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace FlightApp.ViewModels
{
    public class ProductsOverviewViewModel : BindableBase
    {

        #region fields and properties
        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        private Dictionary<int, Product> _discountedProductsDictionary;
        private IEnumerable<Product> _discountedProducts;
        public IEnumerable<Product> DiscountedProducts
        {
            get { return _discountedProducts; }
            set { SetProperty(ref _discountedProducts, value); }
        }
        private double _totalCost;
        public double TotalCost
        {
            get { return _totalCost; }
            set { SetProperty(ref _totalCost, value); }
        }

        private string _discountHeaderString;
        public string DiscountHeaderString
        {
            get { return _discountHeaderString; }
            set { SetProperty(ref _discountHeaderString, value); }
        }
        public HashSet<Product> SelectedProducts { get; set; } = new HashSet<Product>();

        private readonly ProductService productService = new ProductService();

        #endregion
        #region methods

        public ProductsOverviewViewModel()
        {
            _discountedProductsDictionary = new Dictionary<int, Product>();
        }
        public async void SetProductsOfCategoryAsync(string categoryName)
        {
            try
            {
                Products = await productService.GetProductsOfCategory(categoryName);
            }
            catch
            {
                await DialogService.ShowDefaultErrorMessageAsync();
            }

            SetDiscountedProducts();
            ResetOrder();
        }

        private void SetDiscountedProducts()
        {
            foreach (Product product in Products)
            {
                if (product.DiscountPercentage != 0 && !_discountedProductsDictionary.ContainsKey(product.ProductId))
                {
                    _discountedProductsDictionary.Add(product.ProductId, product);
                }
                else if (product.DiscountPercentage == 0 && _discountedProductsDictionary.ContainsKey(product.ProductId))
                {
                    _discountedProductsDictionary.Remove(product.ProductId);
                }

            }
            DiscountedProducts = _discountedProductsDictionary.Values;
            if (_discountedProductsDictionary.Count == 0)
            {
                DiscountHeaderString = "There are no sales actually.";
            }
            else
            {
                DiscountHeaderString = "Here are the current sales: ";
            }
        }

        public async void OrderProducts(List<Product> products)
        {
            try
            {
                await productService.OrderProductsAsync(products);
            }
            catch
            {
                await DialogService.ShowCustomMessageAsync("Something went wrong, couldn't order these products. Please try again later", "Order error");
            }
            finally
            {
                await DialogService.ShowCustomMessageAsync("Your products were successfully ordered", "Products ordered");
            }

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

            SetDiscountedProducts();
            ResetOrder();
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

        private void ResetOrder()
        {
            TotalCost = 0;
            SelectedProducts = new HashSet<Product>();
        }
        #endregion
    }

}
