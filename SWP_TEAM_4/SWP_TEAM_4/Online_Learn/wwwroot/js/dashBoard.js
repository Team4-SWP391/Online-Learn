const roles = document.querySelectorAll('.tab-title');
const listItems = document.querySelectorAll('.list_items');

//roles.forEach((role, index) => {
//    role.addEventListener('click', () => {
//        roles.forEach(role => role.classList.remove('active'));
//        role.classList.add('active');
//        listItems.forEach(listItem => (listItem.style.display = 'none'));
//        listItems[index].style.display = 'grid';
//    });
//});

const role = document.querySelector('.tab-title').dataset.role;
if (role == 3) {
    listItems.forEach(listItem => (listItem.style.display = 'none'));
    listItems[0].style.display = 'grid';
}
if (role == 2) {
    listItems.forEach(listItem => (listItem.style.display = 'none'));
    listItems[1].style.display = 'grid';
}
if (role == 4) {
    listItems.forEach(listItem => (listItem.style.display = 'none'));
    listItems[2].style.display = 'grid';
}
