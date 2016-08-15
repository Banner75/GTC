
function LnkNoticeItemClick(kind,id)
{
    $("#dvSubPage").load("/Information/DoNotice", { kind: kind, id: id });
}