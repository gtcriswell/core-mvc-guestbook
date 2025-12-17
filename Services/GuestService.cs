using Domain.Dtos;
using System.Net.Http.Json;


namespace Services
{
    #region interface

    public interface IGuestService
    {
        public Task<List<GuestbookDto>> GetEntries(CancellationToken cancellationToken = default);

        public Task<GuestbookDto> AddEntry(GuestbookDto guestbookDto, CancellationToken cancellationToken = default);

        public Task RemoveEntry(int id, CancellationToken cancellationToken = default);

        public Task<GuestbookDto> UpdateEntry(GuestbookDto guestbookDto, CancellationToken cancellationToken = default);
    }

    #endregion

    public class GuestService: IGuestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private static readonly System.Text.Json.JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        public GuestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GuestbookDto>> GetEntries(CancellationToken cancellationToken = default)
        {
            HttpClient client = _httpClientFactory.CreateClient("API");
            string url = "api/guestbook/entries";


            try
            {
                // Pass the object, not a serialized string
                HttpResponseMessage response = await client.GetAsync(url, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    List<GuestbookDto>?  guestBook = await response.Content.ReadFromJsonAsync<List<GuestbookDto>>(_jsonOptions, cancellationToken).ConfigureAwait(false);

                    return guestBook ?? new List<GuestbookDto>();
                }

                return new List<GuestbookDto>();
            }
            catch (OperationCanceledException)
            {
                // Propagate cancellation
                throw;
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                return new List<GuestbookDto>();
            }
        }

        public async Task<GuestbookDto> AddEntry(GuestbookDto guestbookDto, CancellationToken cancellationToken = default)
        {
            HttpClient client = _httpClientFactory.CreateClient("API");
            string url = "api/guestbook/entry";


            try
            {
                // Pass the object, not a serialized string
                HttpResponseMessage response = await client.PostAsJsonAsync(url, guestbookDto, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    GuestbookDto? guestBook = await response.Content.ReadFromJsonAsync<GuestbookDto>(_jsonOptions, cancellationToken).ConfigureAwait(false);

                    return guestBook ?? new GuestbookDto();
                }

                return new GuestbookDto();
            }
            catch (OperationCanceledException)
            {
                // Propagate cancellation
                throw;
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                return new GuestbookDto();
            }
        }

        public async Task RemoveEntry(int id, CancellationToken cancellationToken = default)
        {
            HttpClient client = _httpClientFactory.CreateClient("API");
            string url = $"api/guestbook/entry?id={id}";


            try
            {
                // Pass the object, not a serialized string
                HttpResponseMessage response = await client.DeleteAsync(url, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return;
                }

            }
            catch (OperationCanceledException)
            {
                // Propagate cancellation
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GuestbookDto> UpdateEntry(GuestbookDto guestbookDto, CancellationToken cancellationToken = default)
        {
            HttpClient client = _httpClientFactory.CreateClient("API");
            string url = "api/guestbook/entry";


            try
            {
                // Pass the object, not a serialized string
                HttpResponseMessage response = await client.PutAsJsonAsync(url, guestbookDto, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return guestbookDto;
                }

                return new GuestbookDto();

            }
            catch (OperationCanceledException)
            {
                // Propagate cancellation
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
