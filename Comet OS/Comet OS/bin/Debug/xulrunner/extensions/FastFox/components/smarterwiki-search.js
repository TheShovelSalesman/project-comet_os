Components.utils.import("resource://gre/modules/XPCOMUtils.jsm");

function LOG(msg)
{
    var enabled = false;
    if(enabled)
    {
        var consoleService = Components.classes["@mozilla.org/consoleservice;1"].getService(Components.interfaces.nsIConsoleService);
        consoleService.logStringMessage("smarterwiki smarterwiki-search.js: " + msg);
    }
}

// Implements nsIAutoCompleteResult
function SearchAutoCompleteResult(result, search_result, maxNumResults) 
{
    this._result = result;
    this._search_result = search_result;
    this._maxNumResults = maxNumResults;
    LOG("SearchAutoCompleteResult: " + result.searchString + " " + result.searchResult + " " + result.defaultIndex + " " + result.errorDescription + " " + result.matchCount);
    //LOG(result.getValueAt(1000));
};

SearchAutoCompleteResult.prototype = 
{
    get searchString() 
    {
        return this._result.searchString;
    },

    get searchResult()
    {
        LOG("searchResult(): " + this.searchResult2);
        return this.searchResult2;
    },

    get searchResult2() 
    {
        switch(this._result.searchResult)
        {
            case Components.interfaces.nsIAutoCompleteResult.RESULT_NOMATCH:
                if(this._search_result.values == null) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_NOMATCH_ONGOING;
                } else if(this._search_result.values.length > 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS;
                } else if(this._search_result.values.length == 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_NOMATCH;
                }
                break;
            case Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS:
                if(this._search_result.values == null) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING;
                } else if(this._search_result.values.length > 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS;
                } else if(this._search_result.values.length == 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS;
                }
                break;
            case Components.interfaces.nsIAutoCompleteResult.RESULT_NOMATCH_ONGOING:
                if(this._search_result.values == null) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_NOMATCH_ONGOING;
                } else if(this._search_result.values.length > 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING;
                } else if(this._search_result.values.length == 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_NOMATCH_ONGOING;
                }
                break;
            case Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING:
                if(this._search_result.values == null) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING;
                } else if(this._search_result.values.length > 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING;
                } else if(this._search_result.values.length == 0) {
                    return Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING;
                }
                break;
            default:
                return this._result.searchResult;
        }
    },
    
    get defaultIndex() 
    {
        if(this._result.defaultIndex == -1 &&
            this._search_result.values != null && this._search_result.values.length > 0)
        {
            return 0;
        }
        return this._result.defaultIndex;
    },
    
    get errorDescription() 
    {
        return this._result.errorDescription;
    },

    get matchCount()
    {
        var c = Math.min(this._result.matchCount, this._maxNumResults);
        if(this._search_result.values != null)
        {
            c += this._search_result.values.length;
        }
        return c;    
        //return this._result.matchCount;
    },
    
    getValueAt: function(index) 
    {//FF3
        var numResults = Math.min(this._result.matchCount, this._maxNumResults);
        if(index < numResults)
        {
            return this._result.getValueAt(index);
        }
        else
        {
            return this._search_result.values[index - numResults];
        }
    }, 
    
    getLabelAt: function(index) 
    {//FF4
        var numResults = Math.min(this._result.matchCount, this._maxNumResults);
        if(index < numResults)
        {
            return this._result.getLabelAt(index);
        }
        else
        {
            return this._search_result.values[index - numResults];
        }
    }, 

    getCommentAt: function(index) 
    {
        var numResults = Math.min(this._result.matchCount, this._maxNumResults);
        if(index < numResults)
        {
            return this._result.getCommentAt(index);
        }
        else
        {
            LOG("getCommentAt(" + index + "): " + this._search_result.comments[index - numResults]);
            return this._search_result.comments[index - numResults]
                .replace(/&quot;/g, '"')
                .replace(/&amp;/g, '&')
                .replace(/&lt;/g, '<')
                .replace(/&gt;/g, '>');
        }
    },
    
    getStyleAt: function(index) 
    {
        if(index < Math.min(this._result.matchCount, this._maxNumResults))
        {
            return this._result.getStyleAt(index);
        }
        else
        {
            if(index == 0) //_result might be empty
            {
                return "suggestfirst smarterwiki-suggest";  // category label on first line of results
            }
            else
            {
                return "suggesthint smarterwiki-suggest";   // category label on any other line of results
            }
        }
    },
    
    getImageAt: function(index) 
    {
        var numResults = Math.min(this._result.matchCount, this._maxNumResults);
        if(index < numResults)
        {
            return this._result.getImageAt(index);
        }
        else
        {
            return "chrome://smarterwiki/skin/smarterfox-logo-32x32.png";//"moz-anno:favicon:http://www.google.com/favicon.ico";
        }
    },
    
    removeValueAt: function(index, removeFromDb) 
    {
        var numResults = Math.min(this._result.matchCount, this._maxNumResults);
        if(index < numResults)
        {
            return this._result.removeValueAt(index, removeFromDb);
        }
        else
        {
            this._search_result.values.splice(index - numResults, 1);
            this._search_result.comments.splice(index - numResults, 1);
        }
    },

    QueryInterface: XPCOMUtils.generateQI([Components.interfaces.nsIAutoCompleteResult]),
};


