using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Models
{
    public class Product : INotifyPropertyChanged // Explicit implementation because DiscountPercentage notifies PriceToString()
    {
        public int ProductId { get; set; }

        private string _name;
        public string Name
        {
            get => _name.First().ToString().ToUpper() + _name.Substring(1);
            set => _name = value;
        }
        public string ImagePath { get; set; }

        public double BasePrice { get; set; }

        private double _discountPercentage;

        public event PropertyChangedEventHandler PropertyChanged;

        public double DiscountPercentage
        {

            get { return _discountPercentage; }
            set { _discountPercentage = value; OnPropertyChanged("PriceToString"); }
        }

        // private double _price;
        public double Price
        {
            get
            {
                if (DiscountPercentage == 0)
                {
                    return BasePrice;
                }
                else if (DiscountPercentage == 100)
                {
                    return 0;
                }
                else
                {
                    return BasePrice * ((100 - DiscountPercentage) / 100);
                }
            }
        }

        public string PriceToString()
        {
            return "€" + Math.Round(Price, 2).ToString();
        }
        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
