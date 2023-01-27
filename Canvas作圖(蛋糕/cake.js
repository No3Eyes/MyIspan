function doFirst() {
    let canvas = document.querySelector('#canvas');
    let context = canvas.getContext('2d');

    //座標歸零
    context.translate(500, 400);

    context.strokeStyle = 'black';
    context.beginPath();//內圈
    context.lineWidth = 3;
    context.bezierCurveTo(-315, -140, -325, -140, -325, -100);
    context.bezierCurveTo(-325, -100, -260, 130, 75, 85);
    context.bezierCurveTo(75, 85, 276, 58, 341, -75);
    context.bezierCurveTo(341, -75, 406, -208, 205, -265);
    context.bezierCurveTo(205, -265, 215, -245, 210, -230);
    context.bezierCurveTo(210, -230, 240, -235, 248, -205);
    context.bezierCurveTo(248, -205, 265, -220, 290, -185);
    context.bezierCurveTo(290, -185, 325, -125, 275, -100);
    context.bezierCurveTo(275, -100, 265, -98, 255, -100);
    context.bezierCurveTo(255, -100, 272, -20, 225, -17);
    context.bezierCurveTo(225, -17, 194, -20, 195, -28);
    context.bezierCurveTo(195, -28, 165, 18, 133, -27);
    context.bezierCurveTo(133, -27, 110, -8, 83, -28);
    context.bezierCurveTo(83, -28, 50, 35, 20, -20);
    context.bezierCurveTo(20, -20, 23, -15, 5, 0);
    context.bezierCurveTo(5, 0, 6, 40, -35, 15);
    context.bezierCurveTo(-35, 15, -70, 75, -100, 25);
    context.bezierCurveTo(-100, 25, -170, 20, -150, 0);
    context.bezierCurveTo(-150, 0, -200, -30, -180, -60);
    context.bezierCurveTo(-180, -60, -200, -40, -225, -65);
    context.bezierCurveTo(-225, -65, -245, -75, -250, -70);
    context.bezierCurveTo(-250, -70, -275, -65, -280, -90);
    context.bezierCurveTo(-280, -90, -310, -100, -315, -140);
    context.fillStyle = '#FFF895';
    context.fill();
    context.stroke();

    context.beginPath();//內圈上右補齊
    context.bezierCurveTo(148, -283, 145, -285, 130, -288);
    context.bezierCurveTo(130, -288, 136, -280, 138, -267);
    context.bezierCurveTo(138, -267, 135, -265, 148, -283);
    context.fillStyle = '#FFF895';
    context.fill();
    context.stroke();

    context.beginPath();//內圈上中補齊
    context.bezierCurveTo(95, -296, 65, -300, 33, -300);
    context.bezierCurveTo(33, -300, 41, -274, 66, -253);
    context.bezierCurveTo(66, -253, 63, -287, 95, -296);
    context.fillStyle = '#FFF895';
    context.fill();
    context.stroke();

    context.beginPath();//內圈上左補齊
    context.bezierCurveTo(-47, -298, -68, -298, -78, -296);
    context.bezierCurveTo(-78, -296, -70, -280, -60, -275);
    context.bezierCurveTo(-60, -275, -52, -283, -47, -298);
    context.fillStyle = '#FFF895';
    context.fill();
    context.stroke();

    context.beginPath();//(4,2)蛋
    context.bezierCurveTo(225, -170, 230, -190, 248, -205);
    context.bezierCurveTo(248, -205, 265, -220, 290, -185);
    context.bezierCurveTo(290, -185, 325, -125, 275, -100);
    context.bezierCurveTo(275, -100, 263, -90, 248, -107);
    context.bezierCurveTo(248, -107, 245, -120, 230, -122);
    context.bezierCurveTo(230, -122, 240, -145, 225, -170);
    context.fillStyle = '#301458';
    context.fill();
    context.stroke();

    context.beginPath();//(3,3)蛋
    context.bezierCurveTo(210, -230, 178, -230, 173, -183);
    context.bezierCurveTo(173, -183, 208, -210, 225, -170);
    context.bezierCurveTo(225, -170, 230, -190, 248, -205);
    context.bezierCurveTo(248, -205, 240, -235, 210, -230);
    context.fillStyle = '#C8001E';
    context.fill();
    context.stroke();

    context.beginPath();//(3,2)蛋
    context.bezierCurveTo(173, -183, 128, -133, 184, -86);
    context.bezierCurveTo(184, -86, 200, -130, 230, -122);
    context.bezierCurveTo(230, -122, 240, -145, 225, -170);
    context.bezierCurveTo(225, -170, 208, -210, 173, -183);
    context.fillStyle = '#F4C6AA';
    context.fill();
    context.stroke();

    context.beginPath();//(4,1)蛋
    context.bezierCurveTo(184, -86, 174, -60, 195, -30);
    context.bezierCurveTo(195, -30, 194, -20, 225, -17);
    context.bezierCurveTo(225, -17, 272, -20, 255, -100);
    context.bezierCurveTo(255, -100, 243, -120, 230, -122);
    context.bezierCurveTo(230, -122, 200, -130, 184, -86);
    context.fillStyle = '#F90D0D';
    context.fill();
    context.stroke();

    context.beginPath();//(3,1)蛋
    context.bezierCurveTo(160, -118, 107, -95, 133, -27);
    context.bezierCurveTo(133, -27, 165, 18, 195, -30);
    context.bezierCurveTo(195, -30, 174, -60, 184, -86);
    context.bezierCurveTo(184, -86, 170, -95, 160, -118);
    context.fillStyle = '#850104';
    context.fill();
    context.stroke();

    context.beginPath();//(2,1)蛋
    context.bezierCurveTo(140, -103, 102, -155, 75, -90);
    context.bezierCurveTo(75, -90, 95, -65, 83, -28);
    context.bezierCurveTo(83, -28, 110, -8, 133, -27);
    context.bezierCurveTo(133, -27, 110, -70, 140, -103);
    context.fillStyle = '#301458';
    context.fill();
    context.stroke();

    context.beginPath();//(2,2)蛋
    context.bezierCurveTo(175, -184, 120, -215, 120, -120);
    context.bezierCurveTo(120, -120, 133, -115, 139, -102);
    context.bezierCurveTo(139, -102, 146, -110, 160, -118);
    context.bezierCurveTo(160, -118, 145, -152, 175, -184);
    context.fillStyle = '#F90D0D';
    context.fill();
    context.stroke();

    context.beginPath();//(1,1)蛋
    context.bezierCurveTo(21, -90, 50, -118, 75, -90);
    context.bezierCurveTo(75, -90, 95, -65, 83, -28);
    context.bezierCurveTo(83, -28, 50, 35, 20, -20);
    context.bezierCurveTo(20, -20, 0, -50, 21, -90);
    context.fillStyle = '#F4C6AA';
    context.fill();
    context.stroke();

    context.beginPath();//(1,2)蛋
    context.bezierCurveTo(120, -120, 97, -138, 75, -90);
    context.bezierCurveTo(75, -90, 65, -107, 47, -102);
    context.bezierCurveTo(47, -102, 46, -160, 78, -163);
    context.bezierCurveTo(78, -163, 118, -168, 120, -120);
    context.fillStyle = '#850104';
    context.fill();
    context.stroke();

    context.beginPath();//(1,3)蛋
    context.bezierCurveTo(78, -163, 95, -280, 150, -189);
    context.bezierCurveTo(150, -189, 118, -188, 120, -120);
    context.bezierCurveTo(120, -120, 118, -170, 78, -163);
    context.fillStyle = '#F4C6AA';
    context.fill();
    context.stroke();

    context.beginPath();//(1,4)蛋
    context.bezierCurveTo(100, -218, 112, -268, 140, -266);
    context.bezierCurveTo(140, -266, 184, -268, 173, -184);
    context.bezierCurveTo(173, -184, 168, -190, 150, -189);
    context.bezierCurveTo(150, -189, 122, -240, 100, -218);
    context.fillStyle = '#301458';
    context.fill();
    context.stroke();

    context.beginPath();//(1,5)蛋
    context.bezierCurveTo(87, -198, 40, -264, 88, -293);
    context.bezierCurveTo(88, -293, 130, -316, 138, -267);
    context.bezierCurveTo(138, -267, 115, -270, 100, -218);
    context.bezierCurveTo(100, -218, 92, -210, 87, -198);
    context.fillStyle = '#F90D0D';
    context.fill();
    context.stroke();

    context.beginPath();//(2,5)蛋
    context.bezierCurveTo(138, -267, 165, -330, 205, -265);
    context.bezierCurveTo(205, -265, 213, -240, 210, -230);
    context.bezierCurveTo(210, -230, 178, -228, 173, -184);
    context.bezierCurveTo(173, -184, 185, -268, 138, -267);
    context.fillStyle = '#850104';
    context.fill();
    context.stroke();

    context.beginPath();//下面奶油
    context.bezierCurveTo(-180, -60, -75, -190, -115, -242);
    context.bezierCurveTo(-115, -242, -65, -260, -37, -160);
    context.bezierCurveTo(-37, -160, -25, -110, 21, -90);
    context.bezierCurveTo(21, -90, 0, -50, 20, -20);
    context.bezierCurveTo(20, -20, 23, -15, 5, 0);
    context.bezierCurveTo(5, 0, 6, 40, -35, 15);
    context.bezierCurveTo(-35, 15, -70, 75, -100, 25);
    context.bezierCurveTo(-100, 25, -170, 20, -150, 0);
    context.bezierCurveTo(-150, 0, -200, -30, -180, -60);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();

    context.beginPath();//左邊奶油
    context.bezierCurveTo(-315, -140, -290, -200, -255, -240);
    context.bezierCurveTo(-255, -240, -215, -295, -245, -335);
    context.bezierCurveTo(-245, -335, -210, -350, -180, -280);
    context.bezierCurveTo(-180, -280, -150, -210, -112, -180);
    context.bezierCurveTo(-112, -180, -130, -125, -180, -60);
    context.bezierCurveTo(-180, -60, -200, -40, -225, -65);
    context.bezierCurveTo(-225, -65, -245, -75, -250, -70);
    context.bezierCurveTo(-250, -70, -275, -65, -280, -90);
    context.bezierCurveTo(-280, -90, -310, -100, -315, -140);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();

    context.beginPath();//上面奶油
    context.bezierCurveTo(-180, -280, -130, -355, -150, -385);
    context.bezierCurveTo(-150, -385, -115, -390, -94, -320);
    context.bezierCurveTo(-94, -320, -80, -290, -60, -275);
    context.bezierCurveTo(-60, -275, -73, -260, -85, -238);
    context.bezierCurveTo(-85, -238, -100, -247, -115, -242);
    context.bezierCurveTo(-115, -242, -95, -215, -112, -180);
    context.bezierCurveTo(-112, -180, -156, -218, -180, -280);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();

    context.beginPath();//右邊奶油
    context.bezierCurveTo(-115, -242, -65, -260, -37, -160);
    context.bezierCurveTo(-37, -160, -25, -110, 21, -90);
    context.bezierCurveTo(21, -90, 33, -100, 47, -102);
    context.bezierCurveTo(47, -102, 45, -155, 78, -163);
    context.bezierCurveTo(78, -163, 80, -187, 87, -198);
    context.bezierCurveTo(87, -198, 65, -235, 66, -253);
    context.bezierCurveTo(66, -253, 38, -268, 15, -350);
    context.bezierCurveTo(15, -350, 8, -385, -42, -385);
    context.bezierCurveTo(-42, -385, -16, -335, -60, -275);
    context.bezierCurveTo(-60, -275, -73, -260, -85, -238);
    context.bezierCurveTo(-85, -238, -60, -235, -37, -160);
    context.bezierCurveTo(-37, -160, -25, -110, 21, -90);
    context.bezierCurveTo(21, -90, -27, -105, -42, -175);
    context.bezierCurveTo(-42, -175, -50, -218, -85, -237);
    context.bezierCurveTo(-85, -237, -95, -245, -115, -242);
    context.fillStyle = 'white';
    context.fill();
    context.stroke();

    context.beginPath();//上右裙邊
    context.bezierCurveTo(20, -335, 55, -350, 60, -305);
    context.bezierCurveTo(60, -305, 65, -365, 115, -320);
    context.bezierCurveTo(115, -320, 135, -350, 167, -310);
    context.bezierCurveTo(167, -310, 185, -340, 213, -300);
    context.bezierCurveTo(213, -300, 230, -280, 205, -265);
    context.bezierCurveTo(205, -265, 175, -318, 148, -283);
    context.bezierCurveTo(148, -283, 145, -285, 130, -288);
    context.bezierCurveTo(130, -288, 125, -305, 95, -296);
    context.bezierCurveTo(95, -296, 65, -300, 33, -300);
    context.bezierCurveTo(33, -300, 28, -310, 20, -335);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//外圍裙邊
    context.bezierCurveTo(205, -265, 295, -335, 290, -235);
    context.bezierCurveTo(290, -235, 355, -275, 350, -200);
    context.bezierCurveTo(350, -200, 410, -220, 387, -140);
    context.bezierCurveTo(387, -140, 425, -165, 427, -135);
    context.bezierCurveTo(427, -135, 430, -110, 400, -110);
    context.bezierCurveTo(400, -110, 433, -108, 437, -75);
    context.bezierCurveTo(437, -75, 440, -33, 395, -45);
    context.bezierCurveTo(395, -45, 430, 20, 393, 30);
    context.bezierCurveTo(393, 30, 365, 33, 345, 20);
    context.bezierCurveTo(345, 20, 370, 75, 315, 80);
    context.bezierCurveTo(315, 80, 290, 80, 275, 65);
    context.bezierCurveTo(275, 65, 295, 120, 235, 130);
    context.bezierCurveTo(235, 130, 200, 135, 175, 100);
    context.bezierCurveTo(175, 100, 165, 165, 115, 150);
    context.bezierCurveTo(115, 150, 75, 145, 73, 115);
    context.bezierCurveTo(73, 115, 17, 215, -45, 120);
    context.bezierCurveTo(-45, 120, -120, 190, -155, 105);
    context.bezierCurveTo(-155, 105, -250, 135, -255, 110);
    context.bezierCurveTo(-255, 110, -260, 85, -250, 75);
    context.bezierCurveTo(-250, 75, -345, 110, -325, 25);
    context.bezierCurveTo(-325, 25, -440, 30, -370, -28);
    context.bezierCurveTo(-370, -28, -450, -65, -380, -90);
    context.bezierCurveTo(-380, -90, -439, -145, -368, -145);
    context.bezierCurveTo(-368, -145, -380, -200, -330, -190);
    context.bezierCurveTo(-330, -190, -350, -245, -260, -235);
    context.bezierCurveTo(-260, -235, -300, -180, -315, -140);
    context.bezierCurveTo(-315, -140, -325, -140, -325, -100);
    context.bezierCurveTo(-325, -100, -260, 130, 75, 85);
    context.bezierCurveTo(75, 85, 276, 58, 341, -75);
    context.bezierCurveTo(341, -75, 406, -208, 205, -265);
    context.fillStyle = '#FBCF68';
    context.fill();
    context.stroke();

    context.beginPath();//上左裙邊
    context.bezierCurveTo(-260, -235, -267, -275, -239, -275);
    context.bezierCurveTo(-239, -275, -240, -260, -260, -235);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//上中裙邊
    context.bezierCurveTo(-190, -300, -180, -310, -168, -300);
    context.bezierCurveTo(-168, -300, -177, -283, -180, -280);
    context.bezierCurveTo(-180, -280, -180, -280, -190, -300);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//上右裙邊
    context.bezierCurveTo(-95, -325, -75, -330, -55, -315);
    context.bezierCurveTo(-55, -315, -50, -330, -37, -330);
    context.bezierCurveTo(-37, -330, -35, -315, -47, -298);
    context.bezierCurveTo(-47, -298, -68, -298, -78, -296);
    context.bezierCurveTo(-78, -296, -90, -310, -95, -325);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下方杯子左邊補齊
    context.bezierCurveTo(-408, -60, -395, -37, -370, -28);
    context.bezierCurveTo(-370, -28, -387, -20, -391, -4);
    context.lineTo(-408, -60);
    context.fillStyle = '#FBCF68';
    context.fill();
    context.stroke();

    context.beginPath();//下方杯子右邊補齊
    context.moveTo(409, -6);
    context.lineTo(425, -47);
    context.bezierCurveTo(425, -47, 410, -38, 394, -46);
    context.bezierCurveTo(394, -46, 405, -30, 409, -6);
    context.fillStyle = '#FBCF68';
    context.fill();
    context.stroke();

    context.beginPath();//下方杯子
    context.moveTo(-385, 16);
    context.lineTo(-315, 240);
    context.bezierCurveTo(-315, 240, -290, 265, -265, 273);
    context.bezierCurveTo(-265, 273, -250, 310, -215, 300);
    context.bezierCurveTo(-215, 300, -190, 355, -120, 335);
    context.bezierCurveTo(-120, 335, -80, 410, -30, 340);
    context.bezierCurveTo(-30, 340, 0, 420, 50, 350);
    context.bezierCurveTo(50, 350, 120, 410, 130, 335);
    context.bezierCurveTo(130, 335, 225, 350, 233, 305);
    context.bezierCurveTo(233, 305, 280, 300, 285, 275);
    context.bezierCurveTo(285, 275, 305, 265, 313, 250);
    context.lineTo(395, 30);
    context.bezierCurveTo(395, 30, 365, 35, 345, 20);
    context.bezierCurveTo(345, 20, 370, 75, 315, 80);
    context.bezierCurveTo(315, 80, 290, 80, 275, 65);
    context.bezierCurveTo(275, 65, 295, 120, 235, 130);
    context.bezierCurveTo(235, 130, 200, 135, 175, 100);
    context.bezierCurveTo(175, 100, 165, 165, 115, 150);
    context.bezierCurveTo(115, 150, 75, 145, 73, 115);
    context.bezierCurveTo(73, 115, 17, 215, -45, 120);
    context.bezierCurveTo(-45, 120, -120, 190, -155, 105);
    context.bezierCurveTo(-155, 105, -250, 135, -255, 110);
    context.bezierCurveTo(-255, 110, -260, 85, -250, 75);
    context.bezierCurveTo(-250, 75, -345, 110, -325, 25);
    context.bezierCurveTo(-325, 25, -355, 30, -385, 16);
    context.fillStyle = '#FBCF68';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第一條
    context.moveTo(-385, 16);
    context.lineTo(-315, 240);
    context.bezierCurveTo(-315, 240, -290, 265, -265, 273);
    context.lineTo(-335, 25);
    context.bezierCurveTo(-335, 25, -360, 30, -385, 16);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第二條
    context.moveTo(-215, 300);
    context.lineTo(-262, 80);
    context.bezierCurveTo(-262, 80, -270, 81, -280, 82);
    context.lineTo(-230, 300);
    context.bezierCurveTo(-230, 300, -221, 303, -215, 300);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第三條
    context.moveTo(-185, 113);
    context.lineTo(-135, 338);
    context.bezierCurveTo(-135, 338, -126, 337, -120, 335);
    context.bezierCurveTo(-120, 335, -107, 355, -105, 355);
    context.lineTo(-155, 105);
    context.bezierCurveTo(-155, 105, -168, 110, -185, 113);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第四條
    context.moveTo(-45, 120);
    context.lineTo(-30, 340);
    context.lineTo(-45, 357);
    context.lineTo(-65, 135);
    context.lineTo(-45, 120);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第五條
    context.moveTo(73, 115);
    context.lineTo(50, 350);
    context.lineTo(65, 361);
    context.lineTo(85, 137);
    context.bezierCurveTo(85, 137, 75, 130, 73, 115);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第六條
    context.moveTo(175, 100);
    context.lineTo(130, 335);
    context.lineTo(153, 337);
    context.lineTo(203, 125);
    context.bezierCurveTo(203, 125, 180, 115, 175, 100);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子第七條
    context.moveTo(233, 305);
    context.lineTo(285, 72);
    context.lineTo(300, 78);
    context.lineTo(251, 301);
    context.lineTo(233, 305);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下杯子最右條
    context.moveTo(360, 27);
    context.lineTo(285, 275);
    context.bezierCurveTo(285, 275, 305, 265, 313, 250);
    context.lineTo(395, 30);
    context.bezierCurveTo(395, 30, 375, 30, 360, 27);
    context.fillStyle = '#FABA25';
    context.fill();
    context.stroke();

    context.beginPath();//下面奶油線補齊
    context.bezierCurveTo(-115, -242, -50, -140, -173, -20);
    context.moveTo(-115, -242);
    context.bezierCurveTo(-115, -242, -60, -155, -100, -100);
    context.bezierCurveTo(-100, -100, -130, -50, -151, 0);
    context.moveTo(-115, -242);
    context.bezierCurveTo(-115, -242, -30, -125, -125, 20);
    context.moveTo(-115, -242);
    context.bezierCurveTo(-115, -242, -55, -200, -81, -100);
    context.bezierCurveTo(-81, -100, -100, -25, -34, 16);
    context.moveTo(-73, -227);
    context.bezierCurveTo(-73, -227, -73, -153, -25, -85);
    context.bezierCurveTo(-25, -85, 0, -48, 10, -5);
    context.stroke();

    context.beginPath();//右邊奶油線補齊
    context.bezierCurveTo(-42, -385, 5, -275, -60, -215);
    context.moveTo(-42, -385);
    context.bezierCurveTo(-42, -385, 45, -260, -35, -157);
    context.moveTo(-42, -385);
    context.bezierCurveTo(-42, -385, 0, -350, 10, -235);
    context.bezierCurveTo(10, -235, 20, -165, 50, -125);
    context.moveTo(0, -374);
    context.bezierCurveTo(0, -374, 13, -275, 30, -260);
    context.bezierCurveTo(30, -260, 50, -235, 78, -167);
    context.moveTo(10, -250);
    context.bezierCurveTo(10, -250, 30, -185, 60, -150);
    context.stroke();

    context.beginPath();//左邊奶油線補齊
    context.bezierCurveTo(-245, -335, -170, -260, -300, -104);
    context.moveTo(-245, -335);
    context.bezierCurveTo(-245, -335, -150, -250, -250, -70);
    context.moveTo(-204, -225);
    context.bezierCurveTo(-204, -225, -190, -160, -165, -80);
    context.moveTo(-200, -314);
    context.bezierCurveTo(-200, -314, -205, -230, -180, -215);
    context.bezierCurveTo(-180, -215, -160, -210, -130, -136);
    context.moveTo(-200, -314);
    context.bezierCurveTo(-200, -314, -180, -225, -117, -168);
    context.stroke();

    context.beginPath();//上面奶油線補齊
    context.moveTo(-150, -385);
    context.bezierCurveTo(-150, -385, -120, -340, -170, -260);
    context.moveTo(-150, -385);
    context.bezierCurveTo(-150, -385, -100, -340, -160, -240);
    context.moveTo(-131, -320);
    context.bezierCurveTo(-131, -320, -135, -265, -100, -243);
    context.moveTo(-120, -370);
    context.bezierCurveTo(-120, -370, -125, -310, -103, -290);
    context.bezierCurveTo(-103, -290, -83, -272, -76, -253);
    context.moveTo(-110, -358);
    context.bezierCurveTo(-110, -358, -114, -315, -65, -267);
    context.stroke();
}
window.addEventListener('load', doFirst);