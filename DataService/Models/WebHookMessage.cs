using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    public class DeliveryContext
    {
        public bool IsRedelivery { get; set; }
    }

    public class Event
    {
        public string Type { get; set; }
        public Message Message { get; set; }
        public object Timestamp { get; set; }
        public Source Source { get; set; }
        public string ReplyToken { get; set; }
        public string Mode { get; set; }
        public string WebhookEventId { get; set; }
        public DeliveryContext DeliveryContext { get; set; }
    }

    public class Message
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class WebHookMessage
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string Destination { get; set; }
        public List<Event> Events { get; set; }
    }

    public class Source
    {
        public string Type { get; set; }
        public string UserId { get; set; }
    }


}
