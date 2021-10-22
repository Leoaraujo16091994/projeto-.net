using Crud.Core.Entidades;
using Crud.Infrastructure.IRepositorys;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Crud.Infrastructure.DapperDataAcess.Repositorys
{
       public class CaminhaoRepository : ICaminhaoRepository
    {

        const string connectionString = "Server=JOSAFA-PC\\SQLEXPRESS; Database=Crud;  User ID = leo; Password = 123;connect timeout=100; Min Pool Size=2; Max Pool Size=100 ;";
        public void Insert(Caminhao caminhao)
        {
            //var currentUser = _currentUserService.CurrentUserId;
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
                }) ;
            }
        }

/*        public void Update(Caminhao caminhao)
        {
            var currentUser = _currentUserService.CurrentUserId;
            const string update = @"
                UPDATE
                    SIMAQ.COLETA_DADOS
                SET
                    ESTABELECIMENTO_FK = @idEstabelecimento,
                    TIPO_UNIDADE = @tipoUnidade,
                    PERIODO_COLETA_FK = @idPeriodoColeta,
                    INDICADOR_FK = @idIndicador,
                    STATUS_VALIDACAO = @statusValidacao,
                    MODIFICADO_POR = @modificadoPor,
                    DATA_MODIFICACAO = GETDATE()
                WHERE ID = @id";

            _bancoConnection.Get(Banco.SAUDE_DIGITAL).Execute(update, new
            {
                idEstabelecimento = coletaDeDados?.Estabelecimento?.IdEstabelecimento,
                tipoUnidade = coletaDeDados.TipoUnidade,
                idPeriodoColeta = coletaDeDados?.PeriodoColeta?.Id,
                idIndicador = coletaDeDados?.Indicador.Id,
                statusValidacao = coletaDeDados.StatusValidacao,
                modificadoPor = currentUser,
                id = coletaDeDados.Id

            }, _bancoConnection.Transaction);
        }

        public void Delete(int id)
        {
            const string delete = @"DELETE FROM SIMAQ.COLETA_DADOS WHERE ID = @id";

            _bancoConnection.Get(Banco.SAUDE_DIGITAL).Execute(delete, new
            {
                id
            }, _bancoConnection.Transaction);
        }

        public ColetaDados GetById(int id)
        {
            const string query = @"
                SELECT 
                    CD.ID,
                    CD.ESTABELECIMENTO_FK,
                    CD.TIPO_UNIDADE,
                    CD.STATUS_VALIDACAO,
                    CD.PERIODO_COLETA_FK,
                    CD.INDICADOR_FK,
                    E.ID_ESTABELECIMENTO,
                    E.NOME_FANTASIA,
                    E.CNES,
                    PC.ID,
                    PC.CODIGO,
                    PC.DESCRICAO,
                    I.ID,
                    I.TIPO_UNIDADE,
                    I.DESCRICAO,
                    I.TIPO_RESULTADO,
                    I.NUMERADOR,
                    I.DENOMINADOR,
                    I.METODO_DE_CALCULO,
                    I.CONCEITUACAO,
                    I.GUIA_DE_COLETA_DE_DADOS,
                    I.TENDENCIA,
                    I.FONTE_DOS_DADOS
                FROM 
                    SIMAQ.COLETA_DADOS CD
                    INNER JOIN SESABASE.ESTABELECIMENTO E ON E.ID_ESTABELECIMENTO = CD.ESTABELECIMENTO_FK
                    INNER JOIN SIMAQ.PERIODO_COLETA PC ON PC.ID = CD.PERIODO_COLETA_FK
                    INNER JOIN SIMAQ.INDICADOR I ON I.ID = CD.INDICADOR_FK
                WHERE
                    CD.ID = @id ";

            var coleta = _bancoConnection.Get(Banco.SAUDE_DIGITAL).Query(query, (System.Func<ColetaDados, Estabelecimento, PeriodoColeta, Indicador, ColetaDados>)(
                 (coletaDados, estabelecimento, periodoColeta, indicador) =>
                 {
                     coletaDados.Estabelecimento = estabelecimento;
                     coletaDados.PeriodoColeta = periodoColeta;
                     coletaDados.Indicador = indicador;
                     return coletaDados;
                 }), param: new { id }, splitOn: "ID_ESTABELECIMENTO, ID, ID").SingleOrDefault();

            coleta.IndicadorServico = _indicadorServicoPeriodoColetaService.Get(id);

            return coleta;
        }

        public Paginated<ColetaDados> GetListaCaminhaoByFiltro(Paginated<ColetaDados> paginated, ColetaDados filtro)
        {

            switch (paginated.Sort.Active)
            {
                case "estabelecimento.nomeFantasia":
                    paginated.Sort.AliasActive = "E.NOME_FANTASIA";
                    break;
                case "periodoColeta.descricao":
                    paginated.Sort.AliasActive = "PC.DESCRICAO";
                    break;
                case "indicador.descricao":
                    paginated.Sort.AliasActive = "I.DESCRICAO";
                    break;
                case "statusValidacao":
                    paginated.Sort.AliasActive = "CD.STATUS_VALIDACAO";
                    break;
                default:
                    paginated.Sort.AliasActive = "CD.DATA_CRIACAO";
                    break;
            }

            var queryWhere = @" ";

            if (filtro?.Estabelecimento?.IdEstabelecimento > 0)
                queryWhere += " AND CD.ESTABELECIMENTO_FK = @idEstabelecimento ";

            if (filtro?.PeriodoColeta?.Id > 0)
                queryWhere += " AND CD.PERIODO_COLETA_FK = @idPeriodoColeta ";

            if (filtro?.Indicador?.Id > 0)
                queryWhere += " AND CD.INDICADOR_FK = @idIndicador ";

            if (filtro?.StatusValidacao > 0)
                queryWhere += " AND CD.STATUS_VALIDACAO = @statusValidacao ";

            var query = @"
                SELECT
                    COUNT(CD.ID)
                FROM 
                    SIMAQ.COLETA_DADOS CD
                    INNER JOIN SESABASE.ESTABELECIMENTO E ON E.ID_ESTABELECIMENTO = CD.ESTABELECIMENTO_FK
                    INNER JOIN SIMAQ.PERIODO_COLETA PC ON PC.ID = CD.PERIODO_COLETA_FK
                    INNER JOIN SIMAQ.INDICADOR I ON I.ID = CD.INDICADOR_FK 
                WHERE 
                    CD.ATIVO = 1 ";

            query += queryWhere;

            query += @"
                SELECT
                    CD.ID,
                    CD.ESTABELECIMENTO_FK,
                    CD.TIPO_UNIDADE,
                    CD.STATUS_VALIDACAO,
                    CD.PERIODO_COLETA_FK,
                    CD.INDICADOR_FK,
                    E.ID_ESTABELECIMENTO,
                    E.NOME_FANTASIA,
                    E.CNES,
                    PC.ID,
                    PC.CODIGO,
                    PC.DESCRICAO,
                    I.ID,
                    I.TIPO_UNIDADE,
                    I.DESCRICAO,
                    I.TIPO_RESULTADO,
                    I.NUMERADOR,
                    I.DENOMINADOR,
                    I.METODO_DE_CALCULO,
                    I.CONCEITUACAO,
                    I.GUIA_DE_COLETA_DE_DADOS,
                    I.TENDENCIA,
                    I.FONTE_DOS_DADOS
                FROM 
                    SIMAQ.COLETA_DADOS CD
                    INNER JOIN SESABASE.ESTABELECIMENTO E ON E.ID_ESTABELECIMENTO = CD.ESTABELECIMENTO_FK
                    INNER JOIN SIMAQ.PERIODO_COLETA PC ON PC.ID = CD.PERIODO_COLETA_FK
                    INNER JOIN SIMAQ.INDICADOR I ON I.ID = CD.INDICADOR_FK 
                WHERE 
                    CD.ATIVO = 1 ";

            query += queryWhere;

            query += $@" {paginated.Sort} OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY; ";

            query = Regex.Replace(query, @"\s+", " ");

            using (var multi = _bancoConnection.Get(Banco.SAUDE_DIGITAL).QueryMultiple(query, new
            {
                idEstabelecimento = filtro?.Estabelecimento?.IdEstabelecimento,
                idPeriodoColeta = filtro.PeriodoColeta?.Id,
                idIndicador = filtro?.Indicador?.Id,
                statusValidacao = filtro?.StatusValidacao,
                offset = paginated.GetOffSet(),
                pageSize = paginated.PageSize
            }))
            {
                paginated.Count = multi.Read<int>().First();
                paginated.Content = multi.Read<ColetaDados, Estabelecimento, PeriodoColeta, Indicador, ColetaDados>(
                    (coletaDados, estabelecimento, periodoColeta, indicador) =>
                    {
                        coletaDados.Estabelecimento = estabelecimento;
                        coletaDados.PeriodoColeta = periodoColeta;
                        coletaDados.Indicador = indicador;
                        return coletaDados;
                    }, splitOn: "ID_ESTABELECIMENTO, ID, ID").ToList();
            }

            return paginated;
        }
    */
    }
}
