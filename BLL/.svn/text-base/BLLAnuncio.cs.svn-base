using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Repositorio;
using MVC.Models;
using Util;

namespace BLL
{
    public class BLLAnuncio: Repositorio<Anuncio>
    {
         public BLLAnuncio()
            : base()
        {
        
        }

         public BLLAnuncio(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }

         public override void Validate(Anuncio entity)
         {


             Validar.Condicao(entity.AnuncioFoto.Count <= 3,"São permitidas no máximo 3 fotos por anuncio.");
             Validar.StringVazia(entity.Titulo, "Informe o Título do anuncio.");
             Validar.StringVazia(entity.SubTitulo, "Informe o Sub-Título do anuncio.");
             Validar.StringVazia(entity.Descricao, "Informe a Descrição do anuncio.");
             Validar.Condicao(entity.Categoria_ID > 0, "Informe uma Categoria");
             
             var usuarioLogado = new BLLUsuario(_context).SelectByKey(entity.UsuarioInc_ID);
             Validar.Condicao(usuarioLogado.Endereco_ID != null, "Por Favor complemente seus dados de Endereço em Meu Muambba >> Meus Dados para prosseguir.");

             Validar.Condicao(usuarioLogado.UsuarioContato.Count > 0, "Por Favor complemente seus dados de Contato em Meu Muambba >> Meus Dados para prosseguir.");


         }

         protected override Anuncio InsertRule(Anuncio entity)
         {
             var usuarioLogado = new BLLUsuario(_context).SelectByKey(entity.UsuarioInc_ID);

             entity.DataInc = DateTime.Now;
             entity.DataExp = DateTime.Now.AddMonths(2);
             entity.CEP = usuarioLogado.Endereco.EnderecoCep.CEP;

             entity = LimparDadosNaoValidos(entity);

             return entity;
         }

         protected override Anuncio UpdateRule(Anuncio entity)
         {
             var a = SelectByKey(entity.ID);

             a.Titulo = entity.Titulo;
             a.SubTitulo = entity.SubTitulo;
             a.Descricao = entity.Descricao;
             a.AnuncioTipo_ID = entity.AnuncioTipo_ID;
             a.AnuncioConservacao_ID = entity.AnuncioConservacao_ID;

             a.Preco = entity.Preco;

             a.C_Cor = entity.C_Cor;
             a.C_Disponibilidade = entity.C_Disponibilidade;
             a.C_Garantia = entity.C_Garantia;

             a.C_Quantidade = entity.C_Quantidade;
             a.C_Tamanho = entity.C_Tamanho;

             a.C_Veiculo_Acessorios = entity.C_Veiculo_Acessorios;
             a.C_Veiculo_Ano_Fabricacao = entity.C_Veiculo_Ano_Fabricacao;
             a.C_Veiculo_Ano_Modelo = entity.C_Veiculo_Ano_Modelo;
             a.C_Veiculo_Combustivel_ID = entity.C_Veiculo_Combustivel_ID;
             a.C_Veiculo_Cor_ID = entity.C_Veiculo_Cor_ID;
             a.C_Veiculo_Km = entity.C_Veiculo_Km;

             a.C_Imovel_Area_Terreno = entity.C_Imovel_Area_Terreno;
             a.C_Imovel_Area_Util = entity.C_Imovel_Area_Util;
             a.C_Imovel_Condominio_Administradora = entity.C_Imovel_Condominio_Administradora;
             a.C_Imovel_Condominio_Andar = entity.C_Imovel_Condominio_Andar;
             a.C_Imovel_Condominio_Andares = entity.C_Imovel_Condominio_Andares;
             a.C_Imovel_Condominio_Infraestrutura = entity.C_Imovel_Condominio_Infraestrutura;
             a.C_Imovel_Condominio_Nome = entity.C_Imovel_Condominio_Nome;
             a.C_Imovel_Condominio_Unidades_Por_Andar = entity.C_Imovel_Condominio_Unidades_Por_Andar;
             a.C_Imovel_Condominio_Valor = entity.C_Imovel_Condominio_Valor;
             a.C_Imovel_Idade = entity.C_Imovel_Idade;
             a.C_Imovel_Instalacoes = entity.C_Imovel_Instalacoes;
             a.C_Imovel_IPTU = entity.C_Imovel_IPTU;
             a.C_Imovel_Lazer = entity.C_Imovel_Lazer;
             a.C_Imovel_Quartos = entity.C_Imovel_Quartos;
             a.C_Imovel_Suites = entity.C_Imovel_Suites;
             a.C_Imovel_Vagas_Garagem = entity.C_Imovel_Vagas_Garagem;
             
             
             a.C_Localizacao_Latitude = entity.C_Localizacao_Latitude;
             a.C_Localizacao_Longitude = entity.C_Localizacao_Longitude;

             var bllAf = new BLLAnuncioFoto(_context);

             while (a.AnuncioFoto.Count > 0)
             {
                 bllAf.Delete(a.AnuncioFoto.First());
             }

             if (entity.AnuncioFoto.Count > 0)
             {
                 a.NomeArquivoFotoPrincipal = entity.AnuncioFoto.First().NomeArquivo;
             }
             else
             {
                 a.NomeArquivoFotoPrincipal = null;
             }

             foreach (var item in entity.AnuncioFoto)
             {
                 
                     var af = new AnuncioFoto();
                     af.NomeArquivo = item.NomeArquivo;
                     af.DataInc = a.DataInc;
                     a.AnuncioFoto.Add(af);
                 
             }

             a = LimparDadosNaoValidos(a);


             return base.UpdateRule(a);
         }

