read();

function read() {
    $(document).ready(function () {

        $("select").off();
        $("img").off();
        $("input[type=checkbox]").off();
        $(".txtQuantidade").off();
        $(".txtQuantidadeServico").off();
        $("#txtDesconto").off();
        $("#txtAcrescimo").off();
        $("input[type=text]").off();

        // Deixa entrar apenas números nos input boxs
        $("input[type=text]").numeric(false, function () { alert("Digite somente números !"); this.value = ""; this.focus(); });
        $("#txtDesconto").numeric({ decimal: "," });
        $("#txtAcrescimo").numeric({ decimal: "," });
        $("#entradaFormaPagamento").numeric({ decimal: "," });

        // Insere ultima linha para cadastro
        $(".classListaProduto:last").change(function () {
            $(this).parent().parent().clone().insertAfter($(this).parent().parent());
            read();
        });

        // Altera o valor do monitoramento
        $(".classListaProduto").change(function () {
            var linha = $(this).parent().parent();
            var valores = $(this).val().split(";");

            $(".classLinhaServico:contains('" + $(this).data("oldValue") + "'):first").remove();

            linha.children("td:nth-child(2)").text($.formatNumber(valores[0].replace(",", "."), { format: "###,###,##0.00", locale: "br" }));
            linha.children("td:nth-child(3)").html($.formatNumber(valores[1].replace(",", "."), { format: "###,###,##0.00", locale: "br" }) + '<input id="Checkbox1" type="checkbox" class="classChecked" />');

            calcValTot(linha, linha.children("td:nth-child(4)").children("input[type=text]").val());

            changeInputBox();

            calcSubTotalProduto(".tdTotal", ".tdTotGeral");
            calcSubTotalProduto(".tdTotalServico", ".tdTotGeralServicos");

        }).focus(function () {
            $(this).data("oldValue", $(this).children("select option:selected").text());
        });

        // Altera o valor do serviço
        $(".classListaServico:last").change(function () {
            $(this).parent().parent().clone().insertAfter($(this).parent().parent());
            read();
        });

        $(".classListaServico").change(function () {
            var linha = $(this).parent().parent();
            var valores = $(this).val();

            linha.children("td:nth-child(2)").text($.formatNumber(valores.replace(",", "."), { format: "###,###,##0.00", locale: "br" }));

            calcTotServico(linha, linha.children("td:nth-child(4)").children("input[type=text]").val());
        });

        // Calcula o valor da quantidade
        $(".txtQuantidade").focusout(function () {
            calcValTot($(this).parent().parent(), $(this).val());
        });

        // Calcula o valor da quantidade
        $(".txtQuantidadeServico").focusout(function () {
            calcTotServico($(this).parent().parent(), $(this).val());
        });

        // Botão para remover linha
        $(".botaoExcluir").show();

        $(".botaoExcluir").click(function () {
            $(".classLinhaServico:contains('" + $(this).parent().parent().children("td:nth-child(1)").children("select").children("select option:selected").text() + "'):first").remove();
            $(this).parent().parent().remove();
            calcSubTotalProduto(".tdTotal", ".tdTotGeral");
            calcSubTotalProduto(".tdTotalServico", ".tdTotGeralServicos");
        });

        $(".botaoExcluir:last").hide();

        // Botão para remover linha de serviço
        $(".botaoExcluirServico").show();

        $(".botaoExcluirServico").click(function () {
            $(this).parent().parent().remove();
            calcSubTotalProduto(".tdTotalServico", ".tdTotGeralServicos");
        });

        $(".botaoExcluirServico:last").hide();

        // Check box para inserir serviços
        changeInputBox();

        // Calcula o total de desconto
        $("#txtDesconto").focusout(function () {
            calcValDesconto("#txtDesconto", ".tdPercDesc");
        });

        // Calcula o total de acréscimo
        $("#txtAcrescimo").focusout(function () {
            calcValDesconto("#txtAcrescimo", ".tdPercAcres");
        });

        // Calcula forma de pagamento boleto
        $("#ddlParcBoletos").change(function () {
            calcFormaPagamentos("#ddlParcBoletos", ".tdValParcelaBoleto", ".tdGeralBoleto");
        });

        // Calcula forma de pagamento cheque
        $("#ddlParcCheques").change(function () {
            calcFormaPagamentos("#ddlParcCheques", ".tdValParcelaCheque", ".tdGeralCheque");
        });

        // Calcula forma de pagamento cartão
        $("#ddlParcCartao").change(function () {
            calcFormaPagamentos("#ddlParcCartao", ".tdValParcelaCartao", ".tdGeralCartao");
        });

        // Recalula entrada
        $("#entradaFormaPagamento").focusout(function () {
            calcFormaPagamentos("#ddlParcCheques", ".tdValParcelaCheque", ".tdGeralCheque");
            calcFormaPagamentos("#ddlParcCartao", ".tdValParcelaCartao", ".tdGeralCartao");
        });
    });
}

