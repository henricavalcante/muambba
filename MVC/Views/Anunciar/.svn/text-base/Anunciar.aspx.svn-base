<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<Anuncio>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    
    <% if ((bool)ViewData["ModoDebug"]){%>
          
    <link href="/Content/c$a$fileuploader.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/c$a$fileuploader.js" type="text/javascript"></script>


    <% } else { %>
        
    <link href="/css/c/<%= ViewData["SessaoAtual"].ToString() %>.css" rel="stylesheet" type="text/css" />
    <script src="/js/c/<%= ViewData["SessaoAtual"].ToString() %>.js" type="text/javascript"></script>


    <% } %>    
        
   


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%
    var bll = new BLLAnuncio();
    var oBLLCategorias = new BLLCategoria(bll._context);
    
    
    var oAnuncio = new Anuncio();

    if (ViewData["id"] != null)
    {
        oAnuncio = bll.SelectByKey((int)ViewData["id"]);
    }
 %>
 
  

<h1>Cadastre seu Anuncio, é rápido e grátis!!!</h1>

<!-- Categorias -->
<div class="content">
    
    <% if (oAnuncio.ID == null || oAnuncio.ID == 0)
       { 
       
       %>
       

<h2>Selecione uma Categoria para seu anuncio.</h2>


<div class="scroll jsn">
    <div class="scrollme">
        <div id="dvCategorias">
            <ul>

                <li>
                    <div class="scroll-pane dvCategoria">
                        <ul class="ulCategoria">
                        <% 
           foreach (var item in oBLLCategorias.ListarPais(0).OrderBy(a => a.Categoria1))
           {
                               %>
               
                               <li id="li-cat-<%= item.ID %>" onclick="m.jsn.get('<%= SessaoAtual %>').init(1,<%= item.ID %>); $('#hdfCategoriaID').val(<%= item.ID %>);m.c.setaClasseParent(this, 'scroll', 'carregando');"><%= item.Categoria1%></li>
               
                               <%
           }
                            %>

                        </ul>
                    </div>
                </li>
            </ul>
        </div>
        
    </div>
</div>


</div>
<!-- Categorias (FIM) -->

       <% }
       %>
<input type="hidden" value="<%= ((oAnuncio.Categoria_ID != null) ? oAnuncio.Categoria_ID : 0) %>" name="categoria_id" id="hdfCategoriaID" />

<!-- Fotos -->
<div class="content upload-fotos-content ">
    

   

    <h2>Faça upload das imagens.</h2>


    <div id="upload-fotos">		
	    <noscript>			
		    <p>Habilite o Javascript para fazer upload das fotos.</p>
		
	    </noscript>
        <div class="qq-uploader">
            <div class="qq-upload-drop-area"><span>Arraste arquivos para esta área para fazer upload.</span></div>
            <div class="qq-uploader-div"><a href="javascript:void(0);"class="qq-upload-button button">Insira as Imagens</a></div>
            <ul class="qq-upload-list">
            <% int cont = 0; foreach (var foto in oAnuncio.AnuncioFoto)
                   { %>
                    <li class=" qq-upload-success">
                        <img alt="Imagem <%= cont %>" src="/Imagens/Anuncios/<%= foto.NomeArquivo.Split('.')[0] + "s." + foto.NomeArquivo.Split('.')[1]%>" original="<%= foto.NomeArquivo %>" class="imgAnuncio">
                        <input type="hidden" value="320111211170517203.png" name="Fotos_antiga<%= cont %>"><div>
                        <a href="javascript:void(0);" class="qq-upload-excluir button" >Excluir</a><br>
                        <span class="qq-upload-failed-text">Falhou</span></div>
                    </li>
                <% cont += 1;
                   } %>
            </ul>
        </div>
          
    </div>  
    <script type="text/javascript" language="javascript">
  
        function CriarUploader() {
            var uploader = new qq.FileUploader();
        }

        var isiPad = navigator.userAgent.match(/iPad/i) != null;

        if (isiPad) {
            $('.upload-fotos-content').hide();
        } 
            window.onload = CriarUploader;     
        

        
    </script> 
    <%= Html.Informativo("Não é obrigatório o upload de fotos, mas aumenta consideravelmente as chances de seu anuncio ser visto por outra pessoa.") %>
    

</div>  
<!-- Fotos (FIM) -->

