var getSightings = function () {
    $.getJSON('/api/Sighting', {}, function (data) {
        $("body .results").text(JSON.stringify(data));
    })
};

var getSighting = function (id, success) {
    $.getJSON('/api/Sighting', {id: id}, function (data) {
        $("body .results").text(JSON.stringify(data));
    });
}

var update = function (id) {
    $.getJSON('/api/Sighting', { id: id }, function (d) {
        d.Description = 'Test';
        $.ajax('/api/Sighting/'+id, {
            type: 'PUT',
            data: d,
            success: function (data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}

var duplicate = function (id) {
    $.getJSON('/api/Sighting', { id: id }, function (d) {
        d.Title += ' - NEW';
        $.ajax('/api/Sighting', {
            type: 'POST',
            data: d,
            success: function (data) {
                $("body .results").text('SUCCESS');
            }
        });
    });
}

var del = function (id) {
    $.ajax('/api/Sighting/'+id, {
        type: 'DELETE',
        success: function (data) {
            $("body .results").text('SUCCESS');
        }
    });
}