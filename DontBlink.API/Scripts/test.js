var getSightings = function () {
    $.getJSON('http://localhost:53254/api/Sighting', {}, function (data) {
        $("body .results").text(JSON.stringify(data));
    })
};

var getSighting = function (id, success) {
    $.getJSON('http://localhost:53254/api/Sighting', {id: id}, function (data) {
        $("body .results").text(JSON.stringify(data));
    });
}

var update = function (id) {
    $.getJSON('http://localhost:53254/api/Sighting', { id: id }, function (d) {
        d.Description = 'Test';
        $.ajax('http://localhost:53254/api/Sighting/'+id, {
            type: 'PUT',
            data: d,
            success: function (data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}

var duplicate = function (id) {
    $.getJSON('http://localhost:53254/api/Sighting', { id: id }, function (d) {
        d.Title += ' - NEW';
        $.ajax('http://localhost:53254/api/Sighting', {
            type: 'POST',
            data: d,
            success: function (data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}

var del = function (id) {
    $.ajax('http://localhost:53254/api/Sighting/'+id, {
        type: 'DELETE',
        success: function (data) {
            $("body .results").text('SUCCESS');
        }
    });
}