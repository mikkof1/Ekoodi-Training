/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.drawGame = function () {
  // https://www.kirupa.com/html5/animating_many_things_on_a_canvas.htm
   // var canvas = document.getElementById("gameCanvas");
    var ctx = canvas.getContext("2d");
//	var ctxHero = canvas.getContext("2d");
//	 var ctxEvil = canvas.getContext("2d");
	//var evilWallTimer;
	//var heroTimer;
	var gameOn=true;
	var rounds=3;
	var evilSpeed=3;
	var backColor="#ffe6cc";


    function drawGame() {
		
		setPlayer();
		 newEvilWall();
  //  evilWallTimer = setInterval(draw,20);
	// heroTimer=setInterval(moveHero,10);
		// drawHero();	
		draw();

    }
	
	function draw(){
		ctx.clearRect(0, 0, canvas.width, canvas.height);
		ctx.fillStyle = backColor;
        ctx.fillRect(0, 0, canvas.width, canvas.height);
		evilUpdate();
		heroUpdate();
		if(gameOn){
		requestAnimationFrame(draw);
		}
	}
	/*
	function drawHero(){
		ctxHero.clearRect(0, 0, canvas.width, canvas.height);

		heroUpdate();
		
		requestAnimationFrame(drawHero);
		
	}*/
	
	function evilUpdate() {
          //  ctx.clearRect(0, 0, canvas.width, canvas.height);
            evil1.x -= evilSpeed;
            ctx.fillStyle = evil1.color;
            ctx.fillRect(evil1.x, evil1.y, evil1.width, evil1.height);
            evil2.x -= evilSpeed;
            ctx.fillStyle = backColor;
            ctx.fillRect(evil2.x, evil2.y, evil2.width, evil2.height);
			
			var stopTheEvilWall=evil1.x< -1*evil1.width;			
            if(stopTheEvilWall) {
			//clearInterval(evilWallTimer);
				newEvilWall();
				rounds--;
				if(rounds<1){
					gameOn=false;
				}
			}


        }
		
	function heroUpdate(){
		
		ctx.fillStyle = player.color;
        ctx.fillRect(player.x, player.y, player.width, player.height);
		
	}
	
	function newEvilWall(){
		var cHei=canvas.height;
        var cWid=canvas.width;
		var place = Math.floor((Math.random() * cHei-160-40)+80+40);
		 evil1 = gameApp.player(wid-30, 0, 30, cHei, "red");
		 evil2 = gameApp.player(wid-30, place, 30, 80, "white");
	}
	
	function setPlayer(){
		 player = gameApp.player(30, hei / 2, 50, 50, "violet");
	}

    return {
        draw:function () {
            drawGame();
        },
		

    }
}
