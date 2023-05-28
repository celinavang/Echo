// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {


	var exhibitvideo = document.querySelectorAll("[id='exhibitvideo']");

	var playbutton = document.querySelectorAll("[id='play-pause']");
	var rewindbutton = document.querySelectorAll("[id='rewind']");
	var forwardbutton = document.querySelectorAll("[id='forward']");
	var playimg = document.querySelectorAll("[id='play-pause-img']");

	var timeline = document.querySelectorAll("[id='timeline']");

	var currenttime = document.querySelectorAll("[id='currenttime']");
	var totaltime = document.querySelectorAll("[id='totaltime']");

	var videocontainer = document.getElementById("videocontainer");
	var exhibitmain = document.getElementById("exhibitmain");
	var recordimage = document.getElementById("recordimage");

	var returnbutton = document.getElementById("returntoexhibit");

	recordimage.addEventListener("click", function () {
		exhibitmain.style.display = "none";
		videocontainer.style.display = "initial";
	});

	returnbutton.addEventListener("click", function () {
		exhibitmain.style.display = "initial";
		videocontainer.style.display = "none";
	});

	for (var i = 0; i < playbutton.length; i++) {
		playbutton[i].addEventListener("click", function () {
			if (exhibitvideo[0].paused == true) {
				for (var i = 0; i < exhibitvideo.length; i++) {
					exhibitvideo[i].play();
					exhibitvideo[i].currentTime = exhibitvideo[0].currentTime;
				}
				for (var i = 0; i < playimg.length; i++) {
					playimg[i].src = "/Images/PauseButton.png";
				}
				
			} else {
				for (var i = 0; i < exhibitvideo.length; i++) {
					exhibitvideo[i].pause();
					exhibitvideo[i].currentTime = exhibitvideo[0].currentTime;
				}
				for (var i = 0; i < playimg.length; i++) {
					playimg[i].src = "/Images/PlayButton.png";
				}

			}
		})

	}

	for (var i = 0; i < rewindbutton.length; i++) {
		rewindbutton[i].addEventListener("click", function () {
			var time = exhibitvideo[0].currentTime - 15;
			if (time < 0) {
				time = 0;
			}
			for (var i = 0; i < exhibitvideo.length; i++) {
				exhibitvideo[i].currentTime = time;
			}
		})
	}

	for (var i = 0; i < forwardbutton.length; i++) {
		forwardbutton[i].addEventListener("click", function () {
			var time = exhibitvideo[0].currentTime + 15;
			if (time > exhibitvideo[0].duration) {
				time = exhibitvideo[0].duration - 1;
			}
			for (var i = 0; i < exhibitvideo.length; i++) {
				exhibitvideo[i].currentTime = time;
			}
		})
	}


	function calcTime(time) {
		var s = parseInt(time % 60);
		var m = parseInt((time / 60) % 60);

		if (s < 10) {
			s = '0' + s;
		}
		if (m < 10) {
			m = '0' + m;
		}

		var time = m + ':' + s;

		return time;
	}

	exhibitvideo[0].addEventListener("timeupdate", function () {

		var value = (100 / exhibitvideo[0].duration) * exhibitvideo[0].currentTime;

		for (var i = 0; i < timeline.length; i++) {
			timeline[i].value = value;
		}

		for (var i = 0; i < currenttime.length; i++) {
			currenttime[i].innerHTML = calcTime(exhibitvideo[0].currentTime);
		}

		for (var i = 0; i < totaltime.length; i++) {
			totaltime[i].innerHTML = calcTime(exhibitvideo[0].duration);
		}
	})


}


