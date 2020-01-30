function solve() {
let cards = document.getElementsByTagName("img");

   for (let card of cards) {
      card.addEventListener("click", function(){ card.style.backgroundImage("url(images/whiteCard.jpg)")})
      }
   }
 //  element.addEventListener("click", function(){ alert("Hello World!"); });
// console.log( document.getElementByName());
}