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
    
    var oBLLCategorias = new BLLCategoria();
    
    
    var oAnuncio = new Anuncio();
    
    
 %>
 
  

<h1>Cadastre seu Anuncio, é rápido e grátis!!!</h1>

<!-- Categorias -->
<div class="content">
    
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
               
                               <li id="li-cat-<%= item.ID %>" onclick="m.jsn.get('<%= SessaoAtual %>').init(1,<%= item.ID %>); $('#hdfCategoriaID').val(<%= item.ID %>);m.c.setaClasseParent(this, 'scroll', 'carregando');"><%= item.Categoria1 %></li>
               
                               <%
                           }
                            %>

                        </ul>
                    </div>
                </li>
            </ul>
        </div>
        <input type="hidden" value="0" name="categoria_id" id="hdfCategoriaID" />
    </div>
</div>


</div>
<!-- Categorias (FIM) -->




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
            <ul class="qq-upload-list"></ul>
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
                <%= Html.MuambbaTextBox("Titulo", "Insira um título, lembre-se de não usar palavras como Compro, Vendo ou Troco nesse local.",0,0,"",SessaoAtual,"",true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Sub Título:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("SubTitulo", "Insira um breve detalhamento do produto ou serviço a ser anunciado.", 0, 0, "", SessaoAtual,"", true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Descrição:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextArea("Descricao", "Agora sim insira a descrição completa do anuncio.", 0, 0, "", SessaoAtual,"", true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Tipo de Negociação:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("AnuncioTipo", 1, new SelectList(AnuncioTipo.GetAll(), "ID", "Tipo"))%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Conservação:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("AnuncioConservacao",1, new SelectList(AnuncioConservacao.GetAll(), "ID", "Conservacao"))%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Preço:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Preco","0,00",0,0,"decimal",SessaoAtual,"0.00",true) %>
            </div>
        </div>

        <div class="campo-categoria usaQuantidade">      
            <div class="campo c-0-150">
               <b>Quantidade:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Quantidade","Quantos itens deste anuncio você tem em estoque?.",0,0,"999999",SessaoAtual,"",true) %>
            </div>
        </div>

        <div class="campo-categoria usaDisponibilidade">      
            <div class="campo c-0-150">
               <b>Disponibilidade:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Disponibilidade", "Em quantos dias o item anunciado estará disponível?", 0, 0, "999999", SessaoAtual, "", true)%>
            </div>
        </div>

        <div class="campo-categoria usaCor">      
            <div class="campo c-0-150">
               <b>Cor:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Cor","Informe a cor do item anunciado caso queira.",0,0,"",SessaoAtual,"",true) %>
            </div>
        </div> 

        <div class="campo-categoria usaGarantia">      
            <div class="campo c-0-150">
               <b>Garantia:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Garantia","Informe a garantia do item anunciado caso haja.",0,0,"",SessaoAtual,"",true) %>
            </div>
        </div> 

        <div class="campo-categoria usaTamanho">      
            <div class="campo c-0-150">
               <b>Tamanho:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Tamanho", "Informe o tamanho do item, poderá ser útil para cálculo de frete.", 0, 0, "", SessaoAtual, (Model != null) ? Model.C_Tamanho : "", true)%>
            </div>
        </div>

        <div class="campo-categoria usaVeiculo">      
            <div class="campo c-0-150">
               <b>Cor do Veículo:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("Veiculo_Cor",1, new SelectList(Veiculo_Cor.GetAll(), "ID", "Cor"))%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo">      
            <div class="campo c-0-150">
               <b>Ano de Fabricação:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Veiculo_Ano_Fabricacao", "Ano de Fabricação do Veículo", 0, 0, "9999", SessaoAtual, (Model != null) ? Model.C_Veiculo_Ano_Fabricacao.ToString() : DateTime.Now.ToString("yyyy"), true)%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo">      
            <div class="campo c-0-150">
               <b>Ano de Modelo:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Veiculo_Ano_Modelo", "Ano de Modelo do Veículo", 0, 0, "9999", SessaoAtual, (Model != null) ? Model.C_Veiculo_Ano_Modelo.ToString() : DateTime.Now.ToString("yyyy"), true)%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo">      
            <div class="campo c-0-150">
               <b>Combustível:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaDropDownList("Veiculo_Combustivel", 1, new SelectList(Veiculo_Combustivel.GetAll(), "ID", "Combustivel"))%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo">      
            <div class="campo c-0-150">
               <b>Kilometragem Rodada:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Veiculo_Km", "kilometragem atual do veículo", 0, 0, "integer", SessaoAtual, (Model != null) ? Model.C_Veiculo_Km.ToString() : "", true)%>
            </div>
        </div> 
        <div class="campo-categoria usaVeiculo">
            <b>Acessórios:</b>
            <ul class="lista-selecao">
                <% foreach (var item in Veiculo_Acessorios.GetAll())
                   {
                       %>
                            <li class="txt-borda acessorio" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
        
        <div class="campo-categoria usaImovel_Residencial">      
            <div class="campo c-0-150">
               <b>Quartos:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Quartos", "Quantos quartos?", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Residencial">      
            <div class="campo c-0-150">
               <b>Suítes:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Suites", "Quantos são suítes?", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Garagem">      
            <div class="campo c-0-150">
               <b>Vagas de Garagem:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Vagas_Garagem", "Quantas vagas de garagem?", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel">      
            <div class="campo c-0-150">
               <b>Idade do Imóvel:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Idade", "Informe a idade do Imóvel", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel">      
            <div class="campo c-0-150">
               <b>Valor do IPTU:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_IPTU", "0,00", 0, 0, "decimal", SessaoAtual, "0.00", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel">      
            <div class="campo c-0-150">
               <b>Área do Terreno:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Area_Terreno", "0,00", 0, 0, "decimal", SessaoAtual, "0.00", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel">      
            <div class="campo c-0-150">
               <b>Área util:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Area_Util", "0,00", 0, 0, "decimal", SessaoAtual, "0.00", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">      
            <div class="campo c-0-150">
               <b>Nome do Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Nome", "Qual o nome do Condomínio ou Shopping?", 0, 0, "", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">      
            <div class="campo c-0-150">
               <b>Andar do Imóvel:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Andar", "Informe o Andar.", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">      
            <div class="campo c-0-150">
               <b>Andares do Condomínio:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Andares", "Quantos andares tem?", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">      
            <div class="campo c-0-150">
               <b>Imóveis por Andar:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Unidades_Por_Andar", "Imóveis em cada Andar?", 0, 0, "999", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">      
            <div class="campo c-0-150">
               <b>Valor do Condomínio:</b> 
            </div>
            <div class="campo c-150-150">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Valor", "0,00", 0, 0, "decimal", SessaoAtual, "0.00", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">      
            <div class="campo c-0-150">
               <b>Administradora:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Imovel_Condominio_Administradora", "Qual empresa administra o condomínio atualmente?", 0, 0, "", SessaoAtual, "", true)%>
            </div>
        </div>
        <div class="campo-categoria usaImovel_Condominio">
            <b>Infraestrutura do Condomínio:</b>
            <ul class="lista-selecao">
                <% foreach (var item in Imovel_Condominio_Infraestrutura.GetAll())
                   {
                       %>
                            <li class="txt-borda imovel_condominio_infraestrutura" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
        <div class='campo-categoria usaImovel_Instalacoes'>
            <b>Instalações:</b>
            <ul class="lista-selecao">
                <% foreach (var item in Imovel_Instalacoes.GetAll())
                   {
                       %>
                            <li class="txt-borda imovel_instalacoes" ident="<%= item %>">
                            
                                <div>
                                    <%= item %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
        <div class='campo-categoria usaImovel_Lazer'>
            <b>Lazer:</b>
            <ul class="lista-selecao">
                <% foreach (var item in Imovel_Lazer.GetAll())
                   {
                       %>
                            <li class="txt-borda imovel_lazer" ident="<%= item %>">
                            
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
                                ID:  <%= (Model != null) ? Model.ID : 0 %>,
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
