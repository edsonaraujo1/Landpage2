$(function () {
    $('.date_time').mask('00/00/0000 00:00:00');
    $('#b_cep').mask('00000-000', { placeholder: "_____-___" });
    $('.phone').mask('0000-0000');
    $('.phone_with_ddd').mask('(00) 0000-0000');
    $('.phone_us').mask('(000) 000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.ip_address').mask('099.099.099.099');
    $('.percent').mask('##0,00%', { reverse: true });
    $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
    $('#dt_dataniv').mask("00/00/0000", { placeholder: "__/__/____" });
    $('#telefone').mask("(99) 9999-9999", { placeholder: "(__) _____-____" });
    $('#d_fone_com').mask("(99) 9999-9999", { placeholder: "(__) _____-____" });
    $('#d_celular').mask("(99) 99999-9999", { placeholder: "(__) _____-____" });
    $('#d_whatsapp').mask("(99) 99999-9999", { placeholder: "(__) _____-____" });
    $('.fallback').mask("00r00r0000", {
        translation: {
            'r': {
                pattern: /[\/]/,
                fallback: '/'
            },
            placeholder: "__/__/____"
        }
    });

    $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });

    $('.cep_with_callback').mask('00000-000', {
        onComplete: function (cep) {
            console.log('Mask is done!:', cep);
        },
        onKeyPress: function (cep, event, currentField, options) {
            console.log('An key was pressed!:', cep, ' event: ', event, 'currentField: ', currentField.attr('class'), ' options: ', options);
        },
        onInvalid: function (val, e, field, invalid, options) {
            var error = invalid[0];
            console.log("Digit: ", error.v, " is invalid for the position: ", error.p, ". We expect something like: ", error.e);
        }
    });

    $('.crazy_cep').mask('00000-000', {
        onKeyPress: function (cep, e, field, options) {
            var masks = ['00000-000', '0-00-00-00'];
            mask = (cep.length > 7) ? masks[1] : masks[0];
            $('.crazy_cep').mask(mask, options);
        }
    });

    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('#dingast').mask('#.##0,00', { reverse: true });

    var SPMaskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
    spOptions = {
        onKeyPress: function (val, e, field, options) {
            field.mask(SPMaskBehavior.apply({}, arguments), options);
        }
    };

    $('.sp_celphones').mask(SPMaskBehavior, spOptions);

    $(".bt-mask-it").click(function () {
        $(".mask-on-div").mask("000.000.000-00");
        $(".mask-on-div").fadeOut(500).fadeIn(500)
    })

    $('pre').each(function (i, e) { hljs.highlightBlock(e) });
});



$(function () {
	$("#wizard").steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "fade",
        enableAllSteps: true,
        onStepChanging: function (event, currentIndex, newIndex) { 
            if ( newIndex === 1 ) {
                $('.wizard > .steps ul').addClass('step-2');
            } else {
                $('.wizard > .steps ul').removeClass('step-2');
            }
            if ( newIndex === 2 ) {
                $('.wizard > .steps ul').addClass('step-3');
            } else {
                $('.wizard > .steps ul').removeClass('step-3');
            }
            return true; 
        },
        labels: {
            finish: "Submit",
            next: "Continue",
            previous: "Back"
        }
    });
    // Custom Button Jquery Steps
    $('.forward').click(function(){
    	$("#wizard").steps('next');
    })
    $('.backward').click(function(){
        $("#wizard").steps('previous');
    })
    // Date Picker
    var dp1 = $('#dp1').datepicker().data('datepicker');
    dp1.selectDate(new Date());
})


$(function () {

    $("#pais").change(function () {  // change
        var pret_1 = $('#URLi0').val();
        $.ajax({
            type: 'GET',
            url: pret_1 + '/Home/Pais',
            data: {
                var_data1: $('#pais').val()
            },

            dataType: 'json',

            success: function (datas1) {
                $('#estado').html('');
                $('#estado').closest('div-row').remove();
                $('#estado').prop('selectedIndex');
                if (datas1.length > 0) {
                    $('#estado').append('<option value=""></option>');
                    $.each(datas1, function (i, value) {
                        $('#estado').append($('<option>').text(value.estado).attr('value', value.estado));
                    });
                } else {
                    var novaOpcao = $('<option value=""></option>');
                    $('#estado').append(newOption);
                }
            },

            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus, errorThrown);
            }
        });

    });
});

$(function () {

    $("#estado").change(function () {  // change
        var pret_1 = $('#URLi0').val();
        $.ajax({
            type: 'GET',
            url: pret_1 + '/Home/Estado',
            data: {
                var_data1: $('#estado').val()
            },
            
            dataType: 'json',

            success: function (datas1) {
                $('#cidade').html('');
                $('#cidade').closest('div-row').remove();
                $('#cidade').prop('selectedIndex');
                if (datas1.length > 0) {
                    $('#cidade').append('<option value=""></option>');
                    $.each(datas1, function (i, value) {
                        $('#cidade').append($('<option>').text(value.nome).attr('value', value.nome));
                    });
                } else {
                    var novaOpcao = $('<option value=""></option>');
                    $('#cidade').append(newOption);
                }
            },

            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus, errorThrown);
            }
        });

    });
});

$(function () {

    $("#cidade").change(function () {  // change
        var pret_1 = $('#URLi0').val();
        $.ajax({
            type: 'GET',
            url: pret_1 + '/Home/Bairro',
            data: {
                var_data1: $('#cidade').val()
            },

            dataType: 'json',

            success: function (datas1) {
                $('#bairro').html('');
                $('#bairro').closest('div-row').remove();
                $('#bairro').prop('selectedIndex');
                if (datas1.length > 0) {
                    $('#bairro').append('<option value=""></option>');
                    $.each(datas1, function (i, value) {
                        $('#bairro').append($('<option>').text(value.nome).attr('value', value.nome));
                    });
                } else {
                    var novaOpcao = $('<option value=""></option>');
                    $('#bairro').append(newOption);
                }
            },

            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus, errorThrown);
            }
        });

    });
});