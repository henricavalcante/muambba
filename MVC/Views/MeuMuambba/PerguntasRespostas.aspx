<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   


     <%
        string SessaoAtual = ViewData["SessaoAtual"].ToString();
        
        Html.RenderPartial("ucAbasSuperiores");

        var u = UsuarioLogado;

        var ctx = new muambbasqlEntities();
        
        var bllAnuncioPergunta = new BLLAnuncioPergunta();
            var bllAnuncio = new BLLAnuncio();

            var perguntas = from a in ctx.Anuncio
                            where a.UsuarioInc_ID == UsuarioLogado_ID && a.UsuarioExc_ID == null
                            join ap in ctx.AnuncioPergunta on a.ID equals ap.IdAnuncio
                            where ap.Resposta == null
                            join up in ctx.Usuario on ap.IdUsuarioInc equals up.ID
                            orderby ap.DataInc ascending
                            select new ucPerguntasRespostasParam()
                            {
                                IdAnuncio = a.ID,
                                AnuncioTitulo = a.Titulo,
                                AnuncioUsuarioInc_ID = a.UsuarioInc_ID,
                                UsuarioNome = up.Nome,
                                UsuarioQualificacao = up.QualificacaoPositiva - up.QualificacaoNegativa,
                                Pergunta = ap.Pergunta,
                                Resposta = ap.Resposta,
                                DataUpd = ap.DataUpd,
                                DataInc = ap.DataInc
                            };
        
    %>

    
      <h1 class="capi"><%= u.Nome + " " + u.Sobrenome + " (" + u.Usuario1 + ") (" + (u.QualificacaoPositiva - u.QualificacaoPositiva).ToString() + ")"%></h1>
    
    <h2> Perguntas sem resposta</h2>



    <% if (perguntas.Count() > 0) { Html.RenderPartial("ucPerguntasRespostas", perguntas); } else { %>
        Não há perguntas sem resposta no momento.
    <% }%>







      


</asp:Content>
