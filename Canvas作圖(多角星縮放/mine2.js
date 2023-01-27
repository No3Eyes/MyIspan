function doFirst() {
    let canvas = document.querySelector('#canvas');
    let context = canvas.getContext('2d');
    alert("canvas上的調整工具可以調整尖角數量與星星尖銳度")

    context.translate(500, 400);

    //產生角星
    function manstar(p, l, s, x = 0, y = 0, angle = Math.PI / 2) {
        let a = Math.PI / p;
        context.beginPath();
        context.strokeStyle = 'blue';
        context.moveTo(x + l * Math.cos(angle), y - l * Math.sin(angle));
        for (let i = 1; i < 2 * p; i++) {
            if (i % 2 == 1) { context.lineTo(x + s * Math.cos(a * i + angle), y - s * Math.sin(a * i + angle)); }
            else { context.lineTo(x + l * Math.cos(a * i + angle), y - l * Math.sin(a * i + angle)); }
        }
        context.closePath();
        context.fillStyle = 'brown';
        context.fill();
        context.stroke();
    }

    //調整工具
    range = document.getElementById("range")
    Pnum = document.getElementById("Pnum")
    btn = document.getElementById("btn")
    var ppnum
    range.addEventListener('input', function () {
        context.clearRect(-500, -400, 1000, 800);
        if (ppnum === undefined) {
            manstar(9, 300, 300 * (range.value / 100))
        }
        else { manstar(ppnum, 300, 300 * (range.value / 100)); }
    })
    btn.addEventListener('click', function () {
        if (Pnum.value !== "") {
            context.clearRect(-500, -400, 1000, 800);
            ppnum = parseInt(Pnum.value);
            manstar(ppnum, 300, 300 * (range.value / 100));
        }
    })
    manstar(8, 300, 300 * (range.value / 100))

}
window.addEventListener('load', doFirst);