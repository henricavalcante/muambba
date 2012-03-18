

/*

Core principal de scripts

*/



var m = function () {
    var ultimoEvento = new Date();
    return {
        //-------------------------------------------------------------------------------------------------------------
        jsn: function () {
            var token = "";
            return {

                get: function (sch) {

                    token = sch;

                    return m.jsn;


                },
                init: function (tp, obj) {

                    if (tp == 1) {
                        
                        $.ajax({
                            type: "POST",
                            mode: "abort",
                            port: "categorias",
                            url: "/j/json01",
                            data: {
                                sch: token,
                                c: obj
                            },
                            success: function (data) {

                                if (data != null && data !== '') {
                                    if (data.o.lst.length > 0) {


                                        var str = '<li><div style="display:none;" class="scroll-pane dvCategoria"><ul class="ulCategoria">';

                                        for (var i in data.o.lst) {
                                            if (data.o.lst.hasOwnProperty(i)) {

                                                str = str + '<li id="li-cat-' + data.o.lst[i].ID + '" onclick="m.jsn.get(\'' + token + '\').init(1,' + data.o.lst[i].ID + '); $(\'#hdfCategoriaID\').val(' + data.o.lst[i].ID + ');m.c.setaClasseParent(this, \'scroll\', \'carregando\');">' + data.o.lst[i].Categoria1 + '</li>';

                                            }
                                        }

                                        str = str + '</ul></div></li>';

                                        $('#dvCategorias>ul').append(str);

                                        $('.dvCategoria').fadeIn(function () {

                                            var largura = $('#dvCategorias>ul>li').length * ($('#dvCategorias>ul>li').width() + 15);
                                            $('#dvCategorias').css('width', largura + 'px');
                                            $('.scroll .scrollme').jScrollPaneH();

                                        });
                                        $('.dvCategoria').jScrollPane();
                                    }
                                    for (var i in data.o.usa) {
                                        if (data.o.usa.hasOwnProperty(i)) {

                                            $('.' + data.o.usa[i]).fadeIn(400);

                                        }
                                    }


                                }
                                m.c.setaClasseParent($('.dvCategoria'), 'scroll', '');

                            },
                            dataType: "json",
                            traditional: true
                        });

                        $('.campo-categoria').fadeOut(400);

                        objAux = $('#li-cat-' + obj);

                        var l = objAux.parent();
                        var index = l.parent().parent().parent().index();

                        $('#dvCategorias>ul>li:gt(' + index + ')').fadeOut(400, function () {

                            $(this).remove();

                            var largura = $('#dvCategorias>ul>li').length * ($('#dvCategorias>ul>li').width() + 15);
                            $('#dvCategorias').css('width', largura + 'px');




                        });

                        $('#dvCategorias>ul>li:eq(' + index + ')>div>div>ul>li').each(function (i, element) {
                            $(element).removeClass('selecionado');
                        });

                        objAux.addClass('selecionado');



                    } else if (tp == 2) {





                    } else if (tp == 3) {

                        m.c.setaClasseTextBox($(obj).parent().parent(), "carregando");

                        $.ajax({
                            type: "POST",
                            url: "/j/json03",
                            data: {
                                sch: token,
                                n: $(obj).val()
                            },
                            success: function (data) {
                                if (data.valor) {
                                    m.c.setaClasseTextBox($(obj).parent().parent(), "rejeitado");
                                } else {
                                    m.c.setaClasseTextBox($(obj).parent().parent(), "aceito");
                                }
                            },
                            dataType: "json",
                            traditional: true
                        });


                    } else if (tp == 4) {

                        m.c.setaClasseTextBox($(obj).parent().parent(), "carregando");
                        var em = $(obj).val();
                        if (m.val.email(em)) {
                            $.ajax({
                                type: "POST",
                                url: "/j/json04",
                                data: {
                                    sch: token,
                                    e: em
                                },
                                success: function (data) {
                                    if (data.valor) {
                                        m.c.setaClasseTextBox($(obj).parent().parent(), "rejeitado");
                                    } else {
                                        m.c.setaClasseTextBox($(obj).parent().parent(), "aceito");
                                    }
                                },
                                dataType: "json",
                                traditional: true
                            });
                        } else {
                            m.c.setaClasseTextBox($(obj).parent().parent(), "rejeitado");
                        }


                        //SUBMETE O PRE CADASTRO DE UM USUARIO
                    } else if (tp == 5) {

                        $.ajax({
                            type: "POST",
                            url: "/j/json05",
                            data: {
                                sch: token,
                                n: obj.nome.val(),
                                e: obj.email.val()
                            },
                            success: function (data) {
                                alert(data.m);
                                if (data.s) {

                                    obj.nome.val('');
                                    obj.email.val('');
                                    $('#mask').click();

                                }
                                m.c.setaClasseParent(obj.nome, 'jsn', '');

                            },
                            dataType: "json",
                            traditional: true
                        });


                    } else if (tp == 6) {




                    } else if (tp == 7) { //Validação do Endereço


                        $(obj).ac('/j/json07', token);




                        //Responder Perguntas
                    } else if (tp == 8) {
                        $.ajax({
                            type: "POST",
                            url: "/j/json08",
                            data: {
                                sch: token,
                                pid: obj.pid,
                                re: obj.re
                            },
                            success: function (data) {
                                $('#dvResposta_' + obj.pid + ' .resposta-resposta').append(m.util.nl2br(obj.re));
                                $('#dvResposta_' + obj.pid + ' .resposta-acoes .resposta-data').attr('data', new Date()).append('Neste exato momento');

                                $('#dvResponder_' + obj.pid).fadeOut(200, function () {
                                    $('#dvResposta_' + obj.pid).fadeIn(200);

                                });
                            },
                            dataType: "json",
                            traditional: true
                        });
                    } else if (tp == 9) {
                        $.ajax({
                            type: "POST",
                            url: "/j/json09",
                            data: {
                                sch: token,
                                aid: $(obj).attr('an')
                            },
                            success: function (data) {

                                var lst = '';
                                for (var i in data.o) {
                                    if (data.o.hasOwnProperty(i)) {
                                        lst = lst + '<li><img src="/Imagens/Anuncios/' + data.o[i] + '" alt="" width="90" height="90"></li>';
                                    }
                                }
                                var car = $(obj).parent().find('.jcarousel-skin-anuncio-lista');
                                car.text('').append(lst).show();
                                car.jcarousel();
                                $(obj).remove();
                            },
                            dataType: "json",
                            traditional: true
                        });
                    } else if (tp == 10) {

                        var txtUsuario = $('#txtUsuario').val();

                        $.ajax({
                            type: "POST",
                            url: "/j/json10",
                            data: {
                                sch: token,
                                u: txtUsuario,
                                s: "" + obj
                            },
                            success: function (data) {

                                if (data != null && data !== '') {

                                    if (data.s == false) {
                                        alert(data.m);
                                    }
                                    else {
                                        if (data.o) {
                                            window.location.reload();
                                        }
                                        else {
                                            window.location.href = '/MeuMuambba/MeusDados';
                                        }

                                        //window.location.href = document.location.href;
                                    }

                                }
                            },
                            dataType: "json",
                            traditional: true
                        });
                    } else if (tp == 11) {

                        $.ajax({
                            type: "POST",
                            url: "/j/json11",
                            data: {
                                sch: token,
                                a: obj.a,
                                p: obj.p.val(),
                                v: obj.v.val()
                            },
                            success: function (data) {

                                if (data != null && data !== '') {

                                    if (data.s == false) {
                                        alert(data.m);
                                    }
                                    else {
                                        window.location.href = document.location.href;
                                    }

                                }
                            },
                            dataType: "json",
                            traditional: true
                        });
                    } else if (tp == 12) {


                    } else if (tp == 13) {

                        $.ajax({
                            type: "POST",
                            url: "/j/json13",
                            data: {
                                sch: token,
                                a: obj.a
                            },
                            success: function (data) {

                                if (data != null && data !== '') {
                                    alert(data.m);
                                    if (data.s == true) {
                                        $(obj.t).parent().parent().fadeOut(400, function () { $(this).remove(); });
                                    }

                                }
                            },
                            dataType: "json",
                            traditional: true
                        });

                    } else if (tp == 14) {//Envio de emails pela área de contato

                        $.ajax({
                            type: "POST",
                            url: "/j/json14",
                            data: {
                                sch: token,
                                n: obj.n,
                                e: obj.e,
                                m: obj.m
                            },
                            success: function (data) {

                                if (data != null && data !== '') {
                                    alert(data.m);
                                    if (data.s == true) {
                                        window.location.href = '/';
                                    }
                                }
                            },
                            dataType: "json",
                            traditional: true
                        });
                    } else if (tp == 15) {//denundia de um certo objeto

                        $.ajax({
                            type: "POST",
                            url: "/j/json15",
                            data: {
                                sch: token,
                                dn: obj.dn.val(),
                                dnt: obj.dnt,
                                dno: obj.dno,
                                dnc: obj.dnc
                            },
                            success: function (data) {

                                if (data != null && data !== '') {

                                    if (data.s == true) {
                                        $('.denunciar').fadeOut(400, function () { $('.denunciado').fadeIn(400); });

                                    } else {
                                        alert(data.m);
                                    }
                                }
                            },
                            dataType: "json",
                            traditional: true
                        });
                    } else if (tp == 16) {//denundia de um certo objeto

                        $.ajax({
                            type: "POST",
                            url: "/j/json16",
                            data: {
                                sch: token,
                                e: obj
                            },
                            success: function (data) {

                                if (data != null && data !== '') {
                                    alert(data.m);
                                    if (data.s == true) {
                                        $(obj.t).parent().parent().fadeOut(400, function () { $(this).remove(); });
                                    }

                                }
                            },
                            dataType: "json",
                            traditional: true
                        });
                    }

                }
            };
        } (),
        //-------------------------------------------------------------------------------------------------------------
        val: function () {
            return {
                campoUnico: function (obj, idjson, token) {

                    var t = $(obj).val();
                    if (t.length > 3) {


                        var fn = function () { m.jsn.get(token).init(idjson, obj); };

                        m.util.funDelayPadrao(fn);
                    }


                },
                email: function (mail) {
                    var er = new RegExp(/^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-\.]{2,}\.[A-Za-z0-9]{2,}(\.[A-Za-z0-9])?/);

                    if (typeof (mail) == "string") {
                        if (er.test(mail)) {
                            return true;
                        }
                    } else if (typeof (mail) == "object") {
                        if (er.test(mail.value)) {
                            return true;
                        }
                    } else {
                        return false;
                    }
                }
            }
        } (),

        //-------------------------------------------------------------------------------------------------------------
        util: function () {
            return {
                sleep: function (ms) {

                    var start = new Date().getTime();
                    for (var i = 0; i < 1e7; i++) {
                        if ((new Date().getTime() - start) > ms) {
                            break;
                        }
                    }
                },
                substituir: function (str, de, para) {
                    var pos = str.indexOf(de);
                    while (pos > -1) {
                        str = str.replace(de, para);
                        pos = str.indexOf(de);
                    }
                    return (str);
                },
                validaCampo: function (obj, idjson, token) {


                    $(obj).keyup(function () {
                        var t = $(obj).val();
                        if (t.length > 3) {


                            var teste = function () { m.jsn.get(token).init(idjson, obj); };

                            m.util.funDelayPadrao(teste);
                        }
                    });

                },
                ajustaTextArea: function (t) {
                    a = t.value.split('\n');
                    b = 1;
                    for (x = 0; x < a.length; x++) {
                        if (a[x].length >= t.cols)
                            b += Math.floor(a[x].length / t.cols);
                    }
                    b += a.length;
                    t.rows = (b > 5) ? b - 1 : 4;
                },
                nl2br: function (str) {
                    var regX = /\n/gi;

                    s = new String(str);
                    s = s.replace(regX, "<br /> \n");
                    return s;
                },
                funDelayPadrao: function (fun) {
                    m.util.funDelay(fun, 800);
                },
                funDelay: function (fun, delay) {
                    ultimoEvento = new Date();
                    setTimeout(function () {
                        if (m.util.checaDelay(ultimoEvento, delay)) {
                            fun.call();
                        }
                    }, delay);
                },
                checaDelay: function (data, delay) {
                    var agora = new Date();
                    return (data.getTime() + delay - 10 <= agora.getTime())
                },
                verificarMascara: function (tecla, masc) {

                    if (masc == '?') {
                        return ('0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZ'.toLowerCase().indexOf(tecla.toLowerCase()) > -1);
                    } else if (masc == '#') {
                        return ('0123456789'.indexOf(tecla) > -1);
                    } else if (masc == '$') {
                        return ('ABCDEFGHIJKLMNOPQRSTUVXWYZ'.toLowerCase().indexOf(tecla.toLowerCase()) > -1);
                    } else return false;
                },

                mascaraCampo: function (elemento, mascara, event) {

                    if (navigator.appName.toLowerCase().indexOf("netscape") > -1)
                        ntecla = event.which;
                    else
                        ntecla = event.keyCode;

                    tecla = String.fromCharCode(ntecla);

                    var masc = mascara.charAt(elemento.value.length);

                    var teclas = new Array(0, 8, 9, 13, 16, 17, 18, 20, 27, 28, 29, 30, 31);

                    for (var i = 0; i < teclas.length; i++) {
                        if (teclas[i] == ntecla) {
                            return true;
                        }
                    }

                    if ((masc == '?') || (masc == '#') || (masc == '$')) {
                        return m.util.verificarMascara(tecla, masc);
                    }
                    else {
                        elemento.value += mascara.charAt(elemento.value.length);
                        masc = mascara.charAt(elemento.value.length);
                        if (mascara.charAt(elemento.value.length - 1) == tecla) return false;
                        else return m.util.verificarMascara(tecla, masc);
                    }
                },
                updateDates: function (classname) {
                    var timestring; // holds time value
                    var diff; // holds the difference
                    var now = new Date(); // current time
                    var newstring = ""; // new datetime caption to replace current caption
                    var gmtHours = -now.getTimezoneOffset() / 60;

                    $('abbr.' + classname).each(function () {
                        timestring = new Date($(this).attr("data"));
                        timestring = timestring.getTime();

                        diff = Math.ceil(now.getTime() - timestring);
                        newstring = m.util.diffTimeString(diff);

                        if (newstring != null)
                            $(this).html(newstring);

                    });
                },
                diffTimeString: function (time) {
                    var result = null;
                    time = Math.ceil(time / 1000); // round up to closest second

                    if (time > 2) {
                        if (time < 50) {
                            result = time + ' segundos';
                        }
                        else if (time >= 50 && time < 3000) {
                            time = Math.ceil(time / 60);
                            if (time == 1)
                                result = time + ' minuto';
                            else
                                result = time + ' minutos';
                        }
                        else if (time >= 3000 && time < 82800) {
                            time = Math.ceil(time / 3600);
                            if (time == 1)
                                result = 'cerca de uma hora';
                            else
                                result = time + ' horas';
                        }
                        else if (time >= 82800 && time < 518400) {
                            time = Math.ceil(time / 86400) - 1;
                            if (time == 0)
                                result = ' quase um dia';
                            else if (time == 1)
                                result = '1 dia';
                            else
                                result = time + ' dias';
                        }
                        else if (time >= 518400 && time < 2592000) {
                            time = Math.ceil(time / 604800) - 1;
                            if (time == 0)
                                result = ' quase uma semana';
                            else if (time == 1)
                                result = '1 semana';
                            else
                                result = time + ' semanas';
                        }
                        else if (time >= 2592000 && time < 28512000) {
                            time = Math.ceil(time / 2592000) - 1;
                            if (time == 1)
                                result = '1 mês';
                            else
                                result = time + ' meses';
                        }
                        else if (time >= 28512000) {
                            time = Math.ceil(time / 31536000) - 1;
                            if (time == 0)
                                result = ' quase uma ano';
                            else if (time == 1)
                                result = '1 ano';
                            else
                                result = time + ' anos';
                        }
                        else {
                            result = time;
                        }
                    }

                    return 'há ' + result;
                }

            };
        } (),
        c: function () {
            return {
                setaClasseTextBox: function (obj, classe) {

                    $(obj).removeClass("carregando").removeClass("rejeitado").removeClass("aceito");
                    $(obj).addClass(classe);

                },
                setaClasseParent: function (obj, parent, classe) {

                    $(obj).parents("." + parent).removeClass("carregando").removeClass("rejeitado").removeClass("aceito");
                    $(obj).parents("." + parent).addClass(classe);

                }

            };

        } (),
        reset: function () {

            $('input:text').setMask();

            $('.inputtext, .inputtextarea').focus(function () {
                $(this).parent().parent().addClass("txt-borda-selecionado");
            });

            $('.inputtext, .inputtextarea').blur(function () {
                $(this).parent().parent().removeClass("txt-borda-selecionado");
            });

            $('.switcher').bind('click', function () {
                $(this).find('.option').slideToggle('fast');
            });

            $('.switcher').bind('mouseleave', function () {
                $(this).find('.option').slideUp('fast');
            });


            $(document).ready(function () {
                $(this).everyTime("5s", function () {
                    m.util.updateDates('tempo-passado');
                });
            });
        },
        modal: function (j, p, t) {
            $.ajax({
                type: 'POST',
                url: '/Ajax/Modal/' + j + '?p=' + p,
                cache: false,
                success: function (dados) {
                    var modalId = "modal01";
                    $('#mask').before('<div class="modal jsn t' + t + '" id=' + modalId + '></div>');
                    $('#' + modalId).empty().html(dados);

                    var maskHeight = $(document).height();
                    var maskWidth = $(window).width();

                    $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

                    $('#mask').fadeIn(1000);
                    $('#mask').fadeTo("slow", 0.8);


                    $('#' + modalId).slideDown();
                }
            });
        }
    };
} ();

//Scripts Inicializaveis
(function($){
    $(function(){
    
       m.reset();
    

    });
})(jQuery);