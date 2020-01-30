const assert = require('chai').assert;

class BookStore {
    constructor(name) {
        this.name = name;
        this.books = [];
        this._workers = [];
    }

    get workers() {
        return this._workers;
    }

    stockBooks(newBooks) {
        newBooks.forEach((book) => {
            let [title, author] = book.split('-');
            this.books.push({ title, author });
        });

        return this.books;
    }

    hire(name, position) {
        let worker = this.workers.filter(w => w.name === name)[0];
        if (!worker) {
            worker = {
                name: name,
                position: position,
                booksSold: 0
            };
            this.workers.push(worker);
        } else {
            throw new Error('This person is our employee');
        }
        return `${name} started work at ${this.name} as ${position}`
    }

    fire(name) {
        let worker = this.workers.filter(w => w.name === name)[0];
        if (!worker) {
            throw new Error(`${name} doesn't work here`);
        }
        let index = this.workers.indexOf(worker);
        this.workers.splice(index, 1);
        return `${name} is fired`;
    }

    sellBook(title, workerName) {
        let book = this.books.filter(b => b.title === title)[0];
        if (!book) {
            throw new Error('This book is out of stock');
        }

        let worker = this.workers.filter((w) => w.name === workerName)[0];
        if (!worker) {
            throw new Error(`${workerName} is not working here`)
        }

        this.books = this.books.filter(b => b.title !== title);
        this.workers.filter(w => w.name === workerName).map(w => w.booksSold++);
    }

    printWorkers() {
        let result = "";
        this.workers.forEach(w => {
            result += `Name:${w.name} Position:${w.position} BooksSold:${w.booksSold}\n`;
        })
        return result.trim();
    }
}

describe('Tests', () => {

    //Does PizzUni has registeredUsers, availableProducts, orders
    describe('Positive Outcomes', () => {
        it('Does Bookstore initializes correctly with name only', () => {
            let store = new BookStore('Store');
            let expectedStore = 'Store';

            assert.deepEqual(expectedStore, store.name);
        })

        it('Does Bookstore initializes correctly with name only', () => {
            let store = new BookStore('Store');
            let expectedBooks = [];

            assert.deepEqual(expectedBooks, store.books);
        })

        it('Does Bookstore initializes correctly with name only', () => {
            let store = new BookStore('Store');
            let expectedWorkers = [];

            assert.deepEqual(expectedWorkers, store.workers);
        })


        it('Does stockBooks() works correctly with [strings...]', () => {
            let store = new BookStore('Store');
            store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);
            let expectedBooks = [
                { title: 'Inferno', author: 'Dan Braun' },
                { title: 'Harry Potter', author: 'J.Rowling' },
                { title: 'Uncle Toms Cabin', author: 'Hariet Stow' },
                { title: 'The Jungle', author: 'Upton Sinclear' }
            ]

            assert.deepEqual(expectedBooks, store.books);
        })

     

        it('Does hire(name, position) initializes correctly', function()  {
            let store = new BookStore('Store');
            let result = store.hire('George', 'seller');
            
            let expectedResult = 'George started work at Store as seller';

            assert.equal(expectedResult, result);
        })

        it('Does fire(name) initializes correctly', function()  {
            let store = new BookStore('Store');
            store.hire('George', 'seller');
            let fire = store.fire('George');
            
            let expectedResult = 'George is fired';

            assert.equal(expectedResult, fire);
        })

        it('Does printWorkers() works correctly', () => {
            let store = new BookStore('Store');
            store.hire('Aaa', 'Ppp');
           let result = store.printWorkers();

            let expexted = `Name:Aaa Position:Ppp BooksSold:0`

            assert.equal(expexted, result);
        })


        
    })

    describe('Negative Outcomes', () => {
        it('Does hire(name) twice throws an error', () => {
            let store = new BookStore('Store');
            store.hire('George', 'seller');
            let expectedResult = `This person is our employee`;

            assert.throws(() => store.hire('George', 'seller'), Error, expectedResult);
        })

        it('Does fire(name) throws an error', () => {
            let store = new BookStore('Store');
            store.hire('George', 'seller');
            
            let expectedResult = `Ivan doesn't work here`;

            assert.throws(() => fire = store.fire('Ivan'), Error, expectedResult);
        })
    })
})

let store = new BookStore('Store');

store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);
console.log(store.hire('George', 'seller'));
console.log(store.workers)
console.log(store.hire('Ina', 'seller'));
console.log(store.hire('Tom', 'juniorSeller'));

store.sellBook('Inferno', 'Ina');
store.stockBooks(['Harry Potter-J.Rowling']);

console.log(store.fire('Tom'));
console.log(store.printWorkers());
