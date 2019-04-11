$(function () {
    

    $("#Previous").click(function () {
  
        location.href = '/Home/Index';
    })
    var type = null;
    //选择类型
    $(".type>button").bind("click", function () {
        type = $(this).text();
      
    });
   
  
    //文本检测
    $("#Next").click(function () {
        var text = $("#txts").val();
        if (text == null || text == "") {
            layer.msg("请输入完整信息！", { icon: 2 });  
        }
        else {
            $.ajax({
                url: "../Project/Detection",
                data: { "oldstr": $("#txts").val()},
                success: function (data) {
                    if (parseInt(data)!=3) {
                        layer.msg("文本审核通过！", { icon: 1 });
                         
                        AddProject();
                        if (type == "" || type == null) {
                            layer.msg("请选择类型！", { icon: 2 });

                        }
                        else {
                            location.href = '/Project/ProjectReturn';
                        }
                     
                    }
                    else {
                        layer.msg("输入的内容存在违法词汇，请重新输入！", { icon: 2 });
                    }
                },
                error: function () {
                    layer.msg("提交失败！", { icon: 2 });
                }

            });
        }
       
        
    })
    //文本纠查    
    $(".bootstrap-switch span").click(function () {
        if ($("input[type=checkbox]").get(0).checked) {
            
            $.ajax({
                url: "../Project/NewTxet",
                data: { "oldstr": $("#txts").val() },
                success: function (data) {
                    $("#txts").val(data);
                    layer.msg("检测完毕！");
                    
                },
                error: function () {
                    layer.msg("请稍后重试！", { icon: 2 });
                }


            })
        }
    });
    //添加项目
    function AddProject()
    {
        var name = $("#proName").val();
        var days = $("#proDays").val();
        var Add = $("#guo").val() + $("#sheng").val();
        var Details = $("#txts").val();
        var money = $("#proMoney").val();
        if (type == null) {
            layer.msg("请选择类型", { icon: 2 });
        }
        else {
            var Introduction = $("#proIntroduction").val();
            $.ajax({
                url: "../Project/AddProject",
                data: { "name": name, "days": days, "money": money, "Add": Add, "Details": Details, "Introduction": Introduction, "Label": type },
                success: function () {
                    layer.msg("调用成功！", { icon: 1 });
                },
                error: function () {
                    layer.msg("调用失败！", { icon: 2 });
                }
            })
        }
       
    }
    
    ////将file图片路径获取并显示在图片框中
    //$("#file_upload").change(function (){
       
    //        alert("666");
    //        // 检查是否为图像类型
    //    var simpleFile = $("#file_upload").files[0];
    //        if (!/image\/\w+/.test(simpleFile.type)) {
    //            alert("请确保文件类型为图像类型");
    //            return false;
    //        }
    //        var reader = new FileReader();
    //        // 将文件以Data URL形式进行读入页面
    //        reader.readAsDataURL(simpleFile);
    //        reader.onload = function (e) {
    //            console.log(this.result);
    //            result.innerHTML = '<img src="' + this.result + '" alt=""/>';
    //        }
    //    if (this.result != null || this.result != "") {
    //        alert("成功调用2");
    //        alert(this.result)
    //        $.ajax({
    //            url: "../Project/Pro",//提交地址：控制器/方法
    //            data: { "path": this.result },
    //            success: function (data) {
    //                debugger
    //                alert(data[0])
    //                //if (parseInt(data) == 1) {
    //                //    alert("删除成功")
    //                //}
    //                //else {
    //                //    alert("删除失败")
    //                //}

    //            },
    //            error: function () {
    //                debugger
    //            }
    //        });

    //    }
        
    //});
   
    //上一页
   
});