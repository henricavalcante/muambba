/*
particularidades do formulário
*/
function inputTextFocus(obj){
	obj.className = 'formtxtativa';
}
//-------------------------------------------------------------------------------------------------------------
function inputTextBlur(obj){
	obj.className = 'formtxt';
}
//-------------------------------------------------------------------------------------------------------------

function inputNumTextFocus(obj){
	obj.className = 'formtxtNumativa';
}
//-------------------------------------------------------------------------------------------------------------
function inputNumTextBlur(obj){
	obj.className = 'formtxtNum';
}
//-------------------------------------------------------------------------------------------------------------
function ExibirOcultar(objExibir, objOcultar) {

    $('#' + objOcultar).fadeOut(400, function() {

        $('#' + objExibir).fadeIn(400);

    });
}
//-------------------------------------------------------------------------------------------------------------
function ExibirPorCheck(IdCheckbox, IdObjExibir) {

    if (document.getElementById(IdCheckbox).checked) {
        Exibir(IdObjExibir);
    }
    else {
        Ocultar(IdObjExibir);
    }
}
//-------------------------------------------------------------------------------------------------------------
function Exibir(objExibir) {

    $('#' + objExibir).fadeIn(400);
}
//-------------------------------------------------------------------------------------------------------------
function Ocultar(objOcultar) {

    $('#' + objOcultar).fadeOut(400);
}
//--------------------------------------------------------------------------------------------------------
function TrocaDisplay(obj) {

    elemento = document.getElementById(obj);
    if (elemento.style.display == 'none') {
        Exibir(obj);
    }
    else {
        Ocultar(obj);
    }
}
//--------------------------------------------------------------------------------------------------------
function verificarMascara(tecla,m) {

	if (m == '?') {
		return ('0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZ'.toLowerCase().indexOf(tecla.toLowerCase()) > -1);
	} else if (m == '#') {
		return ('0123456789'.indexOf(tecla) > -1);
	} else if (m == '$') {
		return ('ABCDEFGHIJKLMNOPQRSTUVXWYZ'.toLowerCase().indexOf(tecla.toLowerCase()) > -1);
	} else return false;
}

//-------------------------------------------------------------------------------------------------------------
function mascaraCampo(elemento, mascara, event){

	if (navigator.appName.toLowerCase().indexOf("netscape") > -1)
		ntecla=event.which;
	else
		ntecla=event.keyCode;	
		
	tecla = String.fromCharCode(ntecla);
	
	var m = mascara.charAt(elemento.value.length);

	var teclas = new Array(0, 8, 9, 13, 16, 17, 18, 20, 27, 28, 29, 30, 31);

	for (var i = 0; i < teclas.length; i ++) {
	  if (teclas[i] == ntecla) {
	    return true;
	  }
	}
	
	if ((m == '?') || (m == '#') || (m == '$')) return verificarMascara(tecla,m);
	else {
		elemento.value += mascara.charAt(elemento.value.length);
		m = mascara.charAt(elemento.value.length);
		if (mascara.charAt(elemento.value.length-1) == tecla) return false;
		else return verificarMascara(tecla,m);
	}
}
//------------------------------------------------------------------------------------------------------------
function checar(event, obj, objRetorno) {

    if (navigator.appName.toLowerCase().indexOf("netscape") > -1)
		ntecla=event.which;
	else
		ntecla=event.keyCode;
		
	if(obj.value.length == 12) {
    
        return alert(ntecla);
	
	}
}
//------------------------------------------------------------------------------------------------------------

function valida_data(obj) {
	var date = obj.value;
	var array_data = new Array;
	var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
	//vetor que contem o dia o mes e o ano
	array_data = date.split("/");
	erro = false;
	//Valido se a data esta no formato dd/mm/yyyy e se o dia tem 2 digitos e esta entre 01 e 31
	//se o mes tem d2 digitos e esta entre 01 e 12 e o ano se tem 4 digitos e esta entre 1000 e 2999
	if ( date.search(ExpReg) == -1 )
		erro = true;
	//Valido os meses que nao tem 31 dias com execao de fevereiro
	else if ( ( ( array_data[1] == 4 ) || ( array_data[1] == 6 ) || ( array_data[1] == 9 ) || ( array_data[1] == 11 ) ) && ( array_data[0] > 30 ) )
		erro = true;
	//Valido o mes de fevereiro
	else if ( array_data[1] == 2 ) {
		//Valido ano que nao e bissexto
		if ( ( array_data[0] > 28 ) && ( ( array_data[2] % 4 ) != 0 ) )
			erro = true;
		//Valido ano bissexto
		if ( ( array_data[0] > 29 ) && ( ( array_data[2] % 4 ) == 0 ) )
			erro = true;
	}
	if ( erro ) {
		alert("Data Invalida");
		obj.focus();
	}
}

