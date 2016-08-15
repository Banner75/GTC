/// <summary>
/// 子菜单的显示与隐藏
/// <param name="id"></param>
/// </summary>
function ShowSubMenus(id)
{
    var subMenuObj = $("#dvSubMenuBox" + id);
    if (subMenuObj.css("display") == "none")
    {
        subMenuObj.css("display", "inline");
    }
    else
    {
        subMenuObj.css("display", "none");
    }
}

/// <summary>
/// 显示菜单路径信息
/// <param name="caption"></param>
/// <param name="subcaption"></param>
///</summary>
function ShowMenuPath(caption, subcaption)
{
    var pathInfo = "";
    var pathInfoObj = $("#dvPathInfo");
    if ((caption != "undefined") && (caption != ""))
    {
        pathInfo = caption;
        if ((subcaption != "undefined") && (subcaption != ""))
        {
            pathInfo = pathInfo + " -> " + subcaption;
        }
    }
    else
    {
        pathInfo = "";
    }

    pathInfoObj.html(pathInfo);
}

/* ------------------------------------------------------------------------------------------------------------------------ */

/// <summary>
/// 一级菜单点击事件
/// <param name="caption">标题</parma>
/// <param name="url">链接地址</param>
/// <summary>
function HomeItemClick(caption, url)
{
    ShowMenuPath(caption, "");
    $("#dvSubPage").load(url);
}

/// <summary>
/// 一级菜单点击事件
/// <param name="id">菜单标识号</parma>
/// <param name="caption">菜单标题</param>
/// <summary>
function MenuItemClick(id, caption)
{
    ShowMenuPath(caption, "");
    ShowSubMenus(id);
    
}

function SubMenuItemClick(id, caption, parentCaption, url)
{
    ShowMenuPath(parentCaption, caption);

    if ((url != null) && (url != "undefined"))
    {
        var list = url.split("?");
        if (list.length > 1) {

            //$("#dvSubPage").load(list[0].toString(), { kind: parseInt(list[1]) });           // 只传一个参数的情况
            $("#dvSubPage").load(url, { kind: parseInt(list[1]) });           // 只传一个参数的情况
        }
        else {

            $("#dvSubPage").load(list[0].toString());
        }
    }    
}


function SonSubMenuItemClick(url) {

    $("#dvSubPage").load(url);

}