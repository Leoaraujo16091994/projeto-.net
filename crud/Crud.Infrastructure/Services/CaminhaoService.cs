using Crud.Core.Entidades;
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
        {/*
            var caminhaoJaCadastrado = _caminhaoRepository.ExisteIndicador(caminhao.Descricao);
            if (caminhaoJaCadastrado)
                throw new IndicadoJaExistenteException();
                */
            _caminhaoRepository.Insert(caminhao);
        }

        /*
        public Caminhao Update(Caminhao caminhao)
        {
            _indicadorRepository.Update(indicador);
            return indicador
        }

        public IList<Caminhao> GetListaCaminhaoByFiltro(Caminhao filtro)
        {
            return _caminhaoRepository.GetIndicadorByFiltro(filtro);
        }


        public Caminhao GetById(int id)
        {
            return _caminhaoRepository.GetById(id);
        }



        public void Delete(Caminhao caminhao)
        {
      
                if (indicador.Ativo == true)
                {
                    _indicadorRepository.Inativar(indicador);
                }
                else
                {

                    _indicadorRepository.Ativar(indicador);
                }
        }
    */
    }
}
