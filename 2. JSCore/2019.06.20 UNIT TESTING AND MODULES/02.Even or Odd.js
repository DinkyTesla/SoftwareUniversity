const expect = require("chai").expect;

function isOddOrEven(string) {

    if (typeof (string) !== 'string') {
        return undefined;
    }

    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

describe('isOddOrEven', function () {
    it("Test with number parameter, should return undefined", function() {
        let expected = isOddOrEven(100);

        expect(expected).to.equal(undefined, "function did not return the correct result.");
    });

    it("Test with object parameter, should return undefined", function () {

        let expected = isOddOrEven({name: 'George'});
        expect(expected).to.equal(undefined, "function did not return the correct result.");
    });

    it('Should return correct result with even length', function() {
       
        let expected = isOddOrEven("JS4Ever!");

        expect(expected).to.equal("even", "Function return correct result with even string length!")
    });

    it('Should return correct result with odd length', function() {
       
        let expected = isOddOrEven("JS4Ever");

        expect(expected).to.equal("odd", "Function return correct result with odd string length!")
    });
});

console.log(isOddOrEven('aaaa'));