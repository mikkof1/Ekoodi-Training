/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.drawGame = function () {

    var canvas = document.getElementById("gameCanvas");
    var cHei=canvas.height;
    var cWid=canvas.width;
    var ctx = canvas.getContext("2d");



    function drawGame() {
        setInterval(moveEvil,100);
        function moveEvil() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            if(evil1.x>(-1*evil1.width)+3) {
                evil1.x -= 8;
                ctx.fillStyle = evil1.color;
                ctx.fillRect(evil1.x, evil1.y, evil1.width, evil1.height);
                evil2.x -= 8;
                ctx.fillStyle = evil2.color;
                ctx.fillRect(evil2.x, evil2.y, evil2.width, evil2.height);
            }

            ctx.fillStyle = player.color;
            ctx.fillRect(player.x, player.y, player.width, player.height);
        }




    }

    return {
        draw:function () {
            drawGame();
        }

    }
}
