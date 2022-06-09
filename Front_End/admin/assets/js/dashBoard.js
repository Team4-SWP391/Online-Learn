const roles = document.querySelectorAll('.tab-title');
const listItems = document.querySelectorAll('.list_items');

roles.forEach((role, index) => {
    role.addEventListener('click', () => {
        roles.forEach(role => role.classList.remove('active'));
        role.classList.add('active');
        listItems.forEach(listItem => (listItem.style.display = 'none'));
        listItems[index].style.display = 'grid';
    });
});
