//Copyright: 2012 Yongqian Li

(function()
{
    return; //disabled for now
    getBoolPref("add_related_articles", function(pref_value)
    {
        if(pref_value)
        {
            var doc = document;
            var urlRegExp = new RegExp("(http(?:|s)://en.wikipedia.org/wiki/)(.*)");
            var match = urlRegExp.exec(doc.location.href);
            if(match != null)
            {
                //on a Wikipedia page
                var wgPageName = match[2];//.replace("_", " ");
                var title_match = new RegExp("^(.*) - .*$").exec(doc.title);
                var wgArticleName = ""; //Main Page has no title in that format
                if(title_match)
                {
                    wgArticleName = title_match[1];
                }
                var wgArticlePath = match[1];
                //var locale = SW_getCharPref("general.useragent.locale");
                var locale = navigator.language;

                var addRelatedArticlesBox = function(html, textStatus)
                {
                    var searchPortlet = $('#p-search', doc);

                    if(searchPortlet && searchPortlet.attr("class") == "portlet")
                    {
                        var relatedPortlet = $('<div id="p-smarterwiki"></div>', doc);
                        relatedPortlet.addClass('portlet', doc);
                        relatedPortlet.append(html);
                        relatedPortlet.insertBefore(searchPortlet);  
                        /*
                        relatedPortlet.click(function()
                        {

                        });
                        */
                    }
                    else
                    {
                        var $navPortlet = $("#p-interaction");
                        var $relatedPortlet = $('<div id="p-smarterwiki"></div>', doc).addClass('portal', doc).append(html).insertBefore($navPortlet);
                        $relatedPortlet.find(".pBody").removeClass("pBody").addClass("body");  
                        $relatedPortlet.find("h5").text("Related articles");  
                    }
                };

                $.get("http://static.smarterfox.com/api/related_articles",
                    {'topic': wgArticleName,
                     'locale': locale,
                     'format': 'html_frag'}, addRelatedArticlesBox, "html");
            }
        }
    });
}());