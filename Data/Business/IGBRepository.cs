using Domain.Data;
using Domain.Models;

namespace Domain.Business
{
    public interface IGBRepository
    {
        public IQueryable<GuestBook> GetEntries();

        public GuestBook? GetEntry(int id);

        public GuestBook AddEntry(GuestBook entry);

        public void RemoveEntry(int id);
    }
}
