using System;

namespace hLogNet.Domain.Entities
{
    public class Detail
    {
        public string Action { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string RefId { get; set; }
        public string Info { get; set; }
        public string Status { get; set; }
    }
}
