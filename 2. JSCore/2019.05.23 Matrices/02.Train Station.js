function passangersOnATrain(wagonCapacity, passangersArray) {

    let theTrain = [];
    let remainingPassangers = +0;
    let passangersToBoard = +0;

    for (let index = 0; index < passangersArray.length; index++) {

        passangersToBoard = +passangersArray[index] + remainingPassangers;
        // console.log(passangersToBoard + " passangers to board " + index);

        if (passangersToBoard <= wagonCapacity) {
            theTrain[index] = passangersToBoard;
            // console.log(theTrain[index] + " the train index " + index)
            remainingPassangers = +0;

        } else if (passangersToBoard > wagonCapacity) {

            theTrain[index] = +wagonCapacity;
            // console.log(theTrain[index] + " the train index " + index)
            remainingPassangers -= +wagonCapacity;
            // console.log(remainingPassangers + " remaining passangers " + index)
            remainingPassangers += +passangersArray[index];
            // console.log(remainingPassangers + " remaining passangers " + index)

        }
    }
    
    // let result = theTrain.join(', ')
    // console.log(`[ ${result} ]`);

    console.log(theTrain);

    if (remainingPassangers > 0) {
        console.log(`Could not fit ${remainingPassangers} passengers`);
    } else {
        console.log("All passengers aboard");
    }
}

passangersOnATrain(10, [9, 39, 1, 0, 0]);