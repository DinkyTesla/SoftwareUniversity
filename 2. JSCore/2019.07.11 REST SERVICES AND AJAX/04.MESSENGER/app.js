function attachEvents() {

    let url = `https://rest-messanger.firebaseio.com/messanger.json`;

    //Submit
    document.getElementById('submit')
        .addEventListener('click', sendTheMessage);

    function sendTheMessage() {
        let author = document.getElementById('author').value;
        let message = document.getElementById('content').value;

        if (author !== '' && message !== '') {

            let newMessage = {
                'author': `${author}`,
                'content': `${message}`,
            };

            fetch(url, {
                method: 'post',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify(newMessage),
            })
        }

        document.getElementById('author').value = '';
        document.getElementById('content').value = '';

    };
    ///---///

    //Retrieve
    document.getElementById('refresh')
        .addEventListener('click', () => {
            fetch(url)
                .then((request) => request.json())
                .then((data) => refreshTheMessage(data))
        });

    function refreshTheMessage(data) {
        let messageToDisplay = '';
        let messageBoard = document.querySelector('textarea');

        for (const key of Object.keys(data)) {
            let row = data[key];
            let author = row.author;
            let message = row.content;

            messageToDisplay += `${author}: ${message}\n`;
        }

        messageBoard.value = messageToDisplay;
    };
    ///---///
}

attachEvents();