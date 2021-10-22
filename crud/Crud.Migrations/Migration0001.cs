using FluentMigrator;

namespace Crud.Migrations
{
    [Migration(1L, "Criação do esquema Crud e da tabela CAMINHAO")]
    public class Migration0001 : Migration
    {
        public override void Up()
        {
            var schema = "Crud";
            CriarEschema(schema);
            CriarTabelaCaminhao(schema);
        }

        public override void Down()
        {
        }

        private void CriarEschema(string schema)
        {
            if (!Schema.Schema(schema).Exists())
            {
                Create.Schema(schema);
            }
        }

        private void CriarTabelaCaminhao(string schema)
        {
            var tabelaIndicador = "CAMINHAO";
            if (!Schema.Schema(schema).Table(tabelaIndicador).Exists())
            {
                Create.Table(tabelaIndicador).InSchema(schema)
                    .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                    .WithColumn("MODELO").AsInt32().NotNullable()
                    .WithColumn("ANO_FABRICACAO").AsDate().NotNullable()
                    .WithColumn("ANO_MODELO").AsDate().NotNullable()
                    .WithColumn("ATIVO").AsBoolean().NotNullable().WithDefaultValue(true)
                    .WithColumn("CRIADO_POR").AsInt32().NotNullable()
                    .WithColumn("DATA_CRIACAO").AsDateTime().NotNullable()
                    .WithColumn("MODIFICADO_POR").AsInt32().Nullable()
                    .WithColumn("DATA_MODIFICACAO").AsDateTime().Nullable();
            }
        }
    }
}