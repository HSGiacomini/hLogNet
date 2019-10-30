using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hLogNet.Services;
using hLogNet.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace hLogNet.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LogController : Controller
    {

        private IProcessRepository ProcessRepository { get; set; }
        private IPanelRepository PanelRepository { get; set; }

        public LogController(IProcessRepository processRepository, IPanelRepository panelRepository)
        {
            ProcessRepository = processRepository;
            PanelRepository = panelRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcess([FromRoute] string id)
        {
            try
            {
                var process = await ProcessRepository.GetProcessByID(id) ?? new Process();
                return Ok(process);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("lastprocess/")]
        public async Task<IActionResult> GetLastProcess()
        {
            try
            {
                var processes = await ProcessRepository.GetLastProcess();

                return Ok(processes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST api/Process
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Process process)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                process.ProcessId = await ProcessRepository.CreateOrUpdateProcess(process);

                return Ok(process);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("panel")]
        public async Task<IActionResult> PostPanel([FromBody] Panel panel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await PanelRepository.Insert(panel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
