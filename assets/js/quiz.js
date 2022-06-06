const listAnswers = document.querySelectorAll('.question_list-item-choice');
const quizDone = document.querySelector('#quiz_done');
const question = document.querySelector('.question');
const numberQuestion = document.querySelectorAll('.sidebar .count');
const viewResult = document.querySelector('.view_result');

const display = document.querySelector('#time');

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
    const answersOfUser = [];
    if (display.textContent != '00:00') {
        question.querySelectorAll('.question_list-item-choice').forEach(item => {
            let check = 0;
            item.querySelectorAll('section').forEach((choice, index) => {
                if (choice.classList.contains('option-choosed')) {
                    check++;
                    answersOfUser.push(choice.dataset.option);
                }
                if (check == 0 && index == 3) {
                    answersOfUser.push('none');
                }
            });
        });
        if (quizDone.textContent == 10) {
            const check = confirm('Are you sure you want to submit?');
            console.log(check);
            if (check === true) {
                console.log(answersOfUser);
            }
        }
    } else {
        alert('Time Out');
    }
    console.log(answersOfUser);
});

function startTimer(duration, display) {
    var timer = duration,
        minutes,
        seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? '0' + minutes : minutes;
        seconds = seconds < 10 ? '0' + seconds : seconds;

        display.textContent = minutes + ':' + seconds;

        if (--timer < 0) {
            viewResult.click();
        }
    }, 1000);
}

window.onload = function () {
    var fiveMinutes = 5 * 60;
    startTimer(fiveMinutes, display);
};
