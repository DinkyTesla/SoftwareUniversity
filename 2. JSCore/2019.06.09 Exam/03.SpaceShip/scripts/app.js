function spaceshipCrafting() {
	let titaniumCores = Math.round(document.getElementById("titaniumCoreFound").value);
	let aluminiumCores = Math.round(document.getElementById("aluminiumCoreFound").value);
	let magnesiumCores = Math.round(document.getElementById("magnesiumCoreFound").value);
	let carbonCores = Math.round(document.getElementById("carbonCoreFound").value);
	let lossesPercent = Math.round(document.getElementById("lossesPercent").value);

	lossesPercent = lossesPercent / 4; // get the single type percent loses
	lossesPercent = 1 - (lossesPercent / 100) // turn into miltiplyer

	titaniumCores = Math.round(titaniumCores * lossesPercent);
	aluminiumCores = Math.round(aluminiumCores * lossesPercent);
	magnesiumCores = Math.round(magnesiumCores * lossesPercent);
	carbonCores = Math.round(carbonCores * lossesPercent);

	let titaniumBars = Math.round(titaniumCores / 25);
	let aluminiumBars = Math.round(aluminiumCores / 50);
	let magnesiumBars = Math.round(magnesiumCores / 75);
	let carbonBars = Math.round(carbonCores / 100);

	let theUndefinedShip = +0;
	let nullMaster = +0;
	let jSONCrew = +0;
	let falseFleet = +0;
	let stop = 0;

	while (stop < 1) {

		if (titaniumBars >= 7 && aluminiumBars >= 9 && magnesiumBars >= 7 & carbonBars >= 7) {
			titaniumBars -= 7;
			aluminiumBars -= 9;
			magnesiumBars -= 7;
			carbonBars -= 7;
			theUndefinedShip += 1;
		}

		if (titaniumBars >= 5 && aluminiumBars >= 7 && magnesiumBars >= 7 & carbonBars >= 5) {
			titaniumBars -= 5;
			aluminiumBars -= 7;
			magnesiumBars -= 7;
			carbonBars -= 5;
			nullMaster += 1;
		}

		if (titaniumBars >= 3 && aluminiumBars >= 5 && magnesiumBars >= 5 & carbonBars >= 2) {
			titaniumBars -= 3;
			aluminiumBars -= 5;
			magnesiumBars -= 5;
			carbonBars -= 2;
			jSONCrew += 1;
		}
		
		if (titaniumBars >= 2 && aluminiumBars >= 2 && magnesiumBars >= 3 & carbonBars >= 1) {
			titaniumBars -= 2;
			aluminiumBars -= 2;
			magnesiumBars -= 3;
			carbonBars -= 1;
			falseFleet += 1;
		} else {
			stop = 1;
		}

	}

	let result = '';

	if (theUndefinedShip > 0) {
		result += `${theUndefinedShip} THE-UNDEFINED-SHIP`;
	}
	if (nullMaster > 0) {
		result += `, ${nullMaster} NULL-MASTER`;
	}
	if (jSONCrew > 0) {
		result += `, ${jSONCrew} JSON-CREW`;
	}
	if (falseFleet > 0) {
		result += `, ${falseFleet} FALSE-FLEET`;
	}

	document.getElementById('builtSpaceships').getElementsByTagName('p')[0].textContent= result.trim();
	document.getElementById('availableBars').getElementsByTagName('p')[0].textContent= `${titaniumBars} titanium bars, ${aluminiumBars} aluminum bars, ${magnesiumBars} magnesium bars, ${carbonBars} carbon bars`;
	// if (theUndefinedShip > 0 && nullMaster >= 0 && jSONCrew > 0 && falseFleet >= 0 ) {
		
	// 	document.getElementById('builtSpaceships').getElementsByTagName('p')[0].textContent= `${theUndefinedShip} THE-UNDEFINED-SHIP, ${nullMaster} NULL-MASTER, ${jSONCrew} JSON-CREW, ${falseFleet} FALSE-FLEET`;
	// } else if (theUndefinedShip > 0 && nullMaster >= 0 && jSONCrew > 0 && falseFleet >= 0 ) {
		
	// 	document.getElementById('builtSpaceships').getElementsByTagName('p')[0].textContent= `${theUndefinedShip} THE-UNDEFINED-SHIP, ${nullMaster} NULL-MASTER, ${jSONCrew} JSON-CREW, ${falseFleet} FALSE-FLEET`;
	// }
}
