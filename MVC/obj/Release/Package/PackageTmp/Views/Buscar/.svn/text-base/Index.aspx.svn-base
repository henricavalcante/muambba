<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

    <% if ((bool)ViewData["ModoDebug"])
       {%>
        
    <link href="/Content/d$a$jquery.jcarousel-anuncio-lista.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/d$a$jquery.jcarousel.js" type="text/javascript"></script>

    <% }
       else
       { %>

    <link href="/css/d/<%= ViewData["SessaoAtual"].ToString() %>.css" rel="stylesheet" type="text/css" />
    <script src="/js/d/<%= ViewData["SessaoAtual"].ToString() %>.js" type="text/javascript"></script>

    <% } %> 

    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <% string busca = (string)ViewData["busca"];

       var ctx = new ContextoBLL();

       var anuncios = (from a in ctx.Anuncio
                       where a.Titulo.ToLower().Contains(busca.ToLower()) && a.UsuarioExc_ID == null
                       join c in ctx.Categoria on a.Categoria_ID equals c.ID
                       select new ucAnuncioListaPadraoParam { 
                           ID = a.ID,
                           Titulo = a.Titulo,
                           SubTitulo = a.SubTitulo,
                           Preco = a.Preco,
                           NomeArquivoFotoPrincipal = a.NomeArquivoFotoPrincipal,
                           AnuncioConservacao_ID = a.AnuncioConservacao_ID,
                           AnuncioTipo_ID = a.AnuncioTipo_ID,
                           Visitas = a.Visitas,
                           Categoria = c.Categoria1,
                           Categoria_Link = c.Link,
                           DataInc = a.DataInc,
                           UsuarioInc_ID = a.UsuarioInc_ID
                       
                       });
       IEnumerable<ucAnuncioListaPadraoParam> anunciosOrdenados;

        if (P_em_ordem())
       {
           anunciosOrdenados = anuncios.OrderBy(P_Anuncio_ordenado_por()).ToList();
       }
           else
       {
           anunciosOrdenados = anuncios.OrderByDescending(P_Anuncio_ordenado_por()).ToList();
       }                 
                       
       var p = new ucPaginacaoOrdenacaoFiltrosParam();
       //p.QuantidadeRegistros = ctx.Anuncio.Count(a => a.Titulo.ToLower().Contains(busca.ToLower()));
       p.QuantidadeRegistros = anunciosOrdenados.Count();
       p.Ordenacao.Add("Preço");
       p.Ordenacao.Add("Data");
       p.Ordenacao.Add("Visitas");
       p.UrlRetorno = "/b/" + busca + "/";

        var anunciosPaginados = anunciosOrdenados.Skip(P_a_partir_de()).Take(ItensPorPagina);

        if (p.QuantidadeRegistros > 0)
        { 
            var bllBusca = new BLLBusca(ctx);

            var oBusca = new Busca();

            oBusca.Busca1 = busca;
            oBusca.DataInc = DateTime.Now;


            oBusca.UrlAtual = (Request.UrlReferrer != null) ? Request.UrlReferrer.ToString() : string.Empty;

            if (UsuarioLogado_ID != null)
            {
                oBusca.UsuarioInc_ID = UsuarioLogado_ID;

            }
            bllBusca.InsertAndSave(oBusca); 
        }
        
                   
                      
        %>
        
        <span>Exibindo os resultados de '<%= busca %>', foram encontrados <%= p.QuantidadeRegistros %> registros.</span>

    <%  Html.RenderPartial("ucPaginacaoOrdenacaoFiltros", p); %>

    <%  Html.RenderPartial("ucAnuncioListaPadrao", anunciosPaginados); %>

    <%  Html.RenderPartial("ucPaginacaoOrdenacaoFiltros", p); %>


    </asp:Content>
