using Crud.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.IRepositorys
{
    public interface ICaminhaoRepository 
    {
        void Insert(Caminhao caminhao);
      /*  Caminhao Update(Caminhao caminhao);
        IList<Caminhao> GetListaCaminhaoByFiltro(Caminhao filtro);
        Caminhao GetById(int id);
        void Delete(int id); */
    }
}
