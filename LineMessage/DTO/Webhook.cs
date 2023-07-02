using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel;

namespace LineMessage.DTO
{
    public class WebHookRequset
    {
        public string? Destination { get; set; }
        public List<Event>? Events { get; set; }
    }
    public class DeliveryContext
    {
        public bool? IsRedelivery { get; set; }
    }
    public class Event
    {
        public string? Type { get; set; }
        public Message? Message { get; set; }
        public Source? Source { get; set; }
        public string? ReplyToken { get; set; }
        public string? Mode { get; set; }
        public string? WebhookEventId { get; set; }
        public DeliveryContext? DeliveryContext { get; set; }
    }
    public class Message
    {
        public string? Type { get; set; }
        public string? Id { get; set; }
        public string? Text { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Source
    {
        public string? Type { get; set; }
        public string? UserId { get; set; }
        public string? GroupId { get; set; }

    }
}
