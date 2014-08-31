// A button will call this function
// To capture photo
function capturePhoto() {
    // Take picture using device camera and retrieve image as base64-encoded string
    navigator.camera.getPicture(uploadPhoto, onFail, {
        quality: 50, destinationType: Camera.DestinationType.DATA_URL
    });
}

// A button will call this function
// To select image from gallery
function getPhoto(source) {
    // Retrieve image file location from specified source
    navigator.camera.getPicture(uploadPhoto, onFail, {
        quality: 50,
        destinationType: navigator.camera.DestinationType.DATA_URL,
        sourceType: navigator.camera.PictureSourceType.PHOTOLIBRARY
    });
}

function uploadPhoto(imageURI) {
    if (typeof imageURI !== "undefined") {
        var imageSrc = imageURI.indexOf("http") >= 0 ? imageURI : "data:image/png;base64," + imageURI;
        $("#story-image").attr("src", imageSrc);
        $(".resizeme").aeImageResize({ height: 300, width: 300 });
        $("[name=Base64ImageString]").val(imageURI);
    }
}

function onFail(message) {
    alert('Failed because: ' + message);
}

angular.module('ngRouteExample', ['ngRoute'])
    .controller('HomeController', function($scope, $route, $routeParams, $location) {
    })
    .controller('AddController', function($scope, $route, $routeParams, $location) {
       
    })
    .config(function($routeProvider, $locationProvider) {
        // $locationProvider.html5Mode(true).hashPrefix("!");
        $routeProvider
            .when('/', {
                template: function() {
                    return $("#home").html();
                },
                controller: 'AddController'
            }).when('/Sighting/Add', {
                template: function() {
                    return $("#add").html();
                },
                controller: 'AddController'
            })
            .otherwise({
                redirectTo: '/'
            });
    });