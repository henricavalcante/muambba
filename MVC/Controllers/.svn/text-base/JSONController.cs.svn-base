using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MVC.Models;
using System.Web.Script.Serialization;
using Util;
using System.IO;
using System.Collections;

namespace MVC.Controllers
{
    public class JSONController : ControllerBase
    {
        private class RetornoJsonPadrao
        {
            public RetornoJsonPadrao(string m, bool s, object o)
            {
                this.m = m;
                this.s = s;
                this.o = o;
            }

            public string m { get; set; }
            public bool s { get; set; }
            public object o { get; set; }
        }

        private void VerificaSessao(string Token)
        {
            if (Sessao.ToString().Replace("-", "") != Token) throw new Exception("Token de sessão Inválido.");
        }

        public ActionResult RetornoPadrao()
        {
            if (Request.UrlReferrer == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("RetornoPadrao");
            }
        }
        
        /// <summary>
        /// 01 - Retorna a lista de cetegorias de um determinado pai
        /// </summary>
        /// <returns></returns>
        public JsonResult json01(string sch, int c)
        {

            try
            {
                VerificaSessao(sch);

                var Bll = new BLLCategoria();

                var lst = (from cat in Bll.ListarPais(c)
                           orderby cat.Categoria1
                           select new
                           {
                               ID = cat.ID,
                               Categoria1 = cat.Categoria1
                           }).ToList();

                var categoria = Bll.SelectByKey(c);

                var usa = new List<string>();

                
                if (categoria.usaTamanho) usa.Add("usaTamanho");
                if (categoria.usaCor) usa.Add("usaCor");
                if (categoria.usaGarantia) usa.Add("usaGarantia");
                if (categoria.usaDisponibilidade) usa.Add("usaDisponibilidade");
                if (categoria.usaQuantidade) usa.Add("usaQuantidade");
                if (categoria.usaQuantidade) usa.Add("usaLocalizacao");
                if (categoria.usaVeiculo) usa.Add("usaVeiculo");
                if (categoria.usaImovel) usa.Add("usaImovel");
                if (categoria.usaImovel_Condominio) usa.Add("usaImovel_Condominio");
                if (categoria.usaImovel_Instalacoes) usa.Add("usaImovel_Instalacoes");
                if (categoria.usaImovel_Lazer) usa.Add("usaImovel_Lazer");
                if (categoria.usaImovel_Residencial) usa.Add("usaImovel_Residencial");
                if (categoria.usaImovel_Garagem) usa.Add("usaImovel_Garagem");

                var retorno = new
                                {
                                    lst,
                                    anunciavel = categoria.Anunciavel,
                                    usa = usa
                                };

                return Json(new RetornoJsonPadrao("Categorias listadas com sucesso.", true, retorno));

            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }

        /// <summary>
        /// 02 - Salva um anuncio
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public JsonResult json02(int? ID,
                                List<string> fotos, 
                                string titulo, 
                                string subtitulo, 
                                string descricao, 
                                int categoria,
                                int tipo, 
                                int conservacao,
                                string preco,
                                string cor, 
                                string garantia,
                                string tamanho,
                                short? disponibilidade,
                                short? quantidade,
                                int Veiculo_Cor,
                                int Veiculo_Combustivel,
                                int? Veiculo_Ano_Fabricacao,
                                int? Veiculo_Ano_Modelo,
                                string Veiculo_Km,
                                List<string> Veiculo_Acessorios,
                                int? Imovel_Quartos,
                                int? Imovel_Suites,
                                int? Imovel_Vagas_Garagem,
                                int? Imovel_Idade,
                                string Imovel_IPTU,
                                string Imovel_Area_Terreno,
                                string Imovel_Area_Util,
                                string Imovel_Condominio_Nome,
                                int? Imovel_Condominio_Andar,
                                int? Imovel_Condominio_Andares,
                                int? Imovel_Condominio_Unidades_Por_Andar,
                                string Imovel_Condominio_Valor,
                                string Imovel_Condominio_Administradora,
                                List<string> Imovel_condominio_infraestrutura,
                                List<string> Imovel_instalacoes,
                                List<string> Imovel_lazer)
        {
            try
            {

                var bll = new BLLAnuncio();

                Anuncio a = new Anuncio();

                a.Titulo = titulo;
                a.Descricao = descricao;
                a.SubTitulo = subtitulo;
                a.AnuncioTipo_ID = tipo;
                a.AnuncioConservacao_ID = conservacao;
                a.Categoria_ID = categoria;
                a.Preco = decimal.Parse( preco);

                a.C_Cor = cor;
                a.C_Garantia = garantia;
                a.C_Tamanho = tamanho;

                if (disponibilidade != null)
                {
                    a.C_Disponibilidade = disponibilidade.GetValueOrDefault();

                }
                if (quantidade != null)
                {
                    a.C_Quantidade = quantidade.GetValueOrDefault();

                }
                

                a.C_Veiculo_Cor_ID = Veiculo_Cor;
                a.C_Veiculo_Ano_Fabricacao = Veiculo_Ano_Fabricacao;
                a.C_Veiculo_Ano_Modelo = Veiculo_Ano_Modelo;
                a.C_Veiculo_Combustivel_ID = Veiculo_Combustivel;
                if (Veiculo_Km != null && Veiculo_Km != string.Empty) a.C_Veiculo_Km = int.Parse(Veiculo_Km.Replace(".",""));
                if (Veiculo_Acessorios != null && Veiculo_Acessorios.Count > 0)
                {
                    a.C_Veiculo_Acessorios = string.Join("|", Veiculo_Acessorios);
                }
                

                a.C_Imovel_Quartos = (byte?)Imovel_Quartos;
                a.C_Imovel_Suites = (byte?) Imovel_Suites;
                a.C_Imovel_Vagas_Garagem = (byte?) Imovel_Vagas_Garagem;
                a.C_Imovel_Idade = (byte?) Imovel_Idade.GetValueOrDefault();
                a.C_Imovel_IPTU = decimal.Parse( Imovel_IPTU);
                a.C_Imovel_Area_Terreno = decimal.Parse( Imovel_Area_Terreno);
                a.C_Imovel_Area_Util = decimal.Parse( Imovel_Area_Util);
                a.C_Imovel_Condominio_Nome = Imovel_Condominio_Nome;
                a.C_Imovel_Condominio_Andar = (byte?) Imovel_Condominio_Andar;
                a.C_Imovel_Condominio_Andares = (byte?) Imovel_Condominio_Andares;
                a.C_Imovel_Condominio_Unidades_Por_Andar = (byte?) Imovel_Condominio_Unidades_Por_Andar;
                a.C_Imovel_Condominio_Valor = decimal.Parse( Imovel_Condominio_Valor);
                a.C_Imovel_Condominio_Administradora =  Imovel_Condominio_Administradora;
                if (Imovel_condominio_infraestrutura != null && Imovel_condominio_infraestrutura.Count > 0)
                {
                    a.C_Imovel_Condominio_Infraestrutura = string.Join("|", Imovel_condominio_infraestrutura);
                }
                if (Imovel_instalacoes != null && Imovel_instalacoes.Count > 0)
                {
                    a.C_Imovel_Instalacoes = string.Join("|", Imovel_instalacoes);
                }
                if (Imovel_lazer != null && Imovel_lazer.Count > 0)
                {
                    a.C_Imovel_Lazer = string.Join("|", Imovel_lazer);
                }
                

                a.UsuarioInc_ID = UsuarioLogado_ID.GetValueOrDefault();

                if (fotos != null && fotos.Count > 0)
                { 
                    a.NomeArquivoFotoPrincipal = fotos.FirstOrDefault();

                    for (int i = 0; i < fotos.Count; i++)
                    {
                        var af = new AnuncioFoto();
                        af.NomeArquivo = fotos[i];
                        af.DataInc = DateTime.Now;
                        a.AnuncioFoto.Add(af);
        
                    }
                }




                if (ID != null && ID > 0)
                {
                    a.ID = (int)ID;
                    bll.UpdateAndSave(a);
                    return Json(new RetornoJsonPadrao("Anuncio alterado com sucesso.", true, a.ID));
                }
                else
                {
                    Tuitar("A: " + a.Titulo + " U: " + UsuarioLogado_ID);
                    bll.InsertAndSave(a);
                    return Json(new RetornoJsonPadrao("Anuncio cadastrado com sucesso.", true, a.ID));
                }
                
                
            }
            catch (Exception ex)
            {

                return Json(new RetornoJsonPadrao(Excecao.Trata(ex), false, null));
            }



            
        }

        /// <summary>
        /// 03 - Verifica se existe um nome de usuario já cadastrado
        /// </summary>
        /// <param name="sch">Token de Verificação da Sessão</param>
        /// <param name="n">Nome de Usuário a ser Verificado</param>
        /// <returns></returns>
        public JsonResult json03(string sch, string n)
        {

            try
            {
                VerificaSessao(sch);
                
                return Json(new { valor = BLLProcedures.stpNomeUsuarioList(n) });
            }
            catch (Exception ex)
            {
                return Json(new { valor = false , msg = Excecao.Trata(ex)});
                
            }
            
        }

        /// <summary>
        /// 04 - Verifica se existe um email de usuário já cadastrado
        /// </summary>
        /// <param name="sch">Token de Verificação da Sessão</param>
        /// <param name="e">Email a ser verificado</param>
        /// <returns></returns>
        public JsonResult json04(string sch, string e)
        {
            try
            {
                VerificaSessao(sch);

                return Json(new { valor = BLLProcedures.stpEmailUsuarioList(e) });
            }
            catch (Exception ex)
            {
                return Json(new { valor = false, msg = Excecao.Trata(ex) });

            }

        }

        /// <summary>
        /// 05 - Submete o pré-cadastro de um usuário
        /// </summary>
        /// <param name="sch">Token de Verificação da Sessão</param>
        /// <param name="n">Nome de usuário</param>
        /// <param name="e">Email do usuário</param>
        /// <returns></returns>
        public JsonResult json05(string sch, string n, string e)
        {
            try
            {
                VerificaSessao(sch);

                var bll = new BLLUsuario();


                var u = new Usuario();
                u.Nome = n;
                u.Usuario1 = n;
                u.Email = e;
                u.DataInc = DateTime.Now;
                u.Situacao = 0;
                u.Administrador = false;
                u.Senha = new Random().Next(100000, 999999).ToString();

                if (UsuarioLogado_ID != null)
                {
                    u.UsuarioIndicou_ID = UsuarioLogado_ID;
                }
                
                //enviar email com senha
                bll.InsertAndSave(u);

                if (u.ID != 0)
                {
                    
                    Tuitar("@henricavalcante " + u.Nome + "foi Cadastrado" + UsuarioLogado_ID.GetValueOrDefault(0) );
                
                }
                if (UsuarioLogado_ID != null)
                {
                    return Json(new RetornoJsonPadrao(String.Format("Usuário convidado com sucesso, em instantes será enviado um email à {0} com o convite.", e), true, null));
                
                }
                else
                { 
                    return Json(new RetornoJsonPadrao(String.Format("Usuário cadastrado com sucesso, verifique o email {0} com as instruções para concluir o cadastro.", e), true, null));
                
                }
                
            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(Excecao.Trata(ex), false, null));

            }
            
        }

