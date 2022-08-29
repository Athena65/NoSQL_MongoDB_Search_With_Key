using MongoDB.Driver;

namespace NewMongoDBProjectAnd_SearchUsers.Configurations
{
    public class DeveloperDatabaseConfiguration
    {
        //this is dependency injection to access values 
        public string CustomerCollectionName { get; set; }  
        public string ConnectionString { get; set; }    
        public string DatabaseName { get; set; }    
    }
}
