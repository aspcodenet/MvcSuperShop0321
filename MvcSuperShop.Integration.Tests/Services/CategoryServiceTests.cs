using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MvcSuperShop.Data;
using MvcSuperShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace MvcSuperShop.Integration.Tests.Services
{
    [TestClass]
    public class CategoryServiceTests
    {
        private CategoryService sut;
        private ApplicationDbContext context;
        private Fixture fixture = new Fixture();

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
            //var test = fixture.Create<Agreement>();
            //test.AgreementRows[0].CategoryMatch = "van";
            //test.AgreementRows[0].PercentageDiscount = 12;

            int antal = 3;
            context.Categories.AddRange( fixture.CreateMany<Category>(8) );
            //for(int i = 0; i < 8; i++)
            //{
            //    context.Categories.Add(fixture.Create<Category>());
            //}
            context.SaveChanges();

            var result = sut.GetTrendingCategories(antal).Count();

            Assert.AreEqual(3, result);
        }
    }
}
