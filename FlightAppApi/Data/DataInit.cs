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
                #region init users
                Steward steward1 = new Steward { Email = "sebastienwojtyla@gmail.com", FirstName = "Sebastien", LastName = "Wojtyla" };

                await CreateSteward(steward1.Email, "Azertyuiop@1");

                Steward steward2 = new Steward { Email = "julienwojtyla@gmail.com", FirstName = "Julien", LastName = "Wojtyla" };

                await CreateSteward(steward2.Email, "Azertyuiop@1");

                _dbContext.Stewards.AddRange(steward1, steward2);

                Passenger passenger1 = new Passenger { Email = "marielouise@gmail.com", FirstName = "Marie", LastName = "Louise", SeatNumber = 1 };

                await CreatePassenger(passenger1.Email, "Azertyuiop@1");

                Passenger passenger2 = new Passenger { Email = "georgefloyd@gmail.com", FirstName = "George", LastName = "Floyd", SeatNumber = 2 };

                await CreatePassenger(passenger2.Email, "Azertyuiop@1");

                Passenger passenger3 = new Passenger { Email = "sandrawilson@gmail.com", FirstName = "Sandra", LastName = "Wilson", SeatNumber = 3 };

                await CreatePassenger(passenger3.Email, "Azertyuiop@1");

                Passenger passenger4 = new Passenger { Email = "hilairesimard@gmail.com", FirstName = "Hilaire", LastName = "Simard", SeatNumber = 4 };

                await CreatePassenger(passenger4.Email, "Azertyuiop@1");

                Passenger passenger5 = new Passenger { Email = "rogerdupont@gmail.com", FirstName = "Roger", LastName = "Dupont", SeatNumber = 5 };

                await CreatePassenger(passenger5.Email, "Azertyuiop@1");

                Passenger passenger6 = new Passenger { Email = "nandodiemel@gmail.com", FirstName = "Nando", LastName = "Diemel", SeatNumber = 6 };

                await CreatePassenger(passenger6.Email, "Azertyuiop@1");

                _dbContext.Passengers.AddRange(passenger1, passenger2);
                #endregion

                #region set contacts
                PassengerContact passengerContact1 = new PassengerContact { Passenger = passenger1, PassengerId = passenger1.PersonId, Contact = passenger3, ContactId = passenger3.PersonId };
                PassengerContact passengerContact2 = new PassengerContact { Passenger = passenger1, PassengerId = passenger1.PersonId, Contact = passenger4, ContactId = passenger4.PersonId };
                List<PassengerContact> passengerContacts1 = new List<PassengerContact>
                {
                    passengerContact1,
                    passengerContact2
                };
                passenger1.Contacts = passengerContacts1;
                //passenger2.ContactOf = passengerContacts1;


                PassengerContact passengerContact3 = new PassengerContact { Passenger = passenger3, PassengerId = passenger3.PersonId, Contact = passenger1, ContactId = passenger1.PersonId };
                List<PassengerContact> passengerContacts2 = new List<PassengerContact>
                {
                    passengerContact3
                };
                passenger3.Contacts = passengerContacts2;

                PassengerContact passengerContact4 = new PassengerContact { Passenger = passenger4, PassengerId = passenger4.PersonId, Contact = passenger1, ContactId = passenger1.PersonId };
                List<PassengerContact> passengerContacts3 = new List<PassengerContact>
                {
                    passengerContact4
                };
                passenger4.Contacts = passengerContacts3;
                _dbContext.SaveChanges();
                #endregion

                #region init products
                Product water = new Product { Name = "water", ImagePath = "/Assets/water.png", Price = 0.80 };
                Product cola = new Product { Name = "cola", ImagePath = "/Assets/cola.jpg", Price = 1.00 };
                Product tea = new Product { Name = "ice tea", ImagePath = "/Assets/ice_tea.png", Price = 1.00 };

                Product hotdog = new Product { Name = "hotdog", ImagePath = "/Assets/hotdog.jpg", Price = 2.50 };

                _dbContext.Products.AddRange(water, cola, tea, hotdog);
                #endregion

                #region init categories
                List<Product> drinklist = new List<Product>() { water, cola, tea };
                Category drinks = new Category { Name = "drinks", Products = drinklist };

                List<Product> foodlist = new List<Product>() { hotdog };
                Category food = new Category { Name = "food", Products = foodlist };

                _dbContext.Categories.AddRange(drinks, food);
                #endregion
                _dbContext.SaveChanges();

                #region init orders
                Order order1 = new Order(1);
                Orderline orderline1 = new Orderline(water);
                Orderline orderline2 = new Orderline(tea);
                order1.Orderlines.Add(orderline1);
                order1.Orderlines.Add(orderline2);

                Order order2 = new Order(1);
                Orderline orderline3 = new Orderline(hotdog);
                Orderline orderline4 = new Orderline(cola);
                order2.Orderlines.Add(orderline3);
                order2.Orderlines.Add(orderline4);

                _dbContext.Orders.AddRange(order1, order2);
                #endregion

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

