using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class Passenger : Person
    {
        [Required]
        public int SeatNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PassengerContact> Contacts { get; set; }
        //public ICollection<PassengerContact> ContactOf { get; set; }
        public Passenger()
        {
            Orders = new List<Order>();
        }

        public IEnumerable<Product> GetOrderedProducts()
        {
            List<Product> products = new List<Product>();
            foreach (Order order in Orders)
            {
                foreach (Orderline orderline in order.Orderlines)
                {
                    products.Add(orderline.Product);
                }
            }
            return products;
        }

        public ICollection<Order> FilterOrdersOnDelivery(bool delivery)
        {
            List<Order> filteredOrders = new List<Order>();
            foreach (Order order in Orders)
            {
                if (order.IsDelivered == delivery)
                {
                    filteredOrders.Add(order);
                }
            }
            return filteredOrders;
        }

        public IEnumerable<ChatMessage> GetChatsWithContact(string contactEmail)
        {
            //TODO: try to simplify
            List<ChatMessage> messages = new List<ChatMessage>();
            foreach (PassengerContact passengerContact in Contacts)
            {
                if (passengerContact.Contact.Email == contactEmail)
                {
                    foreach (ChatMessage chatMessage in passengerContact.ChatMessages)
                    {
                        messages.Add(chatMessage);
                    }

                    foreach (PassengerContact passengerContact1 in passengerContact.Contact.Contacts)
                    {
                        if (passengerContact1.Passenger.Email == contactEmail)
                        {
                            foreach (ChatMessage chatMessage in passengerContact1.ChatMessages)
                            {
                                messages.Add(chatMessage);
                            }
                        }
                    }
                }
            }

            return messages;
        }

        // public IList<Announcement> ReceivedAnnouncements { get; set; }
    }
}
