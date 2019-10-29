using hLogNet.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hLogNet.Application.Interfaces
{
    public interface IPanelAppService
    {
        Task<IEnumerable<Panel>> GetAllPanelsAsync();
        Task InsertAsync(Panel panel);
    }
}
