using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Util;
using Repositorio;
using MVC.Models;
using System.Collections;

namespace BLL
{
    public class BLLUsuario : Repositorio<Usuario>
    {

        public BLLUsuario()
        {

        }

        public BLLUsuario(ObjectContext _contexto)
            : base(_contexto)
        {
        }

        public override void Validate(Usuario entity)
        {
            
            Validar.Nulo(entity.DataInc,"Informe a Data de Inclusão do Registro");
            Validar.Nulo(entity.Usuario1, "Informe o nome de usuário");
            Validar.NomeDeUsuario(entity.Usuario1, "Informe o nome de usuário corretamente");

        }

        protected override Usuario UpdateRule(Usuario entity)
        {

            Validar.StringVazia(entity.CPF, "Informe um CPF");
            Validar.Condicao(Validar.CPF(entity.CPF), "Informe um CPF");

            var bllUC = new BLLUsuarioContato(_context);
            var bllUF = new BLLUsuarioFoto(_context);

            var u = SelectByKey(entity.ID);

            bool PrimeiroAcesso = (u.CPF == null);

            u.Nome = entity.Nome;
            u.Sobrenome = entity.Sobrenome;
            u.CPF = entity.CPF;
            u.DataUpd = DateTime.Now;
            if (entity.Senha != null && entity.Senha.Trim() != String.Empty && entity.Senha.Length == 6)
            {
                u.Senha = Util.Criptografia.GerarHash(entity.Senha, Util.Criptografia.HashMethod.MD5);
            }
            
            while (u.UsuarioContato.Count > 0)
            {
                bllUC.Delete(u.UsuarioContato.First());
            }

            foreach (var item in entity.UsuarioContato)
            {
                if (item.UsuarioContato1.Trim() != String.Empty)
                { 
                    var uc = new UsuarioContato();
                    uc.UsuarioContatoTipo_ID = item.UsuarioContatoTipo_ID;
                    uc.UsuarioContato1 = item.UsuarioContato1;
                    uc.Publico = item.Publico;
                    u.UsuarioContato.Add(uc);
                }
                
            }

            while (u.UsuarioFoto.Count > 0)
            {
                bllUF.Delete(u.UsuarioFoto.First());
            }

            if (entity.UsuarioFoto.Count > 0)
            {
                u.NomeArquivoFotoPrincipal = entity.UsuarioFoto.First().NomeArquivo;
                foreach (var item in entity.UsuarioFoto)
                {
                    if (item.NomeArquivo.Trim() != String.Empty)
                    {
                        var uf = new UsuarioFoto();
                        uf.NomeArquivo = item.NomeArquivo;
                        uf.DataInc = DateTime.Now;
                        u.UsuarioFoto.Add(uf);
                    }

                }
            }
            else {
                u.NomeArquivoFotoPrincipal = null;
            }

            

            if (entity.Endereco != null)
            {

                if (u.Endereco == null)
                {
                    u.Endereco = new Endereco();
                }
                
                u.Endereco.EnderecoCep_ID = entity.Endereco.EnderecoCep_ID;
                u.Endereco.Complemento = entity.Endereco.Complemento;
                 
            }
            
            
            //validar aqui se o usuário foi convidado e adicionar os pontos a quem convidou.

            if (PrimeiroAcesso && u.UsuarioIndicou_ID != null)
            {

                int premioQualificacao = 5;

                //trocar por metodo credita qualificação
                u.Usuario4.QualificacaoPositiva += premioQualificacao;

                //enviar email

                var bllemail = new BLLEmail();

                Hashtable Parametros = new Hashtable();
                Parametros.Add("NOME-DE-USUARIO", u.Usuario4.Nome);
                Parametros.Add("NOME-DE-USUARIO-NOVO", u.Nome);
                Parametros.Add("PONTOS", premioQualificacao);


                new BLLEmail().EnviarEmailMaster(u.Usuario4.Email, "Parabéns, você recebeu uma qualificação positiva do muambba.com.br", Parametros, "IndicacaoPremio");


            }

            return u;
        }

