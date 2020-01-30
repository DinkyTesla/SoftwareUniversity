function attachEvents() {
    let url = `https://phonebook-nakov.firebaseio.com/phonebook.json`;

    //LoadAllContacts
    document.getElementById('btnLoad')
        .addEventListener('click', loadContacts);
    ///---///

    //CreateNewContact
    document.getElementById('btnCreate')
        .addEventListener('click', () => {

            let name = document.getElementById('person').value;
            let phoneNumber = document.getElementById('phone').value;

            if (name !== '' && phoneNumber !== '') {

                let newContact = {
                    'person': `${name}`,
                    'phone': `${phoneNumber}`
                };

                fetch(url, {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(newContact),
                })
                    .then(loadContacts)
            }

            document.getElementById('person').value = '';
            document.getElementById('phone').value = '';
        });
    ///---///

    function loadContacts() {

        fetch(url)
            .then((request) => request.json())
            .then((data) => {

                document.getElementById('phonebook').innerHTML = '';

                for (const key of Object.keys(data)) {
                    let contact = data[key];
                    let name = contact.person;
                    let phoneNumber = contact.phone;

                    let delBtn = document.createElement('button');
                    delBtn.textContent = 'DELETE';
                    delBtn.addEventListener('click', () => deleteTheGivenContact(key))

                    let listItem = document.createElement('li');
                    listItem.textContent = `${name}: ${phoneNumber}`;
                    listItem.appendChild(delBtn);

                    document.getElementById('phonebook').appendChild(listItem);

                }
            })
    };

    function deleteTheGivenContact(key) {

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`, {
            method: 'DELETE',
        })
            .then((request) => request.json())
            .then(loadContacts)
    };

}

attachEvents();