        /// <summary>
        /// 06 - Valida um nome ou sobrenome de usuário
        /// </summary>
        /// <returns></returns>
        /// 


        public JsonResult json07(string q, string limit, string sch)
        {
            try
            {
                VerificaSessao(sch);


                var rAux = BLLProcedures.stpEnderecoList(q);

                var r = (from a in rAux
                        select new
                        {

                            value = a.id,
                            label = a.Endereco
                        }).ToList();


                return Json(r);

                
            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }

        }



        /// <summary>
        /// 08 - Responde uma pergunta de um vendedor
        /// </summary>
        /// <param name="sch">Token de Verificação da Sessão</param>
        /// <param name="pid">id da pergunta</param>
        /// <param name="re">resposta</param>
        /// <returns></returns>
        public JsonResult json08(string sch, int pid, string re)
        {
            try
            {
                VerificaSessao(sch);

                var bll = new BLLAnuncioPergunta();
                
                var p = bll.SelectByKey(pid);

                p.Resposta = re;
                p.IdUsuarioUpd = UsuarioLogado_ID;

                bll.UpdateAndSave(p);

                return Json(new { valor = true, msg = "Respondido com sucesso." });
            }
            catch (Exception ex)
            {
                return Json(new { valor = false, msg = Excecao.Trata(ex) });

            }

        }


