using MongoDB.Bson.Serialization.Attributes;

namespace LineMessage.DTO
{
    public class LineNotifyConfigRequest
    {
        public string? AccessToken { get; set; }
        public string? NotifyName { get; set; }
        public bool? NotificationDisabled { get; set; } = false;
    }
    public class LineNotifyConfigRequestUpdate
    {
        public string? Id { get; set; }
        public string? AccessToken { get; set; }
        public string? NotifyName { get; set; }
        public bool? NotificationDisabled { get; set; } = false;
    }
}
