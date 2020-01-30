function rotateThisArray(input) {

    let numOfRotations = input.pop();

    let result = [];

   // if ( numOfRotations % input.length === 0) {

    //    result = input.join(" ");
   //     console.log(result);
    //    return;
   // }

    for (let i = 0; i < numOfRotations % input.length; i++) {

        let temp = input[input.length - 1];

        for (let j = input.length - 1; j > 0; j--) {

            input[j] = input[j- 1];
        }

        input[0] = temp;
    }

    result = input.join(" ");
    console.log(result);
}

rotateThisArray(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
);