         private Anuncio LimparDadosNaoValidos(Anuncio entity)
         {

             var bllCat = new BLLCategoria(_context);
             Categoria cat = bllCat.SelectByKey(entity.Categoria_ID);
             Categoria catAux = cat;

             while (catAux != null)
             {
                 catAux.QuantidadeAnuncios += 1;

                 catAux = catAux.Categoria2;

             }


             if (!cat.usaCor)
             {
                 entity.C_Cor = null;
             }

             if (!cat.usaDisponibilidade)
             {
                 entity.C_Disponibilidade = null;
             }

             if (!cat.usaGarantia)
             {
                 entity.C_Garantia = null;
             }


             if (!cat.usaVeiculo)
             {
                 entity.C_Veiculo_Acessorios = null;
                 entity.C_Veiculo_Ano_Fabricacao = null;
                 entity.C_Veiculo_Ano_Modelo = null;
                 entity.C_Veiculo_Combustivel_ID = null;
                 entity.C_Veiculo_Cor_ID = null;
             }

             if (!cat.usaImovel)
             {
                 entity.C_Imovel_Area_Terreno = null;
                 entity.C_Imovel_Area_Util = null;
                 entity.C_Imovel_IPTU = null;
             }
             if (!cat.usaImovel || entity.C_Imovel_Idade == 0)
             {
                 entity.C_Imovel_Idade = null;
             }


             if (!cat.usaImovel_Condominio)
             {
                 entity.C_Imovel_Condominio_Administradora = null;
                 entity.C_Imovel_Condominio_Andar = null;
                 entity.C_Imovel_Condominio_Andares = null;
                 entity.C_Imovel_Condominio_Infraestrutura = null;
                 entity.C_Imovel_Condominio_Nome = null;
                 entity.C_Imovel_Condominio_Unidades_Por_Andar = null;
                 entity.C_Imovel_Condominio_Valor = null;

             }

             if (!cat.usaImovel_Garagem)
             {
                 entity.C_Imovel_Vagas_Garagem = null;
             }

             if (!cat.usaImovel_Lazer)
             {
                 entity.C_Imovel_Lazer = null;
             }

             if (!cat.usaImovel_Instalacoes)
             {
                 entity.C_Imovel_Instalacoes = null;
             }

             if (!cat.usaImovel_Residencial)
             {

                 entity.C_Imovel_Quartos = null;
                 entity.C_Imovel_Suites = null;
             }

             return entity;
         }

         public void AdicionarVisita(int Anuncio_ID)
         {
             var a = SelectByKey(Anuncio_ID);
             a.Visitas += 1;
             SaveChanges();
         }

         public void Arquivar(int Anuncio_ID, int Usuario_ID)
         {
             var bllUsuario = new BLLUsuario(_context); 
             var u = bllUsuario.SelectByKey(Usuario_ID);

             Validar.Condicao(Usuario_ID > 0, "Informe um usuário");

             var a = SelectByKey(Anuncio_ID);

             Validar.Condicao(a.UsuarioInc_ID == Usuario_ID || u.Administrador, "O usuário não tem permissão para excluir este anuncio");
             
             
             a.UsuarioExc_ID = Usuario_ID;
             SaveChanges();
         
         }

         public override Anuncio SelectByKey(int Key)
         {



             return Single(a => int.Parse(a.EntityKey.EntityKeyValues[0].Value.ToString()) == Key && a.UsuarioExc_ID == null);
             //return Single(a => a.EntityKey. == ID);
             //return null;
         }

       


    }
}
