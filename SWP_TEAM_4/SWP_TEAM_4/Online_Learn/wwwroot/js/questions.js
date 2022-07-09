const questionDetail = document.querySelectorAll(".question-detail");
const btnInfo = document.querySelectorAll(".btnInfo");
const buttonClose = document.querySelectorAll(".question-detail__footer button");

//function toggleModal() {
//    questionDetail.classList.toggle("hide");
//}

btnInfo.forEach((btn, index) => {
    btn.addEventListener('click', () => {
        questionDetail[index].classList.toggle("hide");
        buttonClose[index].addEventListener("click", () => questionDetail[index].classList.toggle("hide"))
        questionDetail[index].addEventListener("click", (e) => {
            if (e.target == e.currentTarget) questionDetail[index].classList.toggle("hide");
        });
    });
  
});



