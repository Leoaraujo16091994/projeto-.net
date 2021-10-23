using FluentMigrator;

namespace Crud.Migrations
{
    [Migration(2L, "Script de Insercao de Caminhoes")]
    public class Migration0002 : Migration
    {
        public override void Up()
        {
            this.sqlInsert();
        }

        public override void Down()
        {
        }

        public void sqlInsert() {
                var sql = @"
        INSERT INTO CRUD.CAMINHAO (MODELO,ANO_FABRICACAO,ANO_MODELO,ATIVO,CRIADO_POR,DATA_CRIACAO) 
            VALUES (1,'2021-10-01','2022-01-01',1, 1,GETDATE());


        INSERT INTO CRUD.CAMINHAO (MODELO,ANO_FABRICACAO,ANO_MODELO,ATIVO,CRIADO_POR,DATA_CRIACAO)
            VALUES (2,'2021-10-01','2022-01-01',1, 1,GETDATE());

        INSERT INTO CRUD.CAMINHAO (MODELO,ANO_FABRICACAO,ANO_MODELO,ATIVO,CRIADO_POR,DATA_CRIACAO) 
            VALUES (2,'2021-10-01','2022-01-01',1, 1,GETDATE());


        INSERT INTO CRUD.CAMINHAO (MODELO,ANO_FABRICACAO,ANO_MODELO,ATIVO,CRIADO_POR,DATA_CRIACAO) 
            VALUES (1,'2021-10-01','2021-01-01',1, 1,GETDATE());
    ";
            Execute.Sql(sql);
        }
        
    }
}