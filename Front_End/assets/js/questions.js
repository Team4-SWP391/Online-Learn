const questionDetail = document.querySelector(".question-detail");
const btnInfo = document.querySelectorAll(".btnInfo");
const iconClose = document.querySelector(".question-detail__header i");
const buttonClose = document.querySelector(".question-detail__footer button");


function toggleModal() {
  questionDetail.classList.toggle("hide");
}

btnInfo.forEach((btn, index) => {
  btn.addEventListener('click', toggleModal);
  const id = document.querySelectorAll('#id');
  $.ajax({
    url: `Question/Detail/${id[index].value}`,
    type: 'GET',
    success: function (response) {
        questionList.innerHTML(response);
        btnLoad.style.display = 'none';
    },
  });
});
//btnInfo.addEventListener("click", toggleModal);
iconClose.addEventListener("click", toggleModal);
buttonClose.addEventListener("click", toggleModal);

questionDetail.addEventListener("click", (e) => {
  if (e.target == e.currentTarget) toggleModal();
});
