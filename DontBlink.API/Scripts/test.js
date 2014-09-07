var getSightings = function (returnMethod) {
    $.getJSON('/api/Sighting', {}, function (data) {
        if (typeof returnMethod === "undefined") {
            $("body .results").text(JSON.stringify(data));
        } else {
            returnMethod(data);
        }
    });
};

var getSighting = function (id, success) {
    getSightings(function (data) {
        var d = data[id];
        $.getJSON('/api/Sighting', { id: d.Id }, function (data) {
            $("body .results").text(JSON.stringify(data));
        });
    });
    $.getJSON('/api/Sighting', {id: id}, function (data) {
        $("body .results").text(JSON.stringify(data));
    });
}

var update = function (id) {
    getSightings(function (data) {
        var d = data[id];
        d.Description = 'Description Updated';
        $.ajax('/api/Sighting/' + d.Id, {
            type: 'PUT',
            data: d,
            success: function(data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}

var duplicate = function (id) {
    getSightings(function (data) {
        var d = data[id];
        d.Description = 'Description Dup';
        $.ajax('/api/Sighting/', {
            type: 'POST',
            data: d,
            success: function (data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}

var del = function (id) {
    getSightings(function (data) {
        var d = data[id];
        $.ajax('/api/Sighting/' + d.Id, {
            type: 'DELETE',
            data: d,
            success: function (data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}
var getByName = function(name) {
    return $("[name=" + name + "]").val();
}
var create = function (title, description, lat, long) {
    $.ajax('/api/Sighting', {
        type: 'POST',
        data: { Title: getByName("Title"), Description: getByName("Description"), Latitude: getByName("Lat"), Longitude: getByName("Long") },
        success: function (data) {
            $("body .results").text('SUCCESS');
        }
    });
}