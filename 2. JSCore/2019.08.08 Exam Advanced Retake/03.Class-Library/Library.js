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
        let currentSub = {};
        let newBook = {};


        this.subscribers.forEach(sub => {

            if (sub.name === subscriberName) {
                subFound = true;

                if (sub.type === 'normal') {

                    if (sub.books.length < this.subscriptionTypes.normal) {
                        newBook.title = bookTitle;
                        newBook.author = bookAuthor;

                        sub.books.push(newBook);

                        currentSub = sub;
                    } else {
                        throw new Error(`You have reached your subscription limit ${this.name.length}!`);
                    }
                } else if (sub.type === 'special') {

                    if (sub.books.length < this.subscriptionTypes.special) {
                        newBook.title = bookTitle;
                        newBook.author = bookAuthor;

                        sub.books.push(newBook);

                        currentSub = sub;
                    } else {
                        throw new Error(`You have reached your subscription limit ${this.name.length * 2}!`);
                    }
                }
                else if (sub.type === 'vip') {

                    if (sub.books.length < this.subscriptionTypes.vip) {
                        newBook.title = bookTitle;
                        newBook.author = bookAuthor;

                        sub.books.push(newBook);

                        currentSub = sub;
                    }
                    else {
                        throw new Error(`You have reached your subscription limit ${Number.MAX_SAFE_INTEGER}!`);
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
            let currentUserResult = ``;

            this.subscribers.forEach(sub => {

                result += `Subscriber: ${sub.name}, Type: ${sub.type}\n`;
                result += `Received books: `;

                let booksArray = [];

                sub.books.forEach(book => {
                    booksArray.push(`${book.title} by ${book.author}`);
                })

                result += `${booksArray.join(', ')}`
                result += `\n`

            });

            return result.trim();
        }
    }


}

let lib = new Library('L');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

lib.unsubscribe('John');
console.log(lib.showInfo())
// lib.subscribe('Peter', 'normal');
// lib.subscribe('John', 'special');
// lib.subscribe('Josh','vip')


// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
// lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');
// lib.receiveBook('Josh', 'Graf Monte Cristo', 'Alexandre Dumas');
// lib.receiveBook('Josh','Cromwell','Victor Hugo');
// lib.receiveBook('Josh','Marie Tudor','Victor Hugo');
// lib.receiveBook('Josh','Bug-Jargal','Victor Hugo');
// lib.receiveBook('Josh','Les Orientales','Victor Hugo');
// lib.receiveBook('Josh','Marion de Lorme','Victor Hugo');
