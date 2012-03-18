<%@ Control Language="C#" Inherits="MVC.UserControlBase" %>



 
    <div class="clearfix floatleft acessar">
    <h2>Acesse o Muambba</h2>
        <div class="centralize">
           
            
                <%= Html.MuambbaTextBox("Usuario", "Informe o Usuário", 0, "usuario", SessaoAtual)%>
                <br />
                <%= Html.MuambbaTextBox("Senha", false)%>
                
                
                <input type="hidden" id="txtArr" />
           
                <input type="button" id="txtSenhaButton1" value="0 0" class="button" onclick="javascript: btn01(); return false;"/>
                <input type="button" id="txtSenhaButton2" value="0 0" class="button" onclick="javascript: btn02(); return false;"/>
                <input type="button" id="txtSenhaButton3" value="0 0" class="button" onclick="javascript: btn03(); return false;"/>
                <input type="button" id="txtSenhaButton4" value="0 0" class="button" onclick="javascript: btn04(); return false;"/>
                <input type="button" id="txtSenhaButton5" value="0 0" class="button" onclick="javascript: btn05(); return false;"/>
                <input type="button" id="txtSenhaLimpar" value="<<" class="button" title="Limpar" onclick="$('#txtArr').val('');$('#txtSenha').val('');arrAux=new Array();arr=new Array();"/>
        </div>
                <p class="termos">Para maior segurança somente é permitido a digitação da senha pelo teclado virtual.</p>
        <div style="text-align:center;">
                <a class="button" href="javascript:void(0);" onclick="$('.acessar').fadeOut(400,function(){ $('.recuperar').fadeIn(400); });">Esqueceu a senha?</a> <a class="button" href="javascript:void(0);">Dúvidas de acesso?</a>      
        </div>
        
  </div>

  <div class="clearfix floatleft recuperar escondido">
    <h2>Recupere sua senha</h2>
        <div class="centralize">
           
            
                <%= Html.MuambbaTextBox("EmailRecuperar", "Informe o email cadastrado.", 0, "", SessaoAtual)%>
                <br />
                
                <a class="button" href="javascript:void(0);" onclick="m.jsn.get('<%= SessaoAtual %>').init(16,$('#txtEmailRecuperar').val());m.c.setaClasseParent(this,'jsn','carregando')">Recuperar Senha</a> <a class="button" href="javascript:void(0);" onclick="$('.recuperar').fadeOut(400,function(){ $('.acessar').fadeIn(400); });">Voltar</a>     
        </div>
        
  </div>
    
    <script type="text/javascript">


        var arrInputs = new Array();
        var arr = new Array();
        var arrAux = new Array();

        $(function () {



            arrInputs.push(aleatorio());

            while (arrInputs.length < 10) {
                ale = aleatorio();
                inserir = true;

                for (var i = 0; i <= arrInputs.length - 1; i++) {

                    if (arrInputs[i] == ale) {
                        inserir = false;
                    }
                }

                if (inserir) {
                    arrInputs.push(ale);
                }


            }
            var senha = new Array();

            for (var i = 1; i <= 5; i++) {


                $('#txtSenhaButton' + i).val(arrInputs[(i * 2) - 2] + " " + arrInputs[(i * 2) - 1]);

            }


        });


        function btn01() {
            AddNumeros(arrInputs[0], arrInputs[1])
        }
        function btn02() {
            AddNumeros(arrInputs[2], arrInputs[3])
        }
        function btn03() {
            AddNumeros(arrInputs[4], arrInputs[5])
        }
        function btn04() {
            AddNumeros(arrInputs[6], arrInputs[7])
        }
        function btn05() {
            AddNumeros(arrInputs[8], arrInputs[9])
        }


        function AddNumeros(Valor1, Valor2) {

            if (arr.length == 0) {
                arr.push(Valor1);
                arr.push(Valor2);
            } else {
                arrAux = arr;
                arr = new Array();
                for (i = 0; i <= arrAux.length - 1; i++) {
                    arr.push(arrAux[i] + "" + Valor1);
                    arr.push(arrAux[i] + "" + Valor2);
                }
            }

            var txtSenha = $('#txtSenha');

            txtSenha.val(txtSenha.val() + "*");

            if (arr.length >= 64) {
                ValidarUsuario();
            }

        }

        function ValidarUsuario() {

            m.jsn.get('<%= ViewData["SessaoAtual"].ToString() %>').init(10, arr);

            $('#txtSenha').val("");
            arr = new Array();

        }

        function aleatorio() {
            aleat = Math.random() * 10;
            aleat = Math.floor(aleat);
            return aleat;
        }

        

    </script>
  

  <div class="clearfix floatright">

        <h3 style="margin: 6px 0 12px;">Novo por aqui? Cadastre-se, é grátis!</h3>

    <div>
            
            
                <%= Html.MuambbaTextBox("Nome", "Nome de usuário a ser cadastrado", 3, "usuario", SessaoAtual)%>
                <br />
                <%= Html.MuambbaTextBox("Email", "Insira um e-mail válido", 4, "", SessaoAtual)%>
                <a href="javascript:void(0);" onclick="var objCadastro = {nome: $('#txtNome') ,email: $('#txtEmail')}; m.jsn.get('<%= SessaoAtual %>').init(5,objCadastro);m.c.setaClasseParent(this,'jsn','carregando')" class="button">Cadastre-se</a>
                

                <p class="termos">
                    Ao clicar em Cadastre-se, você está afirmando que leu e concorda com os Termos de uso e com a Política de privacidade.
               </p>

        </div>
    </div>