using Dapper;
using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DNT.DAL.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IDatabaseContext _context;

        public CardRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task Create(Card model)
        {
            var query = new StringBuilder();
            
            if (model.User != null)
            {
                query.Append("INSERT INTO Card(Date, UID, UserId Active)");
                query.AppendLine("VALUES (@Date, @UID, @UserId, @Active)");

                var parameters = new
                {
                    Date = model.Date,
                    UID = model.UID,
                    UserId = model.User.Id,
                    Active = model.IsActive
                };
                await _context.Connection.ExecuteAsync(query.ToString(), parameters);
            }

            if (model.Company != null)
            {
                query.Append("INSERT INTO Card(Date, UID, CompanyId, Active)");
                query.AppendLine("VALUES (@Date, @UID, @CompanyId, @Active)");

                var parameters = new
                {
                    Date = model.Date,
                    UID = model.UID,
                    CompanyId = model.Company.Id,
                    Active = model.IsActive
                };

                await _context.Connection.ExecuteAsync(query.ToString(), parameters);
            }            
        }

        public async Task Delete(int id)
        {
            var query = new StringBuilder();
            query.Append("DELETE FROM Card WHERE id = @Id");

            var param = new { Id = id };
            await _context.Connection.ExecuteAsync(query.ToString(), param);
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Card");

            return await _context.Connection.QueryAsync<Card>(query.ToString());
        }

        public async Task<Card> GetById(int id)
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Card WHERE id = @Id");

            var param = new { Id = id };
            return await _context.Connection.QuerySingleAsync<Card>(query.ToString(), param);
        }

        public async Task Update(Card model)
        {
            var query = new StringBuilder();
            query.Append(" UPDATE Card ");
            query.AppendLine(" SET Contract=@Contract, ");
            query.AppendLine(" Date= @Date,  ");
            query.AppendLine(" CompanyId= @CompanyId, ");
            query.AppendLine(" UserId = @UserId, ");
            query.AppendLine(" Active=@Active ");
            query.AppendLine(" WHERE Id = @Id");

            await _context.Connection.ExecuteAsync(query.ToString(), model);
        }

        public async Task<IEnumerable<Card>> GetCardsForOverview()
        {
            var query = new StringBuilder();
            query.AppendLine("SELECT c.id, c.Date, u.id UserId, u.Name, u.Surname, co.Id CompanyId, co.CompanyName");
            query.AppendLine(" FROM CARD C");
            query.AppendLine(" LEFT JOIN User U ON C.UserId = U.ID");
            query.AppendLine(" JOIN Company co on u.CompanyId = co.id");
            query.AppendLine(" UNION");
            query.AppendLine(" SELECT c.id, c.Date, NULL UserId, NULL, NULL ,co.Id CompanyId, co.CompanyName");
            query.AppendLine(" FROM Card c");
            query.AppendLine(" JOIN Company co on c.CompanyId = co.Id");


            return await _context.Connection.QueryAsync<Card, User, Company, Card>(query.ToString(),
                (card, user, company) =>
                {
                    card.User = user;
                    card.Company = company;
                    return card;
                }, splitOn: "UserId,CompanyId");
        }

        public async Task<IEnumerable<Card>> GetCardsForCompany(Company model)
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Card WHERE CompanyId = @CompanyId");

            var param = new { CompanyId = model.Id };
            return await _context.Connection.QueryAsync<Card>(query.ToString(), param);
        }

        public async Task<IEnumerable<Card>> GetCardsForUser(User model)
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Card WHERE UserId = @UserId");

            var param = new { UserId = model.Id };
            return await _context.Connection.QueryAsync<Card>(query.ToString(), param);
        }

        public Task<IEnumerable<Card>> Filter(Card filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetLastInsertedId()
        {
            throw new System.NotImplementedException();
        }
    }
}
