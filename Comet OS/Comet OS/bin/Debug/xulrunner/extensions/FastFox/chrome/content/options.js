//only used from options.xul

(function()
{
    var prefManager = Components.classes["@mozilla.org/preferences-service;1"].getService(Components.interfaces.nsIPrefBranch);

    var DOM_VK_CANCEL = 3;
    var DOM_VK_HELP = 6;
    var DOM_VK_BACK_SPACE = 8;
    var DOM_VK_TAB = 9;
    var DOM_VK_CLEAR = 12;
    var DOM_VK_RETURN = 13;
    var DOM_VK_ENTER = 14;
    var DOM_VK_SHIFT = 16;
    var DOM_VK_CONTROL = 17;
    var DOM_VK_ALT = 18;
    var DOM_VK_PAUSE = 19;
    var DOM_VK_CAPS_LOCK = 20;
    var DOM_VK_ESCAPE = 27;
    var DOM_VK_SPACE = 32;
    var DOM_VK_PAGE_UP = 33;
    var DOM_VK_PAGE_DOWN = 34;
    var DOM_VK_END = 35;
    var DOM_VK_HOME = 36;
    var DOM_VK_LEFT = 37;
    var DOM_VK_UP = 38;
    var DOM_VK_RIGHT = 39;
    var DOM_VK_DOWN = 40;
    var DOM_VK_PRINTSCREEN = 44;
    var DOM_VK_INSERT = 45;
    var DOM_VK_DELETE = 46;
    var DOM_VK_0 = 48;
    var DOM_VK_1 = 49;
    var DOM_VK_2 = 50;
    var DOM_VK_3 = 51;
    var DOM_VK_4 = 52;
    var DOM_VK_5 = 53;
    var DOM_VK_6 = 54;
    var DOM_VK_7 = 55;
    var DOM_VK_8 = 56;
    var DOM_VK_9 = 57;
    var DOM_VK_SEMICOLON = 59;
    var DOM_VK_EQUALS = 61;
    var DOM_VK_A = 65;
    var DOM_VK_B = 66;
    var DOM_VK_C = 67;
    var DOM_VK_D = 68;
    var DOM_VK_E = 69;
    var DOM_VK_F = 70;
    var DOM_VK_G = 71;
    var DOM_VK_H = 72;
    var DOM_VK_I = 73;
    var DOM_VK_J = 74;
    var DOM_VK_K = 75;
    var DOM_VK_L = 76;
    var DOM_VK_M = 77;
    var DOM_VK_N = 78;
    var DOM_VK_O = 79;
    var DOM_VK_P = 80;
    var DOM_VK_Q = 81;
    var DOM_VK_R = 82;
    var DOM_VK_S = 83;
    var DOM_VK_T = 84;
    var DOM_VK_U = 85;
    var DOM_VK_V = 86;
    var DOM_VK_W = 87;
    var DOM_VK_X = 88;
    var DOM_VK_Y = 89;
    var DOM_VK_Z = 90;
    var DOM_VK_CONTEXT_MENU = 93;
    var DOM_VK_NUMPAD0 = 96;
    var DOM_VK_NUMPAD1 = 97;
    var DOM_VK_NUMPAD2 = 98;
    var DOM_VK_NUMPAD3 = 99;
    var DOM_VK_NUMPAD4 = 100;
    var DOM_VK_NUMPAD5 = 101;
    var DOM_VK_NUMPAD6 = 102;
    var DOM_VK_NUMPAD7 = 103;
    var DOM_VK_NUMPAD8 = 104;
    var DOM_VK_NUMPAD9 = 105;
    var DOM_VK_MULTIPLY = 106;
    var DOM_VK_ADD = 107;
    var DOM_VK_SEPARATOR = 108;
    var DOM_VK_SUBTRACT = 109;
    var DOM_VK_DECIMAL = 110;
    var DOM_VK_DIVIDE = 111;
    var DOM_VK_F1 = 112;
    var DOM_VK_F2 = 113;
    var DOM_VK_F3 = 114;
    var DOM_VK_F4 = 115;
    var DOM_VK_F5 = 116;
    var DOM_VK_F6 = 117;
    var DOM_VK_F7 = 118;
    var DOM_VK_F8 = 119;
    var DOM_VK_F9 = 120;
    var DOM_VK_F10 = 121;
    var DOM_VK_F11 = 122;
    var DOM_VK_F12 = 123;
    var DOM_VK_F13 = 124;
    var DOM_VK_F14 = 125;
    var DOM_VK_F15 = 126;
    var DOM_VK_F16 = 127;
    var DOM_VK_F17 = 128;
    var DOM_VK_F18 = 129;
    var DOM_VK_F19 = 130;
    var DOM_VK_F20 = 131;
    var DOM_VK_F21 = 132;
    var DOM_VK_F22 = 133;
    var DOM_VK_F23 = 134;
    var DOM_VK_F24 = 135;
    var DOM_VK_NUM_LOCK = 144;
    var DOM_VK_SCROLL_LOCK = 145;
    var DOM_VK_COMMA = 188;
    var DOM_VK_PERIOD = 190;
    var DOM_VK_SLASH = 191;
    var DOM_VK_BACK_QUOTE = 192;
    var DOM_VK_OPEN_BRACKET = 219;
    var DOM_VK_BACK_SLASH = 220;
    var DOM_VK_CLOSE_BRACKET = 221;
    var DOM_VK_QUOTE = 222;
    var DOM_VK_META = 224;


    var keycodes = {};
    keycodes[DOM_VK_SPACE] = ' ';
    keycodes[DOM_VK_A] = 'a';
    keycodes[DOM_VK_B] = 'b';
    keycodes[DOM_VK_C] = 'c';
    keycodes[DOM_VK_D] = 'd';
    keycodes[DOM_VK_E] = 'e';
    keycodes[DOM_VK_F] = 'f';
    keycodes[DOM_VK_G] = 'g';
    keycodes[DOM_VK_H] = 'h';
    keycodes[DOM_VK_I] = 'i';
    keycodes[DOM_VK_J] = 'j';
    keycodes[DOM_VK_K] = 'k';
    keycodes[DOM_VK_L] = 'l';
    keycodes[DOM_VK_M] = 'm';
    keycodes[DOM_VK_N] = 'n';
    keycodes[DOM_VK_O] = 'o';
    keycodes[DOM_VK_P] = 'p';
    keycodes[DOM_VK_Q] = 'q';
    keycodes[DOM_VK_R] = 'r';
    keycodes[DOM_VK_S] = 's';
    keycodes[DOM_VK_T] = 't';
    keycodes[DOM_VK_U] = 'u';
    keycodes[DOM_VK_V] = 'v';
    keycodes[DOM_VK_W] = 'w';
    keycodes[DOM_VK_X] = 'x';
    keycodes[DOM_VK_Y] = 'y';
    keycodes[DOM_VK_Z] = 'z';

    $(document).ready(function()
    {
        var strbundle = document.getElementById("smarterwiki_strings");
        //alert(strbundle.getString("welcome"));
        var click_to_change = strbundle.getString("click_to_change");
        var must_include_modifiers = strbundle.getString("must_include_modifiers");
        
        var alt_key_name = strbundle.getString("alt_key_name");
        var ctrl_key_name = strbundle.getString("ctrl_key_name");
        var meta_key_name = strbundle.getString("meta_key_name");
        var shift_key_name = strbundle.getString("shift_key_name");
        var space_key_name = strbundle.getString("space_key_name");
        
        var translate_invoke_key = function(key)
        {
            return key.replace(/META/g, meta_key_name)
                      .replace(/SHIFT/g, shift_key_name)
                      .replace(/ALT/g, alt_key_name)
                      .replace(/CTRL/g, ctrl_key_name)
                      .replace(/SPACE/g, space_key_name);
        };

        $("#shortcut-key-textbox").attr("value", 
            translate_invoke_key(prefManager.getCharPref("extensions.smarterwiki.qlauncher_invoke_key")) + " " + click_to_change);
        
        //$("#shortcut-key-textbox").keypress(function(event)
        $("#shortcut-key-textbox")[0].addEventListener("keydown", function(event)
        {
            event.preventDefault(); 
            event.stopPropagation();
            
            var has_ctrl = event.ctrlKey;
            var has_meta = event.metaKey;
            var has_alt = event.altKey;
            var has_shift = event.shiftKey;
            var char = ""; // var char = String.fromCharCode(event.charCode);
            if(event.keyCode in keycodes)
            {
                char = keycodes[event.keyCode];
            }

            if(!(has_ctrl || has_meta || has_alt || has_shift))
            {
                $("#shortcut-key-textbox").attr("value", 
                    must_include_modifiers);
            }
            else
            {
                var shortcut_key_seq = "";
                if(has_ctrl) {
                    shortcut_key_seq += "CTRL";
                }
                else if(has_meta) {//meta key is weird
                    if(shortcut_key_seq)
                    {
                        shortcut_key_seq += "+";
                    }
                    shortcut_key_seq += "META";
                }
                if(has_alt) {
                    if(shortcut_key_seq) {
                        shortcut_key_seq += "+";
                    }
                    shortcut_key_seq += "ALT";
                }
                if(has_shift) {
                    if(shortcut_key_seq) {
                        shortcut_key_seq += "+";
                    }
                    shortcut_key_seq += "SHIFT";  
                }
                if(char != "") {
                    if(shortcut_key_seq) {
                        shortcut_key_seq += "+";
                    }
                    if(char == " ") {
                        shortcut_key_seq += "SPACE";
                    }
                    else {
                        shortcut_key_seq += char.toUpperCase();
                    }
                }
                prefManager.setCharPref("extensions.smarterwiki.qlauncher_invoke_key", shortcut_key_seq);
                $("#shortcut-key-textbox").attr("value", translate_invoke_key(shortcut_key_seq) + " " + click_to_change);
            }

            return false;
        }, true);

        var set_qlauncher_controls_state = function()
        {
            $("#shortcut-key-textbox, #qlauncher-open-new-tab-checkbox").each(function()
            {
                this.disabled = !$("#enable-qlauncher-checkbox").attr("checked");//jQuery bug causes set .attr to break XUL text input
            });
        };
        set_qlauncher_controls_state();
        $("#enable-qlauncher-checkbox")[0].addEventListener("click", set_qlauncher_controls_state
        , false);


        var set_popup_bubble_controls_state = function()
        {
            $("#popup-bubble-open-new-tab-checkbox, [class~=search-checkbox], #popup-bubble-force-single-row-checkbox").each(function()
            {
                this.disabled = !$("#show-popup-bubble-checkbox").attr("checked");//jQuery bug causes set .attr to break XUL text input
            });
        };
        set_popup_bubble_controls_state();
        $("#show-popup-bubble-checkbox")[0].addEventListener("click", 
        set_popup_bubble_controls_state, false);    
    });
}());