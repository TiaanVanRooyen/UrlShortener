using Microsoft.EntityFrameworkCore;
using UrlShortener.API.Data;

namespace UrlShortener.API.Services
{
    public interface IUrlShorteningService
    {
        Task<string> ShortenUrlAsync(string longUrl);
        Task<string?> GetOriginalUrlAsync(string code);
    }
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly AppDbContext _context;

        public UrlShorteningService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string?> GetOriginalUrlAsync(string code)
        {
            var mapping = await _context.Mapping.FirstOrDefaultAsync(u => u.Code == code);
            return mapping?.LongUrl;
        }

        public async Task<string> ShortenUrlAsync(string longUrl)
        {
            var existingUrl = await _context.Mapping
                .FirstOrDefaultAsync(u => u.LongUrl == longUrl);

            if (existingUrl != null)
            {
                return existingUrl.Code;
            }

            string code;
            do
            {
                code = Guid.NewGuid().ToString().Substring(0, 7);
            } while (await _context.Mapping.AnyAsync(u => u.Code == code));

            var mapping = new UrlMapping
            {
                LongUrl = longUrl,
                Code = code
            };

            _context.Mapping.Add(mapping);
            await _context.SaveChangesAsync();

            return code;
        }
    }
}
