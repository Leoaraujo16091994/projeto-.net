using Crud.Core.Entidades;
using Crud.Infrastructure.Exceptions;
using Crud.Infrastructure.IRepositorys;
using Crud.Infrastructure.IServices;
using System.Collections.Generic;

namespace Crud.Infrastructure.Services
{
    public class CaminhaoService : ICaminhaoService
    {

        private readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoService(ICaminhaoRepository caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }


        public void Insert(Caminhao caminhao)
        {
            if (caminhao.Modelo != Core.Enums.ModeloEnum.FH && caminhao.Modelo != Core.Enums.ModeloEnum.FM) {
                throw new ModeloDiferenteException("O modelo deve ser Fh ou FM");
            }
            if (caminhao.AnoFabricacao.Year != System.DateTime.Now.Year) {
                throw new AnoFabricacaoInvalidoException("O ano de fabricação do caminhão deve ser o ano atual");
            }

            if (caminhao.AnoModelo.Year != System.DateTime.Now.Year &&
                caminhao.AnoModelo.Year != System.DateTime.Now.AddYears(1).Year) {
                throw new AnoModeloInvalidoException("O ano de modelo do caminhão deve ser o ano atual ou ano subsequente");
            }



            _caminhaoRepository.Insert(caminhao);
        }

        
        public void Update(Caminhao caminhao)
        {
            _caminhaoRepository.Update(caminhao);
        }
       
        public IList<Caminhao> GetAll()
        {
            return _caminhaoRepository.GetAll();
        }

        public Caminhao GetById(int id)
        {
            return _caminhaoRepository.GetById(id);
        }



        public void Delete(int id)
        {
            _caminhaoRepository.Delete(id);
        }
    }
}
