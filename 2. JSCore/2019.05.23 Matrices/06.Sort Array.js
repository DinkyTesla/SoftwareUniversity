function sortByTwoCriteria(arr) {

    arr.sort((a, b) => {
        
        return a.length - b.length || a > b;
    }).forEach(x => console.log(x));
}

sortByTwoCriteria(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
);