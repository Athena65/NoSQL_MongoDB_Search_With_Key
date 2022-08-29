using NewMongoDBProjectAnd_SearchUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewMongoDBProjectAnd_SearchUsers.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAllAsync();
        public Task<List<Customer>> GetAllWithFirstNameKey(string key);
        public Task<List<Customer>> SearchWithLastNameKey(string key);
        public Task<Customer> GetByIdAsync(string id);
        public Task<Customer> CreateAsync(Customer customer);
        public Task UpdateAsync(string id,Customer customer);
        public Task DeleteAsync(string id);


    }
}
