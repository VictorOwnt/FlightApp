using FlightAppApi.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightAppApi.Data
{
    public class DataInit
    {
        private readonly FlightDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public DataInit(FlightDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Steward steward1 = new Steward { Email = "sebastienwojtyla@gmail.com", FirstName = "Sebastien", LastName = "Wojtyla" };

                await CreateSteward(steward1.Email, "Azertyuiop@1");

                Steward steward2 = new Steward { Email = "julienwojtyla@gmail.com", FirstName = "Julien", LastName = "Wojtyla" };

                await CreateSteward(steward2.Email, "Azertyuiop@1");

                _dbContext.Stewards.AddRange(steward1, steward2);

                Passenger passenger1 = new Passenger { Email = "marielouise@gmail.com", FirstName = "Marie", LastName = "Louise", SeatNumber = 1 };

                await CreatePassenger(passenger1.Email, "Azertyuiop@1");

                Passenger passenger2 = new Passenger { Email = "georgefloyd@gmail.com", FirstName = "George", LastName = "Floyd", SeatNumber = 2 };

                await CreatePassenger(passenger2.Email, "Azertyuiop@1");

                _dbContext.Passengers.AddRange(passenger1, passenger2);

                #region init flightInfo
                Location brussel = new Location { Country = "Belgium", City = "Zaventem" };
                Location loiu = new Location { Country = "Spain", City = "Loiu" };

                Airport brusselsAirport = new Airport { Name = "Brussels Airport", Location = brussel };
                Airport bilbaoAirport = new Airport { Name = "Bilbao Airport", Location = loiu };

                Aircraft boeing747 = new Aircraft { Name = "Boeing 747", ConstructionYear = 1984, ImageString = "/Assets/aircraft.jpg" };

                Airline soloFlightAirlines = new Airline { Name = "Solo Flight Airlines", Description = "This airline company was found in 2020 during covid-19.", ImageString = "/Assets/airline.png" };

                FlightDetail detail = new FlightDetail { DepartingAirport = brusselsAirport, DepartingTime = new DateTime(2020, 8, 15, 12, 0, 0), ArrivalAirport = bilbaoAirport, ArrivalTime = new DateTime(2020, 8, 15, 15, 0, 0) };

                Flight flight = new Flight { Airline = soloFlightAirlines, Aircraft = boeing747, FlightDetail = detail };
                _dbContext.Flights.Add(flight);
                #endregion

                _dbContext.SaveChanges();
            }

        }
        private async Task CreateSteward(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "steward"));
        }
        private async Task CreatePassenger(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "passenger"));
        }
    }
}

