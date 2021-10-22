using Crud.Core.Enums;
using System;
using Dapper.Contrib.Extensions;

namespace Crud.Core.Entidades
{
    [Table("Caminhao")]
    public class Caminhao
    {
        public int? Id { get; set; }
        public ModeloEnum Modelo { get; set; }
        public DateTime AnoFabricacao { get; set; }
        public DateTime AnoModelo { get; set; }
        public int? Ativo { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? ModificacaoPor { get; set; }
        public DateTime DataModificacao { get; set; }

    }
}





