
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

    m.jsn.get(sch).init(10, arr);




    $('#txtSenha').val("");
    arr = new Array();

}

function aleatorio() {
    aleat = Math.random() * 10;
    aleat = Math.floor(aleat);
    return aleat;
}

function OcultarLogin() {
    $('#LembrarSenha').slideUp();
    $('#login').slideUp();
    $('#mask').fadeOut();

}
function JanelaModal() {

    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

    $('#mask').fadeIn(1000);
    $('#mask').fadeTo("slow", 0.8);



}
function OcultarLembrarSenha() {
    $('#LembrarSenha').fadeOut();

}
function MostrarLembrarSenha() {

    $('#LembrarSenha').fadeIn();

}
