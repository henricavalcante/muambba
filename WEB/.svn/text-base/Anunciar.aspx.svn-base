<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anunciar.aspx.cs" Inherits="WEB.Anunciar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="anunciar_geral">
        <div id="anunciar_topo">
        <asp:Label ID="Label3" runat="server" CssClass="tit" Text="Anunciar"></asp:Label>
        </div>
        <div id="anunciar_left" >
                <div class="lbl">
                Titulo:
                </div>
                <div>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="txt" Width="99%"></asp:TextBox>
                </div>
                <div class="lbl">
                Subtitulo:
                </div>
                <div>
                <asp:TextBox ID="txtSubtitulo" runat="server" CssClass="txt" Width="99%"></asp:TextBox>
                </div>
                <div class="lbl">
                Descrição:
                </div>
                <div>
                <asp:TextBox ID="txtDescricao" runat="server" CssClass="txt" 
                    TextMode="MultiLine" Height="144px" Width="99%"></asp:TextBox>
                </div>
                <div class="lbl">
                Categoria:&nbsp;
                <asp:Label ID="lblCategoria" runat="server" CssClass="lbl-bold" 
                    Text="Categoria &gt;&gt;"></asp:Label>
                </div>
                <div>
                <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" 
                    CssClass="txt" Width="99%" 
                        onselectedindexchanged="ddlCategoria_SelectedIndexChanged1">
                </asp:DropDownList>
                </div>
                <div class="lbl">
                Tipo:
                </div>
                <div>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="txt">
                </asp:DropDownList>
                </div>
                <div class="lbl">
                Conserva&ccedil;&atilde;o:
                </div>
                <div>
                <asp:DropDownList ID="ddlConservacao" runat="server" CssClass="txt">
                </asp:DropDownList>
                </div>
                <div class="lbl">
                Valor:
                </div>
                <div>
                <asp:TextBox ID="txtValor" runat="server" CssClass="txt val"></asp:TextBox>
                </div>
                <div class="lbl">
                Tempo do Anuncio:</div>
                <div>
                <asp:DropDownList ID="ddlExpira" runat="server" CssClass="txt">
                    <asp:ListItem Selected="True" Value="15">15 Dias</asp:ListItem>
                    <asp:ListItem Value="30">30 Dias</asp:ListItem>
                    <asp:ListItem Value="45">45 Dias</asp:ListItem>
                    <asp:ListItem Value="60">60 Dias</asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="divt_btns">
                <asp:Button ID="btnAnunciar" runat="server" Text="Anunciar" CssClass="btn" 
                        onclick="btnAnunciar_Click1" />
                </div>
                
        </div>
        <div id="anunciar_right">
            <div class="lbl">Fotos:</div>
            
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="txt" />
            
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Enviar" CssClass="btn" 
                onclick="btnUpload_Click" />
            <br />
            <asp:Repeater ID="repFotos" runat="server">
                <HeaderTemplate>
                    <ul id="Fotos">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:RadioButton ID="RadioButton1" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "NomeArquivoMiniatura") %>' GroupName="Fotos" />
                        <asp:Image ID="imgFotos" runat="server" ImageUrl='<%# String.Format("img_anuncios/{0}",DataBinder.Eval(Container.DataItem, "NomeArquivoMiniatura")) %>' />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            
        </div>
        
    </div>
    
</asp:Content>
 
