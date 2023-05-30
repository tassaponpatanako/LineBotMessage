using CommonServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    [DisplayName("shop_users")]
    [BsonIgnoreExtraElements]
    public class ShopUser
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public ObjectId Id { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("password")]
        public string? Password { get; set; }
        [BsonElement("is_delete")]
        public bool IsDelete { get; set; }
        [BsonElement("roles")]
        public List<ObjectId> Roles { get; set; } = new List<ObjectId>();
        [BsonElement("is_owner_account")]
        public bool IsOwnerAccount { get; set; }
        [BsonElement("first_name")]
        public string? FirstName { get; set; }
        [BsonElement("last_name")]
        public string? LastName { get; set; }
        [BsonElement("access_token")]
        public string? AccessToken { get; set; }
        [BsonElement("__v")]
        public int version { get; set; }
        [BsonElement("updatedAt")]
        [BsonSerializer(typeof(MongoSerializer))]
        public DateTime UpdatedAt { get; set; }
        [BsonElement("assign_branches")]
        public List<ObjectId> AssignBranches { get; set; } = new List<ObjectId>();
        [BsonElement("is_enable")]
        public bool IsEnable { get; set; }
        [BsonElement("owner_shop")]
        public ObjectId OwnerShop { get; set; }
        [BsonElement("refresh_token")]
        public string? RefreshToken { get; set; }
        [BsonElement("app_access_token")]
        public string? AppAccessToken { get; set; }
        [BsonElement("app_refresh_token")]
        public string? AppRefreshToken { get; set; }
    }
}
