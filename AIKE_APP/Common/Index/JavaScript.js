var sum = 11250;
var sum2 = 32589;
var sum3 = 86952;
var sum4 = 46987;
$(function () {
    setInterval(function () {
        show_num1(sum)
    }, 3000);

    setInterval(function () {
        show_num2(sum2);
        show_num3(sum3);
        show_num4(sum4);
    }, 3000);

  
});

function show_num1(n) {
    sum = sum + Math.floor(Math.random() * 100);
    console.log(n);
    var it = $(".t_num1 i");
  
    var len = String(n).length;
    for (var i = 0; i < len; i++) {
        if (it.length <= i) {
            $(".t_num1").append("<i></i>");
        }
        var num = String(n).charAt(i);
        //根据数字图片的高度设置相应的值
        var y = -parseInt(num) * 58;
        var obj = $(".t_num1 i").eq(i);
        obj.animate({
            backgroundPosition: '(0 ' + String(y) + 'px)'
        }, 'slow', 'swing', function () { });
    }
    $("#cur_num").val(n);
}

function show_num2(n) {
    sum2 = sum2 + Math.floor(Math.random() * 100);
    console.log(n);
    var it = $("#t_num2 i");

    var len = String(n).length;
    for (var i = 0; i < len; i++) {
        if (it.length <= i) {
            $("#t_num2").append("<i></i>");
        }
        var num = String(n).charAt(i);
        //根据数字图片的高度设置相应的值
        var y = -parseInt(num) * 58;
        var obj = $("#t_num2 i").eq(i);
        obj.animate({
            backgroundPosition: '(0 ' + String(y) + 'px)'
        }, 'slow', 'swing', function () { });
    }
    $("#cur_num").val(n);
}

function show_num3(n) {
    sum3 = sum3 + Math.floor(Math.random() * 100);
    console.log(n);
    var it = $("#t_num3 i");

    var len = String(n).length;
    for (var i = 0; i < len; i++) {
        if (it.length <= i) {
            $("#t_num3").append("<i></i>");
        }
        var num = String(n).charAt(i);
        //根据数字图片的高度设置相应的值
        var y = -parseInt(num) * 58;
        var obj = $("#t_num3 i").eq(i);
        obj.animate({
            backgroundPosition: '(0 ' + String(y) + 'px)'
        }, 'slow', 'swing', function () { });
    }
    $("#cur_num").val(n);
}

function show_num4(n) {
    sum4 = sum4 + Math.floor(Math.random() * 100);
    console.log(n);
    var it = $("#t_num4 i");

    var len = String(n).length;
    for (var i = 0; i < len; i++) {
        if (it.length <= i) {
            $("#t_num4").append("<i></i>");
        }
        var num = String(n).charAt(i);
        //根据数字图片的高度设置相应的值
        var y = -parseInt(num) * 58;
        var obj = $("#t_num4 i").eq(i);
        obj.animate({
            backgroundPosition: '(0 ' + String(y) + 'px)'
        }, 'slow', 'swing', function () { });
    }
    $("#cur_num").val(n);
}