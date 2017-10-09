"use strict";
var result = $('#result');
var button = $(':button');
var calcHistory = $('#calcHistory');
var curent = '0';
var number = "";
var newnumber = "";
var operator = "";

$("[data-type='number']").click(function () {
    var buttonVal = $(this).val();
    var value = result.val();
    value += buttonVal;
    result.val(value);

});
 
$('#clear').click(function () {
    result.val('');
});

$('#clearH').click(function () {
    calcHistory.val('');
    curent = '0';
    number = "";
    newnumber = "";
    operator = "";
});

$('#add').click(function () {
    var value = result.val();
    var buttonVal = $(this).val();
    if (curent != 0 && operator != "") {
        curent = compute();

    } else {
        curent = parseFloat(value, 10);
    }

    operator = "+";
    value += buttonVal
    calcHistory.val(calcHistory.val() + value);
    result.val('');


});

$('#min').click(function () {
    var value = result.val();
    var buttonVal = $(this).val();
    if (curent != 0 && operator != "") {
        curent = compute();

    } else {
        curent = parseFloat(value, 10);
    }

    operator = "-";
    value += buttonVal
    calcHistory.val(calcHistory.val() + value);
    result.val('');

});

$('#multipl').click(function () {
    var value = result.val();
    var buttonVal = $(this).val();
    if (curent != 0 && operator != "") {
        curent = compute();

    } else {
        curent = parseFloat(value, 10);
    }

    operator = "X";
    value += buttonVal
    calcHistory.val(calcHistory.val() + value);
    result.val('');

});

$('#divis').click(function () {
    var value = result.val();
    var buttonVal = $(this).val();
    if (curent != 0 && operator != "") {
        curent = compute();

    } else {
        curent = parseFloat(value, 10);
    }

    operator = "/";
    value += buttonVal
    calcHistory.val(calcHistory.val() + value);
    result.val('');

});


$('#point').click(function () {
    result.val(".");
});

$('#back').click(function () {
    var num = result.val();
    var backs = num.length - 1;
    var newValue = num.substring(0, backs);
    result.val(newValue);

});

$("#neg").click(function () {
    var bigNum = parseInt(result.val());
    var negative = bigNum * -1;
    result.val(negative);
});

$('#equal').click(function () {
    var value = result.val();
    calcHistory.val(calcHistory.val() + value);
    curent = compute();
    operator = "";
    calcHistory.val('');
});

function compute() {

    newnumber = result.val();
    if (operator === "+") {
        number = (curent + parseFloat(newnumber, 10));
    } else if (operator === "-") {
        number = (curent - parseFloat(newnumber, 10));
    } else if (operator === "/") {
        number = (curent / parseFloat(newnumber, 10));
    } else if (operator === "X") {
        number = (curent * parseFloat(newnumber, 10));
    }

    result.val(number);
    return number;

}