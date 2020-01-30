function solve() {
    //what is default.
    //Elements
    let titleArea = document.querySelectorAll('input')[0];
    let yearArea = document.querySelectorAll('input')[1];
    let priceArea = document.querySelectorAll('input')[2];
    let profitArea = document.querySelectorAll('h1')[1];

    let newBooksArea = document.querySelectorAll('div')[2];
    let oldBooksArea = document.querySelectorAll('div')[1];
    let addNewBookBtn = document.querySelector('button');
    let totalStoreProfit = +0;



    addNewBookBtn.addEventListener('click', addNewBookFunc);

    function addNewBookFunc(event) {
        event.preventDefault()

        if (titleArea.value && +yearArea.value > 0 && +priceArea.value > 0) {
            let bookTitle = titleArea.value;
            let year = +yearArea.value;
            let price = +priceArea.value;

            let moveBtn = document.createElement('button');
            moveBtn.textContent = 'Move to old section'
            moveBtn.addEventListener('click', moveToOld);

            let bookElement = document.createElement('div');
            bookElement.setAttribute('class', 'book');

            let p = document.createElement('p');
            p.textContent = `${bookTitle} [${year}]`;

            let buyBtn = document.createElement('button');
            buyBtn.textContent = `Buy it only for ${price.toFixed(2)} BGN`;
            buyBtn.addEventListener('click', buyCurrentBook);

            bookElement.appendChild(p);
            bookElement.appendChild(buyBtn);

            if (year >= 2000) {
                bookElement.appendChild(moveBtn);
                newBooksArea.appendChild(bookElement);

            } else {
                moveToOld();
            }

            function buyCurrentBook() {
                totalStoreProfit += price;
                profitArea.textContent = '';
                profitArea.textContent = `Total Store Profit: ${totalStoreProfit.toFixed(2)} BGN`;
                bookElement.remove();

            }

            function moveToOld() {
                moveBtn.remove();
                price = price * 0.85;
                buyBtn.textContent = `Buy it only for ${price.toFixed(2)} BGN`;
                oldBooksArea.appendChild(bookElement);
            }
        }
    }
}