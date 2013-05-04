Components.utils.import("resource://gre/modules/XPCOMUtils.jsm");

function LOG(msg)
{
    var enabled = false;
    if(enabled)
    {
        var consoleService = Components.classes["@mozilla.org/consoleservice;1"]
            .getService(Components.interfaces.nsIConsoleService);
        consoleService.logStringMessage("smarterwiki smarterwiki-http-observer.js: " + msg);
    }
}


function SmarterWikiHTTPObserver() { }

var getDOMWindow = function(contentWindow)
{
    try
    {
        return contentWindow.QueryInterface(Components.interfaces.nsIInterfaceRequestor)
                            .getInterface(Components.interfaces.nsIWebNavigation)
                            .QueryInterface(Components.interfaces.nsIDocShell)
                            .QueryInterface(Components.interfaces.nsIDocShellTreeItem).rootTreeItem
                            .QueryInterface(Components.interfaces.nsIInterfaceRequestor)
                            .getInterface(Components.interfaces.nsIDOMWindow).top;
    }
    catch(e)
    {
        return null;
    }
};


var content_type_to_ext = {
    "video/x-flv": "flv", 
    "application/x-shockwave-flash": "swf",
    "image/jpeg": "jpg",
    "image/png": "png",
    "image/x-icon": "ico",
    };

var media_types = {
    "flv": null,
    "swf": null,
};


SmarterWikiHTTPObserver.prototype = {
    observe: function(aSubject, aTopic, aData)
    {
        try
        {
            if(aTopic == "http-on-examine-response" ||
                aTopic == "http-on-examine-cached-response")
            {
                aSubject.QueryInterface(Components.interfaces.nsIHttpChannel);
                var httpChannel = aSubject;
                try
                {
                    var contentType = httpChannel.getResponseHeader("Content-Type");
                    if(contentType in content_type_to_ext)
                    {
                        LOG("Got: " + contentType);
                        var uri = httpChannel.originalURI;
                        try
                        {
                            var document = (httpChannel.notificationCallbacks || httpChannel.loadGroup.groupObserver)
                                                            .QueryInterface(Components.interfaces.nsIInterfaceRequestor)
                                                            .getInterface(Components.interfaces.nsIDOMWindow).document;

                            var doc = document;
                            for(var i = 0; i < 10; i++)//prevents infinite loop, just in case
                            {
                                if(!doc.SW_uri_content_type)
                                {
                                    doc.SW_uri_content_type = {};
                                }
                                doc.SW_uri_content_type[uri.spec] = contentType;
                                if(!doc.defaultView || doc == doc.defaultView.top)
                                {
                                    break;
                                }
                                else
                                {
                                    doc = doc.defaultView.parent.document;
                                }
                            }
                            
                            var file_ext = content_type_to_ext[contentType];
                            
                            if(file_ext in media_types)
                            {
                                var referrer = httpChannel.referrer;
                                var filename = null;
                                try
                                {
                                    //Example: Content-Disposition   'attachment; filename="video.flv"'
                                    var contentDisposition = httpChannel.getResponseHeader("Content-Disposition");
                                    filename = /attachment; filename="(.*)"/.exec(contentDisposition)[1]
                                }
                                catch(e) {}

                                try
                                {
                                    var contentLength = parseInt(httpChannel.getResponseHeader("Content-Length"));
                                    if(contentLength < 100 * 1024)
                                    {
                                        return;
                                    }
                                }
                                catch(e) {}
                                
                                doc = document;//document.defaultView.top;
                                for(var i = 0; i < 10; i++)//prevents infinite loop, just in case
                                {
                                    if(!doc.SW_media_requests)
                                    {
                                        doc.SW_media_requests = [];
                                    }
                                    doc.SW_media_requests.push([uri, referrer, file_ext, filename]);
                                    if(!doc.defaultView || doc == doc.defaultView.top)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        doc = doc.defaultView.parent.document;
                                    }
                                }
                                
                                LOG("uri: " + uri + " ref: " + referrer + " fileext: " + file_ext + " filename: " + filename);
                                /*
                                var browserWindow = getDOMWindow(document.defaultView.top);
                                if(browserWindow.wrappedJSObject)
                                {
                                    browserWindow = browserWindow.wrappedJSObject;
                                }
                                LOG(browserWindow.SmarterWiki);
                                */
                            }
                        }
                        catch(e)
                        {
                            LOG("ERROR: " + e);
                        }
                    }
                }
                catch(e) { }
            }
            
            if(aTopic == "app-startup" || aTopic == "profile-after-change") 
            {
                var observerService = Components.classes["@mozilla.org/observer-service;1"]
                             .getService(Components.interfaces.nsIObserverService);
                observerService.addObserver(this, "http-on-examine-response", false);
                observerService.addObserver(this, "http-on-examine-cached-response", false);
                LOG("registered everything!");
                return;
            }            
        }
        catch(e)
        {
            LOG("ERROR: " + e);
        }
    },    
    
    QueryInterface: function (iid) 
    {
        if(iid.equals(Components.interfaces.nsIObserver) ||
                iid.equals(Components.interfaces.nsISupports))
        {
            return this;
        }
        Components.returnCode = Components.results.NS_ERROR_NO_INTERFACE;
        return null;
    }
};

