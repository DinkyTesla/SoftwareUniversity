function sortedList() {
    let myObj = {
        list: [],
        size: 0,
        add: function (element) {
            this.list.push(element);
            this.size++;
            this.list = this.list.sort((a, b) => a - b);
        },
        remove: function (index) {
            if (index >= 0 && index < this.list.length) {
                this.list.splice(index, 1);
                this.size--;
            } 
            // else {
            //     throw new Error("Incorrect index!");
            // }
        },
        get: function(index){
            if (index >= 0 && index < this.list.length) {
                return this.list[index];
            }

        }

    }
    // myObj.add(5);
    // myObj.add(1);
    // myObj.add(2);
    // return myObj.get(0);
    return myObj;
}

console.log(sortedList());