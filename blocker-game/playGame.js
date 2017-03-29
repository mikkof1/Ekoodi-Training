/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.playGame = (function () {
    var move = 10;

    var heroTimer;


    function startNew() {


        gameApp.drawGame().draw();
    }

    function goUpper() {
//heroTimer=setInterval(uppp,100);
//function uppp(){
        if (player.y > 0)
            player.y = player.y - move;
//}
        //requestAnimationFrame(goUpper);
        //  gameApp.drawGame.draw();
    }

    function goDowner() {
        if (player.y < canvas.height - player.height)
            player.y = player.y + move;
        // gameApp.drawGame.draw();
    }

    return {
        onStart: function () {
            startNew();
            document.getElementById("points").innerText = "Nyt alkaaa";
        },
        goUpUp: function () {

            goUpper();
        },
        goUpDown: function () {
            //player.y = player.y;
            clearInterval(heroTimer);
        },
        goDown: function () {
            goDowner();
        },
        doKeyDown: function (e) {
            document.getElementById("points").innerText = "Textiä: " + e.keyCode;
            if (e.keyCode == 38 || e.keyCode == 87) { // up/w
                goUpper();
            }

            if (e.keyCode == 40 || e.keyCode == 83) { // down/s
                goDowner();
            }
        }

    }
})();
