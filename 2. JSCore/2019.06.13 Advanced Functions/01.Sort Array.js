function sorter(arr, typeOfSorting) {

    if (typeOfSorting === 'asc') {
        arr.sort((a, b) => a - b);
        return arr;
    } else if (typeOfSorting === 'desc') {
        arr.sort((a, b) => b - a);
        return arr;
    }

}
console.log(sorter([14, 7, 17, 6, 8], 'desc'));