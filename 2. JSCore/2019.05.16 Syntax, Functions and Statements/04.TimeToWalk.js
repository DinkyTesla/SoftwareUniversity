function calculateTimeToWalk(numberOfSteps, lengthOfStep, studentSpeed) {

let metersPerMinute = (studentSpeed * 1000) / 60;

let distance = numberOfSteps * lengthOfStep;

let bonusMinutes = Math.floor(distance / 500)

let timeTakenInMinutes = (distance / metersPerMinute) + bonusMinutes;

console.log(timeTakenInMinutes);
}

calculateTimeToWalk(2564, 0.70, 5.5);
//The first is the number of steps the student takes from their home to the university
//Тhe second number is the length of the student's footprint in meters
//Тhe third number is the student speed in km/h


//Every 500 meters the students a rest and takes a 1 minute break.