<!-- Dados Gerais -->
<div class="content">
    
      <h2>Dados do Anuncio.</h2>
       <div>      
            <div class="campo c-0-150">
               <b>Título do Anuncio:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Titulo", "Insira um título, lembre-se de não usar palavras como Compro, Vendo ou Troco nesse local.",0,0,"",SessaoAtual, oAnuncio.Titulo ,true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Sub Título:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("SubTitulo", "Insira um breve detalhamento do produto ou serviço a ser anunciado.", 0, 0, "", SessaoAtual,oAnuncio.SubTitulo, true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Descrição:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextArea("Descricao", "Agora sim insira a descrição completa do anuncio.", 0, 0, "", SessaoAtual,oAnuncio.Descricao, true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Tipo de Negociação:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("AnuncioTipo", oAnuncio.AnuncioTipo_ID, new SelectList(AnuncioTipo.GetAll(), "ID", "Tipo"))%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Conservação:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("AnuncioConservacao",oAnuncio.AnuncioConservacao_ID, new SelectList(AnuncioConservacao.GetAll(), "ID", "Conservacao"))%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Preço:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Preco","0,00",0,0,"decimal",SessaoAtual,oAnuncio.Preco.GetValueOrDefault().ToString("##,##0.00"),true) %>
            </div>
        </div>
 
        <div class="campo-categoria usaQuantidade" <%= oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaQuantidade ? "style=\"display:block\"" : ""  %>>   
            <div class="campo c-0-150">
               <b>Quantidade:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Quantidade","Quantos itens deste anuncio você tem em estoque?.",0,0,"999999",SessaoAtual,oAnuncio.C_Quantidade.ToString(),true) %>
            </div>
        </div>

        <div class="campo-categoria usaDisponibilidade" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaDisponibilidade ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Disponibilidade:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Disponibilidade", "Em quantos dias o item anunciado estará disponível?", 0, 0, "999999", SessaoAtual, oAnuncio.C_Disponibilidade.ToString(), true)%>
            </div>
        </div>

        <div class="campo-categoria usaCor" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaCor ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Cor:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Cor","Informe a cor do item anunciado caso queira.",0,0,"",SessaoAtual,oAnuncio.C_Cor,true) %>
            </div>
        </div> 

        <div class="campo-categoria usaGarantia" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaGarantia ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Garantia:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Garantia","Informe a garantia do item anunciado caso haja.",0,0,"",SessaoAtual,oAnuncio.C_Garantia,true) %>
            </div>
        </div> 

        <div class="campo-categoria usaTamanho" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaTamanho ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Tamanho:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Tamanho", "Informe o tamanho do item, poderá ser útil para cálculo de frete.", 0, 0, "", SessaoAtual, oAnuncio.C_Tamanho, true)%>
            </div>
        </div>

        <div class="campo-categoria usaVeiculo" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaVeiculo ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Cor do Veículo:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("Veiculo_Cor",oAnuncio.C_Veiculo_Cor_ID.GetValueOrDefault(1), new SelectList(Veiculo_Cor.GetAll(), "ID", "Cor"))%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaVeiculo ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Ano de Fabricação:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Veiculo_Ano_Fabricacao", "Ano de Fabricação do Veículo", 0, 0, "9999", SessaoAtual, oAnuncio.C_Veiculo_Ano_Fabricacao.GetValueOrDefault(int.Parse( DateTime.Now.ToString("yyyy"))).ToString(), true)%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaVeiculo ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Ano de Modelo:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Veiculo_Ano_Modelo", "Ano de Modelo do Veículo", 0, 0, "9999", SessaoAtual, oAnuncio.C_Veiculo_Ano_Modelo.GetValueOrDefault(int.Parse(DateTime.Now.ToString("yyyy"))).ToString(), true)%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaVeiculo ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Combustível:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("Veiculo_Combustivel",oAnuncio.C_Veiculo_Combustivel_ID.GetValueOrDefault(1), new SelectList(Veiculo_Combustivel.GetAll(), "ID", "Combustivel"))%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaVeiculo ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Kilometragem Rodada:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Veiculo_Km", "kilometragem atual do veículo", 0, 0, "integer", SessaoAtual, oAnuncio.C_Veiculo_Km.ToString(), true)%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaVeiculo ? "style=\"display:block\"" : "" %>>
            <b>Acessórios:</b>
            <ul class="lista-selecao">
                <% List<string> arrVeiculo_Acessorios = oAnuncio.C_Veiculo_Acessorios != null ? oAnuncio.C_Veiculo_Acessorios.ToString().Split('|').ToList() : new List<string>();
                   foreach (var item in Veiculo_Acessorios.GetAll())
                   {
                       %>
                            <li class="txt-borda acessorio  <%= arrVeiculo_Acessorios.Contains(item) ? "selecionado" : "" %>" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
        
        <div class="campo-categoria usaImovel_Residencial" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Residencial ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Quartos:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Quartos", "Quantos quartos?", 0, 0, "999", SessaoAtual, oAnuncio.C_Imovel_Quartos.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Residencial" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Residencial ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Suítes:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Suites", "Quantos são suítes?", 0, 0, "999", SessaoAtual, oAnuncio.C_Imovel_Suites.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Garagem" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel_Garagem ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Vagas de Garagem:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Vagas_Garagem", "Quantas vagas de garagem?", 0, 0, "999", SessaoAtual, oAnuncio.C_Imovel_Vagas_Garagem.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Idade do Imóvel:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Idade", "Informe a idade do Imóvel", 0, 0, "999", SessaoAtual, oAnuncio.C_Imovel_Idade.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel ? "style=\"display:block\"" : "" %>>
            <div class="campo c-0-150">
               <b>Valor do IPTU:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_IPTU", "0,00", 0, 0, "decimal", SessaoAtual, oAnuncio.C_Imovel_IPTU.GetValueOrDefault(0).ToString("##,##0.00"), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Área do Terreno:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Area_Terreno", "0,00", 0, 0, "decimal", SessaoAtual, oAnuncio.C_Imovel_Area_Terreno.GetValueOrDefault(0).ToString("##,##0.00"), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Área util:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Area_Util", "0,00", 0, 0, "decimal", SessaoAtual, oAnuncio.C_Imovel_Area_Util.GetValueOrDefault(0).ToString("##,##0.00"), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Nome do Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Nome", "Qual o nome do Condomínio ou Shopping?", 0, 0, "", SessaoAtual, oAnuncio.C_Imovel_Condominio_Nome, true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Andar do Imóvel:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Andar", "Informe o Andar.", 0, 0, "999", SessaoAtual, oAnuncio.C_Imovel_Condominio_Andar.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Andares do Condomínio:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Andares", "Quantos andares tem?", 0, 0, "999", SessaoAtual, oAnuncio.C_Imovel_Condominio_Andares.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Imóveis por Andar:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Unidades_Por_Andar", "Imóveis em cada Andar?", 0, 0, "999", SessaoAtual,oAnuncio.C_Imovel_Condominio_Unidades_Por_Andar.ToString(), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Valor do Condomínio:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Valor", "0,00", 0, 0, "decimal", SessaoAtual, oAnuncio.C_Imovel_Condominio_Valor.GetValueOrDefault(0).ToString("##,##0.00"), true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>      
            <div class="campo c-0-150">
               <b>Administradora:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Administradora", "Qual empresa administra o condomínio atualmente?", 0, 0, "", SessaoAtual, oAnuncio.C_Imovel_Condominio_Administradora, true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Condominio ? "style=\"display:block\"" : "" %>>
            <b>Infraestrutura do Condomínio:</b>
            <ul class="lista-selecao">
                <% List<string> arrImovel_Condominio_Infraestrutura = oAnuncio.C_Imovel_Condominio_Infraestrutura != null ? oAnuncio.C_Imovel_Condominio_Infraestrutura.ToString().Split('|').ToList() : new List<string>();
                    
                    foreach (var item in Imovel_Condominio_Infraestrutura.GetAll())
                   {
                       %>
                            <li class="txt-borda imovel_condominio_infraestrutura <%= arrImovel_Condominio_Infraestrutura.Contains(item) ? "selecionado" : "" %>" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
        <div class="campo-categoria usaImovel_Instalacoes" <%=  oAnuncio.Categoria_ID > 0 && oAnuncio.Categoria.usaImovel_Instalacoes ? "style=\"display:block\"" : "" %>>
            <b>Instalações:</b>
            <ul class="lista-selecao">
                <%  List<string> arrImovel_Instalacoes = oAnuncio.C_Imovel_Instalacoes != null ? oAnuncio.C_Imovel_Instalacoes.ToString().Split('|').ToList() : new List<string>();
                    
                    foreach (var item in Imovel_Instalacoes.GetAll())
                   {
                       %>
                            <li class="txt-borda imovel_instalacoes <%= arrImovel_Instalacoes.Contains(item) ? "selecionado" : "" %>" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
        <div class="campo-categoria usaImovel_Lazer"  <%= oAnuncio.Categoria_ID > 0 &&  oAnuncio.Categoria.usaImovel_Lazer ? "style=\"display:block\"" : "" %>>
            <b>Lazer:</b>
            <ul class="lista-selecao">
                <%  List<string> arrImovel_Lazer = oAnuncio.C_Imovel_Lazer != null ? oAnuncio.C_Imovel_Lazer.ToString().Split('|').ToList() : new List<string>();
                    
                    foreach (var item in Imovel_Lazer.GetAll())
                   {
                       %>
                            <li class="txt-borda imovel_lazer <%= arrImovel_Lazer.Contains(item) ? "selecionado" : "" %>" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>

</div>
<!-- Dados Gerais (FIM) -->
<script type="text/javascript">


    $(".lista-selecao li").click(function () { $(this).toggleClass('selecionado'); });

    
</script>
<div class="content">

    <a class="button" onclick="cadastrar();">Enviar</a>


</div>
    <script language="javascript" type="text/javascript">

        function cadastrar() {

            var arrFotos = new Array();

            $('.imgAnuncio').each(function (i, element) {

                arrFotos.push($(element).attr('original'));

            });

            var arrVeiculo_Acessorios = new Array();
        
            $('.acessorio.selecionado').each(function (i, element) {

                arrVeiculo_Acessorios.push($(element).attr('ident'));

            });


            var arrImovel_condominio_infraestrutura = new Array();

            $('.imovel_condominio_infraestrutura.selecionado').each(function (i, element) {

                arrImovel_condominio_infraestrutura.push($(element).attr('ident'));

            });
            
            var arrImovel_instalacoes = new Array();

            $('.imovel_instalacoes.selecionado').each(function (i, element) {

                arrImovel_instalacoes.push($(element).attr('ident'));

            });


            var arrImovel_lazer = new Array();

            $('.imovel_lazer.selecionado').each(function (i, element) {

                arrImovel_lazer.push($(element).attr('ident'));

            });

            var postData = {
                                ID:  <%= oAnuncio.ID %>,
                                fotos: arrFotos,
                                titulo: $('#txtTitulo').val(),
                                subtitulo: $('#txtSubTitulo').val(),
                                descricao: $('#txtDescricao').val(),
                                categoria: eval($('#hdfCategoriaID').val()),
                                tipo:  eval($('#ddlAnuncioTipo').val()),
                                conservacao: eval($('#ddlAnuncioConservacao').val()),
                                preco: $('#txtPreco').val(),
                                cor: $('#txtCor').val(),
                                garantia: $('#txtGarantia').val(),
                                tamanho: $('#txtTamanho').val(),
                                disponibilidade: eval($('#txtDisponibilidade').val()),
                                quantidade: eval($('#txtQuantidade').val()),
                                Veiculo_Cor: eval($('#ddlVeiculo_Cor').val()),
                                Veiculo_Combustivel: eval($('#ddlVeiculo_Combustivel').val()),
                                Veiculo_Ano_Fabricacao: eval($('#txtVeiculo_Ano_Fabricacao').val()),
                                Veiculo_Ano_Modelo: eval($('#txtVeiculo_Ano_Modelo').val()),
                                Veiculo_Km: $('#txtVeiculo_Km').val(),
                                Veiculo_Acessorios: arrVeiculo_Acessorios,
                                Imovel_Quartos: eval($('#txtImovel_Quartos').val()),
                                Imovel_Suites: eval($('#txtImovel_Suites').val()),
                                Imovel_Vagas_Garagem: eval($('#txtImovel_Vagas_Garagem').val()),
                                Imovel_Idade: eval($('#txtImovel_Idade').val()),
                                Imovel_IPTU: $('#txtImovel_IPTU').val(),
                                Imovel_Area_Terreno: $('#txtImovel_Area_Terreno').val(),
                                Imovel_Area_Util: $('#txtImovel_Area_Util').val(),
                                Imovel_Condominio_Nome: $('#txtImovel_Condominio_Nome').val(),
                                Imovel_Condominio_Andar: eval($('#txtImovel_Condominio_Andar').val()),
                                Imovel_Condominio_Andares: eval($('#txtImovel_Condominio_Andares').val()),
                                Imovel_Condominio_Unidades_Por_Andar: eval($('#txtImovel_Condominio_Unidades_Por_Andar').val()),
                                Imovel_Condominio_Valor: $('#txtImovel_Condominio_Valor').val(),
                                Imovel_Condominio_Administradora: $('#txtImovel_Condominio_Administradora').val(),
                                Imovel_condominio_infraestrutura: arrImovel_condominio_infraestrutura,
                                Imovel_instalacoes: arrImovel_instalacoes,
                                Imovel_lazer: arrImovel_lazer
                            };

            $.ajax({
                type: "POST",
                url: "/j/json02",
                data: postData,
                success: function (data) {
                    
                    alert(data.m);
                    if (data.s)
                    {
                        window.location.href = '/MeuMuambba/Anuncios/_a_partir_de_0_ordenado_por_Data_em_ordem_decrescente';
                    }
                    
                },
                dataType: "json",
                traditional: true
            });
        }

    
    </script>

    
<div class="clear"></div>

  

  <script type="text/javascript">
      $(function () {

          jQuery('.dvCategoria').jScrollPane();
          jQuery('.scroll .scrollme').jScrollPaneH();

	
       });
	</script>
</asp:Content>
