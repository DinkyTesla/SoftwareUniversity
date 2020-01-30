// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - Тhey are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution() {
    let questionBtn = document.querySelector('#inputSection button');
    let pendingArea = document.getElementById('pendingQuestions');
    let openArea = document.getElementById('openQuestions');


    function addTheQuestion() {
        let question = document.querySelector('#inputSection textarea').value;

        //Username -----
        let username = document.querySelector('#inputSection input').value;

        if (username === '') {
            username = 'Anonymous';
        }
        //-----

        //MainDiv -----
        let mainD = document.createElement('div');
        mainD.className = 'pendingQuestion';

        let pic = document.createElement('img');
        pic.src = './images/user.png';
        pic.setAttribute('width', '32');
        pic.setAttribute('height', '32');

        let spn = document.createElement('span');
        spn.textContent = username;

        let p = document.createElement('p');
        p.textContent = question;

        //Action Div -----
        let dAct = document.createElement('div');
        dAct.className = 'actions';

        //Archive Button
        let archiveButton = document.createElement('button');
        archiveButton.className = 'archive';
        archiveButton.textContent = 'Archive';

        archiveButton.addEventListener('click', () => {
            mainD.parentNode.removeChild(mainD);
        });
        //-----

        //Open Button
        let openButton = document.createElement('button');
        openButton.className = 'open';
        openButton.textContent = 'Open';

        openButton.addEventListener('click', () => {

            mainD.className = 'openQuestion';
            openArea.appendChild(mainD);
            mainD.removeChild(dAct);
            mainD.appendChild(dRepAct);

        });

        //------

        //Reply
        let dRepAct = document.createElement('div');
        dRepAct.className = 'actions';

        let replyButton = document.createElement('button');
        replyButton.className = 'reply';
        replyButton.textContent = 'Reply';


        function replyQuestion() {
            let replyDiv = document.createElement('div');
            replyDiv.className = 'replySection';

            let inpt = document.createElement('input');
            inpt.className = 'replyInput';
            inpt.type = 'text';
            inpt.placeholder = 'Reply to this question here...';

            let answerButton = document.createElement('button');
            answerButton.className = 'replyButton';
            answerButton.textContent = 'Send';
            let ol = document.createElement('ol');

            answerButton.addEventListener('click', ()=>{
                let theAnswer = inpt.value;

                if (theAnswer !== '') {
                    let answers = inpt.textContent;
                    let li = document.createElement('li');
                    li.textContent(answers);
                   
                    
                    ol.appendChild(li);
                    replyDiv.appendChild(ol);
                }
            });

           

            
            mainD.appendChild(replyDiv);
            replyDiv.appendChild(inpt);
            replyDiv.appendChild(answerButton);
        }
        replyButton.addEventListener('click', replyQuestion);

        //Input element should have class "replyInput",  type "text" and placeholder "Reply to this question here..." Set in that order!
        //Button element should have class "replyButton" and text content "Send"
        //The ordered list (ol element) should two attributes (class  "reply" and type "1") Set in that order!

        dRepAct.appendChild(replyButton);


        //------

        dAct.appendChild(archiveButton);
        dAct.appendChild(openButton);


        //-----

        //Append to the div
        mainD.appendChild(pic);
        mainD.appendChild(spn);
        mainD.appendChild(p);
        mainD.appendChild(dAct);

        //-----
        pendingArea.appendChild(mainD);
        //To Do clear the fields?
    };

    questionBtn.addEventListener('click', addTheQuestion);

}
// To check out your solution, just submit mySolution() function in judge system.