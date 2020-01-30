const storage = function () {

    const appKey = 'kid_rkJwjMwfB';
    const appSecret = '905bddd476c14953ac0ce3bab7a5d24c';

    const getData = function (key) {
        return localStorage.getItem(key + appKey);
        // return localStorage.getItem(key);
    };

    const saveData = function (key, value) {
        localStorage.setItem(key + appKey, JSON.stringify(value));
        // localStorage.setItem(key, JSON.stringify(value));
    };

    const saveUser = function (data) {
        saveData('userInfo', data);
        saveData('authToken', data._kmd.authtoken);
    };

    const deleteUser = function () {
        localStorage.removeItem('userInfo');
        localStorage.removeItem('authToken');
    };

    return {
        getData,
        saveData,
        saveUser,
        deleteUser,
        appKey,
        appSecret,
    }
}();