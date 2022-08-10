using DNT.DAL.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DNT.DAL.DBUtils
{
    public class DatabaseContext : IDatabaseContext
    {
        public IDbConnection Connection { get; set; }

        public DatabaseContext(IConfiguration configuration)
        {
            Connection = new SqliteConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}