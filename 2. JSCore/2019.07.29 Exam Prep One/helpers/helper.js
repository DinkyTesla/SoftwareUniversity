const helper = function () {

    const handler = function (response) {

        if (response.status >= 400) {
            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }

        //The response is "No Content" so avoid it.
        if (response.status !== 204) {
            response = response.json();
        }

        return response;
    };

    const passwordCheck = function (params) {
        return params.password === params.rePassword;
    };

    return {
        handler,
        passwordCheck
    }
}();