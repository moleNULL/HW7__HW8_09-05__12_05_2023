using HomeAccounting.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DAL.EFCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(GetPreconfiguredCategories());
            modelBuilder.Entity<ExpensesEntity>().HasData(GetPreconfiguredExpenses());
        }

        private static IEnumerable<CategoryEntity> GetPreconfiguredCategories()
        {
            return new List<CategoryEntity>
            {
                new CategoryEntity { Id = 1, Name = "Food" },
                new CategoryEntity { Id = 2, Name = "Transportation" },
                new CategoryEntity { Id = 3, Name = "Cellular Service" },
                new CategoryEntity { Id = 4, Name = "Internet" },
                new CategoryEntity { Id = 5, Name = "Entertainment" }
            };
        }

        private static IEnumerable<ExpensesEntity> GetPreconfiguredExpenses()
        {
            return new List<ExpensesEntity>
            {
                new ExpensesEntity { Id = 1, Name = "McDonalds", Cost = 120, Date = new DateTime(2023, 4, 20), CategoryId = 1, Comment = "Ate 3 hamburgers with friends" },
                new ExpensesEntity { Id = 2, Name = "lifecell", Cost = 200, Date = new DateTime(2023, 4, 21), CategoryId = 3 },
                new ExpensesEntity { Id = 3, Name = "Taxi", Cost = 185, CategoryId = 2, Date = new DateTime(2023, 4, 23), Comment = "Took Uklon taxi for home" },
                new ExpensesEntity { Id = 4, Name = "Cafe", Cost = 320, Date = new DateTime(2023, 4, 25), CategoryId = 1 },
                new ExpensesEntity { Id = 5, Name = "Triolan", Cost = 244, Date = new DateTime(2023, 4, 28), CategoryId = 4, Comment = "Shevchenko street" },

                new ExpensesEntity { Id = 6, Name = "Maxnet", Cost = 150, Date = new DateTime(2023, 4, 30), CategoryId = 4, Comment = "Parent's house" },
                new ExpensesEntity { Id = 7, Name = "CSGO", Cost = 550, Date = new DateTime(2023, 5, 1), CategoryId = 5, Comment = "Bought yet another CSGO copy in Steam" },
                new ExpensesEntity { Id = 8, Name = "Lays Crisps", Cost = 59, Date = new DateTime(2023, 5, 2), CategoryId = 1 },
                new ExpensesEntity { Id = 9, Name = "Spotify subscription", Cost = 139, Date = new DateTime(2023, 5, 2), CategoryId = 5 },
                new ExpensesEntity { Id = 10, Name = "MEGOGO subscription", Cost = 229, Date = new DateTime(2023, 5, 3), CategoryId = 5 },

                new ExpensesEntity { Id = 11, Name = "Vodafone", Cost = 2285, Date = new DateTime(2023, 5, 4), CategoryId = 3, Comment = "Year prepaid for mom" },
                new ExpensesEntity { Id = 12, Name = "Bus", Cost = 20, Date = new DateTime(2023, 5, 5), CategoryId = 2 },
                new ExpensesEntity { Id = 13, Name = "Salami", Cost = 150, Date = new DateTime(2023, 5, 7), CategoryId = 1 },
                new ExpensesEntity { Id = 14, Name = "Zoo", Cost = 450, Date = new DateTime(2023, 5, 8), CategoryId = 5, Comment = "Zoo near the forest" },
                new ExpensesEntity { Id = 15, Name = "Tram", Cost = 16, Date = new DateTime(2023, 4, 9), CategoryId = 2 },

                new ExpensesEntity { Id = 16, Name = "Ekomarket", Cost = 690, Date = new DateTime(2023, 5, 9), CategoryId = 1, Comment = "Bought food for the holiday" },
                new ExpensesEntity { Id = 17, Name = "Bus", Cost = 24, Date = new DateTime(2023, 5, 10), CategoryId = 2, Comment = "247e" },
                new ExpensesEntity { Id = 18, Name = "Ice cream", Cost = 14.8m, Date = new DateTime(2023, 5, 11), CategoryId = 1 },
                new ExpensesEntity { Id = 19, Name = "Metallica concert tickets", Cost = 1350, Date = new DateTime(2023, 5, 13), CategoryId = 5 },
                new ExpensesEntity { Id = 20, Name = "PES2009", Cost = 160, Date = new DateTime(2023, 5, 14), CategoryId = 5, Comment = "Bought in Origin" },
            };
        }
    }
}
