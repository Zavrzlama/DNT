using Dapper;
using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNT.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _context;

        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task Create(User model)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO User(Name,Surname,Email, OIB, Adress, City, CompanyId)");
            query.AppendLine("VALUES (@Name, @Surname, @Email, @OIB, @Adress, @City, @CompanyId);");

            var param = new
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                OIB = model.OIB,
                Adress = model.Adress,
                City = model.City,
                CompanyId = model.Company.Id
            };
            await _context.Connection.ExecuteAsync(query.ToString(), param);
        }

        public async Task Delete(int id)
        {
            var query = new StringBuilder();
            query.Append("DELETE FROM User WHERE id = @Id");

            var param = new { Id = id };
            await _context.Connection.ExecuteAsync(query.ToString(), param);
        }

        public Task<IEnumerable<User>> Filter(User filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM User");

            return await _context.Connection.QueryAsync<User>(query.ToString());
        }

        public async Task<User> GetById(int id)
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM User WHERE id = @Id");

            return await _context.Connection.QuerySingleAsync<User>(query.ToString());
        }

        public async Task<int> GetLastInsertedId()
        {
            var query = new StringBuilder();
            query.Append("SELECT MAX(Id) FROM User");

            return await _context.Connection.QuerySingleAsync<int>(query.ToString());
        }

        public async Task Update(User model)
        {
            var query = new StringBuilder();
            query.Append("UPDATE User");
            query.AppendLine("SET Name = @Name,");
            query.AppendLine("Surname = @Surname,");
            query.AppendLine("Email = @Email,");
            query.AppendLine("OIB = @OIB,");
            query.AppendLine("Adress = @Adress,");
            query.AppendLine("City = @City,");
            query.AppendLine("CompanyId = @CompanyId");
            query.AppendLine("WHERE Id = @Id");

            await _context.Connection.ExecuteAsync(query.ToString(), model);
        }
    }
}
