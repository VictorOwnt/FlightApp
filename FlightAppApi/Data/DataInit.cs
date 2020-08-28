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
                // Stewards
                Steward steward = new Steward { Email = "steward@gmail.com", FirstName = "Sebastien", LastName = "Wojtyla" };

                await CreateSteward(steward.Email, "Azertyuiop@1");

                _dbContext.Stewards.Add(steward);

                // Passengers
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

                Passenger passenger7 = new Passenger { Email = "maartendeur@gmail.com", FirstName = "Maarten", LastName = "Deur", SeatNumber = 7 };

                await CreatePassenger(passenger7.Email, "Azertyuiop@1");

                Passenger passenger8 = new Passenger { Email = "nancybel@gmail.com", FirstName = "Nancy", LastName = "Bel", SeatNumber = 8 };

                await CreatePassenger(passenger8.Email, "Azertyuiop@1");

                Passenger passenger9 = new Passenger { Email = "emileds@gmail.com", FirstName = "Emile", LastName = "Desmet", SeatNumber = 9 };

                await CreatePassenger(passenger9.Email, "Azertyuiop@1");

                Passenger passenger10 = new Passenger { Email = "aaronmeskens@gmail.com", FirstName = "Aaron", LastName = "Meskens", SeatNumber = 10 };

                await CreatePassenger(passenger10.Email, "Azertyuiop@1");

                _dbContext.Passengers.AddRange(passenger1, passenger2, passenger3, passenger4, passenger5, passenger6, passenger7, passenger8, passenger9, passenger10);
                #endregion

                #region set contacts
                // Passenger 1 kent 3 & 4
                PassengerContact passengerContact1 = new PassengerContact { Passenger = passenger1, PassengerId = passenger1.PersonId, Contact = passenger3, ContactId = passenger3.PersonId };
                PassengerContact passengerContact2 = new PassengerContact { Passenger = passenger1, PassengerId = passenger1.PersonId, Contact = passenger4, ContactId = passenger4.PersonId };
                List<PassengerContact> passengerContacts1 = new List<PassengerContact>
                {
                    passengerContact1,
                    passengerContact2
                };
                passenger1.Contacts = passengerContacts1;

                // Passenger 2 kent 5
                PassengerContact passengerContact3 = new PassengerContact { Passenger = passenger2, PassengerId = passenger2.PersonId, Contact = passenger5, ContactId = passenger5.PersonId };
                List<PassengerContact> passengerContacts2 = new List<PassengerContact>
                {
                    passengerContact3
                };
                passenger2.Contacts = passengerContacts2;

                // Passenger 3 kent 1 & 4
                PassengerContact passengerContact4 = new PassengerContact { Passenger = passenger3, PassengerId = passenger3.PersonId, Contact = passenger1, ContactId = passenger1.PersonId };
                PassengerContact passengerContact5 = new PassengerContact { Passenger = passenger3, PassengerId = passenger3.PersonId, Contact = passenger4, ContactId = passenger4.PersonId };
                List<PassengerContact> passengerContacts3 = new List<PassengerContact>
                {
                    passengerContact4,
                    passengerContact5
                };
                passenger3.Contacts = passengerContacts3;

                // Passenger 4 kent 1 & 3
                PassengerContact passengerContact6 = new PassengerContact { Passenger = passenger4, PassengerId = passenger4.PersonId, Contact = passenger1, ContactId = passenger1.PersonId };
                PassengerContact passengerContact7 = new PassengerContact { Passenger = passenger4, PassengerId = passenger4.PersonId, Contact = passenger3, ContactId = passenger3.PersonId };
                List<PassengerContact> passengerContacts4 = new List<PassengerContact>
                {
                    passengerContact6,
                    passengerContact7
                };
                passenger4.Contacts = passengerContacts4;

                // Passenger 5 kent 2
                PassengerContact passengerContact8 = new PassengerContact { Passenger = passenger5, PassengerId = passenger5.PersonId, Contact = passenger2, ContactId = passenger2.PersonId };
                List<PassengerContact> passengerContacts5 = new List<PassengerContact>
                {
                    passengerContact8
                };
                passenger5.Contacts = passengerContacts5;

                // Passenger 6 kent 9 & 10
                PassengerContact passengerContact9 = new PassengerContact { Passenger = passenger6, PassengerId = passenger6.PersonId, Contact = passenger9, ContactId = passenger9.PersonId };
                PassengerContact passengerContact10 = new PassengerContact { Passenger = passenger6, PassengerId = passenger6.PersonId, Contact = passenger10, ContactId = passenger10.PersonId };
                List<PassengerContact> passengerContacts6 = new List<PassengerContact>
                {
                    passengerContact9,
                    passengerContact10
                };
                passenger6.Contacts = passengerContacts6;

                // Passenger 7 kent 8
                PassengerContact passengerContact11 = new PassengerContact { Passenger = passenger7, PassengerId = passenger7.PersonId, Contact = passenger8, ContactId = passenger8.PersonId };
                List<PassengerContact> passengerContacts7 = new List<PassengerContact>
                {
                    passengerContact11
                };
                passenger7.Contacts = passengerContacts7;

                // Passenger 8 kent 7
                PassengerContact passengerContact12 = new PassengerContact { Passenger = passenger8, PassengerId = passenger8.PersonId, Contact = passenger7, ContactId = passenger7.PersonId };
                List<PassengerContact> passengerContacts8 = new List<PassengerContact>
                {
                    passengerContact12
                };
                passenger8.Contacts = passengerContacts8;

                // Passenger 9 kent 6 & 10
                PassengerContact passengerContact13 = new PassengerContact { Passenger = passenger9, PassengerId = passenger9.PersonId, Contact = passenger6, ContactId = passenger6.PersonId };
                PassengerContact passengerContact14 = new PassengerContact { Passenger = passenger9, PassengerId = passenger9.PersonId, Contact = passenger10, ContactId = passenger10.PersonId };
                List<PassengerContact> passengerContacts9 = new List<PassengerContact>
                {
                    passengerContact13,
                    passengerContact14
                };
                passenger9.Contacts = passengerContacts9;

                // Passenger 10 kent 6 & 9
                PassengerContact passengerContact15 = new PassengerContact { Passenger = passenger10, PassengerId = passenger10.PersonId, Contact = passenger6, ContactId = passenger6.PersonId };
                PassengerContact passengerContact16 = new PassengerContact { Passenger = passenger10, PassengerId = passenger10.PersonId, Contact = passenger9, ContactId = passenger9.PersonId };
                List<PassengerContact> passengerContacts10 = new List<PassengerContact>
                {
                    passengerContact15,
                    passengerContact16
                };
                passenger10.Contacts = passengerContacts10;

                _dbContext.SaveChanges();
                #endregion

                #region init products
                Product water = new Product { Name = "water", ImagePath = "/Assets/water.png", BasePrice = 0.80 };
                water.SetPrice();
                Product cola = new Product { Name = "cola", ImagePath = "/Assets/cola.jpg", BasePrice = 1.00 };
                cola.SetPrice();
                Product tea = new Product { Name = "ice tea", ImagePath = "/Assets/ice_tea.png", BasePrice = 1.00 };
                tea.SetPrice();
                Product coffee = new Product { Name = "coffee", ImagePath = "/Assets/coffee.jpg", BasePrice = 1.50 };
                coffee.SetPrice();
                Product orangina = new Product { Name = "orangina", ImagePath = "/Assets/orangina.png", BasePrice = 1.00 };
                orangina.SetPrice();

                Product hotdog = new Product { Name = "hotdog", ImagePath = "/Assets/hotdog.jpg", BasePrice = 2.50 };
                hotdog.SetPrice();
                Product hamburger = new Product { Name = "hamburger", ImagePath = "/Assets/hamburger.jpg", BasePrice = 3.00 };
                hamburger.SetPrice();
                Product panini = new Product { Name = "panini", ImagePath = "/Assets/panini.jpg", BasePrice = 2.50 };
                panini.SetPrice();
                Product donut = new Product { Name = "donut", ImagePath = "/Assets/donut.jpg", BasePrice = 1.50 };
                donut.SetPrice();
                Product chips = new Product { Name = "chips", ImagePath = "/Assets/chips.jpg", BasePrice = 2.00 };
                chips.SetPrice();

                _dbContext.Products.AddRange(water, cola, tea, coffee, orangina, hotdog, hamburger, panini, donut, chips);
                #endregion

                #region init categories
                List<Product> drinklist = new List<Product>() { water, cola, tea, coffee, orangina };
                Category drinks = new Category { Name = "drinks", Products = drinklist };

                List<Product> foodlist = new List<Product>() { hotdog, hamburger, panini, donut, chips };
                Category food = new Category { Name = "food", Products = foodlist };

                _dbContext.Categories.AddRange(drinks, food);
                _dbContext.SaveChanges();
                #endregion

                #region init orders
                // Orderlines - drinks
                Orderline orderlineWater1 = new Orderline(water);
                Orderline orderlineWater2 = new Orderline(water);
                Orderline orderlineWater3 = new Orderline(water);
                Orderline orderlineCola1 = new Orderline(cola);
                Orderline orderlineTea1 = new Orderline(tea);
                Orderline orderlineCoffee1 = new Orderline(coffee);
                Orderline orderlineCoffee2 = new Orderline(coffee);
                Orderline orderlineOrangina1 = new Orderline(orangina);
                Orderline orderlineOrangina2 = new Orderline(orangina);
                // Orderlines - food
                Orderline orderlineHotdog1 = new Orderline(hotdog);
                Orderline orderlineHotdog2 = new Orderline(hotdog);
                Orderline orderlineHamburger1 = new Orderline(hamburger);
                Orderline orderlineHamburger2 = new Orderline(hamburger);
                Orderline orderlinePanini1 = new Orderline(panini);
                Orderline orderlineDonut1 = new Orderline(donut);
                Orderline orderlineDonut2 = new Orderline(donut);
                Orderline orderlineChips1 = new Orderline(chips);

                // Orders
                Order order1 = new Order(1);
                order1.Orderlines.Add(orderlineWater1);
                order1.Orderlines.Add(orderlineHotdog1);
                order1.SetOrderCost();

                Order order2 = new Order(1);
                order2.Orderlines.Add(orderlineTea1);
                order2.Orderlines.Add(orderlineDonut1);
                order2.SetOrderCost();

                Order order3 = new Order(2);
                order3.Orderlines.Add(orderlineOrangina1);
                order3.Orderlines.Add(orderlineHotdog2);
                order3.SetOrderCost();

                Order order4 = new Order(5);
                order4.Orderlines.Add(orderlineCoffee1);
                order4.Orderlines.Add(orderlineDonut2);
                order4.Orderlines.Add(orderlineWater2);
                order4.SetOrderCost();

                Order order5 = new Order(6);
                order5.Orderlines.Add(orderlineCola1);
                order5.Orderlines.Add(orderlineHamburger1);
                order5.Orderlines.Add(orderlinePanini1);
                order5.SetOrderCost();

                Order order6 = new Order(7);
                order6.Orderlines.Add(orderlineCoffee2);
                order6.Orderlines.Add(orderlineHamburger2);
                order6.SetOrderCost();

                Order order7 = new Order(8);
                order7.Orderlines.Add(orderlineWater3);
                order7.SetOrderCost();

                Order order8 = new Order(9);
                order8.Orderlines.Add(orderlineOrangina2);
                order8.Orderlines.Add(orderlineChips1);
                order8.SetOrderCost();

                _dbContext.Orders.AddRange(order1, order2, order3, order4, order5, order6, order7, order8);
                #endregion

                #region init flightInfo
                Location brussel = new Location { Country = "Belgium", City = "Zaventem", Latitude = 50.8855, Longitude = 4.4710 };
                Location loiu = new Location { Country = "Spain", City = "Loiu", Latitude = 43.3161, Longitude = -2.92444 };

                Airport brusselsAirport = new Airport { Name = "Brussels Airport", Location = brussel };
                Airport bilbaoAirport = new Airport { Name = "Bilbao Airport", Location = loiu };

                Aircraft boeing747 = new Aircraft { Name = "Boeing 747", ConstructionYear = 1984, ImageString = "/Assets/aircraft.jpg" };

                Airline soloFlightAirlines = new Airline { Name = "Solo Flight Airlines", Description = "This airline company was found in 2020 during covid-19.", ImageString = "/Assets/airline.png" };

                FlightDetail detail = new FlightDetail { DepartingAirport = brusselsAirport, DepartingTime = new DateTime(2020, 8, 15, 12, 0, 0), ArrivalAirport = bilbaoAirport, ArrivalTime = new DateTime(2020, 8, 15, 15, 0, 0) };

                Flight flight = new Flight { Airline = soloFlightAirlines, Aircraft = boeing747, FlightDetail = detail };
                _dbContext.Flights.Add(flight);
                #endregion

                #region init movies
                List<Movie> movies = new List<Movie> {
                    new Movie("Star Wars: The Rise of Skywalker", DateTime.Parse("2019/12/19"), 141, "The surviving Resistance faces the First Order once more in the final chapter of the Skywalker saga.", "J.J. Abrams", "https://m.media-amazon.com/images/M/MV5BMDljNTQ5ODItZmQwMy00M2ExLTljOTQtZTVjNGE2NTg0NGIxXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/8Qn_spdM5Zg"),
                    new Movie("The Shawshank Redemption", DateTime.Parse("1995/2/17"), 142, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency. ", "F. Darabont", "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/6hB3S9bIaco"),
                    new Movie("The Godfather", DateTime.Parse("1972/8/24"), 175, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son. ", "F. F. Coppola", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR3,0,182,268_AL_.jpg", "https://www.youtube.com/embed/CWoQlDlyQj4"),
                    new Movie("The Godfather: Part II", DateTime.Parse("1975/5/15"), 202, "Early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate. ", "F. F. Coppola", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR3,0,182,268_AL_.jpg", "https://www.youtube.com/embed/9O1Iy9od7-A"),
                    new Movie("Schindler's List", DateTime.Parse("1994/2/18"), 195, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "S. Spielberg", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/gG22XNhtnoY"),
                    new Movie("The Lord of the Rings: The Fellowship of the Ring", DateTime.Parse("2001/12/19"), 178, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron. ", "P. Jackson", "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/V75dMMIW2B4"),
                    new Movie("The Lord of the Rings: The Two Towers", DateTime.Parse("2002/12/18"), 179, "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", "P. Jackson", "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/hYcw5ksV8YQ"),
                    new Movie("The Lord of the Rings: The Return of the King", DateTime.Parse("2003/12/17"), 201, "TGandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "P. Jackson", "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/r5X-hFf6Bwo"),
                    new Movie("Pulp Fiction", DateTime.Parse("1994/10/24"), 154, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption. ", "Q. Tarantino", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg", "https://www.youtube.com/embed/s7EdQ4FqbhY")
                };
                movies.ForEach(m => _dbContext.Movies.Add(m));
                #endregion

                #region init music
                List<Music> music = new List<Music> {
                    new Music("God's Plan", "Drake", "https://charts-static.billboard.com/img/2018/01/drake-hq6-87x87.jpg"),
                    new Music("Perfect", "Ed Sheeran", "https://charts-static.billboard.com/img/2017/03/ed-sheeran-buv-87x87.jpg"),
                    new Music("Meant To Be", "Bebe Rexha", "https://charts-static.billboard.com/img/2017/10/bebe-rexha-8wm-87x87.jpg"),
                    new Music("Havana", "Camila Cabello", "https://charts-static.billboard.com/img/2017/08/camila-cabello-4tx-87x87.jpg"),
                    new Music("Rockstar", "Post Malone", "https://charts-static.billboard.com/img/2017/10/post-malone-1vw-87x87.jpg"),
                    new Music("Psycho", "Post Malone", "https://charts-static.billboard.com/img/2018/03/post-malone-tp6-87x87.jpg"),
                    new Music("I Like It", "Cardi B", "https://charts-static.billboard.com/img/2018/04/cardi-b-n38-i-like-it-ppy-87x87.jpg"),
                    new Music("The Middle", "Zedd", "https://charts-static.billboard.com/img/2018/02/zedd-edd-87x87.jpg"),
                    new Music("In My Feelings", "Drake", "https://charts-static.billboard.com/img/2018/07/drake-zwl-in-my-feelings-591-87x87.jpg"),
                    new Music("Girls Like You", "Maroon 5", "https://charts-static.billboard.com/img/2018/06/maroon-5-9st-girls-like-you-32b-87x87.jpg")
                };
                music.ForEach(m => _dbContext.Music.Add(m));
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

