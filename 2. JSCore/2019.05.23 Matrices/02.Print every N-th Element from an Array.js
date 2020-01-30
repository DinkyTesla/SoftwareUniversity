function printNth(input) {
    
    let stepOfN = +input[input.length - 1];
    input.pop();

    for (let i = 0; i < input.length; i+=stepOfN) {
        console.log(input[i]);
    }
}

printNth(['1', 
'2',
'3', 
'4', 
'5', 
'6']
)