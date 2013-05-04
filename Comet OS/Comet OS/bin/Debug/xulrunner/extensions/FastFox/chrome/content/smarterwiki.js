//to add: clipboard manager?
/*
Note: while this addon uses the jQuery library, which contains eval()s,
it does not cause any of them to be invoked. I believe that jQuery uses
those eval()s for processing json, but this addon no longer uses json.

Also, jQuery.noConflict() is invoked, which prevents namespace conflicts.
*/

var SmarterWiki = function()
{
    var DEBUG = false;
    var LOAD_CSS_LOCALLY = true;
    var LOAD_JS_LOCALLY = true;
    
    
    var consoleService = Components.classes["@mozilla.org/consoleservice;1"]
                               .getService(Components.interfaces.nsIConsoleService);
    var prefManager = Components.classes["@mozilla.org/preferences-service;1"]
                               .getService(Components.interfaces.nsIPrefBranch);
    var faviconService = Components.classes["@mozilla.org/browser/favicon-service;1"]
                               .getService(Components.interfaces.nsIFaviconService);
    var ioService = Components.classes["@mozilla.org/network/io-service;1"]
                               .getService(Components.interfaces.nsIIOService);  
    var bookmarksService = Components.classes["@mozilla.org/browser/nav-bookmarks-service;1"]
                               .getService(Components.interfaces.nsINavBookmarksService);
    var historyService = Components.classes["@mozilla.org/browser/nav-history-service;1"]
                               .getService(Components.interfaces.nsINavHistoryService);
    var taggingService = Components.classes["@mozilla.org/browser/tagging-service;1"]
                               .getService(Components.interfaces.nsITaggingService);
    var downloadManager = Components.classes["@mozilla.org/download-manager;1"]
                               .getService(Components.interfaces.nsIDownloadManager);
    var downloadManagerUI = Components.classes["@mozilla.org/download-manager-ui;1"]
                               .getService(Components.interfaces.nsIDownloadManagerUI);
    var styleSheetService = Components.classes["@mozilla.org/content/style-sheet-service;1"]
                               .getService(Components.interfaces.nsIStyleSheetService);

    var uuid = function()
    {
        var S4 = function() {
           return (((1+Math.random())*0x10000)|0).toString(16).substring(1);
        };
        return (S4()+S4()+'-'+S4()+'-'+S4()+'-'+S4()+'-'+S4()+S4()+S4());
    };
                               

    var prefPrefix = "extensions.smarterwiki.";
    var onuninstallURL = function(install_time, install_duration)
    {
        return "http://smarterfox.com/smarterwiki/uninstalled/?install_time=" + install_time + "&install_duration=" + install_duration;
    };
    var ondisableURL = function(install_time, install_duration)
    {
        return "http://smarterfox.com/smarterwiki/disabled/?install_time=" + install_time + "&install_duration=" + install_duration;
    };
    var oninstallURL = function(lastVersion, currentVersion, install_time)
    {
        return "https://smarterfox.com/smarterwiki/installed/?from_ver=" + lastVersion + "&to_ver=" + currentVersion + "&install_time=" + install_time;
    };
    var onupdateURL = function(lastVersion, currentVersion, install_time)
    {
        return "https://smarterfox.com/smarterwiki/updated/?from_ver=" + lastVersion + "&to_ver=" + currentVersion + "&install_time=" + install_time
                + "&pf1=" + prefManager.getBoolPref(prefPrefix + "add_related_search_results_amazon")
                + "&pf2=" + prefManager.getBoolPref(prefPrefix + "add_similar_product_search");
    };

    var jquery_js = null;
    
    var js_filenames = ["content/scripts/env_setup.js", 
                        "content/scripts/popup_bubble.js", 
                        "content/scripts/related_articles.js", 
                        "content/scripts/linkify.js", 
                        "content/scripts/related_searches.js", 
                        "content/scripts/endless_pages_heuristics.js", 
                        "content/scripts/endless_pages.js", 
                        "content/scripts/related_search_results.js", 
                        "content/scripts/search_refinements.js",
                        //"content/scripts/serp_info_box.js",
                        "content/scripts/related_shopping_results.js"]
    var css_filenames = ["skin/popup_bubble.css", 
                         "skin/related_searches.css", 
                         "skin/endless_pages.css", 
                         "skin/infinite_scroll.css", 
                         "skin/related_search_results.css", 
                         "skin/trending_search_results.css",
                         "skin/ddg_zero_click_info.css",
                         //"skin/serp_info_box.css",
                         "skin/fastest_common.css"]
    var file_text = {};


    var LOG = function(msg, prefix)
    {
        var enabled = DEBUG;
        if(!prefix) {
            prefix = "smarterwiki: ";
        }
        if(enabled) {
            consoleService.logStringMessage(prefix + msg);
        }
    }

    var get_logger = function(prefix)
    {
        return function(msg) {
            LOG(msg, prefix);
        };
    }

    var searchWikipediaURL = function(terms)
    {
        /*
        if exact match is found in Wikipedia, the user is sent to Wikipedia.
        else the user is redirected to Google search.
        */
        return "http://smarterfox.com/wikisearch/search?q=" + encodeURIComponent(terms);
        //return "http://www.google.com/search?q=" + terms + " site:wikipedia.org" //search more than a specific wikipedia such as en.wikipedia.org
    };
    
    var asyncRequestText = function(url, handler)
    {
        var req = new XMLHttpRequest();
        req.open("GET", url);
        req.addEventListener("load", function(event)
        {
            handler(req.responseText);
        }, false);
        req.overrideMimeType("text/plain");
        req.send(null);
    };

    var async_get_file = function(filename, callback)
    {
        var url = (LOAD_JS_LOCALLY ? "chrome://smarterwiki/" : "http://static.smarterfox.com/media/smarterwiki/") + 
                    filename;
        asyncRequestText(url, function(text)
        {
            if(callback) {
                callback(text);
            }
        });
    };
    
    
    var loadStuff = function()
    {
        for(var i = 0; i < js_filenames.length; ++i)
        {
            var filename = js_filenames[i];
            async_get_file(filename, function(text)
            {
                file_text[filename] = text;
            });
        }
        for(var i = 0; i < css_filenames.length; ++i)
        {
            var filename = css_filenames[i];
            async_get_file(filename, function(text)
            {
                file_text[filename] = text;
                loadCSSText(text);
            });
        }
        
        asyncRequestText("chrome://smarterwiki/content/jquery.js", function(text)
        {
            jquery_js = text;
        });

        asyncRequestText("chrome://smarterwiki/content/jquery-1.2.6.js", function(text)
        {
            var jquery_js_old = text;
            eval(jquery_js_old);//load here to prevent namespace collisions
            SmarterWiki.$ = jQuery.noConflict(true);
        });
    };
    
    var loadCSSText = function(css_text)
    {
        var uri = ioService.newURI("data:text/css;base64," + btoa(css_text), null, null);
        if(!styleSheetService.sheetRegistered(uri, styleSheetService.USER_SHEET))
        {
            styleSheetService.loadAndRegisterSheet(uri, styleSheetService.USER_SHEET);
        }
    };

    
    var setupAwesomebar = function()
    {
        if(prefManager.getBoolPref(prefPrefix + "enhance_urlbar"))
        {
            var urlbar = document.getElementById("urlbar");
            //urlbar.setAttribute("autocompletesearch", "smarterwiki-search");//"history smarterwiki-trunc-hist");//
            urlbar.maxRows = 10;
        }

        /*
        //override handleURLBarCommand
        var old_handleURLBarCommand = handleURLBarCommand;
        handleURLBarCommand = function(aTriggeringEvent)
        {
            if(gURLBar.value == "http://google.com")
            {
                gURLBar.value = "http://yahoo.com";
            }
            return old_handleURLBarCommand(aTriggeringEvent);
        }
        */
    };
    
    var setupExitSurvey = function()
    {
        var observerService = Components.classes["@mozilla.org/observer-service;1"].getService(Components.interfaces.nsIObserverService);
        observerService.addObserver(
            {
                observe: function(p_Subject, p_Topic, p_Data)
                {
                    if(p_Topic == "em-action-requested")
                    {
                        p_Subject.QueryInterface(Components.interfaces.nsIUpdateItem);
                        if(p_Subject.id == "smarterwiki@wikiatic.com")
                        {
                            var install_time = parseInt(prefManager.getCharPref(prefPrefix + "install-time"));//too big for int pref
                            var install_duration = new Date().getTime() - install_time;
                            if(p_Data == "item-uninstalled")
                            {
                                gBrowser.selectedTab = gBrowser.addTab(onuninstallURL(install_time, install_duration));
                            }
                            else if(p_Data == "item-disabled")
                            {
                                gBrowser.selectedTab = gBrowser.addTab(ondisableURL(install_time, install_duration));
                            }
                        }
                    }
                }
            }, 
        "em-action-requested", false);
    };
    
    var openNewTab = function(url)
    {
        gBrowser.selectedTab = gBrowser.addTab(url);
    };
    
    
    var setupFirstRun = function()
    {
        //store uuid
        if(prefManager.getCharPref(prefPrefix + "install-uuid") == "") {
            prefManager.setCharPref(prefPrefix + "install-uuid", uuid());
        }


        var getCurrentVersion = function(callback)
        {
            if(Application.extensions) {
                callback(Application.extensions.get("smarterwiki@wikiatic.com").version);
            }
            else
            {
                AddonManager.getAddonByID("smarterwiki@wikiatic.com", function(addon) {
                    callback(addon.version);
                });
            }                
        };

        
        
        getCurrentVersion(function(currentVersion)
        {
            var lastVersion = prefManager.getCharPref(prefPrefix + "last-version");
            var isFirstRun = (lastVersion == "firstrun");
            var install_time = prefManager.getCharPref(prefPrefix + "install-time");
            if(lastVersion != currentVersion)
            {
                setTimeout(function() 
                {
                    if(isFirstRun) {
                        openNewTab(oninstallURL(lastVersion, currentVersion, install_time));
                    }
                    else {
                        openNewTab(onupdateURL(lastVersion, currentVersion, install_time));
                    }            

                    //prepare to clean up prefs in order to support new features
                    //migrate prefs
                    if(prefManager.getBoolPref("extensions.smarterwiki.add_related_search_results_amazon"))
                    {
                        prefManager.setBoolPref("extensions.smarterwiki.add_related_shopping_results", true);
                        prefManager.setBoolPref("extensions.smarterwiki.add_price_comparison_results", true);
                        prefManager.setBoolPref("extensions.smarterwiki.add_extra_search_results", true);
                        prefManager.setBoolPref("extensions.smarterwiki.enable_optional_features", true);
                        prefManager.setBoolPref("extensions.smarterwiki.add_related_search_results", true);
                        prefManager.setBoolPref("extensions.smarterwiki.add_related_pages", true);
                    }                    
                }, 100);
            }
            prefManager.setCharPref(prefPrefix + "last-version", currentVersion);
            if(isFirstRun) {
                prefManager.setCharPref(prefPrefix + "install-time", new Date().getTime());
            }
        });
    };

    var getFaviconURL = function(pageURL)
    {
        if("about:blank" == pageURL) {
            return "about:blank";
        }
        var pageURI = ioService.newURI(pageURL, null, null);
        var getFaviconForPage = function(uri)
        {
            try
            {
                return faviconService.getFaviconForPage(uri).spec;
            }
            catch(error)
            {
                return null;
            }
        };

        var hardcodedRedirects = {};
        hardcodedRedirects["http://reader.google.com"] = "http://www.google.com/reader/view/";

        var favicon_url = getFaviconForPage(pageURI);
        if(favicon_url == null)
        {
            var pageURI2 = pageURI.clone();
            pageURI2.host = "www." + pageURI2.host;
            favicon_url = getFaviconForPage(pageURI2);
            if(favicon_url == null) 
            {
                if(pageURL in hardcodedRedirects)
                {
                    favicon_url = getFaviconForPage(ioService
                        .newURI(hardcodedRedirects[pageURL], null, null));
                }
                if(favicon_url == null)
                {
                    pageURI2 = pageURI.clone();
                    pageURI2.path = "favicon.ico";
                    favicon_url = pageURI2.spec;
                }
            }
        }

        return favicon_url;
    };
    
    var queryBookmarks = function(bookmarkFolderId)
    {
        var options = historyService.getNewQueryOptions();
        var query = historyService.getNewQuery();    
        
        query.setFolders([bookmarkFolderId], 1);
        
        var result = historyService.executeQuery(query, options);
        var rootNode = result.root;
        rootNode.containerOpen = true;

        var bookmarkNodes = [];
        for(var i = 0; i < rootNode.childCount; i++) // iterate over the immediate children of this folder
        {
            var node = rootNode.getChild(i);
            bookmarkNodes.push(node);
        }

        rootNode.containerOpen = false; // IMPORTANT: close a container after using it!

        return bookmarkNodes;
    };
    
    var getQlauncherFolderId = function(create)
    {
        // Application.bookmarks.toolbar.addFolder("qLauncher");
        var qlauncherFolderId = getChildFolder(bookmarksService.bookmarksMenuFolder, "qLauncher");
        if(qlauncherFolderId == 0 && create)
        {
            qlauncherFolderId = bookmarksService.createFolder(bookmarksService.bookmarksMenuFolder, 
                "qLauncher", 0);
        }
        return qlauncherFolderId;
    };
    
    var hasShortcuts = function()
    {
        var qlauncherFolderId = getQlauncherFolderId(false);
        return qlauncherFolderId != 0;
    };
    
    var addShortcut = function(title, uri)
    {
        var qlauncherFolderId = getQlauncherFolderId(true);
        bookmarksService.insertBookmark(qlauncherFolderId, ioService.newURI(uri, null, null), -1, title);        
        taggingService.tagURI(ioService.newURI(uri, null, null), ["qlauncher:"]);
    };
    
    var getChildFolder = function(aFolder, aSubFolder)
    {
        if(bookmarksService.getChildFolder)
        {
            return bookmarksService.getChildFolder(aFolder, aSubFolder);
        }
        else
        {
            var htService = Components.classes["@mozilla.org/browser/nav-history-service;1"].
                getService(Components.interfaces.nsINavHistoryService);
            var query = htService.getNewQuery();
            var options = htService.getNewQueryOptions();
            query.setFolders([aFolder], 1);
            var result = htService.executeQuery(query, options);
            var rootNode = result.root;
            var childFolder = 0;
            rootNode.containerOpen = true;
            for (var i = 0; i < rootNode.childCount; i++) 
            {
                var node = rootNode.getChild(i);
                if (node.type == node.RESULT_TYPE_FOLDER && node.title == aSubFolder) 
                {
                    childFolder = node.itemId;
                    break;
                }
            }
            rootNode.containerOpen = false;
            return childFolder;
        }           
    };
    
    var migrateBookmarks = function()
    {
        var qlauncherToolbarFolderId = getChildFolder(bookmarksService.toolbarFolder, "qLauncher");
        if(qlauncherToolbarFolderId == 0)
        {
            return;
        }
        
        var qlauncherMenuFolderId = getQlauncherFolderId(true);
        
        for each(var bookmarkNode in queryBookmarks(qlauncherToolbarFolderId))
        {
            bookmarksService.insertBookmark(qlauncherMenuFolderId, ioService.newURI(bookmarkNode.uri, null, null), -1, bookmarkNode.title);
        }
        
        bookmarksService.removeItem(qlauncherToolbarFolderId);
    };
    
    var initQlauncherBookmarks = function()
    {
        var qlauncherFolderId = getQlauncherFolderId(true);
        if(queryBookmarks(qlauncherFolderId).length == 0)
        {
            //add the default bookmarks
            var defaultBookmarks = [
                    ["a", "Amazon", "http://www.amazon.com"],
                    ["d", "Download Squad", "http://www.downloadsquad.com"],
                    ["f", "Facebook", "http://www.facebook.com"],
                    ["g", "Digg", "http://digg.com"],
                    ["l", "Lifehacker", "http://lifehacker.com"],
                    ["m", "Mashable", "http://mashable.com"],
                    ["n", "NYTimes", "http://nytimes.com"],
                    ["r", "ReadWriteWeb", "http://www.readwriteweb.com"],
                    ["s", "MySpace", "http://www.myspace.com", ],
                    ["u", "YouTube", "http://www.youtube.com"],
                    ["w", "Wikipedia", "http://en.wikipedia.org/wiki/Main_Page"],
                    //["x", "Reader", "http://www.google.com/reader/view/"],
                ];
            for each(var bkmk in defaultBookmarks)
            {
                var tag = "qlauncher:" + bkmk[0];
                var title = bkmk[1];
                var uri = bkmk[2];
                bookmarksService.insertBookmark(qlauncherFolderId, ioService.newURI(uri, null, null), -1, title);
                taggingService.tagURI(ioService.newURI(uri, null, null), [tag]);
            }
        }

        return qlauncherFolderId;
    };
    
    var removeBookmark = function(itemId)
    {
        bookmarksService.removeItem(itemId);
    };
    
    var getShortcuts = function()
    {
        var qlauncherFolderId = initQlauncherBookmarks();
        var shortcuts = [];
        for each(var bookmarkNode in queryBookmarks(qlauncherFolderId))
        {
            var uri = bookmarkNode.uri;
            var tags = taggingService.getTagsForURI(ioService.newURI(uri, null, null), {});
            var shortcut_key = null;
            for each(var tag in tags)
            {
                var m = /qlauncher:(.?)/.exec(tag);
                if(m != null)
                {
                    shortcut_key = m[1].toLowerCase();
                    break;
                }
            }
            shortcuts.push([shortcut_key, getFaviconURL(uri), bookmarkNode.title, uri, bookmarkNode.itemId]);
        }
        return shortcuts;
    };

    var doAutoCopy = function()
    {
        if(prefManager.getBoolPref(prefPrefix + "auto_copy_selected"))
        {
            var selection = document.commandDispatcher.focusedWindow.getSelection();
            if(selection.toString())
            {
                goDoCommand('cmd_copy');//clipboardHelper.copyString(selection.toString());  
            }
            // goDoCommand('cmd_copy'); //doing this will allow copy of text fields but make life more difficult
        }
    };
    
    var showBookmarkCurrentPageEdit = function()
    {
        PlacesCommandHook.bookmarkCurrentPage(true);
    };
    

    var filename_from_url = function(url)
    {
        var patt = /.*\/([^\/]+?)(?:\/$|$)/;
        var match = patt.exec(url);
        
        var filename = match[1] ? match[1].replace(/[\\\/:*?"<>|]/g, "_") : "_";
        return filename.substring(0, 25);
    };
    
    var downloadURLs = function(download_infos)
    {
        const xulURL = "chrome://smarterwiki/content/folder_chooser.xul";
        const features = "chrome, all, dialog=no, centerscreen";
        var callback = function(folder)//folder is nsILocalFile
        {
            LOG("downloading " + download_infos.length + " urls");
            var callback2 = function()
            {
                var download = null;
                for(var i = 0; i < download_infos.length; i++)
                {
                    var source_uri = download_infos[i][0];
                    var referrerURI = download_infos[i][1];
                    var file_ext = download_infos[i][2] ? download_infos[i][2] : "";
                    var filename = download_infos[i][3];
                    var target_file = folder.clone();
                    
                    
                    var base_name = filename;
                    if(!base_name)
                    {
                        base_name = filename_from_url(source_uri.spec);
                        if(file_ext)
                        {
                            var m = /\.([^.]*)$/.exec(base_name);
                            if(!m || m.length != 2 || m[1] != file_ext)
                            {
                                base_name = base_name + "." + file_ext;
                            }
                        }
                    }
                    
                    target_file.append(base_name);
                    for(var z = 1; true; z++)
                    {
                        if(target_file.exists())
                        {
                            target_file.leafName = "(" + z + ") " + base_name;
                        }
                        else
                        {
                            try
                            {
                                target_file.create(0, 0644);//this marks the file as being created so that we do not overwrite it later
                            }
                            catch(e)
                            {
                                LOG("Cannot create: " + target_file.leafName);
                            }
                            break;
                        }
                    }
                    var target_uri = ioService.newFileURI(target_file)
                    var persist = Components.classes["@mozilla.org/embedding/browser/nsWebBrowserPersist;1"]
                                        .createInstance(Components.interfaces.nsIWebBrowserPersist);
                    persist.persistFlags = Components.interfaces.nsIWebBrowserPersist.PERSIST_FLAGS_AUTODETECT_APPLY_CONVERSION;
                    download = downloadManager.addDownload(Components.interfaces.nsIDownloadManager.DOWNLOAD_TYPE_DOWNLOAD, 
                                                           source_uri, target_uri, target_file.leafName, null, 
                                                           Date.now() * 1000, null, persist);
                    persist.progressListener = download.QueryInterface(Components.interfaces.nsIWebProgressListener);
                    persist.saveURI(source_uri, null, referrerURI, null, null, target_file);
                    //set_message("Downloading %1 urls - this may take a while, please wait...".replace(/%1/g, download_infos.length - i - 1));
                }
                if(download)
                {
                    if(downloadManagerUI.visible)
                    {
                        if(prefManager.getBoolPref("browser.download.manager.focusWhenStarting"))
                        {
                            downloadManagerUI.getAttention();
                        }
                    }
                    else
                    {
                        if(prefManager.getBoolPref("browser.download.manager.showWhenStarting"))
                        {
                            downloadManagerUI.show(null, download, Components.interfaces.nsIDownloadManagerUI.REASON_NEW_DOWNLOAD);
                        }
                    }
                }
                //message_window.close();
            };
            var message_window = window.openDialog("chrome://smarterwiki/content/message_window.xul", "", features, 
                                    SmarterWiki.strbundle.getString("please_wait"), 
                                    SmarterWiki.strbundle.getString("downloading_please_wait").replace(/%1/g, download_infos.length),
                                    callback2);
        };
        window.openDialog(xulURL, "", features, callback);
    };

    return {
        init: function()
        {
            loadStuff();

            setupExitSurvey();

            setupAwesomebar();

            setupFirstRun();

            //migrateBookmarks();

            var menu = document.getElementById("contentAreaContextMenu");
            menu.addEventListener("popupshowing", SmarterWiki.onPopupshowing, false);

            var appcontent = document.getElementById("appcontent");   // browser
            if(appcontent)
            {
                appcontent.addEventListener("DOMContentLoaded", SmarterWiki.onPageLoad, true);
                /*
                //injecting jQuery on DOMContentLoaded can cause problems. :(
                appcontent.addEventListener("load", SmarterWiki.onPageLoad, true);
                */
            }

            window.addEventListener("mouseup", function(event)
            {
                doAutoCopy();
            }, true);
            window.addEventListener("keydown", function(event)
            {
                doAutoCopy();
            }, false);
            window.addEventListener("mousedown", function(event)
            {
                if(
                    (prefManager.getBoolPref(prefPrefix + "enable_middle_click_paste") && event.button == 1) ||                
                    (prefManager.getBoolPref(prefPrefix + "enable_right_click_paste") && event.button == 2)
                )
                {
                    setTimeout(function() // allow focus to shift
                    {
                        goDoCommand('cmd_paste');
                    }, 10);
                }
            }, false);
            SmarterWiki.strbundle = document.getElementById("smarterwiki_strings");            
        },

        showOptions: function()
        {
            var windows = Components.classes["@mozilla.org/appshell/window-mediator;1"]
                          .getService(Components.interfaces.nsIWindowMediator)
                          .getEnumerator(null);
            var windowId = "smarterwikiOptions";
            while(windows.hasMoreElements())
            {
                var wind = windows.getNext()
                           .QueryInterface(Components.interfaces.nsIDOMWindowInternal);
                if(wind.document.documentElement.getAttribute("id") == windowId)
                {
                    wind.focus();
                    return wind;
                }
            }

            const optionsURL = "chrome://smarterwiki/content/options.xul";
            const features = "chrome, all, dialog=no, centerscreen";
            return window.openDialog(optionsURL, "", features);
        },

        onPopupshowing: function()
        {
            if(gContextMenu)
            {
                if(!prefManager.getBoolPref(prefPrefix + "show_context_menu_additions"))
                {
                    document.getElementById("smarterwiki-download-media").hidden = true;
                    document.getElementById("smarterwiki-download-links").hidden = true;
                    document.getElementById("smarterwiki-download-images").hidden = true;
                    document.getElementById("smarterwiki-download-selection").hidden = true;
                    document.getElementById("smarterwiki-remove-selection").hidden = true;
                    //document.getElementById("smarterwiki-search-selection").hidden = true; //don't disable this one                     
                }
                else
                {
                    document.getElementById("smarterwiki-download-media").hidden = false;
                    document.getElementById("smarterwiki-download-links").hidden = false;
                    document.getElementById("smarterwiki-download-images").hidden = false;
                    document.getElementById("smarterwiki-download-selection").hidden = false;
                    document.getElementById("smarterwiki-remove-selection").hidden = false;
                    
                    document.getElementById("smarterwiki-download-links").label = SmarterWiki.strbundle.getString("download_page_links") + " (" + 
                                        SmarterWiki.getPageLinks().length + ")";
                    document.getElementById("smarterwiki-download-images").label = SmarterWiki.strbundle.getString("download_page_images") + " (" + 
                                        SmarterWiki.getPageImages().length + ")";

                    var remove_selection_menuitem = document.getElementById("smarterwiki-remove-selection");
                    if(remove_selection_menuitem)
                    {
                        remove_selection_menuitem.hidden = !gContextMenu.isTextSelection();
                    }

                    var download_selection_menuitem = document.getElementById("smarterwiki-download-selection");
                    if(download_selection_menuitem)
                    {
                        download_selection_menuitem.hidden = !gContextMenu.isTextSelection();
                    }

                    var download_media_menuitem = document.getElementById("smarterwiki-download-media");
                    if(download_media_menuitem)
                    {
                        var SW_media_requests = SmarterWiki.getPageMedia();
                        download_media_menuitem.hidden = SW_media_requests.length ? false : true;
                        if(SW_media_requests.length)
                        {
                            download_media_menuitem.label = SmarterWiki.strbundle.getString("download_page_media") + " (" + 
                                                                SW_media_requests.length + ")";
                        }
                    }
                }
                var menuitem = document.getElementById("smarterwiki-search-selection");
                if(menuitem)
                {
                    menuitem.hidden = !gContextMenu.isTextSelection();
                    //var selection = window.content.getSelection();
                    var focusedWindow = document.commandDispatcher.focusedWindow;
                    var selection = focusedWindow.getSelection();                
                    var selectionStr = selection.toString();
                    var maxStrLength = 15;
                    if(selectionStr.length > maxStrLength)
                    {
                        selectionStr = selectionStr.substring(0, maxStrLength) + "...";
                    }

                    var search_wikipedia_for = SmarterWiki.strbundle.getString("search_wikipedia_for");
                    menuitem.label = search_wikipedia_for.replace(/%1/g, selectionStr);
                }
            }    
        },
        
        getPageLinks: function()
        {
            var download_infos = [];
            var added_urls = [];
            var doc = document.commandDispatcher.focusedWindow.document;
            var a_s = doc.getElementsByTagName("a");
            for(var i = 0; i < a_s.length; i++)
            {
                var url = a_s[i].toString();
                if(!(url in added_urls))
                {
                    if(url.indexOf("http") == 0 || url.indexOf("ftp") == 0)
                    {
                        download_infos.push([ioService.newURI(url, null, null), 
                            doc.documentURI ? ioService.newURI(doc.documentURI, null, null) : null,
                            null, null]);
                        added_urls[url] = null;
                        //                        document.referrer && ioService.newURI(document.referrer, null, null) || null,
                    }
                }                
                else
                {
                    LOG("Duplicate url found: " + url);
                }
            }
            return download_infos;
        },

        doDownloadPageLinks: function()
        {
            downloadURLs(SmarterWiki.getPageLinks());
        },
        
        getPageImages: function()
        {
            var content_type_to_ext = {
                "video/x-flv": "flv", 
                "application/x-shockwave-flash": "swf",
                "image/jpeg": "jpg",
                "image/png": "png",
                "image/x-icon": "ico",
                };

            var download_infos = [];
            var added_urls = [];
            var doc = document.commandDispatcher.focusedWindow.document;
            var img_s = doc.getElementsByTagName("img");
            for(var i = 0; i < img_s.length; i++)
            {
                var src = img_s[i].src;
                var uri = ioService.newURI(src, null, ioService.newURI(document.documentURI, null, null));
                var url = uri.spec;
                if(!(url in added_urls))
                {
                    var file_ext = null;
                    if(doc.SW_uri_content_type && uri.spec in doc.SW_uri_content_type)
                    {
                        file_ext = content_type_to_ext[doc.SW_uri_content_type[uri.spec]];
                    }
                    download_infos.push([uri, 
                                doc.documentURI ? ioService.newURI(doc.documentURI, null, null) : null,
                                file_ext, null]);
                                //document.referrer && ioService.newURI(document.referrer, null, null) || null,
                    added_urls[url] = null;
                }
                else
                {
                    //LOG("Duplicate url found: " + url);
                }
            }
            return download_infos;
        },
        
        doDownloadPageImages: function()
        {
            downloadURLs(SmarterWiki.getPageImages());
        },

        getPageMedia: function()
        {
            var download_infos = [];
            var added_urls = [];
            var SW_media_requests = document.commandDispatcher.focusedWindow.document.SW_media_requests;
            if(!SW_media_requests)
            {
                return [];
            }
            LOG("FOUND MEDIA_LINKS IN RESPONSE TO MENU CLICK: " + SW_media_requests);
            for(var i = 0; i < SW_media_requests.length; i++)
            {
                var url = SW_media_requests[i][0].spec;
                if(!(url in added_urls))
                {
                    download_infos.push(SW_media_requests[i]);//[SW_media_requests[i][0], SW_media_requests[i][1]]);
                    added_urls[url] = null;
                }
                else
                {
                    //LOG("Duplicate url found: " + url);
                }
            }
            return download_infos;
        },
        
        doDownloadPageMedia: function()
        {
            downloadURLs(SmarterWiki.getPageMedia());
        },

        doDownloadSelection: function()
        {
            var focusedWindow = document.commandDispatcher.focusedWindow;
            var selection = focusedWindow.getSelection();
            var urls = [];
            var img_s = focusedWindow.document.getElementsByTagName("img");
            for(var i = 0; i < img_s.length; i++)
            {
                if(selection.containsNode(img_s[i], true))
                {
                    var src = img_s[i].src;
                    urls.push(ioService.newURI(src, null, ioService.newURI(document.documentURI, null, null)).spec);
                }
            }
            var a_s = focusedWindow.document.getElementsByTagName("a");
            for(var i = 0; i < a_s.length; i++)
            {
                if(selection.containsNode(a_s[i], true))
                {
                    var url = a_s[i].toString();
                    if(url.indexOf("http") == 0 || url.indexOf("ftp") == 0)
                    {
                        urls.push(url);
                    }
                }
            }

            downloadURLs(urls, document.referrer);
        },

        doSearchSelection: function()
        {
            var focusedWindow = document.commandDispatcher.focusedWindow;
            var selection = focusedWindow.getSelection();
            var selectionStr = selection.toString();

            var gBrowser = getBrowser();
            gBrowser.selectedTab = gBrowser.addTab(searchWikipediaURL(selectionStr));
                //"http://smarterfox.com/wikisearch/?cx=016740879849949512001:hflecwcqo2c&cof=FORID:10&ie=UTF-8&q=" + escape(selectionStr) + "&sa=Search"
                //, "http://bitstr.org/enhancewikipedia/?");
        },
        
        doRemoveSelection: function()
        {
            var selection = document.commandDispatcher.focusedWindow.getSelection();
            selection.deleteFromDocument();
            selection.collapseToStart();
        },
       
        onPageLoad: function(aEvent)
        {
            var doc = aEvent.originalTarget; // doc is document that triggered "onload" event
            if(doc.nodeName != "#document" || !doc.location
                || doc.location.href.indexOf("chrome://") == 0
                || doc.location.href.indexOf("about:") == 0)
            {
                return;
            }
            LOG("doc loaded: " + doc.location.href);
            LOG("PlacesCommandHook: " + PlacesCommandHook);


            var $ = SmarterWiki.$;

            var privilegeWrap = function(obj, meth)
            {
               var f = function() {
                   return meth.apply(obj, arguments);
               };
               f.__exposedProps__ = {"apply": "r"};
               return f;
            };

            var sandbox = new Components.utils.Sandbox(doc.defaultView); //window
            sandbox.SW_$get = privilegeWrap($, $.get); 
            sandbox.SW_getBoolPref = privilegeWrap(prefManager, prefManager.getBoolPref);
            sandbox.SW_setBoolPref = privilegeWrap(prefManager, prefManager.setBoolPref);
            sandbox.SW_getCharPref = privilegeWrap(prefManager, prefManager.getCharPref);
            sandbox.SW_LOG = privilegeWrap(null, get_logger("smarterwiki-content-script: "));
            sandbox.SW_getShortcuts = privilegeWrap(null, getShortcuts);
            sandbox.SW_hasShortcuts = privilegeWrap(null, hasShortcuts);
            sandbox.SW_addShortcut = privilegeWrap(null, addShortcut);
            sandbox.SW_getFaviconURL = privilegeWrap(null, getFaviconURL);
            sandbox.SW_openNewTab = privilegeWrap(null, openNewTab);
            sandbox.SW_removeBookmark = privilegeWrap(null, removeBookmark);
            sandbox.SW_showBookmarkCurrentPageEdit = privilegeWrap(null, showBookmarkCurrentPageEdit);
            sandbox.SW_showOptions = privilegeWrap(SmarterWiki, SmarterWiki.showOptions);

            sandbox.unsafeWindow = doc.defaultView.wrappedJSObject;
            sandbox.window = doc.defaultView;
            sandbox.document = sandbox.window.document;
            sandbox.XPathResult = Components.interfaces.nsIDOMXPathResult; // hack XPathResult
            sandbox.__proto__ = doc.defaultView;
            
            if(doc.location.protocol == "https:" && doc.location.host == "smarterfox.com")            
            {
                //enable https://smarterfox.com to read prefs, but only FastestFox prefs
                var sandboxed_getBoolPref = function(pref_name) {
                    if(pref_name.indexOf("extensions.smarterwiki.") == 0) {
                        //allow
                        return prefManager.getBoolPref(pref_name);
                    }
                    else {
                        return null;
                    }
                };
                
                sandbox.unsafeWindow.SW_getBoolPref = privilegeWrap(null, sandboxed_getBoolPref);
                
                var enableOptionalPrefs = function()
                {
                    //get user confirmation
                    var notifyBox = window.getNotificationBox(doc.defaultView);
                    var notification = notifyBox.getNotificationWithValue('fastestfox-enable');
                    var message = "Enable extra search results from FastestFox?";
                    if(!notification) 
                    {
                        var buttons = [{
                            label: "Enable (Recommended)",
                            accessKey: "E",
                            popup: null,
                            callback: function() {
                                prefManager.setBoolPref("extensions.smarterwiki.add_similar_product_search", true);
                                prefManager.setBoolPref("extensions.smarterwiki.add_related_search_results_amazon", true);
                                prefManager.setBoolPref("extensions.smarterwiki.add_related_shopping_results", true);
                                prefManager.setBoolPref("extensions.smarterwiki.add_price_comparison_results", true);
                                prefManager.setBoolPref("extensions.smarterwiki.add_extra_search_results", true);
                                prefManager.setBoolPref("extensions.smarterwiki.enable_optional_features", true);
                                prefManager.setBoolPref("extensions.smarterwiki.add_related_search_results", true);
                                prefManager.setBoolPref("extensions.smarterwiki.add_related_pages", true);
                                prefManager.setBoolPref("extensions.smarterwiki.user_opted_in", true);
                            }
                        }, {
                            label: "Disable",
                            accessKey: "D",
                            popup: null,
                            callback: function(){}                            
                        }];
                        const priority = notifyBox.PRIORITY_INFO_HIGH;
                        notifyBox.appendNotification(message, 'fastestfox-enable',
                             null, priority, buttons);
                    }
                };
                sandbox.unsafeWindow.enableOptionalPrefs = privilegeWrap(null, enableOptionalPrefs);
            }

            sandbox.window.add_this_shortcut = SmarterWiki.strbundle.getString("add_this_shortcut");
            sandbox.window.delete_this_shortcut = SmarterWiki.strbundle.getString("delete_this_shortcut");
            sandbox.window.press_space_to_search = SmarterWiki.strbundle.getString("press_space_to_search");
            sandbox.window.confirm_bookmark_delete = SmarterWiki.strbundle.getString("confirm_bookmark_delete");
            sandbox.window.page_str = SmarterWiki.strbundle.getString("page_str");
            sandbox.window.loading_next_page_str = SmarterWiki.strbundle.getString("loading_next_page_str");
            sandbox.window.also_search_on = SmarterWiki.strbundle.getString("also_search_on");
            sandbox.window.confirm_disable = SmarterWiki.strbundle.getString("confirm_disable");
            sandbox.window.disable_label = SmarterWiki.strbundle.getString("disable_label");
            sandbox.window.more_results_str = SmarterWiki.strbundle.getString("more_results");
            
            
            Components.utils.evalInSandbox(jquery_js, sandbox, "1.8", "chrome://smarterwiki/content/jquery.js", 1);
            var eval_scripts = function(i)
            {
                if(i >= js_filenames.length) {
                    return;
                }
                if(!file_text[js_filenames[i]])
                {
                    async_get_file(js_filenames[i], function(text)
                    {
                        file_text[js_filenames[i]] = text;
                        Components.utils.evalInSandbox(file_text[js_filenames[i]], sandbox, "1.0", "chrome://smarterwiki/" + js_filenames[i], 1);
                        eval_scripts(i+1);
                    });
                }
                else
                {
                    Components.utils.evalInSandbox(file_text[js_filenames[i]], sandbox, "1.0", "chrome://smarterwiki/" + js_filenames[i], 1);
                    eval_scripts(i+1);
                }
            };
            eval_scripts(0);
        },
    };
};

window.addEventListener("load", function()
{
    setTimeout(function() {
        SmarterWiki = SmarterWiki();
        SmarterWiki.init();
    }, 1.);//wait a bit so that other components load
}, false);
