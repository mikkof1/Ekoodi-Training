/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.drawGame = function () {
    // https://www.kirupa.com/html5/animating_many_things_on_a_canvas.htm
    // var canvas = document.getElementById("gameCanvas");
    var ctx = canvas.getContext("2d");
//	var ctxHero = canvas.getContext("2d");
//	 var ctxEvil = canvas.getContext("2d");
    var newWalltimer = 0;
    var timer;
    var gameOn = true;
    //  var rounds = 3;
    var evilSpeed = 2;
    var backColor = "#ffe6cc";
    var evilWalls = [];
    var safeHight = 80;


    function drawGame() {

        setPlayer();
        //newEvilWall();
        //  evilWallTimer = setInterval(draw,20);
        timer = setInterval(clock, 10);
        // drawHero();
        draw();

    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.fillStyle = backColor;
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        evilUpdate();
        heroUpdate();
        if (gameOn) {
            requestAnimationFrame(draw);
        }
        else
        {
            ctx.font = "100px Comic Sans MS";
            ctx.fillStyle = "green";
            ctx.textAlign = "center";
            ctx.fillText("Game Over", canvas.width/2, canvas.height/2);
        }
    }

    function clock() {

        if (newWalltimer < 0 && gameOn) {
            newWalltimer = Math.floor(Math.random() * 280) + 180;
            newEvilWall();
        }
        newWalltimer--;

        document.getElementById("tieto").innerText = "evilwalls: " + evilWalls.length;
    }


    function evilUpdate() {

        for (var i = 0; i < evilWalls.length; i++) {
            evilWalls[i].x -= evilSpeed;
            ctx.fillStyle = evilWalls[i].color;
            // upper wall
            ctx.fillRect(evilWalls[i].x, evilWalls[i].upperY, evilWalls[i].width, evilWalls[i].upperHeight);
            // downer wall
            ctx.fillRect(evilWalls[i].x, evilWalls[i].downerY, evilWalls[i].width, evilWalls[i].downerHeight);

            var safeY1 = evilWalls[i].upperY + evilWalls[i].upperHeight;
            var safeY2 = evilWalls[i].downerY;

            if ((evilWalls[i].x <= player.x + player.width) && evilWalls[i].x + evilWalls[i].width > player.x) {
                if (player.y < safeY1 || player.y + player.height > safeY2) {
                    gameOn = false;
                }

            }


            var evilWallHitsEnd = evilWalls[i].x < -1 * evilWalls[i].width;
            if (evilWallHitsEnd) {
                //clearInterval(evilWallTimer);
                //  newEvilWall();
                //  rounds--;
                //  if (rounds < 1) {
                //  gameOn = false;
                //  }
            }

        }


    }

    function heroUpdate() {

        ctx.fillStyle = player.color;
        ctx.fillRect(player.x, player.y, player.width, player.height);

    }


    function newEvilWall() {
        var id = 0;
        var upperHeight = Math.floor((Math.random() * (canvas.height - safeHight )));
        var downerY = upperHeight + safeHight;
        var downerHeigth = canvas.height - downerY;
        var color = "red";
        var width = 20;

        for (var i = 0; i < evilWalls.length; i++) {
            if (evilWalls[i].x + evilWalls[i].width + 5 < 0) {
                id = evilWalls[i].id;
                break;
            }
        }
        if (id == 0) {
            id = evilWalls.length + 1;
        }

        var evil = gameApp.evilWall(id, canvas.width, 0, upperHeight, downerY, downerHeigth, width, color);


        if (evilWalls.length == evil.id - 1)
            evilWalls.push(evil);
        else
            evilWalls[evil.id - 1] = evil;
    }

    function setPlayer() {
        player = gameApp.player(30, canvas.height / 2 - 25, 50, 50, "violet");
    }

    return {
        draw: function () {
            drawGame();
        },


    }
}
