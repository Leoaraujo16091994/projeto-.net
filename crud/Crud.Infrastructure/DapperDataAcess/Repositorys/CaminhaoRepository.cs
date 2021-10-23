using Crud.Core.Entidades;
using Crud.Infrastructure.IRepositorys;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Crud.Infrastructure.DapperDataAcess.Repositorys
{
    public class CaminhaoRepository : ICaminhaoRepository
    {

        const string connectionString = "Server=JOSAFA-PC\\SQLEXPRESS; Database=Crud;  User ID = leo; Password = 123;connect timeout=100; Min Pool Size=2; Max Pool Size=100 ;";
        public void Insert(Caminhao caminhao)
        {
            string insert = @"
                INSERT INTO
                    CRUD.CAMINHAO (
                        MODELO,
                        ANO_FABRICACAO,
                        ANO_MODELO,
                        ATIVO,
                        CRIADO_POR,
                        DATA_CRIACAO
                        )
                VALUES
                    (
                        @modelo,
                        @anoFabricacao,
                        @anoModelo,
                        @ativo,
                        @criadoPor,
                        GETDATE()
                    );";


            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(insert, new
                {
                    modelo = caminhao.Modelo,
                    anoFabricacao = caminhao.AnoFabricacao,
                    anoModelo = caminhao.AnoModelo,
                    ativo = true,
                    criadoPor = 1
                });
            }
        }

        public void Update(Caminhao caminhao)
        {
            const string update = @"
                UPDATE
                    CRUD.CAMINHAO
                SET
                    MODELO = @modelo,
                    ANO_FABRICACAO = @anoFabricacao,
                    ANO_MODELO = @anoModelo,
                    MODIFICADO_POR = @modificadoPor,
                    DATA_MODIFICACAO = GETDATE()
                WHERE ID = @idCaminhao";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(update, new
                {
                    idCaminhao = caminhao.Id,
                    modelo = caminhao.Modelo,
                    anoFabricacao = caminhao.AnoFabricacao,
                    anoModelo = caminhao.AnoModelo,
                    modificadoPor = 1
                });
            }
        }

        public void Delete(int id)
        {
            const string delete = @"
                    UPDATE CRUD.CAMINHAO
                        SET
                        ATIVO = @ativo ,
                        MODIFICADO_POR = @modificadoPor,
                        DATA_MODIFICACAO = GETDATE()
                    WHERE ID = @id";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(delete, new
                {
                    id = id,
                    modificadoPor = 1,
                    ativo = false
                }); ;
            }
        }

        public Caminhao GetById(int id)
        {
            string query = @"
                            SELECT ID,MODELO,ANO_FABRICACAO,ANO_MODELO
                            FROM CRUD.CAMINHAO 
                            WHERE ID = @id;";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.QuerySingle<Caminhao>(query, new
                { id });
                return affectedRows;
            }

        }

        public IList<Caminhao> GetAll()
        {
            string query = @"
                            SELECT ID,MODELO,ANO_FABRICACAO,ANO_MODELO
                            FROM CRUD.CAMINHAO
                            WHERE ATIVO = 1 ;";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Query<Caminhao>(query);
                return affectedRows.ToList();
            }
        }
    }
}
