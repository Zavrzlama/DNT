using DNT.DAL.Interfaces;
using DNT.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNT.DAL.Repositories
{
    public class TransatctionRepository : ITransactionRepository
    {
        public Task Create(Transaction model)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Transaction> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Transaction model)
        {
            throw new System.NotImplementedException();
        }
    }
}
