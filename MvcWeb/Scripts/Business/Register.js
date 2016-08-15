
function CustomerRegisterClick() {
    var Personliable = $("#txtPerson_Liable").val();
    if ((Personliable == "undefined")) {
        Personliable = "";
    }
    else if (Personliable == "") {
        alert("所属责任人不能为空！");
        $("#txtPerson_Liable").focus();
        return;
    }
    // 登录名。必须是6-20位英文+数字组合
    var loginAccount = $("#txtLoginAccount").val();
    if (loginAccount == "" || (loginAccount == "undefined")) {
        alert("登录名不能为空！");
        return;
    }
    else
    {
        var reg1 = /([a-zA-Z]|[0-9]+){6,20}/i;
        if (!reg1.test(loginAccount))
        {
            alert("登录名必须是6-20位长英文和数字组合！");
            return;
        }

    }

    //// 用户等级
    //var userGrade = $("#sltUserGrade").val();
    //if (userGrade == 0 || userGrade == "undefined")
    //{
    //    alert("请选择用户等级！");
    //    return;
    //}

    // 区域位置
    //var Region = $("#sltIndirectParent").val();
    //if (Region == 0 || Region == "undefined")
    //{
    //    alert("区域位置不能为空！");
    //    return;
    //}

    // 昵称
    
    var nickName = $("#txtNickName").val();
    
    /*if (nickName == "" || nickName == "undefined")
    {
        alert("昵称不能为空！");
        return;
    }*/

    // 性别
    //var sex = $("#sltSex").val();
    //if (sex == 0 || sex == "undefined")
    //{
    //    alert("请选择性别！");
    //    return;
    //}

    //// 证件号码。验证是否为18位长身份证
    //var cardNo = $("#txtCardNo").val();
    //if (cardno == "" || (cardNo == "undefined")) {
    //    alert("证件号码不能为空！");
    //    return;
    //}
    //else
    //{
    //    var reg2 = /^\d{18}$/;
    //    if (!reg2.test(cardNo))
    //    {
    //        alert("必须输入18位长的身份证号码！");
    //    }
    //}

    // 电子邮箱
    var email = $("#txtEmail").val();
    //if (email == "" || email == "undefined") {
    //    alert("电子邮箱不能为空！");
    //    return;
    //}
    //else
    //{
    //    var reg3 = /^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$/i;
    //    if (!reg3.test(email))
    //    {
    //        alert("电子邮箱格式不正确！");
    //        return;
    //    }
    //}

    // 移动电话
    var mobile = $("#txtMobile").val();
    if (mobile == "" || mobile == "undefined")
    {
        alert("移动电话不能为空！");
        return;
    }

    // 开户银行
    var bank = $("#sltBank").val();

    // 银行开户名
    var bankUser = $("#txtBankUser").val();

    // 银行卡号
    var bankAccount = $("#txtBankAccount").val();

    // 开户分行
    bankBranch = $("#txtBankBranch").val();

    // 支付宝号
    alipay = $("#txtAlipay").val();

    var data = {
        "loginaccount": loginAccount,
        //"usergrade": userGrade,
        //"Region": Region,
        "nickname": nickName,
        "Personliable": Personliable,
        //"cardno": cardNo,
        "email": email,
        "mobile": mobile,
        "bank": bank,
        "bankuser": bankUser,
        "bankaccount": bankAccount,
        "bankbranch": bankBranch,
        "alipay":alipay
    };

    // 提交到后台
    $.ajax({
        type: "POST",
        url: "/Business/DoRegister",
        data: data,
        dataType: "json",
        success: function (data) {

            if (data.res == 1) {
                alert("会员注册成功！");
                $("#dvSubPage").load("/Business/Register");
            }
            else {
                alert(data.mes);
                return;
            }
        }
    });
}