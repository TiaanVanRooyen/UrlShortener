using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.API.Data;
using UrlShortener.API.Services;

namespace UrlShortener.Tests
{
    public class UrlShorteningServiceTests
    {
        [Fact]
        public async Task ShortenUrlAsync_ShouldCreateAndReturnCode_WhenUrlIsUnique()
        {
            // Arrange: Set up an in-memory SQLite database
            using var connection = new SqliteConnection("DataSource=:memory:");
            await connection.OpenAsync();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new AppDbContext(options);
            await context.Database.EnsureCreatedAsync();

            var service = new UrlShorteningService(context);
            string testUrl = "https://www.github.com";

            // Act
            var code = await service.ShortenUrlAsync(testUrl);
            var retrievedUrl = await service.GetOriginalUrlAsync(code);

            // Assert
            Assert.NotNull(code);
            Assert.Equal(7, code.Length);
            Assert.Equal(testUrl, retrievedUrl);
        }

        [Fact]
        public async Task ShortenUrlAsync_ShouldReturnExistingCode_WhenUrlAlreadyExists()
        {
            // Arrange
            using var connection = new SqliteConnection("DataSource=:memory:");
            await connection.OpenAsync();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new AppDbContext(options);
            await context.Database.EnsureCreatedAsync();

            var service = new UrlShorteningService(context);
            string testUrl = "https://www.github.com";

            // Act - Shorten twice for the same URL
            var firstCode = await service.ShortenUrlAsync(testUrl);
            var secondCode = await service.ShortenUrlAsync(testUrl);

            // Assert - Should return the exact same code without creating a duplicate record
            Assert.Equal(firstCode, secondCode);
            Assert.Equal(1, await context.Mapping.CountAsync());
        }
    }
}
