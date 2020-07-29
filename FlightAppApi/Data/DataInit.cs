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

                _dbContext.Passengers.AddRange(passenger1, passenger2);
                #endregion

                #region init products
                Product water = new Product { Name = "water" };
                Product cola = new Product { Name = "cola" };
                Product tea = new Product { Name = "tea" };

                Product hotdog = new Product { Name = "hotdog" };

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

