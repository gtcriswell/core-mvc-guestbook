using Domain.Data;
using Domain.Models;

namespace Domain.Business
{
    public class GBRepository: IGBRepository
    {
        private readonly GBContext _gBContext;
        public GBRepository(GBContext context)
        {
            _gBContext = context;
        }

        public IQueryable<GuestBook> GetEntries()
        {
            return _gBContext.GuestBooks;
        }

        public GuestBook? GetEntry(int id)
        {
            return _gBContext.GuestBooks.Find(id);
        }

        public GuestBook AddEntry(GuestBook entry)
        {
            _gBContext.GuestBooks.Add(entry);
            _gBContext.SaveChanges();
            return entry;
        }

        public void RemoveEntry(int id)
        {
            var entry = GetEntry(id);
            if(entry == null)
            {
                return;
            }
            _gBContext.GuestBooks.Remove(entry);
            _gBContext.SaveChanges();
            return;
        }
    }
}
