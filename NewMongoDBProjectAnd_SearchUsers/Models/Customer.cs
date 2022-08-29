using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NewMongoDBProjectAnd_SearchUsers.Models
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //cuz mongodb recognize ObjectId not string or int
        public string Id { get; set; }
        [Required(ErrorMessage="First name is required")] //mandatory
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [BsonElement("PhoneNumber")] //For save as phonenumber in the document
        public string Contact { get; set; }
        [Required(ErrorMessage = "Email is required")] //mandatory
        public string Email { get; set; }
    }
}
