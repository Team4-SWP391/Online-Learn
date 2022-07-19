const btns = document.querySelectorAll('#course_section-title');
const list = document.querySelectorAll('#course_section-list');
const options = document.querySelectorAll('#course_options-items');
const courseDes = document.querySelector('.course_about');
const courseRev = document.querySelector('.course_reviews');

btns.forEach((btn, index) => {
    const icon = btn.querySelector('i');
    btn.addEventListener('click', e => {
        console.log(icon.classList);
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
