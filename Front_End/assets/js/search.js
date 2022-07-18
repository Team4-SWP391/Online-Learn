const headerDrop = document.querySelectorAll('.topic-header');
const contentDrop = document.querySelectorAll('.topic-content');
const arrows = document.querySelectorAll('.arrow');

headerDrop.forEach((item, index) => {
    const icon = item.querySelector('i');
    item.addEventListener('click', () => {
        const check = icon.classList.value == 'fa fa-angle-up';
        if (check) {
            icon.classList.remove('fa-angle-up');
            icon.classList.add('fa-angle-down');
            contentDrop[index].style.display = 'none';
        } else {
            icon.classList.add('fa-angle-up');
            icon.classList.remove('fa-angle-down');
            contentDrop[index].style.display = 'block';
        }
    });
});
