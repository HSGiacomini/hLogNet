using hLogNet.Domain.Entities;
using hLogNet.Domain.Interfaces;
using hLogNet.Infra.Data.Context;
using hLogNet.Infra.Data.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hLogNet.Infra.Data.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly MongoContext _context = null;
        private IPanelRepository PanelRepository { get; set; }

        public ProcessRepository(IOptions<Settings> settings, IPanelRepository panelRepository)
        {
            _context = new MongoContext(settings);
            PanelRepository = panelRepository;
        }

        public async Task<IEnumerable<Process>> GetLastProcess()
        {
            IEnumerable<Panel> Panels = await PanelRepository.GetAllPanels();
            List<Process> LastProcess = new List<Process>();

            foreach (var panel in Panels)
            {
                Process process = await GetLastProcessByName(panel.Name);
                if (process == null)
                    continue;

                LastProcess.Add(process);
            }

            return LastProcess;
        }

        public async Task<IEnumerable<Process>> GetProcessDay(DateTime startDate)
        {
            return await _context.Process.Find(x => x.StartDate >= startDate).ToListAsync();
        }

        public async Task<Process> GetProcessByID(string processId)
        {
            var filter = Builders<Process>.Filter.Eq("processid", processId);
            return await _context.Process
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task<Process> GetLastProcessByName(string name)
        {
            try
            {
                return _context.Process
                           .AsQueryable()
                           .Where(x => x.Name == name)
                           .OrderByDescending(z => z.StartDate)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        
        public async Task<Process> GetProcessInitialized(DateTime dateProcess, string processName)
        {
            var filter = Builders<Process>.Filter.And(
                 Builders<Process>.Filter.Gte("startdate", dateProcess.Date),
                  Builders<Process>.Filter.Eq("name", processName)
                );

            return await _context.Process
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task<string> CreateOrUpdateProcess(Process process)
        {
            try
            {

                if (process.Id.Equals("0"))
                    process.Id = Guid.NewGuid().ToString();

                var filter = Builders<Process>.Filter.Eq("processid", process.Id);
                var update = Builders<Process>.Update
                    .Set(o => o.Name, process.Name)
                    .Set(o => o.Group, process.Group)
                    .Set(o => o.StartDate, process.StartDate)
                    .Set(o => o.EndDate, process.EndDate)
                    .Set(o => o.Status, process.Status)
                    .Set(o => o.Observation, process.Observation)
                    .Set(o => o.User, process.User)
                    .PushEach("details", process.Details);

                var result = await _context.Process.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return process.Id;
        }
    }
}
