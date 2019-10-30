// Write your Javascript code.
function autoRefresh(firstAcess)
{
    if (firstAcess == true) {
        update();
        return;
    }
        
    setTimeout("update()", 10000);
}
function update(url) {
    var url = "panellog/indexbody";
    $.get(url, null, 
        function (data) {
            $("#bodyGamber").html(data);
            autoRefresh(false);
    });
}
