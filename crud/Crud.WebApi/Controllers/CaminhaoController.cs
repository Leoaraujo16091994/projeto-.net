using Crud.Core.Entidades;
using Crud.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // POST: api/Caminhao
        [HttpPost]
        public void Post([FromBody] Caminhao caminhao)
        {
            _caminhaoService.Insert(caminhao);
        }

        // PUT: api/Caminhao/5
        [HttpPut]
        public void Update([FromBody] Caminhao caminhao)
        {
            _caminhaoService.Update(caminhao);
        }
        
        // GET: api/Caminhao
        [HttpGet]
        public IList<Caminhao> GetAll()
        {
            return _caminhaoService.GetAll();

        }

        // GET: api/Caminhao/5
        [HttpGet("{id}")]
        public Caminhao GetById(int id)
        {
            return _caminhaoService.GetById(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _caminhaoService.Delete(id);
        }
    }
}
