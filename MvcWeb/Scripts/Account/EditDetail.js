var editinfo = function () {
    $(".ShowInfo").hide();
    $(".EditInfo").show();
}
var cancel = function () {
    $(".ShowInfo").show();
    $(".EditInfo").hide();
}
var comfrom = function () {
    var data={};
    //data.n=$("#NickName").val();
    //data.t=$("#TrulyName").val();    
    //data.em=$("#Email").val();
    //data.mo=$("#Mobile").val();    
    data.bu = $("#BankUser").val();
    data.ba = $("#BankAccount").val();
    data.bb = $("#BankBranch").val();
    data.al = $("#Alipay").val();
    data.bk = $("#Bank").val();
    data.s = $("#Sex").val();
    data.m = $("#Mobile").val();
    
    $.post("/Account/EditMyDetail", data, function (jsons) {
        if (jsons.status == 0) {
            //$("#NickName_label").text(data.n);
            //$("#TrulyName_label").text(data.t);
            //$("#Email_label").text(data.em);
            //$("#Mobile_label").text(data.mo);
            $("#BankUser_label").text(data.bu);
            $("#BankAccount_label").text(data.ba);
            $("#BankBranch_label").text(data.bb);
            $("#Alipay_label").text(data.al);
            $("#Bank_label").text(data.bk);
            $("#sex_label").text(data.s);
            $("#Mobile_label").text(data.m);
            alert(jsons.msg);
            $(".ShowInfo").show();
            $(".EditInfo").hide();
        } else {
            alert(jsons.msg)
            return;
        }
    }, 'json');
    //var nickname = $("").val();
}