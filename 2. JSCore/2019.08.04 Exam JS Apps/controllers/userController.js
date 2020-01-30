const userController = function () {

    //Register
    const getRegister = function (context) {

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/user/registerPage.hbs')
        })
    };

    const postRegister = function (context) {
       
        if (helper.passwordCheck(context.params)) {
            userModel.register(context.params)
                .then(helper.handler)
                .then((data) => {
                    storage.saveUser(data);
                    homeController.getHome(context);
                })
        }else{
            userController.getRegister(context);
        }

        userController.getRegister();
    };

    //Login
    const getLogin = function (context) {
        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/user/loginPage.hbs')
        })
    };

    const postLogin = function (context) {

        userModel.login(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                homeController.getHome(context);
                // context.redirect('#/home');
            })
    };

    const getUser = function (context) {
        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/user/userPage.hbs')
        })
    }

    const logout = function (context) {

        userModel.logout()
            .then(helper.handler)
            .then(() => {
                storage.deleteUser();
                homeController.getHome(context);
            });
    };

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
        getUser
    }
}();