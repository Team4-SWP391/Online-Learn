const headings = document.querySelectorAll('.course-sidebar__heading');
const list = document.querySelectorAll('.course-sidebar__list');
headings.forEach((item, index) => {
    const icon = item.querySelector('i');
    item.addEventListener('click', e => {
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

// const del = document.querySelector('.course-update__info');
// const close = document.querySelector('.delete-close');
// const cancel = document.querySelector('.delete_cancel');
// const url = del.getAttribute("id");
// const template = `<div class="delete">
// <div class="delete-head">
// <div class="delete-close">
//     <i class="fas fa-times-circle"></i>
// </div>
// </div>
// <div class="delete-content">
// <i class="fas fa-exclamation-circle"></i>
// <span class="delete-alert">Do you want delete Course</span>
// </div>
// <div class="delete-main">
// <div class="delete__tt">
//     <a href="${url}" class="delete_link">Delete</a>
// </div>
// <div class="delete__tt">
//     <span class="delete_cancel">Cancel</span>
// </div>

// </div>
// </div>`;

// del.addEventListener('click', deleteModal);
// function deleteModal(e) {
//     document.body.insertAdjacentHTML("beforeend", template);
//     del.setAttribute("disabled", "");
// }

// document.addEventListener('click', (e) => {
//     console.log(e.target)
//     const close = document.querySelector('.delete-close i');
//     const close1 = document.querySelector('.delete-close');
//     const cancel = document.querySelector('.delete_cancel')
//     const nd = document.querySelector('.delete');
//     if (e.target.matches('.delete-close') || e.target.matches('.delete_cancel') || e.target.matches('.delete-close i')) {

//         document.body.removeChild(nd);
//         del.removeAttribute("disabled");
//     }
// })


const template_lecture = `<div class="lecture">
<div class="lecture-heading">
    <div class="lecture-add">
        <h3>New Lecture</h3>
    </div>
    <div class="lecture-icon">
        <i class="fas fa-times" id="lecture-close"></i>
    </div>
</div>
<form action="#" method="get">
    <div class="lecture-form">
        <div class="lecture-form__group">
            <label for="" class="lecture-lable">Name Lecture</label><br>
            <input type="text" name="name" class="lecture-input" placeholder="Create new Lecture...">
            <input type="text" name="course_id" class="lecture-input" hidden>
        </div>
        <div class="lecture-form__group">
            <label for="" class="lecture-lable">Description</label><br>
            <textarea name="desc" cols="58" class="lecture-textar"
                rows="8"></textarea>
        </div>
        <div class="lecture-form__group">
            <button class="lecture-submit">Create new</button>
        </div>
    </div>
</form>
</div>`;
const lecture_create = document.querySelector('.lecture-create');
lecture_create.addEventListener('click', (e) => {
    console.log(e.target)
    document.body.insertAdjacentHTML("beforeend", template_lecture);
    lecture_create.setAttribute("disabled", "");
});

document.addEventListener('click', (e) => {
    const close_lecture = document.querySelector('#lecture-close');
    const lecture = document.querySelector('.lecture');
    console.log(e.target);
    if (e.target.matches('#lecture-close')) {
        document.body.removeChild(lecture);
        lecture_create.removeAttribute("disabled");
    }
})