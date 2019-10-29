using hLogNet.Application.Interfaces;
using hLogNet.Domain.Entities;
using hLogNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hLogNet.Application.Services
{
    public class ProcessAppService : IProcessAppService
    {
        private IProcessRepository _processrepository;

        public ProcessAppService(IProcessRepository processrepository)
        {
            _processrepository = processrepository;
        }

        public async Task<string> CreateOrUpdateProcessAsync(Process process)
        {
            return await _processrepository.CreateOrUpdateProcess(process);
        }

        public async Task<IEnumerable<Process>> GetLastProcessAsync()
        {
            return await _processrepository.GetLastProcess();
        }

        public async Task<Process> GetProcessByIDAsync(string processId)
        {
            return await _processrepository.GetProcessByID(processId);
        }

        public async Task<IEnumerable<Process>> GetProcessDayAsync(DateTime startDate)
        {
            return await _processrepository.GetProcessDay(startDate);
        }

        public async Task<Process> GetProcessInitializedAsync(DateTime dateProcess, string processName)
        {
            return await _processrepository.GetProcessInitialized(dateProcess, processName);
        }
    }
}
