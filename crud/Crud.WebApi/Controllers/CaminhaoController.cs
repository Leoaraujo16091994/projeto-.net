using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Core.Entidades;
using Crud.Infrastructure.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("/caminhao")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        private readonly ICaminhaoService _caminhaoService;
        public CaminhaoController(ICaminhaoService service)
        {
            _caminhaoService = service;
        }



        // GET: api/Caminhao
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Caminhao/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Caminhao
        [HttpPost]
        public void Post([FromBody] Caminhao caminhao)
        {
            _caminhaoService.Insert(caminhao);
        }

        // PUT: api/Caminhao/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
