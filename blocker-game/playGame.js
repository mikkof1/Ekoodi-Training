/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.playGame = (function () {


    function startNew() {

        gameApp.drawGame().draw();
        gameApp.drawGame().drawPlayer(player);
    }

    function goUpper() {
        player.y = player.y - 10;
        gameApp.drawGame().draw();
    }

    function goDowner() {
        player.y = player.y + 10;
        gameApp.drawGame().draw();
    }

    return {
        onStart: function () {
            startNew();
        },
        goUp: function () {
         //   setInterval(goUpper(), 100);
            goUpper();

        },
        goDown: function () {
            goDowner();
        }

    }
})();
