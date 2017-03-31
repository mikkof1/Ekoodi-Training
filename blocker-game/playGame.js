/**
 * Created by ekoodi on 28.3.2017.
 */
gameApp.playGame = (function () {
    var move = 7;
    var canvas = document.getElementById("gameCanvas");
    var heroTimer;
	var indexNumber=0;


    function startNew() {
        gameApp.drawGame().startGame();
    }

    function goUpper() {
//heroTimer=setInterval(uppp,100);
//function uppp(){
        if (player.y > 0)
            player.y = player.y - move;
		if (player.y < 0)
			player.y=0;
//}
        //requestAnimationFrame(goUpper);
        //  gameApp.drawGame.draw();
    }

    function goDowner() {
        if (player.y + player.height < canvas.height )
            player.y = player.y + move;
		if (player.y + player.height > canvas.height )
			player.y = canvas.height - player.height;
        // gameApp.drawGame.draw();
    }
	
	function moveCar(){
			if(keyState[38]){
				if (player.y > 0)
					player.y = player.y - move;
				if (player.y < 0)
					player.y=0;
			}
			
			if(keyState[40]){
				if (player.y + player.height < canvas.height )
					player.y = player.y + move;
				if (player.y + player.height > canvas.height )
					player.y = canvas.height - player.height;
			}
			
			indexNumber++;
			console.log("i: "+ indexNumber +"\n\rmover: " +mover);
			//document.getElementById("tieto2").innerText("i: "+indexNumber);
			
		mover = setTimeout(moveCar, 20);

		if(mover>20){
			//this.clearTimeout(mover);
			//mover=0;
		}
	}
	


    return {
        onStart: function () {
			if(youCanPlay){
				youCanPlay=false;
				startNew();
			}
        },
        goUpUp: function () {

            goUpper();
        },
        goUpDown: function () {
            player.y = player.y;
           // clearInterval(heroTimer);
        },
        goDown: function () {
            goDowner();
        },
        doKeyDown: function (e) {
            if (e.keyCode == 38 || e.keyCode == 87) { // up/w
                goUpper();
            }

            if (e.keyCode == 40 || e.keyCode == 83) { // down/s
                goDowner();
            }
        },
		keyDown: function(e){
		//mover = setInterval(moveCar, 100);
		if(pohjassa == false){
			pohjassa =true;
		keyState[e.keyCode || e.which]= true;
		moveCar();
		
		}
		//mover = setTimeout(moveCar, 10);
		},
		keyUp: function(e){
			keyState[e.keyCode || e.which]= false;
			 clearTimeout(mover);
			// keyState={};
			// mover=null;
		}

    }
})();
