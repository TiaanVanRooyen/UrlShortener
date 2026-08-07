using UrlShortener.API.Services;

namespace UrlShortener.API.Endpoints
{
    public static class ShorteningEnpoints
    {
        public static void MapEnpoints(this WebApplication app)
        {
            app.MapPost("/shorten", async (UrlRequest request, IUrlShorteningService service, HttpContext context) =>
            {
                if ((string.IsNullOrWhiteSpace(request.Url)) || (!Uri.TryCreate(request.Url, UriKind.Absolute, out _)))
                {
                    return Results.BadRequest(new { Message = "Invalid URL format. Please provide a valid absolute URL." });
                }

                var code = await service.ShortenUrlAsync(request.Url);
                var resultUrl = $"{context.Request.Scheme}://{context.Request.Host}/{code}";

                return Results.Ok(new { ShortUrl = resultUrl, Code = code });
            });

            app.MapGet("/{code}", async (string code, IUrlShorteningService service) =>
            {
                var originalUrl = await service.GetOriginalUrlAsync(code);

                if (originalUrl is null)
                {
                    return Results.NotFound(new { Message = "Short URL not found." });
                }

                return Results.Redirect(originalUrl);
            });
        }

        private record UrlRequest(string Url);
    }
}
