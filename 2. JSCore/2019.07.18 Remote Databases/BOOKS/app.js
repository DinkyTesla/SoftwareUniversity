function CRUD() {

    const kinveyUsername = 'guest';
    const kinveyPassword = 'guest';
    const appKey = `kid_rkJwjMwfB`;
    let baseUrl = `https://baas.kinvey.com/appdata/${appKey}/books`;

    const elements = {
        btnSubmit: document.querySelector('#submitBtn'),
        btnLoadBooks: document.querySelector('#loadBooks'),
        btnCancelEdit: document.querySelector('#cancelBtn'),
        btnDoneEdit: document.querySelector('#editBtn'),
        inputTitle: document.querySelector('#title'),
        inputAuthor: document.querySelector('#author'),
        inputIsbn: document.querySelector('#isbn'),
        tbodyBooks: document.querySelector('.tbodyBooks'),
        h3Form: document.querySelector('h3'),
    };

    elements.btnSubmit.addEventListener('click', addBook);
    elements.btnLoadBooks.addEventListener('click', loadBooks);
    elements.btnDoneEdit.addEventListener('click', editBook);
    elements.btnCancelEdit.addEventListener('click', cancelEdit);

    function addBook(event) {
        //Prevents the SubmitButton from refreshing the page.
        event.preventDefault();

        let title = elements.inputTitle.value;
        let author = elements.inputAuthor.value;
        let isbn = elements.inputIsbn.value;

        if (title && author && isbn) {
            const dataObject = {
                title,
                author,
                isbn,
            };

            const headers = {
                method: 'POST',
                body: JSON.stringify(dataObject),
                credentials: 'include',
                Authorization: 'Basic ' + btoa(`${kinveyUsername}:${kinveyPassword}`),
                headers: {
                    'Content-type': 'application/json'
                }
            };

            clearFieldsValues(elements.inputAuthor, elements.inputTitle, elements.inputIsbn);

            fetch(baseUrl, headers)
                .then(handler)
                .then(loadBooks)
                .catch(error => console.error(error));
        }else{
            loadBooks()
        }
    };

    function loadBooks() {
        clearFieldsValues(elements.inputAuthor, elements.inputTitle, elements.inputIsbn);

        const headers = {
            credentials: 'include',
            Authorization: 'Basic ' + btoa(`${kinveyUsername}:${kinveyPassword}`),
            //How to load books if there is loginevent
            // Authorization: 'Kinvey ' + localStorage.getItem('authToken'),
        }

        fetch(baseUrl, headers)
            .then(handler)
            .then((data) => {
                elements.tbodyBooks.innerHTML = '';

                data.forEach(book => {
                    let trNextBook = document.createElement('tr');
                    //Sets the current book id.
                    trNextBook.setAttribute('id', book._id);

                    trNextBook.innerHTML = `<td> ${book.title}</td>
                    <td> ${book.author}</td>
                    <td> ${book.isbn}</td>
                    <td>
                        <button class="btnEdit" value=${book._id}>Edit</button>
                        <button class="btnDelete" value=${book._id}>Delete</button>
                    </td>`

                    trNextBook.querySelector('button.btnEdit')
                        .addEventListener('click', () => loadEditForm(book._id));

                    trNextBook.querySelector('button.btnDelete')
                        .addEventListener('click', () => deleteBook(book._id));

                    elements.tbodyBooks.appendChild(trNextBook);
                })
            })
            .catch((error) => console.error(error));

    };

    function loadEditForm(bookId) {
        let dataToEdit = document.getElementById(bookId)
            .querySelectorAll('td');

        elements.inputTitle.value = dataToEdit[0].textContent;
        elements.inputAuthor.value = dataToEdit[1].textContent;
        elements.inputIsbn.value = dataToEdit[2].textContent;

        elements.h3Form.textContent = 'EDIT BOOK';

        elements.btnSubmit.style.display = 'none';
        elements.btnDoneEdit.style.display = 'block';
        elements.btnCancelEdit.style.display = 'block';

        elements.btnDoneEdit.value = bookId;
    };

    function editBook(event) {
        event.preventDefault();

        let bookId = event.target.value;
        event.target.value = '';

        const bookData = {
            "title": elements.inputTitle.value,
            "author": elements.inputAuthor.value,
            "isbn": elements.inputIsbn.value,
        };

        let editUrl = `${baseUrl}/${bookId}`;

        let headers = {
            method: "PUT",
            body: JSON.stringify(bookData),
            credentials: 'include',
            Authorization: 'Kinvey ' + localStorage.getItem('authToken'),
            headers: {
                'Content-type': 'application/json'
            }
        };

        fetch(editUrl, headers)
            .then(handler)
            .then(loadBooks)
            .catch(error => console.error(error));

        formEditToSubmitForm();

    };

    function cancelEdit(event) {
        event.preventDefault();
        formEditToSubmitForm();
    };

    function deleteBook(bookId) {
        let deleteUrl = `${baseUrl}/${bookId}`;

        let headers = {
            method: "DELETE",
            credentials: 'include',
            Authorization: 'Kinvey ' + localStorage.getItem('authToken'),
            headers: {
                'Content-type': 'application/json'
            }
        };

        fetch(deleteUrl, headers)
        .then(handler)
        .then(loadBooks)
        .catch(error => console.error(error));
    }

    function formEditToSubmitForm() {
        clearFieldsValues(elements.inputAuthor, elements.inputTitle, elements.inputIsbn);

        elements.h3Form.textContent = 'FORM';

        elements.btnSubmit.style.display = 'block';
        elements.btnDoneEdit.style.display = 'none';
        elements.btnCancelEdit.style.display = 'none';

    };

    function clearFieldsValues(...arguments) {
        arguments.forEach(element => {
            element.value = '';
        })
    };


    function handler(response) {
        if (response.status >= 400) {
            throw new Error(response.status);
        }

        return response.json();
    };

};

CRUD();