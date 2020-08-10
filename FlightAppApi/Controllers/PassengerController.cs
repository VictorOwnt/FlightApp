using FlightAppApi.DTO;
using FlightAppApi.Model;
using FlightAppApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Passenger")]
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IProductRepository _productRepository;

        public PassengerController(IPassengerRepository passengerRepo, IProductRepository productRepository)
        {
            _passengerRepository = passengerRepo;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get the current passenger
        /// </summary>        
        [HttpGet]
        public ActionResult<Passenger> GetPassenger()
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmail(User.Identity.Name);
            return passenger;
        }

        /// <summary>
        /// Add products to the current passenger
        /// </summary>        
        [HttpPost("/api/product/")]
        public ActionResult<List<ProductDTO>> OrderProducts(List<ProductDTO> products)
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmail(User.Identity.Name);
            Order order = new Order(passenger.PersonId);
            foreach (ProductDTO productDTO in products)
            {
                Product product = _productRepository.GetProductByName(productDTO.Name);
                order.Orderlines.Add(new Orderline(product));

            }
            passenger.Orders.Add(order);
            _passengerRepository.SaveChanges();
            _productRepository.SaveChanges();
            return products;

        }

        /// <summary>
        /// Get ordered products of the current passenger
        /// </summary>        
        [HttpGet("/api/passenger/order/product")]
        public IEnumerable<Product> GetOrderedProducts()
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmailWithOrders(User.Identity.Name);
            IEnumerable<Product> products = passenger.GetOrderedProducts();

            return products;

        }

        /// <summary>
        /// Get contacts of the current passenger
        /// </summary>        
        [HttpGet("/api/passenger/contacts")]
        public IEnumerable<Passenger> GetContacts()
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmailWithContacts(User.Identity.Name);
            List<Passenger> contacts = new List<Passenger>();
            foreach (PassengerContact passengerContact in passenger.Contacts)
            {
                contacts.Add(passengerContact.Contact);
            }

            return contacts;

        }
    }
}
