    
/*
Função "mask". Insere mascaras nos formulários. Representado da seguinte maneira:
a - Representa letras ( A-Z , a-z);
9 - Representa um caracter numérico (0-9)
* - Representa um caracter alpha numérico (A-Z,a-z,0-9)
*/

/*

var newsitems;
var curritem=0;
var iPause=0;

$(document).ready(function(){
$('div#header').pngFix();
	
$('div#banner').cycle({
fx:      'fade',
pager:  '#rodapeBanner',
delay:  2000
});	

var tickerSelector = "ul#ticker li";
newsitems = $(tickerSelector).hide().hover(
function(){
$(this).addClass("hovered");
iPause=1;
},
function(){
$(this).removeClass("hovered");
iPause=0;
}
).filter(":eq(0)").show().add(tickerSelector).size();
setInterval(ticknews,4000); //time in milliseconds
});
*/

(function($) {
    $(
		function() {

		    $('.val').setMask({ mask: '99,999.999.999', type: 'reverse', defaultValue: '000' },
				$('.val').focus(function() { $(this).value })
			);

		    //            if($.browser.mozilla) 
		    //            {    //Identificado o Browser como Mozilla FireFox            
		    //                $('#ctl00_ContentPlaceHolder1_txtCPF').keypress(verificaTecla);
		    //                $('#ctl00_ContentPlaceHolder1_txtCNPJ').keypress(verificaTecla);
		    //                $('#ctl00_ContentPlaceHolder1_txtCodigo').keypress(verificaTecla);
		    //            }
		    //            else
		    //            {    //Outro Browser
		    //                $('#ctl00_ContentPlaceHolder1_txtCPF').keydown(verificaTecla);
		    //                $('#ctl00_ContentPlaceHolder1_txtCNPJ').keydown(verificaTecla);
		    //                $('#ctl00_ContentPlaceHolder1_txtCodigo').keydown(verificaTecla);
		    //            }                       
		}
	);

    //	    function verificaTecla(event)
    //        {
    //            if(event.keyCode == 13)
    //            {    //Identificado como sendo a tecla ENTER
    //              $('#ctl00_ContentPlaceHolder1_btnLer').click();              
    //            }
    //        }   

})(jQuery);

//--------------------------------------------------------------------------------------------------------------------

$().ready(function() {

    

    $('.master.recolher').click(function() {
        $(this).parent().parent().parent().find(".box-conteudo").slideUp(1000);
    });
    $('.master.expandir').click(function() {
        $(this).parents(".box-controls").parents(".box-topo").parents(".box").find(".box-conteudo").slideDown();
    });
    
    $('.box-topo').find("span").click(function() {
        $(this).parents(".box").find(".box-conteudo").slideDown();
    });
    
    $('.master.fechar').click(function() {
        $(this).parents(".box-controls").parents(".box-topo").parents(".box").fadeOut(1500);
    });

    //$('#tag_cloud').tagCloud({ "direction": "horizontal", "easein": "easeOutBounce", "speed": 50000 });
    var aLi = $("#tag_cloud li");
    var iLi = aLi.length;
    var fonte = 20;
    $.each(aLi, function(i, o) {

        $(o).css({ 'font-size': fonte + 'pt' });
        fonte = fonte - 0.5;
        
        
    });
    $('#tag_cloud').find("li").tsort({order: "rand"});
    
    //caixaTexto = $('.txt');

    //if ($.browser.mozilla) {    //Identificado o Browser como Mozilla FireFox            
    //    $(caixaTexto).keypress(verificaEnter);
    //}
    //else {    //Outro Browser
    //    $(caixaTexto).keydown(verificaEnter);
    //}

    // focus nos campos

    $('.txt').focus(function() {

        $(this).toggleClass('txt-focus');

    });

    $('.txt').blur(function() {

        $(this).toggleClass('txt-focus');

    });

    $('.btn_ofertar_cancelar').click(function() {

        $('div#ofertar').fadeOut(1000);

    });
    
    
});

//function verificaEnter(event) {
//    if (event.keyCode == 13) {    //Identificado como sendo a tecla ENTER
//        campoAtual = caixaTexto.index(this);
//
//       if (caixaTexto[campoAtual + 1] != null) {    //Setando o focu na próxima caixa de texto
//            proxCaixa = caixaTexto[campoAtual + 1];
//            proxCaixa.focus();
//
//            event.preventDefault();
//            return false;
//        }
//    }
//}   