// Faz o calculo  do das quantidades
function calcValTot(linha, qtd) {
    var valProd = linha.children("td:nth-child(2)").text();
    valProd = valProd.replace(".", "").replace(",", ".");

    valProd = valProd * qtd;

    linha.children("td:nth-child(5)").text($.formatNumber(valProd, { format: "###,###,##0.00", locale: "br" }));
    calcSubTotalProduto(".tdTotal", ".tdTotGeral");
}

// Insere o serviço de monitoramento
function changeInputBox() {
    $("input[type=checkbox]").off();

    $("input[type=checkbox]").change(function () {
        if ($(this).is(":checked")) {
            var aux = $(".classLinhaServico:last").clone().insertAfter($(".classHeaderServicos"));
            var ProdSel = $(this).parent().parent().children("td:nth-child(1)").children("select").children("select option:selected").text();

            aux.children("td:nth-child(1)").text("HABILITAÇÃO MONITORAMENTO (" + ProdSel + ")");

            var valMon = $(this).parent().parent().children("td:nth-child(3)").text();
            valMon = valMon.replace(".", "").replace(",", ".");
            valMon = valMon * 12;
            aux.children("td:nth-child(2)").text($.formatNumber(valMon, { format: "###,###,##0.00", locale: "br" }));

            aux.children("td:nth-child(3)").children("input[type=text]").val($(this).parent().parent().children("td:nth-child(4)").children("input[type=text]").val());

            aux.children("td:nth-child(5)").html("");

            calcTotServico(aux, aux.children("td:nth-child(3)").children("input[type=text]").val());

            read();
        }
        else {
            calcTotServico($(".classLinhaServico:contains('" + $(this).parent().parent().children("td:nth-child(1)").children("select").children("select option:selected").text() + "'):first"), 0);
            $(".classLinhaServico:contains('" + $(this).parent().parent().children("td:nth-child(1)").children("select").children("select option:selected").text() + "'):first").remove();
        }
    });
}

// Calcula o total do servico
function calcTotServico(linha, qtd) {
    var valProd = linha.children("td:nth-child(2)").text();
    valProd = valProd.replace(".", "").replace(",", ".");

    valProd = valProd * qtd;

    linha.children("td:nth-child(4)").text($.formatNumber(valProd, { format: "###,###,##0.00", locale: "br" }));

    calcSubTotalProduto(".tdTotalServico", ".tdTotGeralServicos");
}

// Calculo do subtotal geral
function calcSubTotalGeral() {
    var totServico = $(".tdTotGeralServicos").text();
    var totProduto = $(".tdTotGeral").text();

    totServico = parseFloat(totServico.replace(".", "").replace(",", "."));
    totProduto = parseFloat(totProduto.replace(".", "").replace(",", "."));

    var totGeral = totProduto + totServico;

    $(".tdSubTotGeral").text($.formatNumber(totGeral, { format: "###,###,##0.00", locale: "br" }));

    calcValDesconto("#txtDesconto", ".tdPercDesc");
    calcValDesconto("#txtAcrescimo", ".tdPercAcres");

    calcTotGeral();
}

