using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonServices
{
    public class MongoSerializer : IBsonSerializer
    {
        public Type ValueType => typeof(DateTime);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var type = context.Reader.GetCurrentBsonType();
            if (type == BsonType.String)
            {
                var s = context.Reader.ReadString();
                if (s.Equals("N/A", StringComparison.InvariantCultureIgnoreCase))
                {
                    return DateTime.Now;
                }
                else
                {
                    return DateTime.ParseExact(s, "yyyy-MM-dd HH:mm:ss.zzz", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            else if (type == BsonType.DateTime)
            {
                var xx = context.Reader.ReadDateTime();
                return DateTime.Now;
            }
            // Add any other types you need to handle
            else
            {
                return DateTime.Now;
            }
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            throw new NotImplementedException();
        }
    }
}
