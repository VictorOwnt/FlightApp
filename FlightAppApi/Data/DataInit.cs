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




                //// Movies
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

                //// Music
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