var JSON = Components.classes["@mozilla.org/dom/json;1"].createInstance(Components.interfaces.nsIJSON);


function SmarterWikiAutoCompleteSearch() { }

SmarterWikiAutoCompleteSearch.prototype = 
{
    classDescription: "FastestFox Auto-Complete Search Javascript XPCOM Component",
    classID:          Components.ID("bd8cdff6-4312-43e1-b215-1663e9e8a2e2"),
    contractID:       "@mozilla.org/autocomplete/search;1?name=smarterwiki-search",
    QueryInterface:   XPCOMUtils.generateQI([Components.interfaces.nsIAutoCompleteSearch]),
    startSearch:      function(searchString, searchParam, previousResult, listener)
    {
        this.historyAutoComplete =
                Components.classes["@mozilla.org/autocomplete/search;1?name=history"]
                .createInstance(Components.interfaces.nsIAutoCompleteSearch);

        var prefManager = Components.classes["@mozilla.org/preferences-service;1"]
                                   .getService(Components.interfaces.nsIPrefBranch);

        var _search = this;
        _search._result = null;
        var search_result = {values: null, comments: null};
        var searchAutoCompleteResult = null;
        autoCompleteObserver = 
        {
            onSearchResult: function(search, result)
            {
                _search._result = result;
                listener.onSearchResult(_search, new SearchAutoCompleteResult(result, search_result, prefManager.getIntPref("extensions.smarterwiki.num_urlbar_from_history")));
            }
        };
        LOG(previousResult + ": " + previousResult);
        this.historyAutoComplete.startSearch(searchString, searchParam, null, autoCompleteObserver);//previousResult
        

        var req = Components.classes["@mozilla.org/xmlextras/xmlhttprequest;1"].createInstance();
        req.open("GET", "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&q=" + encodeURIComponent(searchString));
        //req.setRequestHeader("Referer", "http://smarterfox.com/");
        req.addEventListener("load", function(event)
        {
            LOG("SmarterWikiAutoCompleteSearch got results");
            var data = JSON.decode(req.responseText);
            LOG(req.responseText);
            if(data["responseData"])
            {
                var values = [];
                var comments = [];
                for(var i in data["responseData"]["results"])
                {
                    values.push(data["responseData"]["results"][i]["unescapedUrl"]);
                    comments.push(data["responseData"]["results"][i]["titleNoFormatting"]);
                }
                search_result.values = values;
                search_result.comments = comments;
                LOG(_search._result);
                LOG("SmarterWikiAutoCompleteSearch got results end");
                if(_search._result != null)
                {
                    listener.onSearchResult(_search, 
                        new SearchAutoCompleteResult(_search._result, search_result, 4)
                    );
                }
                /*
                else
                {
                    listener.onSearchResult(_search, 
                        new SearchAutoCompleteResult(
                            searchString,
                            Components.interfaces.nsIAutoCompleteResult.RESULT_SUCCESS_ONGOING,
                            0,
                            "",
                            values, comments)
                    );
                }
                */
            }
        }, false);
        req.send(null);
        this._req = req;


        LOG("startSearch: " + searchString);
    },

    stopSearch:       function()
    {
        LOG("abort() called");
        this.historyAutoComplete.stopSearch();
        if(this._req)
        {
            this._req.abort();
        }
        LOG("successfully aborted");
    },
};






function NSGetModule(compMgr, fileSpec) 
{
    return XPCOMUtils.generateModule([SmarterWikiAutoCompleteSearch]);
}

if(XPCOMUtils.generateNSGetFactory)
{
    var NSGetFactory = XPCOMUtils.generateNSGetFactory([SmarterWikiAutoCompleteSearch]);
}