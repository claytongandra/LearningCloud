/// <reference path="Plugins/ckeditor.js" />
/// <reference path="Plugins/ckeditor.js" />
//default.AdminLTE.js

$(document).ready(function () {
    //var pathname = window.location.pathname;
    //var subPathname = pathname.substring(1, pathname.lastIndexOf('/'));
    //alert(subPathname);
    //if (subPathname == "Admin/Aula/Edit") {
    //    alert("Aula Edit " + "Tipo: " + $("input[type=radio][name=aul_tipoconteudo]").val())
    //    fnHabilitaAbaTipoAula($("input[type=radio][name=aul_tipoconteudo]").val());
        
    //}

    $('#aulaTabs li').click(function (e) {
        e.preventDefault();
        //if ($(this).hasClass("disabled")) {

        //}
    });


    function fnHabilitaAbaTipoAula(prmJsTipoConteudo) {
        var objJsAbaVideoaula = $("#aulaTabs").find("#tabVideoaula");
        var objJsAbaArtigo = $("#aulaTabs").find("#tabArtigo");

        switch (prmJsTipoConteudo) {
            case 'V':
                if (objJsAbaArtigo.hasClass("active")) {
                    objJsAbaVideoaula.find('a').tab('show');
                }

                objJsAbaVideoaula.removeClass("disabled");
                objJsAbaVideoaula.find('a').addClass("required").attr("data-toggle", "tab");
                objJsAbaArtigo.addClass("disabled");
                objJsAbaArtigo.find('a').removeClass("required").attr("data-toggle", "");

                break;
            case 'A':
                if (objJsAbaVideoaula.hasClass("active")) {
                    objJsAbaArtigo.find('a').tab('show');
                }

                objJsAbaArtigo.removeClass("disabled");
                objJsAbaArtigo.find('a').addClass("required").attr("data-toggle", "tab");
                objJsAbaVideoaula.addClass("disabled");
                objJsAbaVideoaula.find('a').removeClass("required").attr("data-toggle", "");
                break;
        }
    }

    $("input[type=radio][name=aul_tipoconteudo]").change(function () {
        fnHabilitaAbaTipoAula($(this).val());
    });



    $('.content-wrapper').on("submit", '#aulaform', function (e) {
       
  
        $("#aulaTabs li:not(.active) a.required").each(function (index) {
            var vjsShowTab = $(this);

          //  alert($(this).attr("href"));
            //alert('#each'+ index);
            switch ($(this).attr("href")) {
                
                case '#Introdução':
                    if ($("#aul_indroducao").val() == "" || $("#aul_indroducao").val() == null) {
                        $("#aul_indroducao").closest('div').find('.field-validation-valid').text("Preencha o campo Introdução.");
                        vjsShowTab.tab('show');
                        e.preventDefault();
                        return(false);
                    }
                    break;
                case '#Descrição':
                    if ($("#aul_descricao").val() == "" || $("#aul_descricao").val() == null) {
                        $("#aul_descricao").closest('div').find('.field-validation-valid').text("Preencha o campo Descrição.");
                        vjsShowTab.tab('show');
                        e.preventDefault();
                        return (false);
                    }
                    break;
                case '#Videoaula':
                    vjsShowTab.tab('show');
                    break;
                case '#Artigo':
                    if ($("#aul_conteudoartigo").val() == "" || $("#aul_conteudoartigo").val() == null) {
                        $("#aul_conteudoartigo").closest('div').find('.field-validation-valid').text("Preenha o campo Conteúdo do Artigo.");
                        vjsShowTab.tab('show');
                        e.preventDefault();
                        return (false);
                    }
                    break;
            }
            
        });
        //alert('#aulaform.submit()');
       // $('#aulaform')[0].submit();

        return(true);
    });


  

   // var CKEDITOR_BASEPATH = '/ckeditor/';
    //CKEDITOR.config = {
    //    customConfig: "ckeditor.config.js",
    //};
    CKEDITOR.replace('aul_indroducao');
    CKEDITOR.replace('aul_descricao');
    CKEDITOR.replace('aul_prerequisitos');
    CKEDITOR.replace('aul_conteudoartigo');
    //initSample();
    /************************************************************************/

    $(function () {

        var dropbox = $('#dropbox'),
            message = $('.message', dropbox);

        dropbox.filedrop({
            // The name of the $_FILES entry:
            paramname: 'pic',

            maxfiles: 1,
            maxfilesize: 200,// in mb
            url: 'post_file.php',

            uploadFinished: function (i, file, response) {
                $.data(file).addClass('done');
                // response is the JSON object that post_file.php returns
            },

            error: function (err, file) {
                switch (err) {
                    case 'BrowserNotSupported':
                        showMessage('Your browser does not support HTML5 file uploads!');
                        break;
                    case 'TooManyFiles':
                        alert('Too many files! Please select 5 at most! (configurable)');
                        break;
                    case 'FileTooLarge':
                        alert(file.name + ' is too large! Please upload files up to 2mb (configurable).');
                        break;
                    default:
                        break;
                }
            },

            // Called before each upload is started
            beforeEach: function (file) {
                if (!file.type.match(/^video\//)) {
                    alert('Only video are allowed!');

                    // Returning false will cause the
                    // file to be rejected
                    return false;
                }
            },

            uploadStarted: function (i, file, len) {
                createImage(file);
            },

            progressUpdated: function (i, file, progress) {
                $.data(file).find('.progress').width(progress);
            }

        });

        var template = '<div class="preview">' +
                            '<span class="imageHolder">' +
                                '<img />' +
                                '<span class="uploaded"></span>' +
                            '</span>' +
                            '<div class="progressHolder">' +
                                '<div class="progress"></div>' +
                            '</div>' +
                        '</div>';


        function createImage(file) {

            var preview = $(template),
                image = $('img', preview);

            var reader = new FileReader();

            image.width = 100;
            image.height = 100;

            reader.onload = function (e) {

                // e.target.result holds the DataURL which
                // can be used as a source of the image:

                image.attr('src', e.target.result);
            };

            // Reading the file as a DataURL. When finished,
            // this will trigger the onload function above:
            reader.readAsDataURL(file);

            message.hide();
            preview.appendTo(dropbox);

            // Associating a preview container
            // with the file, using jQuery's $.data():

            $.data(file, preview);
        }

        function showMessage(msg) {
            message.html(msg);
        }

    });
    /************************************************************************/

});