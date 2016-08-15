
function ModifyPwdClick(kind)
{


    // 验证旧密码正确性
    var oldPw = $("#txtOldPwd").val();

    if (oldPw == "undefined" || oldPw == "") {
        alert("请输入旧密码！");
        return;
    }


    // 读取新密码
    var newPwd = $("#txtNewPwd").val().trim();
    var reNewPwd = $("#txtConfigPwd").val().trim();

    if (newPwd == "undefined" || newPwd == "")
    {
        alert("请输入新密码！");
        return;
    }

    if (reNewPwd == "undefined" || reNewPwd == "")
    {
        alert("请输入确认密码！");
        return;
    }

    if (newPwd != reNewPwd)
    {
        alert("新密码和确认密码不一致，请重新输入！");
        return;
    }

    $.ajax({

        type: "post",
        url: "/Account/DoModifyPwd",
        data: { kind:kind, oldPwd: oldPw, pwd: reNewPwd },
        dataType: "json",
        success: function (result)
        {
            if (result.res == 0)
            {
                alert(result.mes);
            }
            else
            {
                alert("密码修改成功！");
                location.reload();
            }
        }
    });
}