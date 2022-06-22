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


//const del = document.querySelector('.course-update__info');
//const close = document.querySelector('.delete-close');
//const cancel = document.querySelector('.delete_cancel');
//const url = del.getAttribute("id");
//const template = `<div class="delete">
//<div class="delete-head">
//<div class="delete-close">
//    <i class="fas fa-times-circle"></i>
//</div>
//</div>
//<div class="delete-content">
//<i class="fas fa-exclamation-circle"></i>
//<span class="delete-alert">Do you want delete Course</span>
//</div>
//<div class="delete-main">
//<div class="delete__tt">
//    <a href="${url}" class="delete_link">Delete</a>
//</div>
//<div class="delete__tt">
//    <span class="delete_cancel">Cancel</span>
//</div>

//</div>
//</div>`;

//del.addEventListener('click', deleteModal);
//function deleteModal(e) {
//    document.body.insertAdjacentHTML("beforeend", template);
//    del.setAttribute("disabled", "");
//}

//document.addEventListener('click', (e) => {
//    console.log(e.target)
//    const close = document.querySelector('.delete-close i');
//    const close1 = document.querySelector('.delete-close');
//    const cancel = document.querySelector('.delete_cancel')
//    const nd = document.querySelector('.delete');
//    if (e.target.matches('.delete-close') || e.target.matches('.delete_cancel') || e.target.matches('.delete-close i')) {

//        document.body.removeChild(nd);
//        del.removeAttribute("disabled");
//    }
//})

