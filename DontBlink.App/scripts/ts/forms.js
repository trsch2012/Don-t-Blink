var ts = ts || {};
ts.forms = (function() {
    var submit = function(url, type, parameters, success, error) {
        $.ajax(url, {
            type: type,
            data: parameters,
            success: success,
            error: error
        });
    },
    getFunctionFromString = function(string)
    {
        var scope = window;
        var scopeSplit = string.split('.');
        for (var i = 0; i < scopeSplit.length - 1; i++)
        {
            scope = scope[scopeSplit[i]];

            if (scope == undefined) return;
        }

        return scope[scopeSplit[scopeSplit.length - 1]];
    };

    $("body").on("submit", "form", function (event) {
        var form = $(this),
            url = form.attr("action"),
            method = form.attr("method"),
            parameters = form.serialize(),
            successFunction = form.data("success") != null ?
                getFunctionFromString(form.data("success")) :
                function (data) {
                    alert(JSON.stringify(data));
                },
            errorFunction = form.data("error") != null ?
                getFunctionFromString(form.data("error")) :
                function (data) {
                    alert(JSON.stringify(data));
                };

        submit(url, method, parameters, successFunction, errorFunction);
        return false;
    });
})();