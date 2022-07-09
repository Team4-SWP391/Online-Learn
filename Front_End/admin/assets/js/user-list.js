const categories = document.querySelectorAll(".sidebar-item__link");
[...categories].forEach(item => item.addEventListener('click', handleClick));
function handleClick(e) {
    [...categories].forEach(item => item.classList.remove("active"));
    e.target.classList.add("active");
}