        /// <summary>
        /// Retorna as fotos de um anuncio
        /// </summary>
        /// <param name="sch">Token de Verificação da Sessão</param>
        /// <param name="aid">Id do anuncio</param>
        /// <returns></returns>
        public JsonResult json09(string sch, int aid)
        {
            try
            {
                VerificaSessao(sch);

                var bll = new BLLAnuncioFoto();

                var f = bll.Where(a => a.Anuncio_ID == aid);

                var o = new List<string>();

                foreach (var item in f)
                {
                    o.Add(item.NomeArquivo.Split('.')[0]+ "s." +item.NomeArquivo.Split('.')[1]);
                }

                return Json(new { valor = true, o });
            }
            catch (Exception ex)
            {
                return Json(new { valor = false, msg = Excecao.Trata(ex) });

            }

        }
        /// <summary>
        /// Validar usuário para efetuar login
        /// </summary>
        /// <param name="sch"></param>
        /// <param name="u"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public JsonResult json10(string sch, string u, string s)
        {

            try
            {
                VerificaSessao(sch);

                var PossiveisSenhas = s.Split(',');

                var b = new BLL.BLLUsuario();
                var oUsuario = b.ValidarSenha(u, PossiveisSenhas, Request.UserHostAddress.ToString());

                if (oUsuario != null)
                {
                    UsuarioLogado_ID = oUsuario.ID;
                    UsuarioLogado_ADMIN = oUsuario.Administrador;
                    ItensPorPagina = oUsuario.AnunciosPorPagina;

                    if (oUsuario.Endereco == null || oUsuario.CPF == null || oUsuario.UsuarioContato.Count == 0)
                    {
                        return Json(new RetornoJsonPadrao(null, true, false));
                    }
                    else
                    {
                        return Json(new RetornoJsonPadrao(null, true, true));
                    }

                }
                else
                {
                    
                    return Json(new RetornoJsonPadrao("Usuário e/ou Senha inválidos.", false, null));

                }
                
            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }

            
        
        }

