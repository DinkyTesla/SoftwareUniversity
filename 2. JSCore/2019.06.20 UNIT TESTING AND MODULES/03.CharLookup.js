const expect = require("chai").expect;

function lookupChar(string, index) {

    if (typeof (string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }

    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

describe("lookupChar", function () {

    it("Should return undefined with a non-string first parameter", function () {
        let expected = lookupChar(1, 1);
        expect(expected).to.equal(undefined, "fFrst parameter should be string only!")
    });

    it("Should return undefined with a non-integer second parameter", function () {
        let expected = lookupChar("1", "1");
        expect(expected).to.equal(undefined, "Second parameter should be integer only!")
    });

    it("Should return undefined with a floating point-integer second parameter", function () {
        let expected = lookupChar("1", 1.5);
        expect(expected).to.equal(undefined, "Second parameter should be integer only!(test with floating point)")
    });

    it("Should return 'Incorrect index' with negative index", function(){
        let expected = lookupChar("Hello", -6);
        expect(expected).to.equal("Incorrect index", "The function did not return the correct index!")
    });

    it("Should return 'Incorrect index' with bigger than length index", function(){
        let expected = lookupChar("Hello", 16);
        expect(expected).to.equal("Incorrect index", "The function did not return the correct index!(Index is bigger than the string length)")
    });

    it("Should return correct character", function(){
        let expected = lookupChar("Hello", 1);
        expect(expected).to.equal('e', "The function should return correct result")
    });

});