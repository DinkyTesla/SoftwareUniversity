function calorieObject(input) {
    let foodCouples = {};
    for(let i = 0; i < input.length; i+=2) {
        foodCouples[input[i]] = +input[i+1];
    }

    console.log(foodCouples);
}

calorieObject(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);