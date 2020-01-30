function addItem() {

    let newItemText = document.getElementById('newItemText').value;
    let newItemValue = document.getElementById('newItemValue').value;

    if (newItemText === "" && newItemValue === "") {
        alert("Plese insert some info!");
    }

    let theMenuPart = document.getElementById('menu');

    let newlyCreatedElement = document.createElement('option');

    newlyCreatedElement.textContent = newItemText;
    newlyCreatedElement.value = newItemValue;

    theMenuPart.appendChild(newlyCreatedElement);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}