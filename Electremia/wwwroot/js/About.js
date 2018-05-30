var map;      // global variable
var fontys = { lat: 51.452129, lng: 5.482015 };
var haagstraat = { lat: 51.475228, lng: 5.646937 };

function initMap() {
    var mapOptions = {
        center: new google.maps.LatLng(51.452129, 5.482015),
        zoom: 18,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    // assigning to global variable:
    map = new google.maps.Map(document.getElementById("map"), mapOptions);
    var marker1 = new google.maps.Marker({ position: fontys, map: map });
    var marker2 = new google.maps.Marker({ position: haagstraat, map: map });
}

function moveToFontys() {
    var center = new google.maps.LatLng(fontys);
    // using global variable:
    map.panTo(center);
}

function moveToHaagstraat() {
    var center = new google.maps.LatLng(haagstraat);
    // using global variable:
    map.panTo(center);
}