using Dapper;
using Domain.Models;
using Microsoft.Data.SqlClient;

namespace Domain.Business
{
    public class GBRepository : IGBRepository
    {
        private readonly string _connectionString;

        public GBRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<GuestBook>> GetEntries()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sql = "SELECT * FROM [GuestBook] ORDER BY GuestId DESC";
                var results = await connection.QueryAsync<GuestBook>(sql);

                return results.ToList();
            }
        }

        public async Task<GuestBook> GetEntry(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sql = "SELECT TOP 1 * FROM [GuestBook] WHERE GuestId = @GuestId";
                var result = await connection.QuerySingleOrDefaultAsync<GuestBook>(sql, new { GuestId = id });

                if (result != null)
                { 
                    return result; 
                }
                return new();

            }

        }

        public async Task<GuestBook> AddEntry(GuestBook entry)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "INSERT INTO [GuestBook] ([EmailAddress], [Comment], [CreatedDate]) VALUES (@EmailAddress, @Comment, GetDate()); SELECT CAST(SCOPE_IDENTITY() as int)";

                var identity = connection.Execute(sql, new { EmailAddress = entry.EmailAddress, Comment = entry.Comment });

                return await GetEntry(identity);
            }
        }

        public async Task<GuestBook> UpdateEntry(GuestBook entry)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "UPDATE [GuestBook] SET [EmailAddress] = @EmailAddress, [Comment] = @Comment WHERE GuestId = @GuestId";

                var result = connection.Execute(sql, new { EmailAddress = entry.EmailAddress, Comment = entry.Comment, GuestId = entry.GuestId });

                return entry;
            }
        }

        public async Task RemoveEntry(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "DELETE [GuestBook] WHERE GuestId = @GuestId";

                var identity = connection.Execute(sql, new { GuestId = id });

            }
        }
    }
}
