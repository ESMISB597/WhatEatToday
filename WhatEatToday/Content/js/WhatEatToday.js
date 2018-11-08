    var date = new Date();
    var num1 = date.getDate();
    var num2 = (parseInt(date.getMonth()) + 1);
    var num3 = date.getFullYear();

    function startCalc() {
        interval = setInterval("calc()", 1);
    }

    function calc() {
        num1;
        num2;
        num3;
        one = document.autoSumForm.target.value;
        two = document.autoSumForm.sumassess.value;
        tree = document.autoSumForm.sumassess2.value;
        four = document.autoSumForm.sumassess3.value;
        sum = (two * 1) + (one * 1) + (tree * 1) + (four * 1) + ((num1 * 1) + (num2 * 1) + (num3 * 1));
        document.autoSumForm.gap.value = (two * 1) + (one * 1) + (tree * 1) + (four * 1) + ((num1 * 1) + (num2 * 1) + (num3 * 1));
        if (sum > 2500) {
            $('#demo').text("ข้าวไข่เจียว ร้าน ครัวบ้านฉัน");
        }
    }

    function stopCalc() {
        clearInterval(interval);
    }

    var latMap;
    var lngMap;

    function showMap(lat, lng, id) {
        latMap = lat;
        lngMap = lng;
        showMapWithLo();
        $('#checkin_id').val(id);
        //$('#checkin').attr("href", "~/CheckIn/Index/" + id);
        $('#mapModal').modal('show');
    }

    var marker;

    function initMap() {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 15,
            center: { lat: 14.8817715, lng: 102.0185075 }
        });
        marker = new google.maps.Marker({
            map: map,
            draggable: false,
            animation: google.maps.Animation.BOUNCE,
            mapTypeControl: false,
            scrollwheel: false,
            scrollable: false,
            position: new google.maps.LatLng(14.8817715, 102.0185075)
        });

    }

    function showMapWithLo() {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 15,
            center: { lat: latMap, lng: lngMap }
        });
        marker = new google.maps.Marker({
            map: map,
            draggable: false,
            animation: google.maps.Animation.BOUNCE,
            mapTypeControl: false,
            scrollwheel: false,
            scrollable: false,
            position: new google.maps.LatLng(latMap, lngMap)
        });
        marker.addListener('click', toggleBounce);
    }

    function getMapLocation() {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 15,
            center: { lat: 14.8817715, lng: 102.0185075 }
        });
        marker = new google.maps.Marker({
            map: map,
            draggable: true,
            animation: google.maps.Animation.DROP,
            position: new google.maps.LatLng(14.8817715, 102.0185075)
        });
        google.maps.event.addListener(marker, 'dragend', function (event) {
            $('#latInsert').val(this.getPosition().lat().toFixed(6));
            $('#lngInsert').val(this.getPosition().lng().toFixed(6));
        });
    }

    function showAddMap() {
        getMapLocation();

    }

    function toggleBounce() {
        if (marker.getAnimation() !== null) {
            marker.setAnimation(null);
        } else {
            marker.setAnimation(google.maps.Animation.BOUNCE);
        }

    }

    $('.number-selector > div > div.selected').click(function () {
        console.log("3");
    });