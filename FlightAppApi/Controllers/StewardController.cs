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

        public StewardController(IPassengerRepository passengerRepository, IProductRepository productRepository, IStewardRepository stewardRepository)
        {
            _passengerRepository = passengerRepository;
            _productRepository = productRepository;
            _stewardRepository = stewardRepository;
        }

        /// <summary>
        /// Add products to the current passenger
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
    }
}
