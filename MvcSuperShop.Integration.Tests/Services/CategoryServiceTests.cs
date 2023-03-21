using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MvcSuperShop.Data;
using MvcSuperShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSuperShop.Integration.Tests.Services
{
    [TestClass]
    public class CategoryServiceTests
    {
        private CategoryService sut;
        private ApplicationDbContext context;

        [TestInitialize]
        public void Initialize()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;
            context = new ApplicationDbContext(contextOptions);
            context.Database.EnsureCreated();


            sut = new CategoryService(context);
        }

        [TestMethod]
        public void Get_trending_categories_should_return_only_so_many()
        {
            int antal = 3;
            for(int i = 0; i < 8; i++)
            {
                context.Categories.Add(new Category { Name = "Cat" + i, Icon="" });
            }
            context.SaveChanges();

            var result = sut.GetTrendingCategories(antal).Count();

            Assert.AreEqual(3, result);
        }
    }
}
