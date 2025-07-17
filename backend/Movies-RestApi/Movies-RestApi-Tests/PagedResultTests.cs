using Movies_RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class PagedResultTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var items = new List<string> { "A", "B", "C" };
            int totalCount = 10;
            int pageSize = 3;
            int pageNumber = 2;

            // Act
            var result = new PagedResult<string>(items, totalCount, pageSize, pageNumber);

            // Assert
            Assert.Equal(items, result.Items);
            Assert.Equal(totalCount, result.TotalItemsCount);
            Assert.Equal(4, result.ItemsFrom);         // (3 * (2 - 1)) + 1 = 4
            Assert.Equal(6, result.ItemsTo);           // min(4 + 3 - 1, 10) = 6
            Assert.Equal(4, result.TotalPages);        // ceil(10 / 3) = 4
        }
    }
}
