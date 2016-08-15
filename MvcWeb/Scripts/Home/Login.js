/// <summary>
/// 功能说明：登录验证
/// 编写人员：林红刚
/// 编写日期：2016/06/11
/// </summary>
function Logining()
{
    var account = $("#txtLoginAccount").val();
    var password = $("#txtLoginPassword").val();
    var verifyCode = $("#txtVerifyCode").val();

    if (account == "" || account == "undefined")
    {
        alert("登录帐号不能为空！");
        //$("#txtHintInfo").html("登录帐号不能为空！");
        return;
    }

    if (password == "" || password == "undefined")
    {
        alert("登录密码不能为空！");
        //$("#txtHintInfo").html("登录密码不能为空！");
        return;
    }

    if (verifyCode == "" || verifyCode == "undefined")
    {
        alert("请输入验证码！");
        //$("#txtHintInfo").html("请输入验证码！");
        return;
    }

    $.ajax({

        type: "post",
        url: "/Home/DoLogin",
        data: { "acc": account, "pwd": password, "code": verifyCode },
        dataType: "json",
        success: function (data) {
            if (data != null)
            {
                if (data.res == 0) {
                    $("#txtHintInfo").html(data.mes);
                }
                else
                {
                    $("#dvLoginUserInfo").html(data.username);
                    window.location = "/Home/Index";
                }
            }
        }
    });
}

/// <summary>
/// 功能说明：清除输入框
/// 编写人员：林红刚
/// 编写日期：2016/06/11
/// </summary>
function Clear()
{
    $("#txtLoginAccount").val("");
    $("#txtLoginPassword").val("");
    $("#txtVerifyCode").val("");
}