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



