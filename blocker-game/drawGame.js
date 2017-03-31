/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.drawGame = function () {
    // https://www.kirupa.com/html5/animating_many_things_on_a_canvas.htm
    // var canvas = document.getElementById("gameCanvas");

		var canvas = document.getElementById("gameCanvas");
	 var ctx = canvas.getContext("2d");
   
//	var ctxHero = canvas.getContext("2d");
//	 var ctxEvil = canvas.getContext("2d");
    var newWalltimer = 0;
	var drawTimer;
    var timer;
    var gameOn = true;
    //  var rounds = 3;
    var evilSpeed = 2;
    var backColor = "#ffe6cc";
    var evilWalls = [];
    var safeHight = 80;
	var points=0;
	var pointsTime = 50;
	
	var roadX = -10;
	var coin;
	var roadImg=new Image();
	var mainImg = new Image();
	var playerImg=new Image();
	var coinImg= new Image();
	

    function startGame() {
        player = gameApp.player(30, canvas.height / 2 - 25, 100, 50, "violet");
		coin = gameApp.player(-100, 0, 40, 40, "red");
		coinImg.src = "coin.png";
		playerImg.src = "car.png";
		roadImg.src = "road.png";
		points=0;
		timer = setInterval(gameClock, 10); 
		drawTimer=setInterval(draw, 10);	 
    }

	
	function endGame(){
		    ctx.font = "100px Comic Sans MS";
            ctx.fillStyle = "green";
            ctx.textAlign = "center";
            ctx.fillText("Game Over", canvas.width/2, canvas.height/2);
			youCanPlay=true;
	}

    function draw() {

        ctx.clearRect(0, 0, canvas.width, canvas.height);
	    roadUpdate();
        evilUpdate();
		coinUpdate();
        playerUpdate();

		
		if (!gameOn) {
           // requestAnimationFrame(draw); // one way make a loop
			clearInterval(drawTimer);
		    clearInterval(timer);
			endGame();
        }
    }

    function gameClock() {
		
	
        if (newWalltimer < 0 && gameOn) {
            newWalltimer = Math.floor(Math.random() * 280) + 180;
            newEvilWall();
			if(coin.x+coin.width+10<0)
				newCoin();
        }
        newWalltimer--;
		
		if(pointsTime<=0 && gameOn){
			pointsTime=50;
			points++;
			document.getElementById("points").innerText = "Points: " + points;
		}
		pointsTime--;

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

			// hit the wall test
            var safeY1 = evilWalls[i].upperY + evilWalls[i].upperHeight;
            var safeY2 = evilWalls[i].downerY;
			
			var bumber=3;

            if ((evilWalls[i].x <= player.x + player.width-bumber) && evilWalls[i].x + evilWalls[i].width > player.x+bumber) {
                if (player.y+bumber < safeY1 || player.y + player.height-bumber > safeY2) {
                  //  gameOn = false;
                }

            }


        } // for end


    } // evil update end

    function playerUpdate() {
		ctx.drawImage(playerImg, player.x, player.y);
    }
	
	function coinUpdate(){
		coin.x -= evilSpeed;
		ctx.drawImage(coinImg, coin.x, coin.y);
		
		var coinHorizontalHit=(coin.x <= player.x + player.width) && coin.x + coin.width > player.x;
		if (coinHorizontalHit) {

			var coinVerticalHit=player.y+player.height>=coin.y &&player.y<coin.y+coin.height;
			if(coinVerticalHit){
				points=points+1000;
				coin.x=-100;	
			}
        }
	}
	
	function roadUpdate(){
		roadX -= evilSpeed;
		if(roadX < -400)//521 road2
			roadX = 0;
		
	    ctx.drawImage(roadImg, roadX, 0);
	}
	
	function newCoin(){
		y = Math.floor(Math.random() * (canvas.height-120))+60;
		console.log("coin y: " +y);
		x = canvas.width + Math.floor((Math.random() * 120))+200;
		coin.x=x;
		coin.y=y;
		
	}


    function newEvilWall() {
        var id = 0;
		safeHight = Math.floor((Math.random() * 120))+ player.height + 10;
        var upperHeight = Math.floor((Math.random() * (canvas.height - safeHight )));
        var downerY = upperHeight + safeHight;
        var downerHeigth = canvas.height - downerY;
        var color = "#848484";
        var width = 20; // Math.floor((Math.random() * 80))+5;

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
	


	// Wait for image
	function loadRoad (callback){
		mainImg.onload=callback;
		mainImg.src = "road.png";
		}

	function drawMain(){
		ctx.clearRect(0, 0, canvas.width, canvas.height);	
		ctx.drawImage(mainImg, 10, 10);

		ctx.font = "100px Comic Sans MS";
        ctx.fillStyle = "green";
        ctx.textAlign = "center";
        ctx.fillText("Push Start", canvas.width/2, canvas.height/2);
	}


    return {
        startGame: function () {
            startGame();
        },
		drawDefault: function(){
			loadRoad(drawMain);
			
		}


    }
}
