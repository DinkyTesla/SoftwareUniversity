function AddRemover(commands) {

    let myArray = [];
    let myNumber = +0;

    commands.forEach(element => {
        
        ++myNumber;

        if (element === "add") {

            myArray.push(myNumber);
        }
        else if (element === "remove") {

            myArray.pop();
        }
    });

    if (myArray.length === 0) {

        console.log("Empty");
    }
    else {

        myArray.forEach(element => {
            console.log(element);
        });
    }
}

AddRemover(['add', 
'add', 
'remove', 
'add', 
'add']
);