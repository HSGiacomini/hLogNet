using hLogNet.Domain.Entities;
using System.Collections.Generic;

namespace hLogNet.Application.ViewModels
{
    public class ProcessPanelViewModel
    {
        public IEnumerable<Process> Process { get; set; }
        public List<string> Groups { get; set; }
    }
}
