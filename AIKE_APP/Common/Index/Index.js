$(function () {
    $.ajax({
        url: "../Home/Read",
        data: {},
        success: function (data) {
            alert("进入");
            var t = data[0].ProjectName;
            alert(t);
            
        },
        error: function () {
            alert("未进入");
        }
    });
    

})