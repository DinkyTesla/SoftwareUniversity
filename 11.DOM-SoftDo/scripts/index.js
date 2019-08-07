// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution() {

    //Elements
    let questionArea = document.querySelector('textarea');
    let usernameArea = document.querySelector('input');
    let sendButton = document.querySelector('button');
    let pendingArea = document.getElementById('pendingQuestions');
    sendButton.addEventListener('click', sendQuestionFunc);

    function sendQuestionFunc() {

        if (questionArea.value) {

            let username = 'Anonymous';

            if (usernameArea.value) {
                username = usernameArea.value;
            }

            // <div class="pendingQuestion">
            let divPending = document.createElement('div');
            divPending.setAttribute("class", "pendingQuestion");
            // profileImg
            let profileImg = document.createElement('img');
            profileImg.setAttribute("src", "./images/user.png");
            profileImg.setAttribute("width", "32");
            profileImg.setAttribute("height", "32");
            // Username
            let spanPending = document.createElement('span');
            spanPending.textContent = username;
            //Actual question
            let pPending = document.createElement('p');
            pPending.textContent = questionArea.value;

            // <div class="actions"> for buttons
            // Archive BTN
            let divActions = document.createElement('div');
            divActions.setAttribute("class", "actions");
            let archiveBtn = document.createElement('button');
            archiveBtn.setAttribute('class', 'archive');
            archiveBtn.textContent = 'Archive';

            archiveBtn.addEventListener('click', () => {
                divPending.remove();
            })

            // Open BTN
            let openBtn = document.createElement('button');
            openBtn.textContent = 'Open';
            openBtn.setAttribute('class', 'open');
            openBtn.addEventListener('click', openQuestion);

            function openQuestion() {

                //Make the question open for answers
                document.getElementById('openQuestions').appendChild(divPending);
                divPending.setAttribute('class', 'openQuestion')

                archiveBtn.remove();
                openBtn.remove();

                let replyBtn = document.createElement('button');
                replyBtn.setAttribute('class', 'reply');
                replyBtn.textContent = 'Reply';
                replyBtn.addEventListener('click', showHideReplys);

                let replySection = document.createElement('div');
                replySection.setAttribute('class', 'replySection');
                replySection.setAttribute('style', 'display: none;');

                let replyInput = document.createElement('input');
                replyInput.setAttribute('class', 'replyInput');
                replyInput.setAttribute('type', 'text');
                replyInput.setAttribute('placeholder', 'Reply to this question here...');
                
                let sendReplyBtn = document.createElement('button');
                sendReplyBtn.setAttribute('class', 'replyButton');
                sendReplyBtn.textContent = 'Send';
                sendReplyBtn.addEventListener('click', sendReplyFunc);
                
                let listedReplys = document.createElement('ol');
                listedReplys.setAttribute('class', 'reply');
                listedReplys.setAttribute('type', '1');

                divActions.appendChild(replyBtn);
                replySection.appendChild(replyInput);
                replySection.appendChild(sendReplyBtn);
                replySection.appendChild(listedReplys);

                divPending.appendChild(replySection);

                function sendReplyFunc(){

                    if (replyInput.value) {

                        let finalReply = document.createElement('li');
                        finalReply.textContent = replyInput.value;

                        listedReplys.appendChild(finalReply);
                        replyInput.value = '';
                    }
                }

                function showHideReplys() {

                    if (replyBtn.textContent === 'Reply') {
                        replyBtn.textContent = 'Back';
                        replySection.style = 'display: block;';
                    } else if (replyBtn.textContent === 'Back') {

                        replyBtn.textContent = 'Reply';
                        replySection.style = 'display: none;';
                    }
                }
            }

            // Create element for input into html
            divPending.appendChild(profileImg);
            divPending.appendChild(spanPending);
            divPending.appendChild(pPending);

            divActions.appendChild(archiveBtn);
            divActions.appendChild(openBtn);
            divPending.appendChild(divActions);

            pendingArea.appendChild(divPending);

            // Clear the input fields
            questionArea.value = '';
            usernameArea.value = '';
        }
    }
}