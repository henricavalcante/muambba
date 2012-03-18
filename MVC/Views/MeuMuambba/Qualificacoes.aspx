<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.RenderPartial("ucAbasSuperiores"); %>




   <div class="ajudante" style="left: 300px; top: 300px;">
          <div class="ajudante-interno" style="bottom: 0pt;">
              <div class="ajudante-nucleo">
                  <div class="ajudante-conteudo">Em Breve um sistema de qualificações</div>
                  <i class="ajudante-bola1">&bull;</i>
                  <i class="ajudante-bola2">&bull;</i>
                  <i class="ajudante-bola3">&bull;</i>

              </div>
          </div>
      </div>






</asp:Content>
