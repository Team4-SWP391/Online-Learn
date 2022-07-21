const update = document.querySelector('#lecture-update');
const del = document.querySelector('#lecture-delete');

const value_id = del.getAttribute('data-id');
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


const lecture_create = document.querySelector('.lesson-create');
const value_cid = lecture_create.getAttribute('data-cid');
console.log(value_cid)

const template_lecture = `<div class="lesson">
<div class="lesson-heading">
    <div class="lesson-add">
        <h3>New lesson</h3>
    </div>
    <div class="lesson-icon">
        <i class="fas fa-times" id="lesson-close"></i>
    </div>
</div>
<form action="addLesson">
    <div class="lesson-form">
        <div class="lesson-form__group">
            <label for="" class="lesson-lable">Name lesson</label><br>
            <input type="text" name="NewLesson.LessonName" class="lesson-input" placeholder="Create new Lesson...">
               
            
                
         
        </div>

        <div class="lesson-form__group" hidden>
            <label for="" class="lesson-lable">Name lesson</label><br>
           <input type="text" name="NewLesson.LectureId" class="lecture-input" value="${value_cid}">
        </div>
           
        <div class="lesson-form__group">
            <label for="" class="lesson-lable">Video</label><br>
            <input type="text" name="NewLesson.Video" class="lesson-input">
            
        <div class="lesson-form__group">
            <label for="" class="lesson-lable">Description</label><br>
            <textarea name="NewLesson.Main" cols="62" class="lesson-textar"
                rows="8"></textarea>
        </div>
        <div class="lesson-form__group">
            <button class="lesson-submit">Add new</button>
        </div>
    </div>
</form>
</div>`;

lecture_create.addEventListener('click', (e) => {
    console.log(e.target)
    document.body.insertAdjacentHTML("beforeend", template_lecture);
    lecture_create.setAttribute("disabled", "");
});

document.addEventListener('click', (e) => {
    const close_lecture = document.querySelector('#lesson-close');
    const lecture = document.querySelector('.lesson');
    console.log(e.target);
    if (e.target.matches('#lesson-close')) {
        document.body.removeChild(lecture);
        lecture_create.removeAttribute("disabled");
    }
})

/*lesson*/

/*const lessonupdate = document.querySelector('#lesson-update');*/


const lessonvalue_id = lessondel.getAttribute('data-lesid');


function deleteLesson(id){
    const template_deletelesson = `<div class="delete">
<div class="delete-heading">
    <div class="delete-add">
        <p>Do you want to delete this lesson?</p>
    </div>
    <div class="delete-icon">
        <i class="fas fa-times" id="delete-close"></i>
    </div>
</div>
<div class="delete-footer">
    <a href="DeleteLesson?id=${id}" class="delete-acpt">Ok</a>
    <span class="delete-cancel">Cancel</span>
</div>
</div>`;
    document.body.insertAdjacentHTML('beforeend', template_deletelesson);
   
    lessondel.setAttribute('disabled', '');
}


document.addEventListener('click', (e) => {
    const tpl_deleteles = document.querySelector('.delete');
    const close_deleteles = document.querySelector('#delete-close');
    const cancelles = document.querySelector('.delete-cancel');
    if (e.target.matches('#delete-close') || e.target.matches('.delete-cancel')) {
        document.body.removeChild(tpl_deleteles);
        lessonupdate.removeAttribute('disabled');
        lessondel.removeAttribute('disabled');
    }
})