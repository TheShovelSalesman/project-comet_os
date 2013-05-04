//Copyright: 2012 Yongqian Li
EXTENSION_NAME = 'FastestFox';

var safe_SW_getBoolPref = function(name)
{
    try
    {
        return SW_getBoolPref(name);
    }
    catch(err)
    {
        return null;
    }
};

var safe_SW_getCharPref = function(name)
{
    try
    {
        return SW_getCharPref(name);
    }
    catch(err)
    {
        return null;
    }
};

var getStringPref = function(pref_name, callback)
{
    callback(safe_SW_getCharPref("extensions.smarterwiki." + pref_name));
};

var getBoolPref = function(pref_name, callback)
{
    callback(safe_SW_getBoolPref("extensions.smarterwiki." + pref_name));
};

var setBoolPref = function(pref_name, pref_val, callback)
{
    SW_setBoolPref("extensions.smarterwiki." + pref_name, pref_val);
    if(callback) {
        callback();
    }
};

var get_localized_message = function(msg_name, default_msg, substitution)
{
    var msg = default_msg;
    if(substitution) {
        msg = msg.replace('{0}', substitution);
    }
    return msg;
};

$.get = function(url, data, callback, type)
{
    SW_$get(url, data, function(data, textStatus)
    {
        if(callback)
        {
            if(type == 'json') {
                callback(JSON.parse(data), textStatus);
            }
            else {
                callback(data, textStatus);
            }
        }
    }, 'html');            
}; //prevents logging of referer

LOG_ERROR = SW_LOG;

