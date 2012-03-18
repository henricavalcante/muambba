<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
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

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%
    var ctx = new ContextoBLL();
    
    var bll = new BLL.BLLCategoria(ctx);
    
    int categoria_id = (int)ViewData["Categoria_ID"];

    


    var lstCategorias = bll.SelectByKey(categoria_id).Categoria11.OrderBy(a => a.Categoria1).ToList();

    
    
%>
    
    <div class="cart">
    
    <div id="category" class="middle">

   <ul>
  <%
      
      foreach (var i in lstCategorias)
          {

              var lnk = (Request.RawUrl.Substring((Request.RawUrl.Count()-1),1) == "/" ? Request.RawUrl.Substring(0,Request.RawUrl.LastIndexOf("/")) : Request.RawUrl);
              
              %>
              <li class="category-inline-block"><a href="<%= String.Format("{0}/{1}", lnk, i.Categoria1 )%>"><%= i.Categoria1%> (<%= i.QuantidadeAnuncios%>)</a></li>
          
              <%
          
          }
     
       %>

   </ul>

</div>
    </div>

         
    
    <% 
        var CategoriasFilhas = bll.ListaDeIDsFilhosCompleta(categoria_id);
//se for adicionar mais itens criar um objeto dinamico apenas com os itens desejados
       var anuncios = (from a in ctx.Anuncio
                       where CategoriasFilhas.Contains(a.Categoria_ID) && a.UsuarioExc_ID == null
                       join c in ctx.Categoria on a.Categoria_ID equals c.ID
                       select new ucAnuncioListaPadraoParam
                       {
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
       p.UrlRetorno = "/" + String.Join("/", Categorias) + "/";

        var anunciosPaginados = anunciosOrdenados.Skip(P_a_partir_de()).Take(ItensPorPagina);

                     
                      
        %>
        
        <span>Foram encontrados <%= p.QuantidadeRegistros %> registros nesta categoria.</span>

    <%  Html.RenderPartial("ucPaginacaoOrdenacaoFiltros", p); %>

    <%  Html.RenderPartial("ucAnuncioListaPadrao", anunciosPaginados); %>

    <%  Html.RenderPartial("ucPaginacaoOrdenacaoFiltros", p); %>
 

</asp:Content>
