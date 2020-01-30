const app = Sammy("body", function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);

    // User
    this.get('#/userPage', userController.getUser);
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);
    this.get('#/logout', userController.logout);

    //Event Offers
    this.get('#/createEvent', eventController.getCreateEvent);
    this.get('#/detailsEvent/:eventId', eventController.getDetailsEvent);
    this.get('#/editEvent/:eventId', eventController.getEditEvent);
    this.get('#/deleteEvent/:eventId', eventController.postDeleteEvent);
    this.get('#/dashboard', eventController.getDashboard);

    this.post('#/createEvent', eventController.postCreateEvent);
    this.post('#/editEvent/:eventId', eventController.postEditEvent);
});

(() => {
    app.run('#/home');
})();