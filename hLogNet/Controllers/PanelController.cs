using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hLogNet.Application.Interfaces;
using hLogNet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hLogNet.Controllers
{
    [Produces("application/json")]
    [Route("api/Panel")]
    public class PanelController : Controller
    {
        private IPanelAppService _panelAppService;

        public PanelController(IPanelAppService panelAppService)
        {
            _panelAppService = panelAppService;
        }

        // GET: api/Panel
        [HttpGet]
        public async Task<IEnumerable<Panel>> GetAsync()
        {
            //return new string[] { "value1", "value2" };
            return await _panelAppService.GetAllPanelsAsync();
        }

        // GET: api/Panel/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Panel
        [HttpPost]
        public async Task PostAsync([FromBody]Panel item)
        {
            await _panelAppService.InsertAsync(item);
        }
        
        // PUT: api/Panel/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
