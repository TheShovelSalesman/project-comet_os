//Copyright: 2012 Yongqian Li

(function()
{
    var also_search_on = window.also_search_on || "Also search on: ";
    var confirm_disable = window.confirm_disable || "Are you sure you want to disable this?\n\nTo re-enable, go to Tools -> SmarterFox";
    var disable_str = window.disable_label || "disable";
    

    
    var get_log_msg_url = function(msg)
    {
        msg["rand"] = parseInt(Math.random() * 1000000000);
        var params = [];
        for(var k in msg)
        {
            params.push(encodeURIComponent(k) + "=" + encodeURIComponent(msg[k]));
        }
        /*
        if("https:" == document.location.protocol)
        {
            return "https://ssl.msgs.smarterfox.com/log_msg?" + params.join("&");
        }
        */
        return "http://msgs.smarterfox.com/log_msg?" + params.join("&");
    };
    

    var log_msg_async = function(msg, callback)
    {
        var $ting = $('<img style="display: none;" />');
        if(callback)
        {
            $ting.load(callback);
        }
        $ting.attr("src", get_log_msg_url(msg));
        return $ting;
    };

    var track_click = function($a, msg)
    {
        $a.mouseup(function(event)
        {
            var original_href = $a.attr("href");
            msg["redirect_to"] = original_href;
            $a.attr("href", get_log_msg_url(msg));

            setTimeout(function()
            {
                $a.attr("href", original_href);
            }, 10);
        });
    };        
    
    

    var add_related_searches = function(doc)
    {
        var getSearchResultsURL = function(url, terms)
        {
            var language = navigator.language ? navigator.language : navigator.userLanguage;
            var url = url.replace(/{searchTerms}/g, encodeURIComponent(terms));
            url = url.replace(/{language}/g, language);
            return url;
        };

        var searchWikipediaURL = "http://smarterfox.com/wikisearch/search?q={searchTerms}&locale={language}";
        var searchDDGURL = "http://duckduckgo.com/?q={searchTerms}";
        var searchYandexURL = "http://yandex.ru/yandsearch?text={searchTerms}&clid=127505";
        var searchDeliciousURL = "http://delicious.com/search?p={searchTerms}";
        var searchTwitterURL = "http://search.twitter.com/search?q={searchTerms}";
        var tweetThisURL = "http://twitter.com/home?status={searchTerms}";
        var searchBingURL = "http://www.bing.com/search?q={searchTerms}";
        var searchBaiduURL = "http://www.baidu.com/s?wd={searchTerms}";
        var searchRedditURL = "http://www.reddit.com/search?q={searchTerms}";
        var searchYouTubeURL = "http://www.youtube.com/results?search_query={searchTerms}";
        var searchGoogleURL = "http://www.google.com/search?q={searchTerms}";
        var searchAmazonURL = "http://www.amazon.com/s?ie=UTF8&index=blended&field-keywords={searchTerms}&tag=smtfx1-20";
        var searchYahooURL = "http://search.yahoo.com/search?p={searchTerms}";
        var searchSurfCanyonURL = "http://search.surfcanyon.com/search?f=nrl1&q={searchTerms}&partner=fastestfox";
        

        var get_$related_searches_inline = function(queryTerms, addSearchEngines, se_class)
        {
            //log_msg_async({name: "related_searches_inserted", source: "smarterfox", type: "inline"});

            var $container = $('<span id="related-searches" class="inline related-searches-' + se_class + '"></span>', doc);

            var $delete_button = $('<a href="#" title="' + disable_str + '" id="smarterwiki-disable-button"></a>')
                .click(function(event)
                {
                    if(doc.defaultView.confirm(confirm_disable))
                    { 
                        setBoolPref("add_related_searches", false);
                        $container.fadeOut("normal", function()
                            {
                                $container.remove();
                            });
                    }
                    return false;
                });
                
    
            var addSearchEngine = function(favicon, title, searchURL)
            {
                var $a = $('<a class="search-engine-link" href="' + searchURL + '" title="' + title + '">' + 
                            '<img class="search-engine-favicon" src="' + favicon + '" alt="' + title + '" />' + 
                            '</a>'
                          ).attr("target", "_blank");
                $a.appendTo($container);
                track_click($a, {name: "related_searches_searched", "title": title, source: "smarterfox"});
                return $a;
            }
    
            addSearchEngines(addSearchEngine);
            
            $delete_button.appendTo($container);            
            return $container;
        };

        var get_$related_searches = function(queryTerms, addSearchEngines, se_class)
        {
            //log_msg_async({name: "related_searches_inserted", source: "smarterfox"});

            var $container = $('<div id="related-searches" class="boxed related-searches-' + se_class + '"></div>', doc);
            
            var $top_container = $('<div class="smarterwiki-clearfix"></div>', doc).appendTo($container);

            $('<label id="related-searches-label" title="More searches">' + also_search_on + '</label>').appendTo($top_container);

            var $delete_button = $('<a href="#" title="' + disable_str + '" id="smarterwiki-disable-button"></a>')
                .click(function(event)
                {
                    if(doc.defaultView.confirm(confirm_disable))
                    { 
                        setBoolPref("add_related_searches", false);
                        $container.slideUp("normal", function()
                            {
                                $container.remove();
                            });
                    }
                    return false;
                })
                .appendTo($top_container);

           
            var $ulist = $('<ul class="smarterwiki-clearfix" id="related-searches-list"></ul>').appendTo($container);
            
            var addSearchEngine = function(favicon, title, searchURL)
            {
                var $a = $('<a class="search-engine-link" href="' + searchURL + '" title="' + title + '">' + 
                            '<img class="search-engine-favicon" src="' + favicon + '" alt="' + title + '" />' + 
                            '<span class="search-engine-label">' + title + '</span>' + 
                            '</a>'
                          ).attr("target", "_blank");
                $('<li class="related-searches-list-item"></li>').append(
                    $a
                ).appendTo($ulist);
                track_click($a, {name: "related_searches_searched", "title": title, source: "smarterfox"});
                return $a;
            }
            
            addSearchEngines(addSearchEngine);            
            return $container;
        };
        

        var googleURLRegExp = new RegExp("^http://www.google.(?:[^/]*)/(?:search\\?|#)(?:.*&)?q=([^&=]*)(.*)$");
        var match = googleURLRegExp.exec(doc.location.href);
        if(match)
        {
            //alert(doc.location.href + " matched");
            var insert_into_google = function(match)
            {
                var queryTerms = decodeURIComponent(match[1]).replace(/\+/g, " ");
                get_$related_searches(queryTerms, function(addSearchEngine)
                {
                    var $a = addSearchEngine(
                        'http://www.amazon.com/favicon.ico', 
                        'Amazon', 
                        getSearchResultsURL(searchAmazonURL, queryTerms));
                    $a.click(function()
                    {
                        SW_openNewTab($(this).attr("href"));
                        return false;
                    });
                    addSearchEngine(
                        'http://surfcanyon.com/favicon.ico', 
                        'Surf Canyon', 
                        getSearchResultsURL(searchSurfCanyonURL, queryTerms));
                    addSearchEngine(
                        'https://ff.duckduckgo.com/favicon.ico', 
                        'DuckDuckGo', 
                        getSearchResultsURL(searchDDGURL, queryTerms));
                    addSearchEngine(
                        'http://www.yahoo.com/favicon.ico', 
                        'Yahoo', 
                        getSearchResultsURL(searchYahooURL, queryTerms));
                    addSearchEngine(
                        'http://twitter.com/favicon.ico', 
                        'Twitter', 
                        getSearchResultsURL(searchTwitterURL, queryTerms));
                }, "google").insertAfter($("#ssb", doc));                
            };

            document.addEventListener("DOMNodeInserted", function()
            {
                if($("#ssb", doc).length > 0 && $("#related-searches").length == 0)
                {
                    insert_into_google(googleURLRegExp.exec(doc.location.href));
                }
            }, false);

            return;
        }

        var yahooURLRegExp = new RegExp("^http://search.yahoo.com/search[^?]*\\?(?:.*&)?p=([^&=]*)(.*)$");
        match = yahooURLRegExp.exec(doc.location.href);
        if(match)
        {
            var queryTerms = decodeURIComponent(match[1]).replace(/\+/g, " ");
            get_$related_searches(queryTerms, function(addSearchEngine)
            {
                var $a = addSearchEngine(
                    'http://www.amazon.com/favicon.ico', 
                    'Amazon', 
                    getSearchResultsURL(searchAmazonURL, queryTerms));
                $a.click(function()
                {
                    SW_openNewTab($(this).attr("href"));
                    return false;
                });
                addSearchEngine(
                    'http://surfcanyon.com/favicon.ico', 
                    'Surf Canyon', 
                    getSearchResultsURL(searchSurfCanyonURL, queryTerms));
                addSearchEngine(
                    'https://ff.duckduckgo.com/favicon.ico', 
                    'DDG', 
                    getSearchResultsURL(searchDDGURL, queryTerms));
                addSearchEngine(
                    'http://www.google.com/favicon.ico', 
                    'Google', 
                    getSearchResultsURL(searchGoogleURL, queryTerms));
                addSearchEngine(
                    'http://twitter.com/favicon.ico', 
                    'Twitter', 
                    getSearchResultsURL(searchTwitterURL, queryTerms));
            }, "yahoo").prependTo($("#main", doc));
        }


        var bingURLRegExp = new RegExp("^http://www.bing.com/search[^?]*\\?(?:.*&)?q=([^&=]*)(.*)$");
        match = bingURLRegExp.exec(doc.location.href);
        if(match)
        {
            var queryTerms = decodeURIComponent(match[1]).replace(/\+/g, " ");
            get_$related_searches(queryTerms, function(addSearchEngine)
            {
                var $a = addSearchEngine(
                    'http://www.amazon.com/favicon.ico', 
                    'Amazon', 
                    getSearchResultsURL(searchAmazonURL, queryTerms));
                $a.click(function()
                {
                    SW_openNewTab($(this).attr("href"));
                    return false;
                });
                addSearchEngine(
                    'http://surfcanyon.com/favicon.ico', 
                    'Surf Canyon', 
                    getSearchResultsURL(searchSurfCanyonURL, queryTerms));
                addSearchEngine(
                    'https://ff.duckduckgo.com/favicon.ico', 
                    'DuckDuckGo', 
                    getSearchResultsURL(searchDDGURL, queryTerms));
                /*
                addSearchEngine(
                    'http://www.yahoo.com/favicon.ico',
                    'Yahoo',
                    getSearchResultsURL(searchYahooURL, queryTerms));
                */
                addSearchEngine(
                    'http://twitter.com/favicon.ico', 
                    'Twitter', 
                    getSearchResultsURL(searchTwitterURL, queryTerms));
            }, "bing").prependTo($("#results_container", doc));
        }


        var baiduURLRegExp = new RegExp("^http://www.baidu.com/s[^?]*\\?(?:.*&)?wd=([^&=]*)(.*)$");
        match = baiduURLRegExp.exec(doc.location.href);
        if(match)
        {
            var queryTerms = decodeURIComponent(match[1]).replace(/\+/g, " ");
            get_$related_searches(queryTerms, function(addSearchEngine)
            {
                addSearchEngine(
                    'https://ff.duckduckgo.com/favicon.ico',
                    'DuckDuckGo',
                    getSearchResultsURL(searchDDGURL, queryTerms));
                addSearchEngine(
                    'http://www.yahoo.com/favicon.ico',
                    'Yahoo',
                    getSearchResultsURL(searchYahooURL, queryTerms));
                var $a = addSearchEngine(
                    'http://www.amazon.com/favicon.ico', 
                    'Amazon', 
                    getSearchResultsURL(searchAmazonURL, queryTerms));
                $a.click(function()
                {
                    SW_openNewTab($(this).attr("href"));
                    return false;
                });
                addSearchEngine(
                    'http://twitter.com/favicon.ico',
                    'Twitter',
                    getSearchResultsURL(searchTwitterURL, queryTerms));
                addSearchEngine(
                    'http://delicious.com/favicon.ico',
                    'del.icio.us',
                    getSearchResultsURL(searchDeliciousURL, queryTerms));
            }, "baidu").insertAfter($("body > table", doc)[1]);
        }
        
        var wikipediaURLRegExp = new RegExp("^http://.*\.wikipedia\.org/wiki/(.*)$");
        match = wikipediaURLRegExp.exec(doc.location.href);
        if(match)
        {
            var queryTerms = decodeURIComponent(match[1]).replace(/\+|_/g, " ");
            get_$related_searches_inline(queryTerms, function(addSearchEngine)
            {
                addSearchEngine(
                    'https://ff.duckduckgo.com/favicon.ico',
                    'DuckDuckGo',
                    getSearchResultsURL(searchDDGURL, queryTerms));
                addSearchEngine(
                    'http://www.yahoo.com/favicon.ico',
                    'Yahoo',
                    getSearchResultsURL(searchYahooURL, queryTerms));
                var $a = addSearchEngine(
                    'http://www.amazon.com/favicon.ico', 
                    'Amazon', 
                    getSearchResultsURL(searchAmazonURL, queryTerms));
                $a.click(function()
                {
                    SW_openNewTab($(this).attr("href"));
                    return false;
                });
                addSearchEngine(
                    'http://twitter.com/favicon.ico',
                    'Twitter',
                    getSearchResultsURL(searchTwitterURL, queryTerms));
                addSearchEngine(
                    'http://delicious.com/favicon.ico',
                    'del.icio.us',
                    getSearchResultsURL(searchDeliciousURL, queryTerms));
            }, "wikipedia").appendTo($("h1#firstHeading", doc));
        }
    };



    var doc = window.document;
    getBoolPref("add_related_searches", function(pref_value)
    {
        if(pref_value)
        {
            add_related_searches(doc);        
        }
    });
}());