using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace hLogNet.Models
{
    [BsonIgnoreExtraElements]
    public class Detail
    {
        [BsonElement("action")]
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [BsonElement("executiontime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExecutionTime { get; set; }

        [BsonElement("refid")]
        public string RefId { get; set; }

        [BsonElement("info")]
        public string Info { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }
    }
}
