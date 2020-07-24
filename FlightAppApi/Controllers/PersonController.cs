using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase //Opsplitsen in steward en passenger?
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IStewardRepository _stewardRepository;

        public PersonController(IPassengerRepository passengerRepo, IStewardRepository stewardRepo)
        {
            _passengerRepository = passengerRepo;
            _stewardRepository = stewardRepo;
        }

        /// <summary>
        /// Check if person is steward
        /// </summary>        
        [HttpGet]
        public bool IsSteward()
        {
            return User.HasClaim(ClaimTypes.Role, "steward");
        }

    }
}