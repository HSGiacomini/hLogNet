using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hLogNet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace hLogNet.Services
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

        //public async Task<IEnumerable<Process>> GetLastProcess()
        //{
        //    List<Process> pps = new List<Process>();

        //    var aggregate = _context.Process.Aggregate().Group(new BsonDocument { { "_id", "$name" }, { "count", new BsonDocument("$sum", 1) } });

        //    var results = await aggregate.ToListAsync();


        //    foreach (var item in results)

        //    {
        //        var pp =_context.Process
        //            .AsQueryable().Where(l => l.Name == item["_id"].ToString())
        //            .AsQueryable()
        //            .OrderByDescending(l => l.StartDate)
        //            .FirstOrDefault();
        //        pps.Add(new Process() { ProcessId = pp.ProcessId, Group = pp.Group, Name =  pp.Name, Observation = pp.Observation, StartDate = pp.StartDate, EndDate = pp.EndDate, Status = pp.Status, User = pp.User,Details = pp.Details });
        //    }

        //    // return await _context.Process.Find(_ => true).ToListAsync();
        //    return pps;
        //}

        public async Task<IEnumerable<Process>> GetLastProcess()
        {
            IEnumerable<Panel> Panels = await PanelRepository.GetAllPanels();
            List<Process> LastProcess = new List<Process>();

            foreach(var panel in Panels)
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

                if (process.ProcessId.Equals("0"))
                    process.ProcessId = Guid.NewGuid().ToString().Substring(24, 12);

                var filter = Builders<Process>.Filter.Eq("processid", process.ProcessId);
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

            return process.ProcessId;
        }

     
    }
}