// Ativa formulário para pesquisa de dados --------------------------------------------------------------
function AtivarPesquisa(strTab, strDest, strFltExt, strOrdExt, strReq) {

	var strHREF = '';
	var oWnd;

	strHREF += '_pesquisa.aspx?tab=' + strTab + '';	
	
	if (strDest)    {strHREF += '&dest=' + strDest};
	if (strFltExt)  {strHREF += '&fltext=' + strFltExt};
	if (strOrdExt)  {strHREF += '&ordext=' + strOrdExt};
	if (strReq)     {strHREF += '&txtreq=' + strReq}; 
   
	oWnd = window.open(strHREF, 'Pesquisa', 'top=20,left=20,width=760,height=540,menubar=no,statusbar=0,resizable=yes,scrollbars=no');
	
	oWnd.focus();

}

//--------------------------------------------------------------------------------------------------------
function abrirJanelaScroll(url,target,w,h,scrollbar) 
{
	l = parseInt((screen.width - w) / 2);
	t = parseInt((screen.height - h) / 2);
	return window.open(url,target,'width='+w+',height='+h+',left='+l+',top='+t+',status=yes,scrollbars='+scrollbar);
}

// ------------------------------------------------------------------------------------------------------
function showCrystalRPT(rptName, rptParam){

    l = parseInt((screen.width - 300) / 2);
	t = parseInt((screen.height - 150) / 2);
	

    oWnd = window.open('rptview.aspx?rpt=' + rptName + '&param=' + rptParam + '', 'pesquisa', 'top='+t+',left='+l+',width=300,height=150,menubar=no,statusbar=0,resizable=yes');
	
	oWnd.focus();	
}

//--------------------------------------------------------------------------------------------------------

function showCrystalRPT2010(rptName, rptParam) {

    l = parseInt((screen.width - 300) / 2);
    t = parseInt((screen.height - 150) / 2);


    oWnd = window.open('rptview2010.aspx?rpt=' + rptName + '&param=' + rptParam + '', 'pesquisa', 'top=' + t + ',left=' + l + ',width=300,height=150,menubar=no,statusbar=0,resizable=yes');

    oWnd.focus();
}

//--------------------------------------------------------------------------------------------------------

function showCrystalRPT2009(rptName, rptParam) {

    l = parseInt((screen.width - 300) / 2);
    t = parseInt((screen.height - 150) / 2);


    oWnd = window.open('rptview2009.aspx?rpt=' + rptName + '&param=' + rptParam + '', 'pesquisa', 'top=' + t + ',left=' + l + ',width=300,height=150,menubar=no,statusbar=0,resizable=yes');

    oWnd.focus();
}

//--------------------------------------------------------------------------------------------------------

function showCrystalRPTAUX(rptName, rptParam) {

    l = parseInt((screen.width - 300) / 2);
    t = parseInt((screen.height - 150) / 2);


    oWnd = window.open('rptviewaux.aspx?rpt=' + rptName + '&param=' + rptParam + '', 'pesquisa', 'top=' + t + ',left=' + l + ',width=300,height=150,menubar=no,statusbar=0,resizable=yes');

    oWnd.focus();
}


//--------------------------------------------------------------------------------------------------------

function RMouseOver(oRow)
{	

    oRow.style.cursor = 'pointer';
    oRow.style.backgroundColor = '#eee';
}

//--------------------------------------------------------------------------------------------------------
function RMouseOut(oRow)
{

    oRow.style.cursor = 'pointer';
	oRow.style.backgroundColor = '#fefefe';
}

//--------------------------------------------------------------------------------------------------------
function IE(){ return navigator.appName.indexOf('Internet') >= 0; }

//--------------------------------------------------------------------------------------------------------
function parentWindow()
{
    if(IE()){ return document.parentWindow.parent; }
    else{ return document.defaultView.parent; }
}

//---------------------------------------------------------------------------------------------------------

