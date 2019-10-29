using hLogNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hLogNet.Application.Interfaces
{
    public interface IProcessAppService
    {
        Task<IEnumerable<Process>> GetLastProcessAsync();
        Task<IEnumerable<Process>> GetProcessDayAsync(DateTime startDate);
        Task<Process> GetProcessInitializedAsync(DateTime dateProcess, string processName);
        Task<Process> GetProcessByIDAsync(string processId);
        Task<string> CreateOrUpdateProcessAsync(Process process);
    }
}
