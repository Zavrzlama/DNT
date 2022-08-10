using System.Data;

namespace DNT.DAL.Interfaces
{
    public interface IDatabaseContext
    {
        IDbConnection Connection { get; set; }
    }
}
