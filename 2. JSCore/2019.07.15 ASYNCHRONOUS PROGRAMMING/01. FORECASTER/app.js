function attachEvents() {

    const url = 'https://judgetests.firebaseio.com/locations.json';

    const elements = {
        inputField: document.getElementById('location'),
        button: document.getElementById('submit'),
        current: document.getElementById('current'),
        upcoming: document.getElementById('upcoming'),
        forecast: document.getElementById('forecast'),
    };

    const symbols = {
        sunny: '☀',
        partlySunny: '⛅',
        overcast: '☁',
        rain: '☂',
        degrees: '°',
    };

    elements.button.addEventListener('click', loadWeatherInfo);

    function loadWeatherInfo() {

        reloadTheApp();

        fetch(url)
            .then(handler)
            .then(loadLocalWeatherInfo);
    };

    function loadLocalWeatherInfo(data) {

        let location = data.filter((obj) => obj.name === elements.inputField.value)[0];

        elements.inputField.value = '';

        if (location) {

            elements.forecast.style.display = "block";

            const todayUrl = `https://judgetests.firebaseio.com/forecast/today/${location.code}.json`;

            fetch(todayUrl)
                .then(handler)
                .then((data) => showLocationWeatherInfo(data, location.code))
        } else {
            elements.forecast.style.display = "none";

            if (document.getElementById('error') === null) {
                errorMessage();
            }

            document.getElementById('error').style.display = 'block';
            
        }
    };

    function showLocationWeatherInfo(data, code) {

        let divForecast = createHtmlElement('div', 'forecasts');

        let symbol = symbols[data.forecast.condition.toLowerCase()];
        let spanSymbol = createHtmlElement('span', ['condition', 'symbol'], symbol);

        let spanHolder = createHtmlElement('span', 'condition');

        let spanName = createHtmlElement('span', 'forecast-data', data.name);

        let degrees = `${data.forecast.low}${symbols.degrees}/${data.forecast.high}${symbols.degrees}`;

        let spanDegrees = createHtmlElement('span', 'forecast-data', degrees);

        let spanCondition = createHtmlElement('span', 'forecast-data', data.forecast.condition);

        spanHolder = appendChildrenToParent([spanName, spanDegrees, spanCondition], spanHolder);
        divForecast = appendChildrenToParent([spanSymbol, spanHolder], divForecast);

        elements.current.appendChild(divForecast);

        loadUpcomingLocationWeatherInfo(code);
    };

    function loadUpcomingLocationWeatherInfo(code) {
        fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
            .then(handler)
            .then(showUpcomingLocationWeatherInfo)
    };

    function showUpcomingLocationWeatherInfo(data) {

        let divUpcomingForecast = createHtmlElement('div', 'forecast-info');

        data.forecast.forEach((obj) => {
            let spanUpcoming = createHtmlElement('span', 'upcoming');

            let symbol = symbols[obj.condition.toLowerCase()] || symbols['partlySunny'];
            let spanSymbol = createHtmlElement('span', 'symbol', symbol);

            let degrees = `${obj.low}${symbols.degrees}/${obj.high}${symbols.degrees}`;
            let spanDegrees = createHtmlElement('span', 'forecast-data', degrees);

            let spanCondition = createHtmlElement('span', 'forecast-data', obj.condition);

            divUpcomingForecast.appendChild(appendChildrenToParent([spanSymbol, spanDegrees, spanCondition], spanUpcoming));
        });

        elements.upcoming.appendChild(divUpcomingForecast);
    };

    function appendChildrenToParent(children, parent) {

        children.forEach((child) => parent.appendChild(child));

        return parent;
    };

    function createHtmlElement(tagName, className, textContent) {

        let currentElement = document.createElement(tagName);

        if (typeof className === 'string') {
            currentElement.classList.add(className);
        } else if (typeof className === 'object') {
            currentElement.classList.add(...className);
        }

        if (textContent) {
            currentElement.textContent = textContent;
        }

        return currentElement;
    };

    function reloadTheApp() {
        let currentLabel = elements.current.children[0];
        let upcomingLabel = elements.upcoming.children[0];
        document.getElementById('current').innerHTML = '';
        document.getElementById('current').innerHTML = '';
        document.getElementById('upcoming').innerHTML = '';

        document.getElementById('current').appendChild(currentLabel);
        document.getElementById('upcoming').appendChild(upcomingLabel);

        if (document.getElementById('error') !== null) {
            document.getElementById('error').style.display = 'none';
        }

    };

    function errorMessage(){
        let errorMessageElement = document.createElement('div');
        errorMessageElement.setAttribute('style', 'display: none');
        errorMessageElement.setAttribute('id', 'error');
        errorMessageElement.setAttribute('align', 'center');
        errorMessageElement.innerHTML = `<h1>Error: No such location! Please, Try Again!</h1>`;
        document.getElementById('content').appendChild(errorMessageElement);
    };

    function handler(response) {

        if (response.status > 400) {
            elements.forecast.innerHTML = `E R R O R`;

            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }

        return response.json();
    };
}

attachEvents();