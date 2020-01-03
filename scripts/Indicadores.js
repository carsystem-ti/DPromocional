$(document).ready(function () {
    $('#btnCadastrarInd').click(function () {
        // captura email
        var email = $("#txtNovoEmail").val();
        // expressão regular
        var emailValido = /^.+@.+\..{2,}$/;

        if (!emailValido.test(email)) {
            alert('Email inválido!');
        }
    });
});
$(document).ready(function () {
    $('#btnCadastrarInd').click(function () {
        // captura email
        var email = $("#txtNovoEmail").val();
        // expressão regular
        if (!emailValido.test(email)) {
            alert('Email inválido!');
        }
    });
});