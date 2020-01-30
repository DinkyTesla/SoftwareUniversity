function toggle() {
    
    let myButton = document.querySelector('.button');
    let elementWithText = document.getElementById('extra');

    if (elementWithText.style.display === 'none') {
        elementWithText.style.display = 'block';
        myButton.textContent = 'Less';
    }else{
        elementWithText.style.display = 'none';
        myButton.textContent = 'More';
    };
}