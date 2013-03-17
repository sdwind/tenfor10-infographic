$(function () {
	site.init();
});

var site = (function () {
	var seconds = 5;
	var goal;
	var signupsPerIcon;
	var iconsPerRow;
	var signups;
	var numberOfRows;

	var initializeDisplay = function (data) {
		if (data) {
			goal = data.Goal;
			signupsPerIcon = data.SignUpsPerIcon;
			iconsPerRow = data.IconsPerRow;
			signups = data.SignUps ? data.SignUps : 0;
			numberOfRows = Math.ceil((goal / signupsPerIcon) / iconsPerRow);

			// initiliaze view
			$("#total").html(goal);
			$("#count").html(signups);
			$("#goal").hide();

			// Add icons to view based on goal
			for (var i = 1; i <= numberOfRows; i++) {
				rowDiv = document.createElement('div');
				$(rowDiv).addClass("row");

				iconsPerRow = i == numberOfRows ?
					Math.ceil((goal - signupsPerIcon * iconsPerRow * (numberOfRows - 1)) / signupsPerIcon)
					: iconsPerRow;

				for (var j = 1; j <= iconsPerRow; j++) {
					iconDiv = document.createElement('div');
					$(iconDiv).addClass("span1").addClass(site.isOdd(j) == true ? "icon-man" : "icon-women").appendTo($(rowDiv));
				}

				$(rowDiv).appendTo($("#mainContent"));
			}

			site.getSignups();
		}
	};

	return {
		init: function () {
			site.getInfographicData(initializeDisplay);
		},
		getSignups: function () {
			setInterval(function () {
				site.getInfographicData(site.updateIcons);
			}, seconds * 1000);
		},
		getInfographicData: function (callback) {
			$.getJSON('signups.txt', function (data) {
				callback(data);
			}).error(function (jqXHR, textStatus, errorThrown) {
				alert(jqXHR.status);
				alert(textStatus);
				alert(errorThrown);
			});
		},
		isOdd: function (num) {
			return (num % 2) == 1;
		},
		updateIcons: function (data) {
			if (data.SignUps) {
				signups = data.SignUps > goal ? goal : data.SignUps;
			} else {
				signups = 0;
			}
			
			var iconsToFill = Math.ceil(signups / 5);
			var currentClassName;
			var newClassName = "";

			// Update goal with current number of signups
			$("#count").html(signups);

			// Update icon grid
			if (iconsToFill < 1) {
				switch (signups) {
					case 1:
						newClassName = "full-1";
						break;
					case 2:
						newClassName = "full-2";
						break;
					case 3:
						newClassName = "full-3";
						break;
					case 4:
						newClassName = "full-4";
						break;
					case 5:
						newClassName = "full";
						break;
					case 0:
						newClassName = "";
						break;
				}
			} else {
				var icons = signups - (iconsToFill * signupsPerIcon) + signupsPerIcon;
				switch (icons) {
					case 1:
						newClassName = "full-1";
						break;
					case 2:
						newClassName = "full-2";
						break;
					case 3:
						newClassName = "full-3";
						break;
					case 4:
						newClassName = "full-4";
						break;
					case 5:
						newClassName = "full";
						break;
				}
			}

			currentClassName = newClassName;

			var fullRange = iconsToFill == 0 ? iconsToFill : iconsToFill - 1;
			$(".span1:lt(" + fullRange + ")").addClass("full");

			// if goal reached, show message
			if (signups >= goal) {
				$(".full").removeClass("[class^='full'']").addClass("full-1");
				$("#goal").show();
			} else {
				// If number of signups changed since last check,
				// remove all classes on last icon and reset
				if (currentClassName != newClassName) {
					$(".span1:eq(" + fullRange + ")").removeClass();
				}
				$(".span1:eq(" + fullRange + ")").addClass(newClassName).addClass("heartbeat");
			}
		}
	};
} ());