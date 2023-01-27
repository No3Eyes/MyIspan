function doFirst() {
    let canvas = document.querySelector('#canvas');
    let context = canvas.getContext('2d');

    // context.beginPath();
    // for (let i = 0; i < 100; i++) {
    //     let interval = i * 50
    //     context.moveTo(0, interval);
    //     context.lineTo(canvas.width, interval);
    //     context.fillText(interval - 400, 500, interval + 5);

    //     context.moveTo(interval, 0);
    //     context.lineTo(interval, canvas.height);
    //     context.fillText(interval - 500, interval - 10, 8 + 400);
    // }
    // context.strokeStyle = 'rgba(0,0,0,0.3)';
    // context.stroke();

    context.translate(500, 400);

    //正多邊形
    function drawReg(p, r, x = 0, y = 0, ang = 0) {
        context.translate(x, y);
        context.beginPath();
        let t = 2 * Math.PI / p;

        context.moveTo(x + r * Math.cos(ang), y - r * Math.sin(ang));
        for (let i = 1; i < p; i++) {
            context.lineTo(r * Math.cos(t * i + ang), -r * Math.sin(t * i + ang));
        }
        context.closePath();
        context.strokeStyle = 'blue';
        context.stroke();
        context.translate(-x, -y);
    }

    //正芒星
    function drawStar(p, r, x = 0, y = 0, ang = 0) {
        context.translate(x, y);
        context.beginPath();
        let t = 2 * Math.PI / p;
        let aa = (p - 1) / 2;
        if (p % 2 === 1) {
            context.moveTo(x + r * Math.cos(ang), y - r * Math.sin(ang));
            for (let i = 1; i < p; i++) {
                context.lineTo(r * Math.cos(t * i * aa + ang), -r * Math.sin(t * i * aa + ang));
            }
            context.closePath();
        }
        else {
            for (let i = 0; i < p; i++) {
                context.moveTo(300 * Math.cos(t * i + ang), -300 * Math.sin(t * i + ang));
                context.lineTo(300 * Math.cos(t * (i + p / 2 - 1) + ang), -300 * Math.sin(t * (i + p / 2 - 1) + ang));
                context.moveTo(300 * Math.cos(t * i + ang), -300 * Math.sin(t * i + ang));
                context.lineTo(300 * Math.cos(t * (i + p / 2 + 1) + ang), -300 * Math.sin(t * (i + p / 2 + 1) + ang));
                context.stroke();
            }
        }
        context.strokeStyle = 'blue';
        context.stroke();
        context.translate(-x, -y);
    }

    range = document.getElementById("range")
    Pnum = document.getElementById("Pnum")
    btn = document.getElementById("btn")
    var ppnum
    range.addEventListener('input', function () {
        context.clearRect(-500, -400, 1000, 800);
        if (ppnum === undefined) {
            drawReg(9, 300, 0, 0, 2 * Math.PI * range.value / 100);
            drawStar(9, 300, 0, 0, 2 * Math.PI * range.value / 100);
        }
        else {
            drawReg(ppnum, 300, 0, 0, 2 * Math.PI * range.value / 100);
            drawStar(ppnum, 300, 0, 0, 2 * Math.PI * range.value / 100);
        }
    })
    btn.addEventListener('click', function () {
        if (Pnum.value !== "") {
            context.clearRect(-500, -400, 1000, 800);
            ppnum = parseInt(Pnum.value);
            drawReg(ppnum, 300, 0, 0, 2 * Math.PI * range.value / 100);
            drawStar(ppnum, 300, 0, 0, 2 * Math.PI * range.value / 100);
        }
    })

    numm = 10
    a2 = Math.PI / 2
    drawReg(numm, 300, 0, 0, a2)
    drawStar(numm, 300, 0, 0, a2)
    //drawStar(8, 300, 0, 0, Math.PI / 2)
    // context.moveTo(0, -300);
    // context.lineTo(300 * Math.cos(Math.PI * 5 / 4), -300 * Math.sin(Math.PI * 5 / 4));
    // context.moveTo(0, -300);
    // context.lineTo(300 * Math.cos(Math.PI * 7 / 4), -300 * Math.sin(Math.PI * 7 / 4));
    // context.stroke();
    // aa = 2 * Math.PI / numm
    // for (let i = 0; i < numm; i++) {
    //     context.moveTo(300 * Math.cos(aa * i + a2), -300 * Math.sin(aa * i + a2));
    //     context.lineTo(300 * Math.cos(aa * (i + numm / 2 - 1) + a2), -300 * Math.sin(aa * (i + numm / 2 - 1) + a2));
    //     context.moveTo(300 * Math.cos(aa * i + a2), -300 * Math.sin(aa * i + a2));
    //     context.lineTo(300 * Math.cos(aa * (i + numm / 2 + 1) + a2), -300 * Math.sin(aa * (i + numm / 2 + 1) + a2));
    //     context.stroke();
    // }

}
window.addEventListener('load', doFirst);