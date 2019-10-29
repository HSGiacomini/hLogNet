using hLogNet.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hLogNet.Domain.Interfaces
{
    public interface IPanelRepository
    {
        Task<IEnumerable<Panel>> GetAllPanels();
        Task Insert(Panel panel);
    }
}
