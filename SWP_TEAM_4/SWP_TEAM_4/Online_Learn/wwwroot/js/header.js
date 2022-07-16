const input = document.querySelector('.header_center-search input');
const btnSearch = document.querySelector('#btnSubmit');
const form = document.querySelector('#formHeader');
input.addEventListener('keyup', function () {
    if (input.value != '') {
        btnSearch.style.opacity = '1';
        btnSearch.style.visibility = 'visible';
    } else {
        btnSearch.style.visibility = 'hidden';
        btnSearch.style.opacity = '0';
    }
});
form.addEventListener('submit', function (e) {
    if (input.value == '') {
        e.preventDefault();
    }
});
