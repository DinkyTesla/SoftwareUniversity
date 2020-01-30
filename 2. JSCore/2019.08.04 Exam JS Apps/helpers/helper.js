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
        let valid = false;
        
        if(params.password === params.rePassword){
            valid = true;
        }
        
        return valid;
    };

    const inputValidator = function (params) {
        let valid = true;

        if (!params.product || !params.description || !params.price || !params.pictureUrl) {
            valid = false;
        }

        let pictureLink = params.pictureUrl;
        let substring = "https://";
        if (!pictureLink.includes(substring)) {
            valid = false;
        }

        return valid;
    };

    return {
        handler,
        passwordCheck,
        inputValidator
    }
}();