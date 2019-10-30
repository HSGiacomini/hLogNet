using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hLogNet.Models
{
    [BsonIgnoreExtraElements]
    public class Panel
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("group")]
        public string Group { get; set; }
    }
}
