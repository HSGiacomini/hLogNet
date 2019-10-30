using hLogNet.Models;
using System.Collections.Generic;

namespace hLogNet.ViewModels
{
    public class ProcessPanelViewModel
    {
        public IEnumerable<Process> Process { get; set; }
        public List<string> Groups { get; set; }
    }
}
