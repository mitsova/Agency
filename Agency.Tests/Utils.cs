using Agency.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Agency.Tests
{
    public class Utils
    {
        public static DbContextOptions<AgencyContext> GetOptions(string nameOfDb)
        {
            return new DbContextOptionsBuilder<AgencyContext>()
                .UseInMemoryDatabase(databaseName: nameOfDb)
                .Options;
        }

        public static void Seed(AgencyContext context)
        {
            var categories = new[]
            {
                new Category { Id = 1, Name = "Vehicles" },
                new Category { Id = 2, Name = "Tickets" },
                new Category { Id = 3, Name = "Journeys" }
            };

            var vehicles = new[]
            {
                new Vehicle { Id = 1, PassangerCapacity = 33, PricePerKilometer = 3},
                new Vehicle { Id = 2, PassangerCapacity = 167, PricePerKilometer = 5.76m},
                new Vehicle { Id = 3, PassangerCapacity = 69, PricePerKilometer = 2.41m},
                new Vehicle { Id = 4, PassangerCapacity = 22, PricePerKilometer = 2},
                new Vehicle { Id = 5, PassangerCapacity = 157, PricePerKilometer = 3.84m},
                new Vehicle { Id = 6, PassangerCapacity = 80, PricePerKilometer = 2.41m},
            };

            var buses = new[]
            {
                new Bus { Id = 1, VehicleId = 1 },
                new Bus { Id = 2, VehicleId = 4 }
            };

            var trains = new[]
            {
                new Train { Id = 1, VehicleId = 3, CartsAmount = 6},
                new Train { Id = 2, VehicleId = 6, CartsAmount = 8}
            };

            var planes = new[]
            {
                new Airplane { Id = 1, VehicleId = 2, HasFreeFood = true },
                new Airplane { Id = 2, VehicleId = 5, HasFreeFood = false }
            };

            var journeys = new[]
            {
                new Journey { Id = 1, StartLocation = "Ruse", Destination = "Sofia", VehicleId = 1, TravelCosts = 432.11m, Distance = 320.15, CategoryId = 3},
                new Journey { Id = 2, StartLocation = "Sofia", Destination= "London", VehicleId = 2, Distance = 1450, TravelCosts= 1234.56m, CategoryId = 3},
                new Journey {Id = 3, StartLocation = "Ruse", Destination = "Varna",
                VehicleId = 3, TravelCosts = 230, Distance = 187.3, CategoryId = 3}
            };

            var tickets = new[]
            {
                new Ticket { Id = 1, CategoryId = 2, JourneyId = 1, Price = 21.75m, AdministrativeCosts = 4.33m},
                new Ticket { Id = 2, CategoryId = 2, JourneyId = 1, Price = 20.75m, AdministrativeCosts = 4.33m},
                new Ticket { Id = 3, CategoryId = 2, JourneyId = 1, Price = 20.75m, AdministrativeCosts = 4.33m},
                new Ticket { Id = 4, CategoryId = 2, JourneyId = 1, Price = 21.75m, AdministrativeCosts = 4.33m},

                new Ticket { Id = 5, CategoryId = 2, AdministrativeCosts = 2.98m, Price = 15.33m, JourneyId =3},
                new Ticket { Id = 6, CategoryId = 2, AdministrativeCosts = 2.98m, Price = 10.33m, JourneyId =3},
                new Ticket { Id = 7, CategoryId = 2, AdministrativeCosts = 2.98m, Price = 10.33m, JourneyId =3},
                new Ticket { Id = 8, CategoryId = 2, AdministrativeCosts = 2.98m, Price = 15.33m, JourneyId =3},
                new Ticket { Id = 9, CategoryId = 2, AdministrativeCosts = 2.98m, Price = 15.33m, JourneyId =3},

                new Ticket{ Id = 10, CategoryId = 2, AdministrativeCosts = 6.21m, Price = 78.42m, JourneyId = 2},
                new Ticket{ Id = 11, CategoryId = 2, AdministrativeCosts = 6.21m, Price = 78.42m, JourneyId = 2},
                new Ticket{ Id = 12, CategoryId = 2, AdministrativeCosts = 6.21m, Price = 78.42m, JourneyId = 2},
                new Ticket{ Id = 13, CategoryId = 2, AdministrativeCosts = 6.21m, Price = 78.42m, JourneyId = 2},
                new Ticket{ Id = 14, CategoryId = 2, AdministrativeCosts = 6.21m, Price = 78.42m, JourneyId = 2}
            };

            context.AddRange(categories);
            context.AddRange(vehicles);
            context.AddRange(buses);
            context.AddRange(trains);
            context.AddRange(planes);
            context.AddRange(journeys);
            context.AddRange(tickets);

            context.SaveChanges();
        }
    }
}
