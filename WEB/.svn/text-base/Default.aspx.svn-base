<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WEB._Default" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <div id="default_menu">
    
    <asp:Repeater ID="repCategoria" runat="server">
    <HeaderTemplate>
            <ul id="menu">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
            <asp:HyperLink id="hlEdit" runat="server" NavigateUrl='<%# String.Format("categoria.aspx?c={0}",DataBinder.Eval(Container.DataItem, "IdCategoria")) %>' Text='<%# DataBinder.Eval(Container.DataItem, "Categoria1") %>'>
            </asp:HyperLink>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>

        </FooterTemplate>
    </asp:Repeater>
 
           
</div>


<div id="default_corpo">

<div id="default_anuncie" class="lbl t11">
<a href="cadastrar.aspx" class="bold tu">Cadastre-se já.</a> É gratuito, simples, rápido e fácil <a href="anunciar.aspx" class="bold tu">Anunciar</a> no muambba.com.br.
</div>
<div class="ClearBoth">
</div>
    <div id="default_corpo_top6">

    <asp:Repeater ID="repAnuncios" runat="server">
        <HeaderTemplate>
            <ul id="anuncios_top6">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div class="listagem_top6">
                
                    <div class="listagem_titulo_top6">
                        <a href='<%# String.Format("anuncio.aspx?a={0}",DataBinder.Eval(Container.DataItem, "a.IdAnuncio")) %>'>
                            <asp:Label ID="lblTitulo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "a.Titulo") %>' CssClass="tit bold t10"></asp:Label>
                        </a><br />
                    </div>
                
                    <div class="listagem_foto_top6">
                        <img alt="muambba.com.br" src='<%# String.Format("img_anuncios/{0}",DataBinder.Eval(Container.DataItem, "NomeArquivo")) %>' border="none"/>
                    </div>
                    
                    
                    <div class="listagem_dados_top6">
                        <div class="listagem_valor_top6 tit bold t07">
                            R$<asp:Label ID="lblValor" runat="server" Text='<%# String.Format("{0:##,##0.00}",DataBinder.Eval(Container.DataItem, "a.Preco")) %>' CssClass="t13"></asp:Label>
                            
                        </div>
                        <div class="listagem_categoria_top6 lbl t07">
                                <p><a href='<%# String.Format("categoria.aspx?c={0}",DataBinder.Eval(Container.DataItem, "a.IdCategoria")) %>'>
                                    + de <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>'></asp:Label>
                                </a> </p>
                            </div>
                        <div class="listagem_dados2_top6 ClearBoth">
                        
                            <asp:Label ID="lblAnuncioTipo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "a.AnuncioTipo") %>' CssClass="lbl"></asp:Label>
                            <div>
                            <a href='<%# String.Format("usuario.aspx?u={0}",DataBinder.Eval(Container.DataItem, "a.IdUsuarioInc")) %>'>
                                <asp:Label ID="lblUsuario" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nome") %>' CssClass="lbl bold"></asp:Label>
                            </a>
                            </div>
                            
                            
                        </div>
                    </div>
                </div>
                
             </li>
             </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater> 

    </div>
    <div class="separadorH ClearBoth">
    
    </div>
    
 <div class="box-sugestao box">
 
      <div class="box-topo"> <span class="lbl bold"> Sugestões \ Reclamações</span> <div class="box-controls"> <img src="img/pixel.gif" class="master recolher" /> <img src="img/pixel.gif" class="master expandir" /> <img src="img/pixel.gif" class="master fechar" /></div></div>
    <div class="box-conteudo" style="display:none;">
    
        <span class="lbl">Este website está em construção e em constante desenvolvimento.
        Deixe uma sugestão no formulário abaixo, tenha certeza que sua ajuda será muito útil e de muito agrado. Obrigado.<asp:ImageButton ID="imbAjuda" runat="server" ImageUrl="img/pixel.gif" class="master ajuda"/>
        </span>
            
        
            
        <div class="lbl">
            Nome:
        </div>
        <div>
            <asp:TextBox ID="txtNome" runat="server" CssClass="txt" Width="95%"></asp:TextBox>
        </div>
        <div class="lbl">
            E-Mail:
        </div>
        <div>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="95%"></asp:TextBox>
        </div>
        <div class="lbl">
            Sugestão:
        </div>
        <div>
            <asp:TextBox ID="txtSugestao" runat="server" CssClass="txt" 
                TextMode="MultiLine" Width="95%"></asp:TextBox>
        
        </div>
        <div class="divt_btns">
            <asp:Button ID="btnEnviarSugestao" runat="server" CssClass="btn" 
                Text="Enviar" />
        </div>
    
    
   </div>
   

</div>    

</div>
<div id="default_tag_cloud" class="ClearBoth">
    
    <asp:Repeater ID="repTagCloud" runat="server">
    <HeaderTemplate>
            <ul id="tag_cloud">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href='<%# String.Format("busca.aspx?q={0}",DataBinder.Eval(Container.DataItem, "Busca")) %>'>
                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Busca") %>'></asp:Label>
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
 
           
</div>
</asp:Content>
