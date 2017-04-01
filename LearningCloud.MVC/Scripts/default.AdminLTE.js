/// <reference path="Plugins/ckeditor.js" />
/// <reference path="Plugins/ckeditor.js" />
//default.AdminLTE.js

$(document).ready(function () {
    var vjsPathname = window.location.pathname;
    var vjsSubPathname = vjsPathname.substring(0, vjsPathname.lastIndexOf('/'));
    //alert(vjsPathname);
    //alert(vjsSubPathname);
    //if (subPathname == "Admin/Aula/Edit") {
    //    alert("Aula Edit " + "Tipo: " + $("input[type=radio][name=aul_tipoconteudo]").val())
    //    fnHabilitaAbaTipoAula($("input[type=radio][name=aul_tipoconteudo]").val());

    //}

    if (vjsSubPathname == "/Admin/Aula/Edit" || vjsPathname == "/Admin/Aula/Create") {
        CKEDITOR.replace('aul_indroducao');
    }

   
    $('#aulaTabs').on("shown.bs.tab", function(e){
       // alert(e.target.hash);
        switch (e.target.hash) {
            case "#Descricao":
                // alert($("#aul_descricao").css("display"));
                if (!$(e.target.hash).hasClass("content-visited")) {
                    console.log("Intanciar editor para Descrição");
                    CKEDITOR.replace('aul_descricao');
                    $(e.target.hash).addClass("content-visited");
                }

                break;
            case "#Prerequisitos":
                if (!$(e.target.hash).hasClass("content-visited")) {
                    console.log("Intanciar editor para Prerequisitos");
                    CKEDITOR.replace('aul_prerequisitos');
                    $(e.target.hash).addClass("content-visited");
                }
                break;

            case "#Videoaula":
                console.log("Intanciar editor para Videoaula");
       
                break;
            case "#Artigo":
                if (!$(e.target.hash).hasClass("content-visited")) {
                    console.log("Intanciar editor para Artigo");
                    CKEDITOR.replace('aul_conteudoartigo');
                    $(e.target.hash).addClass("content-visited");
                }
                break;
        }
    });

    $('#aulaTabs li').click(function (e) {
        e.preventDefault();
        //if ($(this).hasClass("disabled")) {

        //var vjsAbaSelecionada = $(this).attr("id");
        
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

                case '#Introducao':
                    if ($("#aul_indroducao").val() == "" || $("#aul_indroducao").val() == null) {
                        $("#aul_indroducao").closest('div').find('.field-validation-valid').text("Preencha o campo Introdução.");
                        vjsShowTab.tab('show');
                        e.preventDefault();
                        return (false);
                    }
                    break;
                case '#Descricao':
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

        return (true);
    });




    // var CKEDITOR_BASEPATH = '/ckeditor/';
    //CKEDITOR.config = {
    //    customConfig: "ckeditor.config.js",
    //};
    //CKEDITOR.replace('aul_indroducao');
    //CKEDITOR.replace('aul_descricao');
    //CKEDITOR.replace('aul_prerequisitos');
    //CKEDITOR.replace('aul_conteudoartigo');
    //initSample();


    /**************************************************************************/

   
    /************************************************************************/
   

    // enable fileuploader plugin
    $('input[name="filevideo"]').fileuploader({
        limit: 1, // limit of the files {Number}
        maxSize: 500, // files maximal size in Mb {Number}
        fileMaxSize: 500, // file maximal size in Mb {Number}
        extensions: ['video/mp4', 'video/webm'], // allowed extensions or types {Array}
        changeInput: '<div class="fileuploader-input">' +
					      '<div class="fileuploader-input-inner">' +
						      '<img src="/Content/Images/img_botoes/fileuploader-dragdrop-icon.png">' +
							  '<h3 class="fileuploader-input-caption"><span>Arraste e solte o vídeo aqui</span></h3>' +
							  '<p>ou</p>' +
							  '<div class="fileuploader-input-button"><span>Selecione Vídeo</span></div>' +
						  '</div>' +
					  '</div>',
        theme: 'dragdrop',
        upload: {
            url: 'AdicionarVideo',
            data: null,
            type: 'POST',
            enctype: 'multipart/form-data',
            start: true,
            synchron: true,
            beforeSend: null,
            onSuccess: function (result, item, listEl, parentEl, newInputEl, inputEl, textStatus, jqXHR) {
                console.log("onSuccess result: " + result);
                console.log("onSuccess item: " + item);
                console.log("onSuccess listEl: " + listEl);
                console.log("onSuccess parentEl: " + parentEl);
                console.log("onSuccess newInputEl: " + newInputEl);
                console.log("onSuccess inputEl: " + inputEl);
                console.log("onSuccess textStatus: " + textStatus);
                console.log("onSuccess jqXHR: " + jqXHR);

                console.log("onSuccess jqXHR.status: " + jqXHR.status);

                console.log("onSuccess jqXHR.statusText: " + jqXHR.statusText);

                console.log("onSuccess jqXHR.responseText: " + jqXHR.responseText);

                var data = JSON.parse(result);

                if (data.isSuccess && data.files[0]) {
                    item.name = data.files[0].name;
                }

                item.html.find('.column-actions').append('<a class="fileuploader-action fileuploader-action-remove fileuploader-action-success" title="Remove"><i></i></a>');
                setTimeout(function () {
                    item.html.find('.progress-bar2').fadeOut(400);
                }, 400);
            },
            onError: function (item, jqXHR, textStatus, errorThrown) {
                var progressBar = item.html.find('.progress-bar2');

                if (progressBar.length > 0) {
                    progressBar.find('span').html(0 + "%");
                    progressBar.find('.fileuploader-progressbar .bar').width(0 + "%");
                    item.html.find('.progress-bar2').fadeOut(400);
                }

                item.upload.status != 'cancelled' && item.html.find('.fileuploader-action-retry').length == 0 ? item.html.find('.column-actions').prepend(
                    '<a class="fileuploader-action fileuploader-action-retry" title="Retry"><i></i></a>'
                ) : null;

                console.log("onError item: " + item);

                console.log("onError textStatus: " + textStatus);

                console.log("onError errorThrown: " + errorThrown);

                console.log("onError jqXHR status: " + jqXHR.status);
                console.log("onError jqXHR statusText: " + jqXHR.statusText);
            },
            onProgress: function (data, item) {
                var progressBar = item.html.find('.progress-bar2');

                if (progressBar.length > 0) {
                    progressBar.show();
                    progressBar.find('span').html(data.percentage + "%");
                    progressBar.find('.fileuploader-progressbar .bar').width(data.percentage + "%");
                }

                console.log("onProgress: " + data.percentage);
            },
            onComplete: null,
        },
        onRemove: function (item) {
            $.post('RemoverVideo', {
                file: item.name
            });
        },
        dialogs: {
	
            // alert dialog
            alert: function(text) {
                return alert(text);
            },
		
            // confirm dialog
            confirm: function(text, callback) {
                confirm(text) ? callback() : null;
            }
        },
        captions: {
            feedback: 'Arraste e solte o vídeo aqui',
            feedback2: 'Arraste e solte o vídeo aqui',
            drop: 'Arraste e solte o vídeo aqui',
            removeConfirmation: 'Are you sure you want to remove this file?',
            errors: {
                filesLimit: 'Only ${limit} files are allowed to be uploaded.',
                filesType: 'Only ${extensions} files are allowed to be uploaded.',
                fileSize: '${name} is too large! Please choose a file up to ${fileMaxSize}MB.',
                filesSizeAll: 'Files that you choosed are too large! Please upload files up to ${maxSize} MB.',
                fileName: 'File with the name ${name} is already selected.',
                folderUpload: 'You are not allowed to upload folders.'
            }
        },
    });


            //console.log("Arquivo: " + file.type)
            //$.ajax({
            //    url: "AdicionarVideo",
            //    type: 'POST',
            //    contentType: "multipart/form-data",
            //    processData: false,
            //    cache: false,
            //    global: true,
            //    data: { "file": file },
            //    beforeSend: function () {
                    
            //    },
            //    success: function (result) {
            //        $("#messages").html(result);
            //    },
            //    error: function (xhr, errorMessage, thrownError) {
            //        $('#messages').empty().append("<div class='alert alert-danger' role='alert'><ul id='erro_post'><li>Ocorreu um erro ao carregar as informações.</li><li>Erro: " + xhr.status + "</li><li>Descrição: " + xhr.statusText + "</li><li>Caso o problema persista, contate o administrador do sistema.</li></ul></div>");
            //    }
            //});

 
      
 
    
    /************************************************************************/

});