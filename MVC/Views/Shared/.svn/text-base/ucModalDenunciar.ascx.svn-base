<%@ Control Language="C#" Inherits="MVC.UserControlBase<Object>" %>

<h2> Denuncia de <%= DenunciaClasse.ToString(int.Parse(Model.ToString().Split('|')[1]))%></h2>

<div class="denunciar">
    <%= Html.MuambbaDropDownList("DenunciaTipo", 1, new SelectList(DenunciaTipo.GetAll(), "ID", "Tipo"))%>
    <%= Html.MuambbaTextArea("DenunciaTexto","Informe algo complementar a sua denuncia.",0,0,"",SessaoAtual,"",true) %>
    <a href="javascript:void(0);" class="button" onclick="m.jsn.get('<%= SessaoAtual %>').init(15,{dn: $('#txtDenunciaTexto') ,dnt:1, dno:<%= Model.ToString().Split('|')[0] %>, dnc: <%= Model.ToString().Split('|')[1] %> });">Denunciar</a>
</div>
<div class="denunciado escondido" >
    <p>
        <span class="bold">Obrigado por contribuir denunciando este item! </span>
        <br /><br />
        * Se denunciou o item de forma errada, não se preocupe, são necessárias várias denúncias para afetar o item.
        <br /><br />
        * 90% dos itens eliminados através destas denuncias violam as Condições de utilização do Muambba.
        
    </p>
</div>
