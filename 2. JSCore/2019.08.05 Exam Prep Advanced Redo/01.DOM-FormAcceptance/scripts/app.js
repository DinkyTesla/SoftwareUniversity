function acceptance() {
	//Button
	const acceptBtn = document.getElementById('acceptance');

	acceptBtn.addEventListener('click', acceptForm);

	function acceptForm() {

		//Fields
		let companyName = document.getElementsByName('shippingCompany')[0].value;
		let productName = document.getElementsByName('productName')[0].value;
		let productQuantity = document.getElementsByName('productQuantity')[0].value;
		let productScrape = document.getElementsByName('productScrape')[0].value;

		//Logic
		if (companyName && productName && !isNaN(productQuantity) && !isNaN(productScrape)) {
			let finalQuantity = productQuantity - productScrape;

			if (finalQuantity > 0) {
				//Elements
				let warehouse = document.getElementById('warehouse');
				let divWrap = document.createElement('div');
				let product = document.createElement('p');
				let outOfStockButton = document.createElement('button');

				//Magic
				outOfStockButton.innerHTML = 'Out of stock';
				outOfStockButton.setAttribute('type', 'button');
				outOfStockButton.addEventListener('click', removeProduct);
				product.textContent = `[${companyName}] ${productName} - ${finalQuantity} pieces`;
				divWrap.appendChild(product)
				divWrap.appendChild(outOfStockButton);
				warehouse.appendChild(divWrap);

				function removeProduct() {
					warehouse.removeChild(divWrap);
				};

				//Clear the form
				document.getElementsByName('shippingCompany')[0].value = '';
				document.getElementsByName('productName')[0].value = '';
				document.getElementsByName('productQuantity')[0].value = '';
				document.getElementsByName('productScrape')[0].value = '';
			};
		};
	}
}