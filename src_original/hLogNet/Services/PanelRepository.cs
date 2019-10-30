using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hLogNet.Models;
using Microsoft.Extensions.Options;
using static MongoDB.Bson.Serialization.BsonSerializationContext;
using MongoDB.Driver;

namespace hLogNet.Services
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
            return await _context.Panel.Find(_=>true).ToListAsync();
        }
        public async Task Insert(Panel panel)
        {
            await _context.Panel.InsertOneAsync(panel);
        }
    }
}
