using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    [DisplayName("line_notify_config")]
    [BsonIgnoreExtraElements]
    public class LineNotifyConfig
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("access_token")]
        public string? AccessToken { get; set; }
        [BsonElement("notify_name")]
        public string? NotifyName { get; set; }
        [BsonElement("notification_disabled")]
        public bool? NotificationDisabled { get; set; } = false;
        
        [BsonElement("remaining")]
        public int? Remaining { get; set; }
        [BsonElement("reset_at")]
        public DateTime? ResetAt { get; set; } = DateTime.Now;
        [BsonElement("create_at")]
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        [BsonElement("create_by")]
        public string? CreateBy { get; set; } = "system";
        [BsonElement("update_by")]
        public string? UpdateBy { get; set; }
        [BsonElement("update_at")]
        public DateTime? UpdateAt { get; set; }
    }
}
