using FlightAppApi.Model;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerController(IPassengerRepository passengerRepo)
        {
            _passengerRepository = passengerRepo;
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

    }
}
