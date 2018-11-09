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
        if (sum > 4038) {
            $('#demo').text("ข้าวไข่เจียว ร้าน ครัวบ้านฉัน");
        }
        if (sum > 4039) {
            $('#demo').text("ก๋วยเต๊๋ยวน้ำตก ร้าน ลองเบิ่ง");
        }
        if (sum > 4040) {
            $('#demo').text("ข้าวผัดกระเพราไก่กรอบ ร้าน รสนิยม");
        }
        if (sum > 4041) {
            $('#demo').text("สเต็กหมู ร้าน ครัวบ้านย่า");
        }
        if (sum > 4042) {
            $('#demo').text("ชาบู ร้าน หม้อหน้ามอ");
        }
        if (sum > 4043) {
            $('#demo').text("ก๋วยเตี๋ยวเรือ ร้าน AB");
        }
        if (sum > 4044) {
            $('#demo').text("ส้มตำไก่ย่าง ร้าน ก.เก่ง");
        }
        if (sum > 4045) {
            $('#demo').text("เครปเย็น ร้าน House of Crepe");
        }
        if (sum > 4046) {
            $('#demo').text("โกโก้เย็น ร้าน เฮ้ยมิลค์");
        }
        if (sum > 4047) {
            $('#demo').text("ก๋วยจั๊บญวณ ร้าน ร่มไม้ชายคา");
        }
        if (sum > 4048) {
            $('#demo').text("แหนมเนือง ร้าน VTแหนมเนือง");
        }
        if (sum > 4049) {
            $('#demo').text("ยำไก่เเซ่บ ร้าน ป้าไหมต้มเเซ่บ");
        }
        if (sum > 4050) {
            $('#demo').text("เหล้าปั่น ร้าน ลั้ลลา");
        }
        if (sum > 4055) {
            $('#demo').text("ข้าวผัดปู ร้าน VTแหนมเนือง");
        }
        if (sum > 4060) {
            $('#demo').text("บิงซูบราวนี่คาราเมล ร้าน ไอเย็นI-Yen");
        }
        if (sum > 4065) {
            $('#demo').text("ข้าวผัดพริกแกงไก่หรอบ ร้าน ครัวบ้านฉัน");
        }
        if (sum > 4070) {
            $('#demo').text("ส้มตำปูปลาร้า ร้าน หมื่นแซ่บ");
        }
        if (sum > 4075) {
            $('#demo').text("มาม่าชีสลาวา ร้าน จุดสามจุด");
        }
        if (sum > 4080) {
            $('#demo').text("สเต็กพอร์คชอร์ป ร้าน 7คาเฟ่");
        }
        if (sum > 4085) {
            $('#demo').text("ข้าวไข่เจียว ต้มยำกุ้งน้ำข้น ร้าน แมมมอธ");
        }
        if (sum > 4090) {
            $('#demo').text("คอหมูย่างน้ำตก ข้าวเหนียว ร้าน ต้นไผ่ส้มตำ");
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
    
    $(document).ready(function(){
        $('#cirwheel').click(function () {
            $('#advanced').addClass('animated twister');
        });
    });
    

