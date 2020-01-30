function acceptance() {
	let warehouse = document.getElementById('warehouse');
	let company = document.querySelector('input[name="shippingCompany"]');
	let product = document.querySelector('input[name="productName"]');
	let quantity = document.querySelector('input[name="productQuantity"]');
	let scrape = document.querySelector('input[name="productScrape"]');

	let acceptButton = document.querySelector("#acceptance");
	acceptButton.addEventListener('click', acceptCompany);

	function acceptCompany(){
		if (company.value && product.value && +quantity.value && +scrape.value) {
			let totalToAdd = +quantity.value - +scrape.value;

			if (totalToAdd <= 0) {
				return;
			}

			let div = document.createElement('div');
			let p = document.createElement('p');

			let removeBTN = document.createElement('button');
			removeBTN.textContent = 'Out of stock';
			removeBTN.addEventListener('click', () => div.remove());

			p.textContent = `[${company.value}] ${product.value} - ${totalToAdd} pieces`
			div.appendChild(p);
			div.appendChild(removeBTN);
			warehouse.appendChild(div);
		};

		company.value = '';
		product.value = '';
		quantity.value = '';
		scrape.value = '';
	}
}