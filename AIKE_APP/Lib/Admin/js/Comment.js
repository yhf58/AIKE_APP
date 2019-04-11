
$(function (){
    $(".allcheck").click(function () {
       
        //if ($(":checkbox").prop("checked")) {
        //    $("input[type='checkbox']").prop("checked", false);
        //}
        //else {
        //    $("input[type='checkbox']").prop("checked", true);
        //}

        $("input[type='checkbox']").prop("checked", function (i, val) {   //i:索引  val:true/false(选中为true,否则为false)
            return !val;
        });
    });

});