        protected override Usuario InsertRule(Usuario entity)
        {
            Validar.Condicao(!Exists(a => a.Nome == entity.Nome), "Nome de Usuário já existe");
            Validar.Condicao(!Exists(a => a.Email == entity.Email), "Email já existe");
            entity.QualificacaoPositiva = 0;
            entity.QualificacaoNeutra = 0;
            entity.QualificacaoNegativa = 0;
            entity.Linguagem = "ptBR";
            entity.ManterConectado = true;
            entity.ReceberEmails = true;
            entity.AnunciosPorPagina = 25;

            Hashtable Parametros = new Hashtable();
            Parametros.Add("NOME-DE-USUARIO", entity.Nome);
            Parametros.Add("SENHA", entity.Senha);
            if (entity.UsuarioIndicou_ID != null)
            {
                var u = SelectByKey(entity.UsuarioIndicou_ID.GetValueOrDefault());

                Parametros.Add("NOME-DE-USUARIO-CONVIDOU", u.Nome);
                new BLLEmail().EnviarEmailMaster(entity.Email, "Um convite especial", Parametros, "Indicacao");
            }
            else
            { 
                new BLLEmail().EnviarEmailMaster(entity.Email, "Bem Vindo ao Muambba.", Parametros, "Cadastro");
            }
            
            entity.Senha = Util.Criptografia.GerarHash(entity.Senha, Util.Criptografia.HashMethod.MD5);

            return base.InsertRule(entity);
        }

        public Usuario ValidarSenha(string _login, IList<string> _possiveisSenhas, string ip)
        {

            Validar.Condicao(_possiveisSenhas.Count == 64, "Problemas identificados ao tentar válidar a senha, se chegou nessa mensagem de próposito entre em contato com contato@henrimichel.com.br que eu tenho um emprego para você.");

            var o = base.Single(a => a.Usuario1.ToLower() == _login.ToLower());
            
            var v = false;

            if (o != null)
            {


                foreach (string Item in _possiveisSenhas)
                {

                    if (Item.Length == 6)
                    {
                        if (Util.Criptografia.GerarHash(Item, Util.Criptografia.HashMethod.MD5) == o.Senha)
                        {
                            v = true;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }

                if (o.LoginUltimoFalha.GetValueOrDefault().AddMinutes(5) > DateTime.Now && o.LoginQuantidadeSucessivaFalha >= 3)
                {
                    v = false;
                }

            }


            

            if (v)
            {

                o.LoginQuantidadeTotalSucesso += 1;

                o.LoginQuantidadeSucessivaSucesso += 1;

                o.LoginUltimoSucesso = DateTime.Now;
                o.LoginQuantidadeSucessivaFalha = 0;
                SaveChanges();
                return o;

            }
            else
            {
                

                if (o != null)
                {

                    o.LoginQuantidadeTotalFalha += 1;
                    o.LoginQuantidadeSucessivaFalha += 1;
                    o.LoginUltimoFalha = DateTime.Now;
                    o.LoginQuantidadeSucessivaSucesso = 0;
                    SaveChanges();

                    if (o.LoginQuantidadeSucessivaFalha <= 3)
                    {
                        Hashtable Parametros = new Hashtable();
                        Parametros.Add("NOME-DE-USUARIO", o.Nome);
                        Parametros.Add("LOGIN", o.Usuario1);
                        Parametros.Add("IP", ip);
                        new BLLEmail().EnviarEmailMaster(o.Email, "Login Malsucedido", Parametros, "LoginIncorreto");

                    }
                    
                
                }

                return null;
            }

        
        }

        public bool RenovarSenha(string _email)
        {
            var r = false;
            Random Aleatorio = new Random();
            int NovaSenha = Aleatorio.Next(100000, 999999);

            var o = base.First(a => a.Email == _email);

            if (o != null)
            {
                r = true;
            }
            else
            {
                return false;
            }
            o.Senha = Util.Criptografia.GerarHash(Convert.ToString(NovaSenha), Util.Criptografia.HashMethod.MD5);

            base.SaveChanges();

            if (r)
            {
                Hashtable Parametros = new Hashtable();
                Parametros.Add("NOME-DE-USUARIO", o.Nome);
                Parametros.Add("SENHA", NovaSenha);
                new BLLEmail().EnviarEmailMaster(o.Email, "Recuperação de senha.", Parametros, "SenhaRecuperacao");
            }
            
            return  r;
        }

        public Usuario SelectByName(string nome)
        {
            var u = base.Single(a => a.Usuario1 == nome);

            return u;
        }

    }
}
