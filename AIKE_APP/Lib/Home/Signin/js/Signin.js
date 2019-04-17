$(function () {
    $("#sp1").click(function () {
      
        $("#row1").slideUp(500);
        $("#row").slideDown(500);
    })

    $("#sp2").click(function () {

        $("#row").slideUp(500);
        $("#row1").slideDown(500);
    })
})