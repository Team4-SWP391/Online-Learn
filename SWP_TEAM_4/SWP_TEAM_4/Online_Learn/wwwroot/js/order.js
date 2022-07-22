
const contact = document.querySelector('.course-show');

contact.addEventListener('click', (e) => {
    console.log(e)
    const dropdown = document.querySelector('.course-contact__user');
    dropdown.classList.toggle('active');
});

