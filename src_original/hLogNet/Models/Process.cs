using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace hLogNet.Models
{
    [BsonIgnoreExtraElements]
    public class Process
    {
        [BsonElement("processid")]
        public string ProcessId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("group")]
        public string Group { get; set; }

        [BsonElement("startdate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }

        [BsonElement("enddate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("observation")]
        public string Observation { get; set; }

        [BsonElement("user")]
        public string User { get; set; }

        [BsonElement("details")]
        public List<Detail> Details { get; set; }
    }
}
