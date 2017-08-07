var COMMON = {};

COMMON.SendToSession = function(url, data, returnType, success, error)
{
    if (returnType == null)
    {
        returnType = "text";
    }

    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(data),
        cache: false,
        contentType: 'application/json; charset=utf-8',
        dataType: returnType,
        success: success,
        error: error,
        async: true
    });
};

COMMON.Message = function (msg) {
    noty({
        text: msg,
        type: "information",
        layout: "top",
        theme: "relax",
        animation: {
            open: { height: 'toggle' }, // jQuery animate function property object
            close: { height: 'toggle' }, // jQuery animate function property object
            easing: 'swing', // easing
            speed: 500 // opening & closing animation speed
        }
    });
};
//COMMON.BrowserHasFocus = function () {
//    var window_focus;

//    $(window).focus(function () {
//        window_focus = true;
//    })
//        .blur(function () {
//            window_focus = false;
//        });

//    return window_focus;
//};