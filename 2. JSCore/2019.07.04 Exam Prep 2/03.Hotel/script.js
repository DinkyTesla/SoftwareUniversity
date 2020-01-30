class Hotel {
    constructor(name, capacity) {
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;

        this.roomsPricing = {
            single: 50,
            double: 90,
            maisonette: 135
        };

        this.servicesPricing = {
            food: 10,
            drink: 15,
            housekeeping: 25
        };

        this.availableRooms = {
            single: Math.floor(this.capacity * 0.5),
            double: Math.floor(this.capacity * 0.3),
            maisonette: Math.floor(this.capacity * 0.2)
        };
    }

    rentARoom(clientName, roomType, nights) {
        if (this.availableRooms[roomType] <= 0) {
            let output = [];
            output.push(`No ${roomType} rooms available!`);

            let keys = Object.keys(this.availableRooms)
                .filter(x => this.availableRooms[x] > 0);

            for (const room of keys) {
                output.push(`Available ${room} rooms: ${this.availableRooms[room]}.`)
            }

            return output.join(' ');
        }

        let output = `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${this.currentBookingNumber}.`;

        let obj = {
            clientName,
            roomType,
            nights,
            currentBookingNumber: this.currentBookingNumber
        };

        this.bookings.push(obj);
        this.availableRooms[roomType]--;
        this.currentBookingNumber++;

        return output;
    };

}
let hotel = new Hotel('HotUni', 10);

console.log(hotel.rentARoom('Peter', 'single', 4));
console.log(hotel.rentARoom('Robert', 'double', 4));
console.log(hotel.rentARoom('Geroge', 'maisonette', 6));
