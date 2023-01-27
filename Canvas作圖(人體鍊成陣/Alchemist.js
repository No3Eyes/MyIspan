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
    // context.closePath();


    context.translate(500, 400);
    context.strokeStyle = 'black';

    //最外圍圓
    context.beginPath();
    context.arc(0, 0, 400, 0, 2 * Math.PI);
    context.stroke();

    //往內第二層圓
    context.beginPath();
    context.arc(0, 0, 350, 0, 2 * Math.PI);
    context.stroke();

    //中間鉛錘線
    context.beginPath();
    context.moveTo(0, 350);
    context.lineTo(0, 100);
    context.moveTo(0, -100);
    context.lineTo(0, -350);
    context.moveTo(0, 75);
    context.lineTo(0, -75);
    context.stroke();

    //左下到右上直線
    context.beginPath();
    context.moveTo(350 * Math.cos(Math.PI * 7 / 6), -350 * Math.sin(Math.PI * 7 / 6));
    context.lineTo(100 * Math.cos(Math.PI * 7 / 6), -100 * Math.sin(Math.PI * 7 / 6));
    context.moveTo(75 * Math.cos(Math.PI * 7 / 6), -75 * Math.sin(Math.PI * 7 / 6));
    context.lineTo(75 * Math.cos(Math.PI / 6), -75 * Math.sin(Math.PI / 6));
    context.moveTo(100 * Math.cos(Math.PI / 6), -100 * Math.sin(Math.PI / 6));
    context.lineTo(350 * Math.cos(Math.PI / 6), -350 * Math.sin(Math.PI / 6));
    context.stroke();

    //右下到左上直線
    context.beginPath();
    context.moveTo(350 * Math.cos(Math.PI * 11 / 6), -350 * Math.sin(Math.PI * 11 / 6));
    context.lineTo(100 * Math.cos(Math.PI * 11 / 6), -100 * Math.sin(Math.PI * 11 / 6));
    context.moveTo(75 * Math.cos(Math.PI * 11 / 6), -75 * Math.sin(Math.PI * 11 / 6));
    context.lineTo(75 * Math.cos(Math.PI * 5 / 6), -75 * Math.sin(Math.PI * 5 / 6));
    context.moveTo(100 * Math.cos(Math.PI * 5 / 6), -100 * Math.sin(Math.PI * 5 / 6));
    context.lineTo(350 * Math.cos(Math.PI * 5 / 6), -350 * Math.sin(Math.PI * 5 / 6));
    context.stroke();

    //正六邊形
    context.beginPath();
    context.moveTo(0, -350);
    context.lineTo(350 * Math.cos(Math.PI * 5 / 6), -350 * Math.sin(Math.PI * 5 / 6));
    context.lineTo(350 * Math.cos(Math.PI * 7 / 6), -350 * Math.sin(Math.PI * 7 / 6));
    context.lineTo(0, 350);
    context.lineTo(350 * Math.cos(Math.PI * 11 / 6), -350 * Math.sin(Math.PI * 11 / 6));
    context.lineTo(350 * Math.cos(Math.PI / 6), -350 * Math.sin(Math.PI / 6));
    context.closePath();
    context.stroke();

    //正倒三角
    context.beginPath();
    context.moveTo(350 * Math.cos(Math.PI / 6), -350 * Math.sin(Math.PI / 6));
    context.lineTo(350 * Math.cos(Math.PI * 5 / 6), -350 * Math.sin(Math.PI * 5 / 6));
    context.lineTo(350 * Math.cos(Math.PI * 9 / 6), -350 * Math.sin(Math.PI * 9 / 6));
    context.closePath();
    context.stroke();


    //右上兩組1/3圓
    context.beginPath();
    context.arc(350 * Math.cos(Math.PI / 6), -350 * Math.sin(Math.PI / 6), 150, Math.PI / 2, 7 * Math.PI / 6);
    context.stroke();

    context.beginPath();
    context.arc(350 * Math.cos(Math.PI / 6), -350 * Math.sin(Math.PI / 6), 120, Math.PI / 2, 7 * Math.PI / 6);
    context.stroke();

    //左上兩組1/3圓
    context.beginPath();
    context.arc(350 * Math.cos(Math.PI * 5 / 6), -350 * Math.sin(Math.PI * 5 / 6), 120, Math.PI * 11 / 6, Math.PI / 2);
    context.stroke();

    context.beginPath();
    context.arc(350 * Math.cos(Math.PI * 5 / 6), -350 * Math.sin(Math.PI * 5 / 6), 150, Math.PI * 11 / 6, Math.PI / 2);
    context.stroke();

    //下兩組1/3圓
    context.beginPath();
    context.arc(350 * Math.cos(Math.PI * 5 / 6), -350 * Math.sin(Math.PI * 5 / 6), 150, Math.PI * 11 / 6, Math.PI / 2);
    context.stroke();

    context.beginPath();
    context.arc(350 * Math.cos(Math.PI * 9 / 6), -350 * Math.sin(Math.PI * 9 / 6), 150, Math.PI * 7 / 6, Math.PI * 11 / 6);
    context.stroke();


    context.beginPath();
    context.arc(350 * Math.cos(Math.PI * 9 / 6), -350 * Math.sin(Math.PI * 9 / 6), 120, Math.PI * 7 / 6, Math.PI * 11 / 6);
    context.stroke();

    //正六邊形內大圓
    context.beginPath();
    context.arc(0, 0, 290, 0, Math.PI * 2);
    context.stroke();

    context.beginPath();
    context.arc(0, 0, 75, 0, 2 * Math.PI);
    context.stroke();
    context.beginPath();
    context.arc(0, 0, 100, 0, 2 * Math.PI);
    context.stroke();

    //內圓(上)
    context.beginPath();
    context.arc(0, -350 * Math.sin(Math.PI / 6), 50, 0, Math.PI * 2);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();

    let rr = 350 * Math.sin(Math.PI / 6);
    //內圓(左下)
    context.beginPath();
    context.arc(rr * Math.cos(Math.PI * 7 / 6), -rr * Math.sin(Math.PI * 7 / 6), 50, 0, Math.PI * 2);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();
    //內圓(右下)
    context.beginPath();
    context.arc(rr * Math.cos(Math.PI * 11 / 6), -rr * Math.sin(Math.PI * 11 / 6), 50, 0, Math.PI * 2);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();
}
window.addEventListener('load', doFirst);