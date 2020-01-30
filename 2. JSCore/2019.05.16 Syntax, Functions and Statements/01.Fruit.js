function calculateMoney(fruit, grams, PricePerKilo){

let weight = grams / 1000;
let moneyINeed = (weight * PricePerKilo);

let result = `I need $${moneyINeed.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`;
console.log(result);
}
