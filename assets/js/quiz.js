const listAnswers = document.querySelectorAll('.question_list-item-choice');
const quizDone = document.querySelector('#quiz_done');
const question = document.querySelector('.question');
const numberQuestion = document.querySelectorAll('.sidebar .count');
const viewResult = document.querySelector('.view_result');

var answersOfUser = [];

listAnswers.forEach((answer, index) => {
    answer.addEventListener('click', function (e) {
        const choice = answer.querySelectorAll('section');
        if (e.target.dataset.option) {
            choice.forEach(item => {
                item.classList.remove('option-choosed');
            });
            const el = Array.from(choice).filter(item => item.dataset.option === e.target.dataset.option);
            el[0].classList.add('option-choosed');
        }

        numberQuestion[index].style.color = 'var(--main-color)';
        numberQuestion[index].querySelector('i').style.display = '';
        quizDone.textContent = question.querySelectorAll('.option-choosed').length;
    });
});

viewResult.addEventListener('click', e => {
    if (quizDone.textContent < 10) {
        alert('Bạn chưa hoàn thành bài thi');
    } else {
        question.querySelectorAll('.option-choosed').forEach(item => {
            answersOfUser.push(item.dataset.option);
        });
        console.log(answersOfUser);
    }
});
