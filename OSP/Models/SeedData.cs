using Microsoft.EntityFrameworkCore;
using OSP.Data;
using System.Data;

namespace OSP.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new OSPContext(serviceProvider.GetRequiredService<DbContextOptions<OSPContext>>()))
            {
                if (!context.Firefighter.Any())
                {
                    context.Firefighter.AddRange(
                        new Firefighter { Name = "Adam", Surname = "Nowak", DataS = DateTime.Now.AddMonths(6), Driver = true, Commander = false },
                        new Firefighter { Name = "Ewa", Surname = "Kowalska", DataS = DateTime.Now.AddMonths(9), Driver = false, Commander = true },
                        new Firefighter { Name = "Marek", Surname = "Wiśniewski", DataS = DateTime.Now.AddMonths(12), Driver = true, Commander = false },
                        new Firefighter { Name = "Anna", Surname = "Kaczmarek", DataS = DateTime.Now.AddMonths(8), Driver = false, Commander = false },
                        new Firefighter { Name = "Piotr", Surname = "Lis", DataS = DateTime.Now.AddMonths(10), Driver = true, Commander = true },
                        new Firefighter { Name = "Katarzyna", Surname = "Zając", DataS = DateTime.Now.AddMonths(7), Driver = false, Commander = false },
                        new Firefighter { Name = "Robert", Surname = "Wójcik", DataS = DateTime.Now.AddMonths(11), Driver = true, Commander = false },
                        new Firefighter { Name = "Monika", Surname = "Szymańska", DataS = DateTime.Now.AddMonths(9), Driver = false, Commander = true },
                        new Firefighter { Name = "Michał", Surname = "Dąbrowski", DataS = DateTime.Now.AddMonths(8), Driver = true, Commander = false },
                        new Firefighter { Name = "Alicja", Surname = "Wilk", DataS = DateTime.Now.AddMonths(10), Driver = false, Commander = false }

                    );
                    context.SaveChanges();
                }
                if (!context.Car.Any())
                {
                    context.Car.AddRange(
                        new Car { Name = "Mercedes", Model = "Sprinter", Liters = 20000 },
                        new Car { Name = "Volvo", Model = "FL", Liters = 25000 },
                        new Car { Name = "Scania", Model = "P-series", Liters = 30000 },
                        new Car { Name = "MAN", Model = "TGL", Liters = 28000 },
                        new Car { Name = "Iveco", Model = "Eurocargo", Liters = 26000 }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
