using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServices.Models;
using DataServices;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Reflection;
using CommonServices;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace DataService
{
    public class MongoDBServices : IMongoDBServices
    {
        private readonly IConfiguration _configuration;
        public MongoDBServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IMongoDatabase GetMongoDbInstance()
        {
            var mongoDBSettings = _configuration.GetSection("MongoDBSettings")
                                                    .Get<MongoDBSettings>();
            var client = new MongoClient(mongoDBSettings?.ConnectionString);
            var db = client.GetDatabase(mongoDBSettings?.DatabaseName);
            return db;
        }
        private IMongoCollection<T> GetCollection<T>()
        {
            string collectionName = string.Empty;
            //DisplayNameAttribute? displayNameAttribute = typeof(T).GetCustomAttribute<DisplayNameAttribute>();
            //if (displayNameAttribute != null)
            //    collectionName = displayNameAttribute.DisplayName;
            //else
            //    collectionName = StringExtensions.ConvertToSnakeCase(typeof(T).Name);
            return GetMongoDbInstance().GetCollection<T>("messenger");
        }
        public async Task CreateDocument<T>(T document)
        {
            GetCollection<T>().InsertOne(document);
        }
        public async Task DeleteDocument<T>(FilterDefinition<T> filter)
        {
            await GetCollection<T>().DeleteOneAsync(filter);
        }
        public async Task<List<T>> GetAllDocuments<T>()
        {
            var collection = GetCollection<T>();
            var xx = collection.Find(x => true).ToList();
            return xx.ToList();
        }
        public async Task<List<T>> GetFilteredDocuments<T>(FilterDefinition<T> filter)
        {
            return await GetCollection<T>().Find(filter).ToListAsync();
        }
        public async Task UpdateDocument<T>(FilterDefinition<T> filter, UpdateDefinition<T> document)
        {
            await GetCollection<T>().UpdateOneAsync(filter, document);
        }
    }
}
