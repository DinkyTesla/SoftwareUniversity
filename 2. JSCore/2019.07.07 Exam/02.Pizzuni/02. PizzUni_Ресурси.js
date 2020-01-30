// Example of a WORKING PizzUni Class
var expect = require('chai').expect;

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


describe('PizzUni', function () {
    let sampleInstance;
    this.beforeEach(function () {
        sampleInstance = new PizzUni();
    });

    it('On creations userlist is empty', function () {
        expect(sampleInstance.registeredUsers).to.deep.equal([]);
    })

    it('On creations availableproducts is ready', function () {
        let expectedArr1 = ["Italian Style", "Barbeque Classic", "Classic Margherita"];
        let expectedArr2 = ["Coca-Cola", "Fanta", "Water"];
        let expectedObj = {
            pizzas: expectedArr1,
            drinks: expectedArr2
        }
        expect(sampleInstance.availableProducts).to.deep.equal(expectedObj);
    })

    it('On creations orders is empty', function () {
        expect(sampleInstance.orders).to.deep.equal([]);
    })

    it('Testing registerUser() with right args', function () {
        sampleInstance.registerUser('veryFineEmail');
        let result = sampleInstance.registeredUsers[0];
        expect(result).to.deep.equal({ email: 'veryFineEmail', orderHistory: [] });
    });

    it('Testing registerUser() with wrong args', function () {

        sampleInstance.registerUser('veryFineEmail');
        expect(() => sampleInstance.registerUser('veryFineEmail')).to.throw(`This email address (veryFineEmail) is already being used!`);
    });

    it('Testing makeAnOrder() with right args', function () {
        sampleInstance.registerUser('veryFineEmail');
        sampleInstance.makeAnOrder('veryFineEmail', 'Italian Style', 'Fanta');
        let result = sampleInstance.orders;

        let expected = [
            {
              orderedPizza: 'Italian Style',
              orderedDrink: 'Fanta',
              email: 'veryFineEmail',
              status: 'pending'
            }
          ]

        expect(result).to.deep.equal(expected);
    });

});