using hLogNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hLogNet.Domain.Interfaces
{
    public interface IProcessRepository
    {
        Task<IEnumerable<Process>> GetLastProcess();
        Task<IEnumerable<Process>> GetProcessDay(DateTime startDate);
        Task<Process> GetProcessInitialized(DateTime dateProcess, string processName);
        Task<Process> GetProcessByID(string processId);
        Task<string> CreateOrUpdateProcess(Process process);
    }
}
