<<<<<<< HEAD
﻿const btns = document.querySelectorAll('#course_section-title');
=======
const btns = document.querySelectorAll('#course_section-title');
>>>>>>> f8654a48020cbcb3bcac4c83e7cd5f6e2313d210
const list = document.querySelectorAll('#course_section-list');
const options = document.querySelectorAll('#course_options-items');
const courseDes = document.querySelector('.course_about');
const courseRev = document.querySelector('.course_reviews');

<<<<<<< HEAD
btns.forEach((btn, index) => {
    const icon = btn.querySelector('i');
    btn.addEventListener('click', e => {
        console.log(icon.classList);
=======

btns.forEach((btn, index) => {
    const icon = btn.querySelector('i');
    btn.addEventListener('click', e => {
>>>>>>> f8654a48020cbcb3bcac4c83e7cd5f6e2313d210
        list[index].classList.toggle('isToggle');
        const check = icon.classList.value == 'fas fa-angle-up';
        if (check) {
            icon.classList.remove('fa-angle-up');
            icon.classList.add('fa-angle-down');
        } else {
            icon.classList.add('fa-angle-up');
            icon.classList.remove('fa-angle-down');
        }
    });
});

options.forEach(option => {
    option.addEventListener('click', e => {
        options.forEach(opt => {
            opt.style.color = 'black';
        });
        option.style.color = 'var(--main-color)';
        if (option.textContent === 'Overview') {
            courseDes.style.display = 'block';
            courseRev.style.display = 'none';
        } else {
            courseDes.style.display = 'none';
            courseRev.style.display = 'block';
        }
    });
});
<<<<<<< HEAD
=======
const changeVideo = (e, url, courseId, lessonId, accountId) => {
    const progress = document.querySelector('#progress').textContent.trim();
    var current = progress.split('/')[0];
    const total = progress.split('/')[1];
    current = current < total ? parseInt(current) + 1 : current;
    document.querySelector('#progress').textContent = `${current}/${total}`;
    e.style.color = 'var(--main-color)'
    const iframe = document.querySelector('iframe');
    iframe.src = `https://www.youtube.com/embed/${url}`;
    $.ajax({
        url: '/Course/Progress',
        type: 'POST',
        data: { accountId: accountId, lessonId: lessonId, courseId: courseId },
        dataType: 'json',
        success: function (res) {
            console.log(res.status)
        },
    });
}


>>>>>>> f8654a48020cbcb3bcac4c83e7cd5f6e2313d210
