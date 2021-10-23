using Crud.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.IRepositorys
{
    public interface ICaminhaoRepository 
    {
        void Insert(Caminhao caminhao);
        void Update(Caminhao caminhao);
        IList<Caminhao> GetAll();
        Caminhao GetById(int id);
        void Delete(int id); 
    }
}
