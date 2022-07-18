const myBtn = document.getElementById('myBtn');
const myQuestionCreate = document.getElementById('myQuestionCreate');
const close = document.getElementById('close');
myBtn.addEventListener('click', () => myQuestionCreate.classList.toggle("hide"));
window.onclick = function (event) {
    if (event.target == myQuestionCreate) {
        modal.style.display = "none";
    }
}