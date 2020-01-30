const storage = function () {

    //Miro's
    // const appKey = "kid_BkSiSf7fH";
    // const appSecret = "087e74b551a840d88a4a9708162f5556";
    //Mine
    const appKey = 'kid_HJoOkJmXr';
    const appSecret = 'a9cf993b28f9493fa30a5de5b331752e';

    const getData = function (key) {
        return localStorage.getItem(key + appKey);
    };

    const saveData = function (key, value) {
        localStorage.setItem(key + appKey, JSON.stringify(value));
    };

    const saveUser = function (data) {
        saveData("userInfo", data);
        saveData("authToken", data._kmd.authtoken);
    };

    const deleteUser = function () {
        localStorage.removeItem("userInfo" + appKey);
        localStorage.removeItem("authToken" + appKey);
    };

    return {
        getData,
        saveData,
        saveUser,
        deleteUser,
        appKey,
        appSecret
    }
}();