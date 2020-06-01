using Concerts.Controllers;
using Concerts.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ConcertsContext>();
            optionsBuilder.UseSqlServer("Server=ROOFLER\\SQLEXPRESS; Database=Concerts; Trusted_Connection=True; MultipleActiveResultSets=true");
            
            var controller = new GenresController(new ConcertsContext(optionsBuilder.Options));

            // Act
            var result = await controller.GetGenres();

            // Assert
            Assert.Contains(result.Value, g => g.Name.Equals("Áëþç"));
        }
    }
}
