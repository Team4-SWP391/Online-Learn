const update = document.querySelector('#lecture-update');
const del = document.querySelector('#lecture-delete');

const value_id = del.getAttribute('data-id');
console.log(value_id)
const template_delete = `<div class="delete">
<div class="delete-heading">
    <div class="delete-add">
        <p>Do you want to delete ?</p>
    </div>
    <div class="delete-icon">
        <i class="fas fa-times" id="delete-close"></i>
    </div>
</div>
<div class="delete-footer">
    <a href="Delete?id=${value_id}" class="delete-acpt">Ok</a>
    <span class="delete-cancel">Cancel</span>
</div>
</div>`;

const tpl_update = document.querySelector('.update');
update.addEventListener('click', (e) => {
    tpl_update.classList.add("show-update");
    update.setAttribute('disabled', '');
    del.setAttribute('disabled', '');
})

const close_update = document.querySelector('#update-close');
close_update.addEventListener('click', (e) => {
    console.log(e.target)
    tpl_update.classList.remove("show-update");
    update.removeAttribute('disabled');
    del.removeAttribute('disabled');
})

del.addEventListener('click', (e) => {
    document.body.insertAdjacentHTML('beforeend', template_delete);
    update.setAttribute('disabled', '');
    del.setAttribute('disabled', '');
})

document.addEventListener('click', (e) => {
    const tpl_delete = document.querySelector('.delete');
    const close_delete = document.querySelector('#delete-close');
    const cancel = document.querySelector('.delete-cancel');
    if (e.target.matches('#delete-close') || e.target.matches('.delete-cancel')) {
        document.body.removeChild(tpl_delete);
        update.removeAttribute('disabled');
        del.removeAttribute('disabled');
    }
})