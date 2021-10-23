
using Crud.Core.Entidades;
using System.Collections.Generic;

namespace Crud.Infrastructure.IServices
{
   public interface ICaminhaoService
    {
        void Insert(Caminhao caminhao);
        void Update(Caminhao caminhao);
        IList<Caminhao> GetAll();
        Caminhao GetById(int id);
        void Delete(int id);
    }
}