var _module = {
    registerSelf: function (compMgr, fileSpec, location, type) 
    {
        var compMgr = compMgr.QueryInterface(Components.interfaces.nsIComponentRegistrar);
        compMgr.registerFactoryLocation(this._classID,
                                        this._classDescription,
                                        this._contractID,
                                        fileSpec,
                                        location,
                                        type);

        var categoryManager = Components.classes["@mozilla.org/categorymanager;1"]
                                .getService(Components.interfaces.nsICategoryManager);
        categoryManager.addCategoryEntry("app-startup", this._classDescription, this._contractID, true, true);
    },

    _classID: Components.ID("{67d054a6-7173-47e4-bf4a-dcd77b88fa59}"),
    _classDescription: "FastestFox HTTP Observer Javascript XPCOM Component",
    _contractID: "@smarterwiki/http-observer;1",
    _factory: {
        QueryInterface: function(aIID) 
        {
            if (!aIID.equals(Components.interfaces.nsISupports) &&
                !aIID.equals(Components.interfaces.nsIFactory))
            {
                throw Components.results.NS_ERROR_NO_INTERFACE;
            }
            return this;
        },

        createInstance: function(outer, iid)
        {
            return new SmarterWikiHTTPObserver();
        }
    },

    getClassObject: function (compMgr, cid, iid) 
    {
        return this._factory;
    },

    canUnload: function(compMgr) 
    {
        return true;
    }
};

function NSGetModule(compMgr, fileSpec) 
{
    return _module;
}



function SmarterWikiHTTPObserver() { }

SmarterWikiHTTPObserver.prototype = 
{
    classDescription: "FastestFox HTTP Observer Javascript XPCOM Component",
    classID:          Components.ID("67d054a6-7173-47e4-bf4a-dcd77b88fa59"),
    contractID:       "@smarterwiki/http-observer;1",
    QueryInterface:   XPCOMUtils.generateQI([Components.interfaces.nsISupports, Components.interfaces.nsIFactory]),
    _xpcom_factory: {
        QueryInterface: function(aIID) 
        {
            if (!aIID.equals(Components.interfaces.nsISupports) &&
                !aIID.equals(Components.interfaces.nsIFactory))
            {
                throw Components.results.NS_ERROR_NO_INTERFACE;
            }
            return this;
        },

        createInstance: function(outer, iid)
        {
            return new SmarterWikiHTTPObserver();
        }
    }
};

if(XPCOMUtils.generateNSGetFactory)
{
    var NSGetFactory = XPCOMUtils.generateNSGetFactory([SmarterWikiHTTPObserver]);
}