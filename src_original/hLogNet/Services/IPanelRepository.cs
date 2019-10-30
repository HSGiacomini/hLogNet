using hLogNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hLogNet.Services
{
    public interface IPanelRepository
    {
        Task<IEnumerable<Panel>> GetAllPanels();
        Task Insert(Panel panel);
    }
}
