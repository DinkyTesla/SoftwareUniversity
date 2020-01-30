function solve() {
let targetDiv = document.getElementsByClassName("my-message")[0];
let sendButton = document.getElementById("send");
let textArea = document.getElementById("chat_input");
let chatMessageArea = document.getElementById("chat_messages");


sendButton.addEventListener("click", function(){
   let targetDivClone = targetDiv.cloneNode(true);
   
   let textAreaContent = textArea.value;

   if (textAreaContent !=="") {

      targetDivClone.textContent = textAreaContent;
   
      chatMessageArea.appendChild(targetDivClone);
   
      textArea.value = "";
   }
   else{
      let errorElement = alert("Ne Pip Che Plqs!");
   }


});



}


