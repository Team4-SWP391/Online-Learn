const categories = document.querySelectorAll(".sidebar-item__link");
[...categories].forEach(item => item.addEventListener('click', handleClick));
function handleClick(e) {
    [...categories].forEach(item => item.classList.remove("active"));
    e.target.classList.add("active");
}

// const page = document.querySelectorAll('.pagination-link');
// [...page].forEach(item => item.addEventListener('click', activePage));
// function activePage(e) {
//     console.log(e.target);
//     [...page].forEach(item => item.classList.remove('page-active'));
//     e.target.classList.add('page-active');
// }