using Dapper;
using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNT.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDatabaseContext _context;

        public CompanyRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task Create(Company model)
        {
            var query = new StringBuilder();
            query.Append("INSERT INTO Company(CompanyName,Adress,OIB,OwnerName,OwnerSurname,Email,Description)");
            query.AppendLine("VALUES (@CompanyName,@Adress,OIB,@OwnerName,@OwnerSurname,@Email,@Description);");

            await _context.Connection.ExecuteAsync(query.ToString(), model);
        }

        public async Task Delete(int id)
        {
            var query = new StringBuilder();
            query.Append("DELETE FROM Company WHERE id = @Id");

            var param = new { Id = id };
            await _context.Connection.ExecuteAsync(query.ToString(), param);
        }

        public async Task<IEnumerable<Company>> Filter(Company filter)
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Company");
            query.Append("WHERE 1 = 1");

            if (!string.IsNullOrEmpty(filter.CompanyName))
                query.Append("AND City LIKE %@CompanyName%");

            if (!string.IsNullOrEmpty(filter.City))
                query.Append("AND City LIKE %@City%");

            return await _context.Connection.QueryAsync<Company>(query.ToString());
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Company");

            return await _context.Connection.QueryAsync<Company>(query.ToString());
        }

        public async Task<Company> GetById(int id)
        {
            var query = new StringBuilder();
            query.Append("SELECT * FROM Company WHERE id = @Id");

            var param = new { Id = id };
            return await _context.Connection.QuerySingleAsync<Company>(query.ToString(), param);
        }

        public async Task<int> GetLastInsertedId()
        {
            var query = new StringBuilder();
            query.Append("SELECT MAX(Id) FROM Company");

            return await _context.Connection.QuerySingleAsync<int>(query.ToString());
        }

        public async Task Update(Company model)
        {
            var query = new StringBuilder();
            query.Append(" UPDATE Company ");
            query.AppendLine(" SET CompanyName = @CompanyName, ");
            query.AppendLine(" Adress = @Adress, ");
            query.AppendLine(" City = @City, ");
            query.AppendLine(" OIB = @OIB, ");
            query.AppendLine(" OwnerName = @OwnerName, ");
            query.AppendLine(" OwnerSurname = @OwnerSurname, ");
            query.AppendLine(" Email = @Email, ");
            query.AppendLine(" Description = @Description ");
            query.AppendLine(" WHERE Id = @Id");

            await _context.Connection.ExecuteAsync(query.ToString(), model);
        }
    }
}
