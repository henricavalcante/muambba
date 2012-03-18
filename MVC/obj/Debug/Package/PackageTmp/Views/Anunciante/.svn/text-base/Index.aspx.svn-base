<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<input type="text" title="Procurar" value="Procurar" spellcheck="false" onfocus="$('search_first_focus').value = $(&quot;search_first_focus&quot;).value || +new Date(); var f = function() { JSCC.get('j4e814409abcdb10000725033').init([&quot;searchRecorderBasic&quot;,&quot;showLoadingIndicator&quot;]); ; }; if (window.loaded) { f(); } else { Bootloader.loadComponents(&quot;SearchBootloader&quot;, f); }; " tabindex="" autocomplete="off" placeholder="Procurar" onclick="var q = $(&quot;q&quot;);if (q.value == q.getAttribute(&quot;placeholder&quot;)) {q.focus(); return false;}" name="q2" id="q2" accesskey="/" class="" style="direction: ltr;">

    <input type="text" id="txtEndereco" />
    <ul id="lstPossiveisEnderecos">
    
    </ul>


    <script language="javascript" type="text/javascript">

        $('#txtEndereco').keypress(function () {

            $.post("/Ajax/PesquisaEndereco",
                            {
                                q: $('#txtEndereco').val()

                            },
                            function (dados) {

                                if (dados != null && dados !== '') {

                                    $('#lstPossiveisEnderecos').text('');
                                    $('#lstPossiveisEnderecos').append(dados);
                                }


                            });


        });

    












    $('search_first_focus').value = $('search_first_focus').value || +new Date();
    var f = function() { JSCC.get('j4e814409abcdb10000725033').init(['SearchRecorderBasic','showLoadingIndicator']); ; };
    if (window.loaded) { f(); } else { Bootloader.loadComponents('SearchBootloader', f); }; 




    
    
    </script>

</asp:Content>
