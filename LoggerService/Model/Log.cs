using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoggerService.Model
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("User")]
        public string User { get; set; } = null!;

        [BsonElement("LogText")]
        public string LogText { get; set; } = null!;

        [BsonElement("Service")]
        public string Service { get; set; } = null!;
    }
}