function apenasNumDec(Obj, casas, tam, aEvent)
{
    var Numero = Obj.value;
    var NumeroInt, NumeroDec;
    var intKeyCode = aEvent.keyCode ? aEvent.keyCode : aEvent.which ? aEvent.which : aEvent.charCode;    

    //Limita o tamanho de caracteres do número.
    if ((Numero.length >= tam) && (intKeyCode != 8) && (intKeyCode != 46) && (intKeyCode != 37) && (intKeyCode != 38) && (intKeyCode != 39) && (intKeyCode != 40)) {        
        if(IE()){ aEvent.returnValue = false; }
        else{ aEvent.stopPropagation(); aEvent.preventDefault();}
        return(false);
    }    

    //Só permite a digitação dessas teclas.
    if ((intKeyCode < 48 || intKeyCode > 57) && (intKeyCode != 8) && (intKeyCode != 46) && (intKeyCode != 37) && (intKeyCode != 38) && (intKeyCode != 39) && (intKeyCode != 40)) {
        if(IE()){ aEvent.returnValue = false; }
        else{ aEvent.stopPropagation(); aEvent.preventDefault();}
        return(false);   
    } 

    //Retira a vírgula.
    var rVg      
    rVg = Numero.replace(",", "");
    Numero = rVg;

    //Retira o ponto.
    var NumeroSemPonto = Numero.split(".");
    if(NumeroSemPonto[0] != "")
    {
        Numero = "";
        for(i = 0; i <= NumeroSemPonto.length - 1; i++)
            Numero = Numero + NumeroSemPonto[i];
        }

    //Caso o número não contenha parte inteira são acrescentados
    //zeros à esquerda.
    if(Numero.length < casas)
    {
        var zeros = "";
        for(i = 0; i < casas - Numero.length; i++){
            zeros += "0";
        }
        Numero = zeros + Numero;	
    }

    //Se o número tiver parte inteira e o primeiro número for '0'
    //o mesmo é desprezado.
    if((Numero.substring(0, 1) == "0") && (Numero.length > casas))
        NumeroInt = Numero.substring(1, Numero.length - (casas - 1));
    else
        //Caso possua parte inteira e o primeiro não for zero,
        //o primeiro número é considerado.
        NumeroInt = Numero.substring(0, Numero.length - (casas - 1));

    //Determina a parte decimal.
    NumeroDec = Numero.substring(Numero.length - (casas - 1), Numero.length);

    //Coloca o ponto na parte inteira.
    if(NumeroInt.length > 1){
        var NumeroIntAux = "";
        var vetorNum = new Array(NumeroInt.length - 1);
        for(i = 0; i < NumeroInt.length; i++){
            vetorNum[i] = NumeroInt.substring(i, i + 1);
        }
        var j = 0;
        for(i = NumeroInt.length - 1; i > -1; i--){
            if(j == 3){
                j = 1;
                NumeroIntAux = vetorNum[i] + "." + NumeroIntAux; 
            }
            else{
                NumeroIntAux = vetorNum[i] + NumeroIntAux 
                j++;
            }
        }
        NumeroInt = NumeroIntAux;
    }

    //Concatena a parte inteira com a parte decimal.
    Numero = NumeroInt + "," + NumeroDec;

    //Atribui o número ao objeto.
    Obj.value = Numero;
}
//---------------------------------------------------------------------------------------------------------

function Trim(str){return str.replace(/^\s+|\s+$/g,"");}

//---------------------------------------------------------------------------------------------------------

function emitirAlerta(msg,obj) {
	if (msg != '') alert(msg);
	if (obj) obj.focus();
}
//---------------------------------------------------------------------------------------------------------

function validaCPF(cpf){
	s = cpf.substring(0,3) + cpf.substring(4,7) + cpf.substring(8,11) + cpf.substring(12,14);
	var c = s.substr(0,9);
	var dv = s.substr(9,2);
	var d1 = 0;
	for (var i = 0; i < 9; i++){
		d1 += c.charAt(i)*(10-i);
	}
	if (d1 == 0){
		return false;
	}
	d1 = 11 - (d1 % 11);
	if (d1 > 9) d1 = 0;
	if (dv.charAt(0) != d1){
		return false;
	}
	d1 *= 2;
	for (i = 0; i < 9; i++) {
		d1 += c.charAt(i)*(11-i);
	}
	d1 = 11 - (d1 % 11);
	if (d1 > 9) d1 = 0;
	if (dv.charAt(1) != d1){
		return false;
	}

	if (cpf == '111.111.111-11') return false;
	return true;
}

//--------------------------------------------------------------------------------------------------------
function RMouseOver(oRow)
{	

    oRow.style.cursor = 'pointer';
    oRow.style.backgroundColor = '#eee';
}

//--------------------------------------------------------------------------------------------------------
function RMouseOut(oRow)
{

    oRow.style.cursor = 'pointer';
	oRow.style.backgroundColor = '#fefefe';
}