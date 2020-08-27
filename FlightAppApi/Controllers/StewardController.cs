using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FlightAppApi.DTO;
using FlightAppApi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAppApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Steward")]
    [Route("api/[controller]")]
    [ApiController]
    public class StewardController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStewardRepository _stewardRepository;
        private readonly IOrderRepository _orderRepository;


        public StewardController(IPassengerRepository passengerRepository, IProductRepository productRepository, IStewardRepository stewardRepository, IOrderRepository orderRepository)
        {
            _passengerRepository = passengerRepository;
            _productRepository = productRepository;
            _stewardRepository = stewardRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Change seats of the 2 passengers
        /// </summary>        
        [HttpPut("/api/steward/seat/change")]
        public IEnumerable<Passenger> ChangeSeats(SeatDTO seatDTO) // Use seatNumber or passenger name?
        {
            Passenger passenger1 = _passengerRepository.GetPassengerBySeatNumber(seatDTO.SeatNumber1);
            Passenger passenger2 = _passengerRepository.GetPassengerBySeatNumber(seatDTO.SeatNumber2);
            passenger1.SeatNumber = seatDTO.SeatNumber2;
            passenger2.SeatNumber = seatDTO.SeatNumber1;
            _passengerRepository.SaveChanges();
            List<Passenger> passengers = new List<Passenger>() { passenger1, passenger2 };
            return passengers;

        }

        /// <summary>
        /// Get all passengers with their orders
        /// </summary>        
        [HttpGet("/api/steward/passengers/orders")]
        public IEnumerable<Passenger> GetPassengersWithOrders()
        {
            IEnumerable<Passenger> passengers = _passengerRepository.GetPassengersWithOrders();
            return passengers;

        }

        /// <summary>
        /// Get all passengers with their orders
        /// </summary>        
        [HttpGet("/api/steward/passengers/orders/deliver")]
        public IEnumerable<Passenger> GetPassengersWithFilteredOrders(bool delivery)
        {
            IEnumerable<Passenger> passengers = _passengerRepository.GetPassengersWithOrders(); // Get passengers first and filter after because filtering on include was not possible. More info:  https://stackoverflow.com/questions/43618096/filtering-on-include-in-ef-core
            foreach (Passenger passenger in passengers)
            {
                passenger.Orders = passenger.FilterOrdersOnDelivery(delivery);
            }
            return passengers;
        }

        /// <summary>
        /// Set order with given orderId as delivered
        /// </summary>        
        [HttpPut("/api/steward/passenger/order/deliver")]
        public IActionResult DeliverOrder(int orderId)
        {

            Order order = _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound();
            }
            order.IsDelivered = true;
            _orderRepository.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Change Discount of product
        /// </summary>        
        [HttpPut("/api/steward/products/discount")]
        public IActionResult SetDiscount(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                Product productToChange = _productRepository.GetProductById(product.ProductId);
                if (productToChange == null)
                {
                    return NotFound();
                }
                productToChange.DiscountPercentage = product.DiscountPercentage;
                productToChange.SetPrice();
            }
            _productRepository.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Get all passengers
        /// </summary> 
        [HttpGet("/api/steward/passengers")]
        public IEnumerable<Passenger> GetAllPassengers()
        {
            IEnumerable<Passenger> passengers = _passengerRepository.GetAllPassengers();
            return passengers;
        }

    }
}
