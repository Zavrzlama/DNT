using DNT.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNT.DAL.Interfaces
{
    public interface ICardRepository : IAsyncRepository<Card>
    {
        Task<IEnumerable<Card>> GetCardsForOverview();
        Task<IEnumerable<Card>> GetCardsForCompany(Company model);
        Task<IEnumerable<Card>> GetCardsForUser(User model);
    }
}
