using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataServices.Models
{
    [DisplayName("messenger")]
    [BsonIgnoreExtraElements]
    public class WebHookMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("destination")]
        public string? Destination { get; set; }
        [BsonElement("events")]
        public List<Event>? Events { get; set; }
        [BsonElement("create_date")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
    [BsonIgnoreExtraElements]
    public class DeliveryContext
    {
        [BsonElement("is_redelivery")]
        public bool? IsRedelivery { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Event
    {
        [BsonElement("type")]
        public string? Type { get; set; }
        [BsonElement("message")]
        public Message? Message { get; set; }
        [BsonElement("source")]
        public Source? Source { get; set; }
        [BsonElement("reply_token")]
        public string? ReplyToken { get; set; }
        [BsonElement("mode")]
        public string? Mode { get; set; }
        [BsonElement("webhook_event_id")]
        public string? WebhookEventId { get; set; }
        [BsonElement("delivery_context")]
        public DeliveryContext? DeliveryContext { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Message
    {
        [BsonElement("type")]
        public string? Type { get; set; }
        [BsonElement("id")]
        public string? Id { get; set; }
        [BsonElement("text")]
        public string? Text { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Source
    {
        [BsonElement("type")]
        public string? Type { get; set; }
        [BsonElement("user_id")]
        public string? UserId { get; set; }
        [BsonElement("group_id")]
        public string? GroupId { get; set; }

    }
}
