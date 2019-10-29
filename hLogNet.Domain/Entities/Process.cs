using System;
using System.Collections.Generic;

namespace hLogNet.Domain.Entities
{
    public class Process
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Observation { get; set; }
        public string User { get; set; }
        public List<Detail> Details { get; set; }
    }
}
