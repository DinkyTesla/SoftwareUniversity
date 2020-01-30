function comparator(givenNumber) {
//var digits = (""+givenNumber).split("").map(Number);
//let testArray = givenNumber.toString().split('').map(Number);
var digits = Array.from(String(givenNumber), Number);

let firstDigit = digits[0];
let areEqual = true;
let sum = 0;

for (i = 0; i < digits.length; i++) {
    if (firstDigit !== digits[i]){
      areEqual = false;
    }

sum += digits[i];
}
console.log(areEqual)
console.log(sum);
}

comparator(2222222);