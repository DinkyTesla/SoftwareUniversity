function delimit(input) {

let delimiter = input[input.length - 1];
input.pop();

let result = input.join(delimiter);

console.log(result);
}

delimit(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']);