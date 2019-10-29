using hLogNet.Application.Interfaces;
using hLogNet.Domain.Entities;
using hLogNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hLogNet.Application.Services
{
    public class PanelAppService : IPanelAppService
    {
        private IPanelRepository _panelrepository;

        public PanelAppService(IPanelRepository panelrepository)
        {
            _panelrepository = panelrepository;
        }

        public async Task<IEnumerable<Panel>> GetAllPanelsAsync()
        {
            return await _panelrepository.GetAllPanels();
        }

        public async Task InsertAsync(Panel panel)
        {
            panel.Id = Guid.NewGuid().ToString();
            await _panelrepository.Insert(panel);
        }
    }
}
