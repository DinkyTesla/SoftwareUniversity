// Every day
// in the morning he drinks 3 cups of coffee (150 ml per cup) // 180
// at every lunch he drinks 2 bottles of coca cola (250 ml per bottle) // 40
// at every brunch he drinks 3 cups of tea (350 ml per tea) // 210
//430
// Every 5th day he drinks 3 energy drinks (500 ml per can)
// Every 9th day he drinks 4 bottles of coca cola and 2 energy drinks


// Coffee - 40 mg caffeine per 100 ml
// Coca Cola - 8 mg caffeine per 100 ml
// Tea - 20 mg caffeine per 100 ml
// Energy - 30 mg caffeine per 100 ml


// "{consumedCaffeine} milligrams of caffeine were consumed"
function solve(daysOfStudy) {
    let totalCaffeine = +0;

    let coffeeCup = +40 * 1.5; //60
    let colaBottle = +8 * 2.5; //20
    let teaCup = +20 * 3.5; //70
    let energyDrink = +30 * 5; //150

    for (let index = 1; index <= daysOfStudy; index++) {

        totalCaffeine += (3 * coffeeCup) + (2 * colaBottle) + (3 * teaCup);

        if (index % 5 === 0) {
            totalCaffeine += (3 * energyDrink);
        }
        if (index % 9 === 0) {
            totalCaffeine += (2 * energyDrink) + (4 * colaBottle);
        }
    }
    
    console.log(totalCaffeine + ' milligrams of caffeine were consumed');
}

solve(8);
