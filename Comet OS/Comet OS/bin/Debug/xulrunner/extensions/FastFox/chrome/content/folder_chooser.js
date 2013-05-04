var FolderChooser = function()
{
    var prefManager = Components.classes["@mozilla.org/preferences-service;1"].getService(Components.interfaces.nsIPrefBranch);

    function LOG(msg)
    {
        var enabled = false;
        if(enabled)
        {
            var consoleService = Components.classes["@mozilla.org/consoleservice;1"].getService(Components.interfaces.nsIConsoleService);
            consoleService.logStringMessage("smarterwiki smarterwiki.js: " + msg);
        }
    }

    var path_to_nsILocalFile = function(path)
    {
        var dir = Components.classes["@mozilla.org/file/local;1"].createInstance(Components.interfaces.nsILocalFile);
        dir.initWithPath(path);
        return dir;
    };
    
    $(document).ready(function()
    {
        var dest_folder_textbox = document.getElementById("dest-folder-textbox");
        dest_folder_textbox.value = prefManager.getCharPref("browser.download.lastDir");
        var set_accept_button_status = function()
        {
            var path = dest_folder_textbox.value;
            var disable_accept = true;
            try
            {
                var dir = path_to_nsILocalFile(path);
                if(!dir.exists() || dir.isDirectory())
                {
                    disable_accept = false;
                }
            } 
            catch(e) 
            {
                LOG(e);
            }
            document.documentElement.getButton("accept").setAttribute("disabled", disable_accept);
        };            
        dest_folder_textbox.addEventListener("keydown", function(event)
        {
            set_accept_button_status();
        }, true);
        set_accept_button_status();
    });
    
    return {
        ondialogaccept: function()
        {
            try
            {
                var dest_folder_textbox = document.getElementById("dest-folder-textbox");
                var dir = path_to_nsILocalFile(dest_folder_textbox.value);
                if(!dir.exists()) 
                {
                    var permissions = dir.parent.exists() ? dir.parent.permissions : 0600;
                    dir.create(Components.interfaces.nsIFile.DIRECTORY_TYPE, permissions);
                }
                prefManager.setCharPref("browser.download.lastDir", dir.path);
                //CANNOT use setTimeout because window might be destroyed first,
                window.arguments[0](dir);
            }
            catch(e)
            {
                LOG(e);
            }
        },

        ondialogcancel: function()
        {
        },

        onbrowsecommand: function()
        {
            var strbundle = document.getElementById("smarterwiki_strings");
            var select_folder_str = strbundle.getString("select_folder_str");

            var filePicker = Components.classes["@mozilla.org/filepicker;1"].createInstance(Components.interfaces.nsIFilePicker);
            filePicker.init(window, select_folder_str, Components.interfaces.nsIFilePicker.modeGetFolder);

            var dest_folder_textbox = document.getElementById("dest-folder-textbox");
            try 
            {
                var dir = path_to_nsILocalFile(dest_folder_textbox.value.toString());
                if(!dir.exists())
                {
                    dir = dir.parent;
                }
                if(dir.exists() && dir.isDirectory()) 
                {
                    filePicker.displayDirectory = dir;
                }
            } 
            catch(e)
            {
            }

            filePicker.appendFilters(Components.interfaces.nsIFilePicker.filterAll);

            if(filePicker.show() == Components.interfaces.nsIFilePicker.returnOK) 
            {
                dest_folder_textbox.value = filePicker.file.path;
                document.documentElement.getButton("accept").setAttribute("disabled", false);
            }
        },
    };
}();