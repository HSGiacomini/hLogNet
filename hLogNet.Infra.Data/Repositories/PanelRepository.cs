using hLogNet.Domain.Entities;
using hLogNet.Domain.Interfaces;
using hLogNet.Infra.Data.Context;
using hLogNet.Infra.Data.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hLogNet.Infra.Data.Repositories
{
    public class PanelRepository : IPanelRepository
    {
        private readonly MongoContext _context = null;

        public PanelRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }
        public async Task<IEnumerable<Panel>> GetAllPanels()
        {
            return await _context.Panel.Find(_ => true).ToListAsync();
        }
        public async Task Insert(Panel panel)
        {
            await _context.Panel.InsertOneAsync(panel);
        }
    }
}
