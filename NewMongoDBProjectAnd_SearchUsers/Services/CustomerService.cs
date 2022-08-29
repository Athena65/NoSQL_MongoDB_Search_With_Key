using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NewMongoDBProjectAnd_SearchUsers.Configurations;
using NewMongoDBProjectAnd_SearchUsers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewMongoDBProjectAnd_SearchUsers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        private readonly DeveloperDatabaseConfiguration _settings;

        public CustomerService(IOptions<DeveloperDatabaseConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _customer = database.GetCollection<Customer>(_settings.CustomerCollectionName);


        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _customer.InsertOneAsync(customer);
            return customer;
        }

        public async Task DeleteAsync(string id)
        {
            await _customer.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customer.Find(c => true).ToListAsync();
        }



        public async Task<Customer> GetByIdAsync(string id)
        {

            return await _customer.Find<Customer>(c => c.Id == id).FirstOrDefaultAsync();

        }

        public async Task UpdateAsync(string id, Customer customer)
        {
            await _customer.ReplaceOneAsync(c => c.Id == id, customer);
        }

        public Task<List<Customer>> GetAllWithFirstNameKey(string key)
        {
            
            
            var filter = Builders<Customer>.Filter.Where(x => x.FirstName.ToLower().Contains(key));
            var customer = _customer.Find(filter).ToListAsync();
            return customer;
        }

        public Task<List<Customer>> SearchWithLastNameKey(string key)
        {
            var filter = Builders<Customer>.Filter.Where(x => x.LastName.ToLower().Contains(key));
            var customer = _customer.Find(filter).ToListAsync();
            return customer;
        }


 
    }
    
}
