$(document).ready(function () {
    $('.slider_list').slick({
        arrows: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        variableWidth: false,
        prevArrow:
            "<button type='button' class='slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow:
            "<button type='button' class='slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>",
    });

    $('.slick-prev').click(() => {
        var current = $('.current');
        var currentValue = current.text();
        var totalValue = $('.slider').data('total');
        if (currentValue == 1) {
            current.text(totalValue);
        } else {
            current.text(parseInt(currentValue) - 1);
        }
    });
    $('.slick-next').click(() => {
        var current = $('.current');
        var currentValue = current.text();
        var totalValue = $('.slider').data('total');
        if (currentValue == totalValue) {
            current.text(1);
        } else {
            current.text(parseInt(currentValue) + 1);
        }
    });
});




const editQuestion = (index) => {
    const btnEdit = document.querySelectorAll('#btnEdit');
    const titleQuestion = document.querySelectorAll('.title');
    const inputHidden = document.querySelectorAll('.inputHidden');
    const result = document.querySelectorAll('.result');
    const btnHidden = document.querySelectorAll('.btnHidden');
    const choices = document.querySelectorAll('.choice span');
    console.log(index);
    for (let i = index * 6; i < (index + 1) * 6; i++) {
        inputHidden[i].style.display = 'flex';
    }
    titleQuestion[index].style.display = 'none';
    for (let i = index * 4; i < (index + 1) * 4; i++) {
        choices[i].style.display = 'none';
    }
    result[index].style.display = 'none';
    btnEdit[index].style.display = 'none';
    btnHidden[index].style.display = 'block';
}
const finishEdit = (index) => {
    const btnEdit = document.querySelectorAll('#btnEdit');
    const titleQuestion = document.querySelectorAll('.title');
    const inputHidden = document.querySelectorAll('.inputHidden');
    const result = document.querySelectorAll('.result');
    const btnHidden = document.querySelectorAll('.btnHidden');
    const choices = document.querySelectorAll('.choice span');
    console.log('asd');
    for (let i = index * 6; i < (index + 1) * 6; i++) {
        inputHidden[i].style.display = 'none';
    }
    titleQuestion[index].style.display = 'block';
    for (let i = index * 4; i < (index + 1) * 4; i++) {
        choices[i].style.display = 'block';
    }
    btnEdit[index].style.display = 'block';
    result[index].style.display = 'block';
    btnHidden[index].style.display = 'none';
    const questionInfo = document.querySelectorAll('.questionInfo');
    const id = document.querySelectorAll('#id');
    const indexQuestionInfo = index * 6;
    $.ajax({
        url: 'Question/Edit',
        type: 'POST',
        data: {
            id: id[index].value,
            quiz: questionInfo[indexQuestionInfo].value,
            op1: questionInfo[indexQuestionInfo + 1].value,
            op2: questionInfo[indexQuestionInfo + 2].value,
            op3: questionInfo[indexQuestionInfo + 3].value,
            op4: questionInfo[indexQuestionInfo + 4].value,
            solution: questionInfo[indexQuestionInfo + 5].value,
            totalQuestion: titleQuestion.length,
        },
        success: function (response) {
            questionList.innerHTML = response;

        },
    });
}


const questionList = document.querySelector('.question_list');
const btnLoad = document.querySelector('.btnLoad');
btnLoad.addEventListener('click', () => {
    $.ajax({
        url: 'Question/LoadMore',
        type: 'GET',
        data: '',
        success: function (response) {
            questionList.innerHTML = response;
            btnLoad.style.display = 'none';
        },
    });
});


const validate = e => {
    console.log(e.getAttribute('value'));
    var value = e.getAttribute('value');
    if (value < 1 && value > 4) {
        alert('Please select a number between 1 and 4');
    }
};