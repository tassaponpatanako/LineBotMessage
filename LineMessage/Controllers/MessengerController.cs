using DataServices;
using DataServices.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace LineMessage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessengerController : ControllerBase
    {
        private readonly IMongoDBServices _dbServices;
        public MessengerController(IMongoDBServices mongo)
        {
            _dbServices = mongo;
        }
        [HttpPost]
        public async Task<IActionResult> TEST()
        {
            LogMongoDBModel model = new LogMongoDBModel()
            {
                ApiURL = ""
            };
            await Insert();
            //var xx = await _dbServices.GetAllDocuments<LogMongoDBModel>();
            return await Task.FromResult(StatusCode(200, model));
        }
        private async Task<LogMongoDBModel> Insert()
        {
            try
            {
                BsonDocument bsonContent = new BsonDocument();
                LogMongoDBModel model = new LogMongoDBModel()
                {
                    ApiURL = ""
                };

                var mongoClient = new MongoClient("mongodb+srv://techdice99:iJE80jPswzhVp6WD@rolldice.upfj8j1.mongodb.net/?retryWrites=true&w=majority");
                var database = mongoClient.GetDatabase($"RollDice");
                var collection = database.GetCollection<LogMongoDBModel>($"messenger"); // เข้า document
                //collection.InsertOne(model);
                var xx = await collection.Find(x => true).ToListAsync();
                return model;
            }
            catch
            {
                return new LogMongoDBModel();
            }

        }
    }
}
