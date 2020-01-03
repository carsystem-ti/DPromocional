$("document").ready(function () {    
    $("#ddlOpcoesBusca").change(function () {
        if ($("#ddlOpcoesBusca").val() == "Carteira" || $("#ddlOpcoesBusca").val() == "Dias") {
            $("#lbValor").hide();
            $("#txtValor").hide();
        }
        else {
            $("#lbValor").show();
            $("#txtValor").show();
        }
    });
});