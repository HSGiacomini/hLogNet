using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hLogNet.Services;
using hLogNet.Models;
using hLogNet.ViewModels;
using System.Threading;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace hLogNet.Controllers
{
    public class PanelLogController : Controller
    {

        private readonly IProcessRepository _logRepository;

        public PanelLogController(IProcessRepository logRepository)
        {
            _logRepository = logRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> IndexBody()
        {
            IEnumerable<Process> listProcess = await _logRepository.GetLastProcess();

            ProcessPanelViewModel processPanel = new ProcessPanelViewModel();

            processPanel.Process = listProcess;
            processPanel.Groups = listProcess.Select(x => x.Group).Distinct().ToList();

            return PartialView("_index", processPanel);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(string processId)
        {
            Process process = await _logRepository.GetProcessByID(processId);
            return View(process);
        }
    }
}
