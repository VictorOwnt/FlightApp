using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightAppApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPassengerRepository _passengerRepository;
        private IStewardRepository _stewardRepository;

        public PersonController(IPassengerRepository passengerRepo, IStewardRepository stewardRepo)
        {
            _passengerRepository = passengerRepo;
            _stewardRepository = stewardRepo;
        }

        [HttpGet("{firstName}/{lastName}/{seatNumber}")]        
        public Person PassengerLogIn(string firstName, string lastName, string seatNumber)
        {
            if(long.Parse(seatNumber) == 0)
            {
                return _stewardRepository.GetSteward(firstName, lastName);
            }
            return _passengerRepository.GetPassenger(firstName,lastName,seatNumber);
        }
        
    }
}