using Crud.Core.Entidades;
using Crud.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Crud.WebApi.Controllers
{
    [Route("/caminhao")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        private readonly ICaminhaoService _caminhaoService;
        public CaminhaoController(ICaminhaoService service)
        {
            _caminhaoService = service;
        }

        [HttpPost]
        public void Post([FromBody] Caminhao caminhao)
        {
            _caminhaoService.Insert(caminhao);
        }

        [HttpPut]
        public void Update([FromBody] Caminhao caminhao)
        {
            _caminhaoService.Update(caminhao);
        }
        
        [HttpGet]
        public IList<Caminhao> GetAll()
        {
            return _caminhaoService.GetAll();

        }

        [HttpGet("{id}")]
        public Caminhao GetById(int id)
        {
            return _caminhaoService.GetById(id);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _caminhaoService.Delete(id);
        }
    }
}
