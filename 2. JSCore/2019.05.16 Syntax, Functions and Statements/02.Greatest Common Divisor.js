function gcd(firstNumber, secondNumber) {

firstNumber = +firstNumber;
secondNumber = +secondNumber;// pravi inputa chislo na 100%;

let greatestDivisor = 0;

for (let i = 1 ; i <= Math.min(firstNumber,secondNumber); i++) {
if  (firstNumber % i === 0 && secondNumber % i ===0 ) {
    greatestDivisor = i;
}
}
console.log(greatestDivisor);
}
//while (secondNumber) {
//var tempNumber = secondNumber;
//secondNumber = firstNumber % secondNumber;
//firstNumber = tempNumber;
//}
//
//return firstNumber;
//}
