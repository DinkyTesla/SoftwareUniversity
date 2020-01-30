function solve() {
   //Get The Stuff
   let jsFundamentals = document.getElementsByName('js-fundamentals')[0];
   let jsAdvanced = document.getElementsByName('js-advanced')[0];
   let jsApplications = document.getElementsByName('js-applications')[0];
   let jsWeb = document.getElementsByName('js-web')[0];
   let onlineFormOfEducation = document.getElementsByName('educationForm')[1];

   let myButton = document.querySelector("button");
   //-----


   function Eurika() {
      let total = +0;
      let coursesSigned = [];

      if (jsFundamentals.checked == true) {
         total += 170;
         coursesSigned.push('JS-Fundamentals');
      }
      if (jsAdvanced.checked == true) {
         total += 180;
         coursesSigned.push('JS-Advanced');
      }
      if (jsApplications.checked == true) {
         total += 190;
         coursesSigned.push('JS-Applications');
      }
      if (jsWeb.checked == true) {
         total += 490;
         coursesSigned.push('JS-Web');
      }

      if (onlineFormOfEducation.checked == true) {
         total = total * 0.94;
      }

      console.log(Math.round(total));
      console.log(coursesSigned);
      return Math.round(total);
   }

   myButton.onclick = Eurika;
}

solve();