        /// <summary>
        /// Realiza uma pergunta em um anuncio
        /// </summary>
        /// <param name="sch"></param>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public JsonResult json11(string sch, int a, string p, bool v)
        {

            try
            {
                VerificaSessao(sch);

               
                var bll = new BLLAnuncioPergunta();
                var bllAnuncio = new BLLAnuncio(bll._context);
                var Anuncio = bllAnuncio.SelectByKey(a);

                var ap = new AnuncioPergunta();
                ap.DataInc = DateTime.Now;
                ap.Pergunta = p;
                ap.IdUsuarioInc = UsuarioLogado_ID.GetValueOrDefault();
                ap.IdAnuncio = a;
                ap.Privada = v;
                bll.InsertAndSave(ap);

                return Json(new RetornoJsonPadrao(null, true, null));

            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }



        }

        /// <summary>
        /// Ofertar em um anuncio
        /// </summary>
        /// <param name="sch"></param>
        /// <param name="anuncio_id"></param>
        /// <param name="ofertas"></param>
        /// <param name="descricao"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public JsonResult json12(string sch, int anuncio_id, List<int> ofertas, string descricao, string valor)
        {

            try
            {
                VerificaSessao(sch);

                var bll = new BLLAnuncioOferta();

                var o = new AnuncioOferta();

                if (ofertas != null)
                {
                    foreach (var item in ofertas)
                    {
                        var a = new AnuncioOfertaAnuncio();
                        a.Anuncio_ID = item;
                        o.AnuncioOfertaAnuncio.Add(a);
                    }
                }
                

                o.OfertaDescricao = descricao;
                o.OfertaValor = decimal.Parse( valor);
                o.Anuncio_ID = anuncio_id;
                o.UsuarioInc_ID = UsuarioLogado_ID.GetValueOrDefault();


                bll.InsertAndSave(o);



                return Json(new RetornoJsonPadrao("Oferta realizada com sucesso.", true, null));



            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }

        /// <summary>
        /// Excluir um Anuncio
        /// </summary>
        /// <param name="sch"></param>
        /// <param name="anuncio_id"></param>
        /// <returns></returns>
        public JsonResult json13(string sch, int a)
        {

            try
            {
                VerificaSessao(sch);

                var bll = new BLLAnuncio();

                bll.Arquivar(a, UsuarioLogado_ID.GetValueOrDefault());

                return Json(new RetornoJsonPadrao("Anuncio excluido com sucesso.", true, null));

            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }

        /// <summary>
        /// Enviar email pela area de contato.
        /// </summary>
        /// <param name="sch">Token de autenticação de sessão</param>
        /// <param name="n">Nome</param>
        /// <param name="e">Email</param>
        /// <param name="m">Mensagem</param>
        /// <returns></returns>
        public JsonResult json14(string sch, string n, string e, string m)
        {

            try
            {
                VerificaSessao(sch);

                var bll = new BLLEmail();

                Validar.StringVazia(n, "Informe um nome.");
                Validar.StringVazia(e, "Informe um email.");
                Validar.StringVazia(m, "Informe a mensagem a ser enviada.");

                Validar.Condicao(Validar.EMail(e), "Informe um email válido.");

                bll.EnviarEmail("contato@henrimichel.com.br", "(MUAMBBA)(" + n + ")(" + e + ")", m);

                
                return Json(new RetornoJsonPadrao("Mensagem enviada com sucesso.", true, null));

            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }


        /// <summary>
        /// Registrar denuncia
        /// </summary>
        /// <param name="sch"></param>
        /// <param name="dn"></param>
        /// <param name="dnt"></param>
        /// <param name="dno"></param>
        /// <param name="dnc"></param>
        /// <returns></returns>
        public JsonResult json15(string sch, string dn, int dnt, int dno, int dnc)
        {

            try
            {
                VerificaSessao(sch);

                var bll = new BLLDenuncia();

                var d = new Denuncia();

                d.Denuncia1 = dn;
                d.DenunciaObjeto_ID = dno;
                d.DenunciaTipo_ID = dnt;
                d.DenunciaClasse_ID = dnc;
                d.UsuarioInc_ID = UsuarioLogado_ID;

                bll.InsertAndSave(d);


                return Json(new RetornoJsonPadrao("Denuncia Registrada com Sucesso.", true, null));

            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }



        /// <summary>
        /// Reenviar senha
        /// </summary>
        /// <param name="sch"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public JsonResult json16(string sch, string e)
        {

            try
            {
                VerificaSessao(sch);

                var bll = new BLLUsuario();


                var b = bll.RenovarSenha(e);

                if (b)
                {
                    return Json(new RetornoJsonPadrao("Um email com instruções foi enviado.", true, null));
                }
                else
                {
                    throw new Exception("Problemas ao reenviar a senha.");
                }
                
            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }

        
    }
}
