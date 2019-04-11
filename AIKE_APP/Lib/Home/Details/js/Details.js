$(function () {
    //// Initializes and creates emoji set from sprite sheet
    //window.emojiPicker = new EmojiPicker({
    //    emojiable_selector: '[data-emojiable=true]',
    //    assetsPath: '../Lib/Home/Details/img',
    //    popupButtonClasses: 'fa fa-smile-o'
    //});
  
    //window.emojiPicker.discover();
});

//评论
$(function () {
    $("#button").click(function () {
        
        name = $(".form-control").val();
      
        if (name == "") {
            alert("哇！你要发表的评论被劫持了，请重新输入");
            return false;
        }
        $("#ProjectID").hide();

        //////////////
            $.ajax({
                url: "../Home/Connrent_s",
                dataType: "json",
                data: { "txt": $(".form-control").val(), "ProjectID": $("#ProjectID").text() },
                success: function (data) {
                    if (parseInt(data) == 1) {
                        layer.msg("发表成功！", { icon: 1 });
                        //$("#Opinion").append("<div>" + name + "</div>");
                       
                        //for (var i = 0; i < data.data.lemgth; i++) {
                      
                        setTimeout("location.href='../Home/Details?ProjectID=" + $("#ProjectID").text() + "'", 500);
                        //}
                    }
                   else if (parseInt(data) == 2) {
                        layer.msg("请登录后再发表评论！", { icon: 2 });
                    }
                    else {
                        layer.msg("发表失败！", { icon: 2 });
                    }
                },
                error: function () {
                    layer.msg("发表失败！", { icon: 2 });
                }
        });
       
    });
});
