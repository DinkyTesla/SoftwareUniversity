// Example of a WORKING PizzUni Class

const assert = require('chai').assert;

class PizzUni {
    constructor() {
        this.registeredUsers = [];
        this.availableProducts = {
            pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
            drinks: ['Coca-Cola', 'Fanta', 'Water']
        };
        this.orders = [];
    }

    registerUser(email) {

        const user = this.doesTheUserExist(email);

        if (user) {
            throw new Error(`This email address (${email}) is already being used!`)
        }

        const currentUser = {
            email,
            orderHistory: []
        };

        this.registeredUsers.push(currentUser);

        return currentUser;
    }

    makeAnOrder(email, orderedPizza, orderedDrink) {

        const user = this.doesTheUserExist(email);

        if (!user) {
            throw new Error(`You must be registered to make orders!`);
        }

        const isThereAPizzaOrdered = this.availableProducts.pizzas.includes(orderedPizza);

        if (!isThereAPizzaOrdered) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        }

        let userOrder = {
            orderedPizza
        };

        const isThereADrinkOrdered = this.availableProducts.drinks.includes(orderedDrink);

        if (isThereADrinkOrdered) {
            userOrder.orderedDrink = orderedDrink;
        }

        user.orderHistory.push(userOrder);

        const currentOrder = {
            ...userOrder,
            email,
            status: 'pending'
        };
        this.orders.push(currentOrder);

        return this.orders.length - 1;
    }

    detailsAboutMyOrder(id) {
        if (this.orders[id]) {
            return `Status of your order: ${this.orders[id].status}`;
        }
    }

    doesTheUserExist(email) {
        return this.registeredUsers.filter((user) => user.email === email)[0];
    }

    completeOrder() {
        if (this.orders.length > 0) {
            const index = this.orders.findIndex((o) => o.status === "pending");
            this.orders[index].status = 'completed';

            return this.orders[index];
        }
    }
}
module.exports = PizzUni; // This piece of code exports the PizzUni Class, so it could be accessed in other files.
describe('Tests', () => {

    //Does PizzUni has registeredUsers, availableProducts, orders
    describe('Positive Outcomes', () => {
        it('Does PizzUni has registeredUsers = []', () => {
            let pizza = new PizzUni();
            let expectedUsers = [];

            assert.deepEqual(expectedUsers, pizza.registeredUsers);
        })

        it('Does PizzUni has availableProducts{smth..}} ', () => {
            let pizza = new PizzUni();

            let expectedProducts = {
                pizzas: ["Italian Style", "Barbeque Classic", "Classic Margherita"],
                drinks: ["Coca-Cola", "Fanta", "Water"]
            };

            assert.deepEqual(expectedProducts, pizza.availableProducts);
        })

        it('Does PizzUni has orders = []', () => {
            let pizza = new PizzUni();

            let expextedOrders = [];

            assert.deepEqual(expextedOrders, pizza.orders);
        })

        it('Does registerUser(email) adds user', () => {
            let pizza = new PizzUni();
            pizza.registerUser('wantPizza@eatpizza.piz');

            let expectedUsers = [{ email: 'wantPizza@eatpizza.piz', orderHistory: [] }];

            assert.deepEqual(expectedUsers, pizza.registeredUsers);
        })
        
        it('Does makeAnOrder(email, pizza) adds user with order', () => {
            let pizza = new PizzUni();
            pizza.registerUser('wantPizza@eatpizza.piz');

            let expectedUsers = [{ email: 'wantPizza@eatpizza.piz', orderHistory: [] }];

            assert.deepEqual(expectedUsers, pizza.registeredUsers);
        })


    })

    describe('Negative Outcomes', () => {
        it('Does registerUser(email) twice throws an error', () => {
            let pizza = new PizzUni();
            pizza.registerUser('wantPizza@eatpizza.piz');

            let expectedResult = `This email address (wantPizza@eatpizza.piz) is already being used!`;

            assert.throws(() => pizza.registerUser('wantPizza@eatpizza.piz'), Error, expectedResult);
        })
    })
})

let pizza = new PizzUni();
pizza.registerUser('wantPizza@eatpizza.piz');
pizza.makeAnOrder('wantPizza@eatpizza.piz', "Italian Style");

console.log(pizza.registeredUsers);