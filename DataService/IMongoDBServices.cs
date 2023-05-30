using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IMongoDBServices
    {
        Task<List<T>> GetAllDocuments<T>();
        Task<List<T>> GetFilteredDocuments<T>(FilterDefinition<T> filter);
        Task UpdateDocument<T>(FilterDefinition<T> filter, UpdateDefinition<T> document);
        Task CreateDocument<T>(T document);
        Task DeleteDocument<T>(FilterDefinition<T> filter);
    }
}
