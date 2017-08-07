$.fn.extend({
    animateCss: function (animationName) {
        var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
        $(this).addClass('animated ' + animationName).one(animationEnd, function () {
            $(this).removeClass('animated ' + animationName);
        });
    },
    animateCssHide: function (animationName, optionalAfterFunction) {
        if ($(this).is(":visible")) {
            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
            $(this).addClass('animated ' + animationName).one(animationEnd, function () {

                if (optionalAfterFunction != null) { optionalAfterFunction(); }
                $(this).removeClass('animated ' + animationName);
                $(this).hide();
            });
        } else {
            if (optionalAfterFunction != null) { optionalAfterFunction(); }
        }
    },
    animateCssShow: function (animationName, optionalAfterFunction) {
        if ($(this).is(":hidden")) {
            $(this).show();
            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
            $(this).addClass('animated ' + animationName).one(animationEnd, function () {
                if (optionalAfterFunction != null) { optionalAfterFunction(); }
                $(this).removeClass('animated ' + animationName);
            });
        } else {
            if (optionalAfterFunction != null) { optionalAfterFunction(); }
        }
    },
    delayKeyup: function (ms, loader, callback) {

        var timer = 0;
        $(this).keyup(function () {
            //CAlls the loader function
            if (loader != null) { loader(); }
            clearTimeout(timer);
            timer = setTimeout(callback, ms);
        });
        return $(this);
    }
});