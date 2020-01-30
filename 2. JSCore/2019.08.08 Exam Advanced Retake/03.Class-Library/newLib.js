class Library {
    constructor(name) {
        this.name = name;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: this.name.length,
            special: this.name.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        }
    }

    subscribe(name, type) {

        if (type !== 'normal' && type !== 'special' && type !== 'vip') {
            throw new Error(`The type ${type} is invalid`);
        };

        let alreadyIn = false;

        let subscriber = {
            name: name,
            type: type,
            books: []
        }

        if (this.subscribers.length > 0) {

            this.subscribers.forEach(sub => {

                if (sub.name === name) {
                    sub.type = type;
                    alreadyIn = true;
                }
            })
        }

        if (alreadyIn) {
            return;
        } else {

            this.subscribers.push(subscriber);
        }

        return subscriber;
    };

    unsubscribe(name) {

        let subFound = false;

        this.subscribers.forEach(sub => {

            if (sub.name === name) {

                let indexOfSub = this.subscribers.indexOf(sub);

                this.subscribers.splice(indexOfSub, 1);

                subFound = true;
            };
        });

        if (subFound) {
            return this.subscribers;
        } else {
            throw new Error(`There is no such subscriber as ${name}`);
        };
    };

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        let subFound = false;
        let allowAddFunc = false;
        let maxBooks = 0;
        let currentSub = {};
        // let newBook = {};

        this.subscribers.forEach(sub => {

            if (sub.name === subscriberName) {
                subFound = true;

                if (sub.type === 'normal') {
                    if (sub.books.length < this.subscriptionTypes.normal) {
                        let newBook = {
                            title: bookTitle,
                            author: bookAuthor
                        }
                        allowAddFunc = true;

                        sub.books.push(newBook);
                    }

                } else if (sub.type === 'special') {
                    if (sub.books.length < this.subscriptionTypes.special) {
                        let newBook = {
                            title: bookTitle,
                            author: bookAuthor
                        }
                        allowAddFunc = true;

                        sub.books.push(newBook);
                    }
                }
                else if (sub.type === 'special') {
                    if (sub.books.length < this.subscriptionTypes.vip) {
                        let newBook = {
                            title: bookTitle,
                            author: bookAuthor
                        }
                        allowAddFunc = true;

                        sub.books.push(newBook);
                    }
                }


                // let newBook = {
                //     title: bookTitle,
                //     author: bookAuthor
                // }

                // sub.books.push(newBook);
            }
        });

        if (subFound) {
            return currentSub;
        } else {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }
    }

    showInfo() {

        if (this.subscribers.length === 0) {
            return `${this.name} has no information about any subscribers`;
        } else {
            let result = ``;
            let booksArray = [];

            this.subscribers.forEach(sub => {
                result += `Subscriber: ${sub.name}, Type: ${sub.type}\n`;
                result += `Received books: `;

                sub.books.forEach(book => {
                    booksArray.push(`${book.title} by ${book.author}`);
                })

                result += `${booksArray.join(', ')}\n`

            });

            return result.trim();
        }
    }


}

let lib = new Library('L');

//act
lib.subscribe('Peter', 'normal');
lib.subscribe('Ivan', 'vip');
console.log(lib.showInfo())

// lib.receiveBook('Peter', '11', '1');
lib.receiveBook('Ivan', '22', '2');
lib.receiveBook('Ivan', '33', '3');