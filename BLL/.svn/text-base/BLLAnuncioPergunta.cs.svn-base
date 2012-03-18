using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVC.Models;
using Repositorio;
using System.Data.Objects;
using Util;
using System.Collections;

namespace BLL
{
    public class BLLAnuncioPergunta: Repositorio<AnuncioPergunta>
    {

        

        public BLLAnuncioPergunta()
            : base()
        {
        
        }

        public BLLAnuncioPergunta(ObjectContext _contexto)
            : base(_contexto)
        { 
        
        }


        public override void Validate(AnuncioPergunta entity)
        {
            Validar.Condicao(entity.IdUsuarioInc != null && entity.IdUsuarioInc > 0, "É necessário realizar o login para fazer uma pergunta ao anunciante.");
            var bllAnuncio = new BLLAnuncio(_context);
            Validar.Condicao(entity.IdUsuarioInc != bllAnuncio.SelectByKey(entity.IdAnuncio).UsuarioInc_ID, "Não é permitido fazer perguntas nos próprios anuncios.");    
        }

        protected override void DeleteRule(AnuncioPergunta entity)
        {
                base.DeleteRule(entity);
        }


        protected override AnuncioPergunta InsertRule(AnuncioPergunta entity)
        {
            var bllAnuncio = new BLLAnuncio(_context);
            var a = bllAnuncio.SelectByKey(entity.IdAnuncio);

            entity.DataInc = DateTime.Now;


            Hashtable Parametros = new Hashtable();
            Parametros.Add("NOME-DE-USUARIO", a.Usuario.Nome);
            Parametros.Add("NOME-DO-ANUNCIO", a.Titulo);
            Parametros.Add("URL-DO-ANUNCIO", "http://www.muambba.com.br/" + a.ID + "/" + Util.Util.TituloAnuncio(a.Titulo));

            new BLLEmail().EnviarEmailMaster(a.Usuario.Email, "Nova Pergunta em seu Anuncio", Parametros, "AvisoPergunta");

            return entity;
        }

        protected override AnuncioPergunta UpdateRule(AnuncioPergunta entity)
        {
            var bllAnuncio = new BLLAnuncio(_context);
            var a = bllAnuncio.SelectByKey(entity.IdAnuncio);

            entity.DataUpd = DateTime.Now;

            Hashtable Parametros = new Hashtable();
            Parametros.Add("NOME-DE-USUARIO", a.Usuario.Nome);
            Parametros.Add("NOME-DO-ANUNCIO", a.Titulo);
            Parametros.Add("URL-DO-ANUNCIO", "http://www.muambba.com.br/" + a.ID + "/" + Util.Util.TituloAnuncio(a.Titulo));


            new BLLEmail().EnviarEmailMaster(a.Usuario.Email, "Resposta para sua Pergunta em Anuncio.", Parametros, "AvisoResposta");

            return entity;
        }
    }
}
