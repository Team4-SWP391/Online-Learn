const questionDetail = document.querySelectorAll(".question-detail");
const btnInfo = document.querySelectorAll(".btnInfo");
const buttonClose = document.querySelectorAll(".question-detail__footer button");

btnInfo.forEach((btn, index) => {
    btn.addEventListener('click', () => {
        questionDetail[index].style.display = "block";
        buttonClose[index+1].addEventListener("click", () => questionDetail[index].style.display = "none");
        questionDetail[index].addEventListener("click", (e) => {
            if (e.target == e.currentTarget) questionDetail[index].style.display = "none";;
        });
    });
});

const myBtn = document.getElementById('myBtn');
const myQuestionCreate = document.getElementById('myQuestionCreate');
const close = document.getElementById('close');
myBtn.addEventListener('click', () => myQuestionCreate.style.display = "block");
close.addEventListener('click', () => myQuestionCreate.style.display = "none");
window.onclick = function (event) {
    if (event.target == myQuestionCreate) {
        myQuestionCreate.style.display = "none";
    }
}




