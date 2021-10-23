using Crud.Core.Entidades;
using Crud.Core.Enums;
using Crud.Infrastructure.Exceptions;
using Crud.Infrastructure.IRepositorys;
using Crud.Infrastructure.IServices;
using Crud.Infrastructure.Services;
using NSubstitute;
using System;
using Xunit;

namespace Crud.Infrastructure.Test
{
    public class CaminhaoServiceTest
    {
        [Fact]
        public void TestCaminhaoDevePossuirPropriedadesModeloCorreto()
        {
            var caminhaoRepository = Substitute.For<ICaminhaoRepository>();
            var caminhaoService = new CaminhaoService(caminhaoRepository);
            var caminhaoInvalido = new Caminhao
            {
                Modelo = (ModeloEnum)3,
                AnoFabricacao = new DateTime(2021, 1, 1),
                AnoModelo = new DateTime(2021, 1, 1),
            };
            Assert.Throws<ModeloDiferenteException>(() => caminhaoService.Insert(caminhaoInvalido));
        }


        [Fact]
        public void TestCaminhaoDevePossuirPropriedadesModelo()
        {
            var caminhaoService = Substitute.For<ICaminhaoService>();
            caminhaoService.GetById(Arg.Any<int>()).Returns(new Caminhao());
            var caminhao = caminhaoService.GetById(1);           

            Assert.NotEqual(caminhao.GetType().GetProperty("Modelo"),null) ;

        }

        [Fact]
        public void TestCaminhaoDevePossuirPropriedadesAnoFabricacao()
        {
            var caminhaoService = Substitute.For<ICaminhaoService>();
            caminhaoService.GetById(Arg.Any<int>()).Returns(new Caminhao());
            var caminhao = caminhaoService.GetById(1);

            Assert.NotEqual(caminhao.GetType().GetProperty("AnoFabricacao"), null);

        }


        [Fact]
        public void TestCaminhaoDevePossuirPropriedadesAnoModelo()
        {
            var caminhaoService = Substitute.For<ICaminhaoService>();
            caminhaoService.GetById(Arg.Any<int>()).Returns(new Caminhao());
            var caminhao = caminhaoService.GetById(1);

            Assert.NotEqual(caminhao.GetType().GetProperty("AnoModelo"), null);
        }

        [Fact]
        public void TestNaoPodeInserirCaminhaoAnoFabricacaoDiferenteAtual() 
        {
            var caminhaoRepository = Substitute.For<ICaminhaoRepository>();
            var caminhaoService = new CaminhaoService(caminhaoRepository);
            var caminhaoInvalido = new Caminhao {
                Modelo =ModeloEnum.FM,
                AnoFabricacao = new DateTime(2020,1,1),
                AnoModelo = new DateTime(2021, 1, 1),
            };
            Assert.Throws<AnoFabricacaoInvalidoException>(() => caminhaoService.Insert(caminhaoInvalido));
        }

        [Fact]
        public void TestInserirCaminhaoAnoFabricacaoAtual()
        {
            var caminhaoRepository = Substitute.For<ICaminhaoRepository>();
            var caminhaoService = new CaminhaoService(caminhaoRepository);
            var caminhaoInvalido = new Caminhao
            {
                Modelo = ModeloEnum.FM,
                AnoFabricacao = new DateTime(2021, 1, 1),
                AnoModelo = new DateTime(2021, 1, 1),
            };

            var exception = Record.Exception((() => caminhaoService.Insert(caminhaoInvalido)));
            Assert.Null(exception);
            
            caminhaoRepository.Received(1).Insert(Arg.Any<Caminhao>());
        }


        [Fact]
        public void TestNaoPodeInserirCaminhaoAnoModeloDiferenteAtualOuSubsquente()
        {
            var caminhaoRepository = Substitute.For<ICaminhaoRepository>();
            var caminhaoService = new CaminhaoService(caminhaoRepository);
            var caminhaoInvalido = new Caminhao
            {
                Modelo = ModeloEnum.FM,
                AnoFabricacao = new DateTime(2021, 1, 1),
                AnoModelo = new DateTime(2023, 1, 1),
            };
            Assert.Throws<AnoModeloInvalidoException>(() => caminhaoService.Insert(caminhaoInvalido));
        }


        [Fact]
        public void TestInserirCaminhaoAnoModeloAtual()
        {
            var caminhaoRepository = Substitute.For<ICaminhaoRepository>();
            var caminhaoService = new CaminhaoService(caminhaoRepository);
            var caminhaoInvalido = new Caminhao
            {
                Modelo = ModeloEnum.FM,
                AnoFabricacao = new DateTime(2021, 1, 1),
                AnoModelo = new DateTime(2021, 1, 1),
            };

            var exception = Record.Exception((() => caminhaoService.Insert(caminhaoInvalido)));
            Assert.Null(exception);

            caminhaoRepository.Received(1).Insert(Arg.Any<Caminhao>());
        }

        [Fact]
        public void TestInserirCaminhaoAnoModeloSubsquente()
        {
            var caminhaoRepository = Substitute.For<ICaminhaoRepository>();
            var caminhaoService = new CaminhaoService(caminhaoRepository);
            var caminhaoInvalido = new Caminhao
            {
                Modelo = ModeloEnum.FM,
                AnoFabricacao = new DateTime(2021, 1, 1),
                AnoModelo = new DateTime(2022, 1, 1),
            };

            var exception = Record.Exception((() => caminhaoService.Insert(caminhaoInvalido)));
            Assert.Null(exception);

            caminhaoRepository.Received(1).Insert(Arg.Any<Caminhao>());
        }
    }
}
