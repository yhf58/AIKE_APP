$(function () {
    var i = 1;
    var tables = $("#ProRetunTable");
    //添加项目回报
    $("#AddBtn").click(function () {
        
        //获取输入的金额
        var money = $("#ProMoney").val();
        //获取输入的限定人数
        var number = $("#ProNumbers").val();
        //获取输入的限定时间
        var time = $("#ProTime").val();
       
        if (i>3) {
            alert("回报设置限制设置三个")
        }
        else if (money < 10 || money > 100000000 || number < 1 || number > 1000000 || time < 0) {
            alert("请填写有效数据");
        }
        else {
            $("#ProMoney").val("");
           
            $("#ProNumbers").val("");
           
            $("#ProTime").val("");
           
            //获取输入的回报内容
            var content = $("#ProContent").val();
            $("#ProContent").val("");
            var trtd = $('<tr><td>' + i + '</td> <td style="width:30%;">' + content + '</td><td>' + number + '</td><td>' + money + '</td><td>' + time + '</td><td> <button type="button" id="delete">删除</button></td></tr>');

            trtd.appendTo(tables);
            i++;
            alert("添加成功");
        }
    })
    //清空项目回报
    $("#Eliminate").click(function () {

        $("#ProMoney").val("");
        $("#ProNumbers").val("");
        $("#ProTime").val("");
        $("#ProContent").val("");
    })

    //实现删除
    $(document).on("click", "#delete", function () {
        var index = $(this).parents("tr").children("td:eq(0)").text();
      
        var tb = document.getElementById("ProRetunTable");
        var rows = tb.rows.length;
        for (var t = index; t < rows; t++)
        {
            var cells = tb.rows[t].cells[0];

            var g = parseInt(cells.innerHTML);
            cells.innerHTML = g - 1;
        }   
        $(this).parents('tr').remove();
        i = document.getElementById("ProRetunTable").rows.length;
    })

    $("#Pre").click(function () {

        location.href = '/Project/ProjectDetails';
    })
    $("#Nex").click(function () {

        var t = document.getElementById("ProRetunTable").rows.length;
        if (t < 2) {
            layer.msg("至少需要设置一条汇报内容！", { icon: 2 });
        }
        else {
            var tb = document.getElementById("ProRetunTable");
            var rows = tb.rows.length;
            
            for (var t = 1; t < rows; t++)
            {
                var Content = tb.rows[t].cells[1].innerHTML;
                var number = parseInt(tb.rows[t].cells[2].innerHTML);
                var Money = parseInt(tb.rows[t].cells[3].innerHTML);
                var time = parseInt(tb.rows[t].cells[4].innerHTML);

                $.ajax({
                    url: "../Project/AddReturn",
                    data: { "Money": Money, "number": number, "Content": Content, "time": time, },
                    success: function (data) {
                        
                        layer.msg("添加成功！", { icon: 1 });
                    },
                    error: function () {
                        layer.msg("添加失败！", { icon: 2 });
                    }

                });
            }   
            $.ajax({
                url: "../Project/AddNumber",
                data: {},
                success: function () {
                    
                    layer.msg("进入！", { icon: 1 });
                },
                error: function () {
                    layer.msg("提交失败！", { icon: 2 });
                }

            });
            
        }
        
    })
})