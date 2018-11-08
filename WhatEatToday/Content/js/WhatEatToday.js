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


/** GAMES **/
    var selectedNumbers = [];

    function generateCombination(n, numbers) {
        if (n === 1) {
            return numbers;
        }

        if (numbers.length === 0) {
            return [];
        }

        var i;
        var output = [];
        var b = generateCombination(n - 1, numbers.slice(1));

        for (i = 0; i < b.length; i += 1) {
            output.push(numbers[0] + b[i]);
        }

        return output.concat(generateCombination(n, numbers.slice(1)));
    }

    function selectNumber(selectionElm) {
        var number = selectionElm.textContent;
        var selection = $(selectionElm);

        selection.toggleClass('selected');

        if (selection.hasClass('selected')) {
            selectedNumbers.push(number);
        } else {
            selectedNumbers = selectedNumbers.filter(function (selectedNumber) {
                return selectedNumber !== number;
            });
        }

        selectedNumbers = selectedNumbers.sort();
    }

    function displayClipboardMessage() {
        var modal = $('.modal');

        modal.addClass('active');

        setTimeout(function () {
            modal.addClass('active-fade');

            setTimeout(function () {
                modal.removeClass('active active-fade');
            }, 300)
        }, 500);
    }

    $(function () {
        var numberSelections = $('.number-selector > div > div');
        var combinationsInputs = $('.combinations-input');
        var copyButtons = $('.copy-button');

        numberSelections.click(function (event) {
            var twos = document.getElementById('twos');
            var threes = document.getElementById('threes');
            var twosButton = $('#twos-button');
            var threesButton = $('#threes-button');

            event.preventDefault();

            selectNumber(event.target);

            // Generate twos and threes combinations.
            twos.value = generateCombination(2, selectedNumbers).join(' ');
            threes.value = generateCombination(3, selectedNumbers).join(' ');

            twosButton.prop('disabled', twos.value.length === 0);
            threesButton.prop('disabled', threes.value.length === 0);
        });

        copyButtons.click(function (event) {
            var data = $(event.target).parent('div').find('p > input');

            data[0].select();
            document.execCommand('copy');
            window.getSelection().removeAllRanges();

            displayClipboardMessage();
        });

        // Prevent editing input elements used to display combinations.
        combinationsInputs.on('keydown', function (event) {
            event.preventDefault();
        });
    });


    $(function () {
        var numberSelections = $('.number-selector2 > div > div');
        var combinationsInputs = $('.combinations-input');
        var copyButtons = $('.copy-button');

        numberSelections.click(function (event) {
            var twos = document.getElementById('twos');
            var threes = document.getElementById('threes');
            var twosButton = $('#twos-button');
            var threesButton = $('#threes-button');

            event.preventDefault();

            selectNumber(event.target);

            // Generate twos and threes combinations.
            twos.value = generateCombination(2, selectedNumbers).join(' ');
            threes.value = generateCombination(3, selectedNumbers).join(' ');

            twosButton.prop('disabled', twos.value.length === 0);
            threesButton.prop('disabled', threes.value.length === 0);
        });

        copyButtons.click(function (event) {
            var data = $(event.target).parent('div').find('p > input');

            data[0].select();
            document.execCommand('copy');
            window.getSelection().removeAllRanges();

            displayClipboardMessage();
        });

        // Prevent editing input elements used to display combinations.
        combinationsInputs.on('keydown', function (event) {
            event.preventDefault();
        });
    });