// Calculo do desconto
function calcValDesconto(idTXT, idColuna) {
    var valDesconto = $(idTXT).val();
    valDesconto = parseFloat(valDesconto.replace(",", "."));
    var valSubTotal = $(".tdSubTotGeral").text();
    valSubTotal = parseFloat(valSubTotal.replace(".", "").replace(",", "."));

    if (idTXT == "#txtDesconto")
        valDesconto = ((valSubTotal * valDesconto) / 100) * -1;
    else
        valDesconto = (valSubTotal * valDesconto) / 100;

    $(idColuna).text($.formatNumber(valDesconto, { format: "###,###,##0.00", locale: "br" }));

    calcTotGeral();
}

// Calculo do total geral
function calcTotGeral() {
    var totDesconto = $(".tdPercDesc").text();
    var totAcrescimo = $(".tdPercAcres").text();

    totDesconto = parseFloat(totDesconto.replace(".", "").replace(",", "."));
    totAcrescimo = parseFloat(totAcrescimo.replace(".", "").replace(",", "."));

    var valSubTotal = $(".tdSubTotGeral").text();
    valSubTotal = parseFloat(valSubTotal.replace(".", "").replace(",", "."));

    valSubTotal = valSubTotal + totDesconto + totAcrescimo;

    $(".tdTotalGeral").text($.formatNumber(valSubTotal, { format: "###,###,##0.00", locale: "br" }));

    calcFormaPagamentos("#ddlParcBoletos", ".tdValParcelaBoleto", ".tdGeralBoleto");
    calcFormaPagamentos("#ddlParcCheques", ".tdValParcelaCheque", ".tdGeralCheque");
    calcFormaPagamentos("#ddlParcCartao", ".tdValParcelaCartao", ".tdGeralCartao");
}

// Calculo dos subTotais 
function calcSubTotalProduto(tdTotal, tdTotGeral) {
    var total = 0;
    $(tdTotal).each(function (i, tot) {
        if ($(tot).text().trim().length > 0) {
            total = total + parseFloat($(tot).text().replace(".", "").replace(",", "."));
        }
    });

    $(tdTotGeral).text($.formatNumber(total, { format: "###,###,##0.00", locale: "br" }));

    calcSubTotalGeral();
}


function calcFormaPagamentos(comboParcela, valorParcela, valorTotal) {
    // Pega as parcelas da parcela
    var totParcela = parseInt($(comboParcela).children("select option:selected").text());

    // Pega o fator da parcela
    var fator;
    // Se for cartão de crédito verifica se o serviço está habilitado para tirar o juros
    if (comboParcela == "#ddlParcCartao") {
        $(".classChecked").each(function (i, hab) {
            if (!$(hab).is(":checked")) {
                fator = 0;
                return false;
            }
            else
                fator = 12;
        });
    }


    if (fator != 12) {
        fator = $(comboParcela).val();
        fator = parseFloat(fator.replace(",", "."));
    }

    // Pega o total geral    
    var totalGeral = $(".tdTotalGeral").text();
    totalGeral = parseFloat(totalGeral.replace(".", "").replace(",", "."));

    // Verifica a entrada
    var entrada;
    if (comboParcela == "#ddlParcBoletos") {
        // Calcula a entrada do boleto   
        entrada = totalGeral * 0.30;
        $(".tdEntradaBoleto").text($.formatNumber(entrada, { format: "###,###,##0.00", locale: "br" }));
    } else {
        // Pega a entrada das outras formas de pagamento        
        entrada = $("#entradaFormaPagamento").val();
        entrada = parseFloat(entrada.replace(",", "."));
        if (isNaN(entrada))
            entrada = 0;
    }

    // Calcula as parcelas
    var valParcela;
    if (fator == 12)
        valParcela = (totalGeral - entrada) / totParcela;
    else
        valParcela = (totalGeral - entrada) * fator;
    $(valorParcela).text($.formatNumber(valParcela, { format: "###,###,##0.00", locale: "br" }));

    // Calcula o total da compra em boleto
    $(valorTotal).text($.formatNumber((valParcela * totParcela) + entrada, { format: "###,###,##0.00", locale: "br" }));
}