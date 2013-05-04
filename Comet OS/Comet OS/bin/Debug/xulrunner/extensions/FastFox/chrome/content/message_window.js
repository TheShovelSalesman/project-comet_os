var MessageWindow = function()
{
    $(document).ready(function()
    {
        document.documentElement.setAttribute("title", window.arguments[0]);
        var message_label = document.getElementById("message-label");
        message_label.value = window.arguments[1];
        setTimeout(function()
        {
            window.arguments[2]();
            window.close();
        }, 300);//at least show window for a bit, also to prevent problems
    });    
}();