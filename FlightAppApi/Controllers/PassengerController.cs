using FlightAppApi.DTO;
using FlightAppApi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<Product>> OrderProducts(List<Product> orderedProducts)
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmail(User.Identity.Name);
            Order order = new Order(passenger.PersonId);
            foreach (Product orderedProduct in orderedProducts)
            {
                Product product = _productRepository.GetProductById(orderedProduct.ProductId);
                order.Orderlines.Add(new Orderline(product));

            }
            passenger.Orders.Add(order);
            _passengerRepository.SaveChanges();
            _productRepository.SaveChanges();
            return orderedProducts;

        }

        /// <summary>
        /// Get orders of current passenger
        /// </summary>        
        [HttpGet("/api/passenger/orders")]
        public ActionResult<Passenger> GetOrderedProducts()
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmailWithOrders(User.Identity.Name);

            return passenger;

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
        /// <summary>
        /// Get messages of the current passenger with given contactEmail
        /// </summary>        
        [HttpGet("/api/passenger/messages/")]
        public IEnumerable<ChatMessage> GetPassengerWithMessages(string contactEmail)
        {
            Passenger passenger = _passengerRepository.GetPassengerByEmailWithChatMessages(User.Identity.Name);
            return passenger.GetChatsWithContact(contactEmail);

        }
    }
}
