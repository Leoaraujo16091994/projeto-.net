
using Crud.Core.Entidades;
using System.Collections.Generic;

namespace Crud.Infrastructure.IServices
{
   public interface ICaminhaoService
    {
        void Insert(Caminhao caminhao);
      /*  Caminhao Update(Caminhao caminhao);
        IList<Caminhao> GetListaCaminhaoByFiltro(Caminhao filtro);
        Caminhao GetById(int id);
        void Delete(int id);
        */
    }
}
