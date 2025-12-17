using Domain.Models;

namespace Domain.Business
{
    public interface IGBRepository
    {
        public Task<List<GuestBook>> GetEntries();

        public Task <GuestBook> GetEntry(int id);

        public Task <GuestBook> AddEntry(GuestBook entry);

        public Task RemoveEntry(int id);
    }
}
