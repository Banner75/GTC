var saleMrc = function () {
    var data = {};
    data.practical_money = $("#Salenum1").val();
    data.num = $("#Salenum").val();
    data.safepwd = $("#Salepaypwd").val();
    if (data.num == "")
    {
        return alert("数量不能为空！");
    }
    if (data.safepwd == "") {
        return alert("请输入安全密码！");
    }
    if (confirm("卖出价格受市场波动影响，实际卖出价格将以会员购买日期的当日价格为准")) {
        loadingShow();
        $.post('/Market/shouwbt', data, function (jsons) {
            loadingHide();
            alert(jsons.msg);
            if (jsons.status == 0) {
                location.reload();
            } else {
                return;
            }
        }, 'json');
    }
}

var cancelbtorder = function (id) {
    var para = {};
    para.id = id;
    if (confirm("取消订单会导致诚信度将会下降，是否确认取消订单？")) {
        loadingShow();
        $.post("/Market/cancelbtorder", para, function (jsons) {
            loadingHide();
            alert(jsons.msg);
            if (jsons.status == 0) {
                window.location.href = "/User/BybtLog";
            }
            else {
                return;
            }
        }, 'json');
    }
}
//确认购买MRC币
var affirmbtsonlist = function (id) {
    var para = {};
    para.ID = id;
    if (confirm("确认之前请确保已收到汇款！")) {
        loadingShow();
        $.ajax({
            url: "/Market/affirmbtsonlist",
            data: para,
            type: "POST",
            dataType: "json",
            success: function (pagedata) {
                loadingHide();
                if (pagedata.success) {
                    alert(pagedata.msg);
                    window.location.reload();
                }
                else {
                    alert(pagedata.msg);
                    return;
                }
            }
        });
    }
}
var bybtform=function () {
    var BTID = $("#BTID").val();
    var bynum = $("#bynum").val();
    if (BTID.length == 0) {
        alert("参数错误！请重新打开");
        return;
    }
    if (bynum.length == 0) {
        alert("购买数不能为空");
        return;
    }
    loadingShow();
    var para = {};
    para.BTID = BTID;
    para.bynum = bynum;
    $.ajax({
        url: "/Market/bybtform",
        data: para,
        type: "POST",
        dataType: "json",
        success: function (data) {
            loadingHide();
            if (data.success) {
                alert(data.msg);
                window.location.href = "/User/BybtLog";
            } else {
                alert(data.msg);
            }
        }
    });

}