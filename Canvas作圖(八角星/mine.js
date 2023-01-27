function doFirst() {
    let canvas = document.querySelector('#canvas');
    let context = canvas.getContext('2d');

    for (let i = 0; i < 100; i++) {
        let interval = i * 50
        context.moveTo(0, interval);
        context.lineTo(canvas.width, interval);
        context.fillText(interval, 0, interval + 5);

        context.moveTo(interval, 0);
        context.lineTo(interval, canvas.height);
        context.fillText(interval, interval - 10, 8);
    }

    context.moveTo(10, 150);
    context.lineTo(150, 150);
    context.lineTo(150, 10);
    context.lineTo(250, 110);
    context.lineTo(350, 10);
    context.lineTo(350, 150);
    context.lineTo(490, 150);
    context.lineTo(390, 250);
    context.lineTo(490, 350);
    context.lineTo(350, 350);
    context.lineTo(350, 490);
    context.lineTo(250, 390);
    context.lineTo(150, 490);
    context.lineTo(150, 350);
    context.lineTo(10, 350);
    context.lineTo(110, 250);
    context.closePath();


    // context.moveTo(650, 540);
    // context.lineTo(650, 540 + 260);         //下
    // context.moveTo(650, 540);
    // context.lineTo(650, 540 - 260);         //上
    // context.moveTo(650, 540);
    // context.lineTo(650 - 260, 540);         //左
    // context.moveTo(650, 540);
    // context.lineTo(650 + 260, 540);         //右
    // context.moveTo(650, 540);
    // context.lineTo(650 + 184, 540 + 184);   //右下
    // context.moveTo(650, 540);
    // context.lineTo(650 + 184, 540 - 184);   //右上
    // context.moveTo(650, 540);
    // context.lineTo(650 - 184, 540 - 184);   //左上  
    // context.moveTo(650, 540);
    // context.lineTo(650 - 184, 540 + 184);   //左下





    let s = 12;
    let sh = 2;
    let lo = 5;
    context.moveTo(650, 280);   //北
    context.lineTo(705, 410);           //
    context.lineTo(834, 356);   //東北
    context.lineTo(779, 486);           //
    context.lineTo(910, 540);   //東
    context.lineTo(780, 595);           //
    context.lineTo(834, 724);   //東南
    context.lineTo(704, 669);           //
    context.lineTo(650, 800);   //南
    context.lineTo(595, 670);           //
    context.lineTo(466, 724);   //西南
    context.lineTo(521, 594);           //
    context.lineTo(390, 540);   //西
    context.lineTo(520, 495);           //
    context.lineTo(466, 356);   //西北
    context.lineTo(596, 411);           //
    context.closePath();


    context.strokeStyle = 'rgba(0,0,0,0.3)';
    context.fillStyle = 'yellow';

    context.stroke();
    context.fill();

}
window.addEventListener('load', doFirst);