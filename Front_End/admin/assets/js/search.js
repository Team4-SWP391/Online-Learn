const headerDrop = document.querySelectorAll('.topic-header');
const contentDrop = document.querySelectorAll('.topic-content');
const arrows = document.querySelectorAll('.arrow');

let isDrop = false;

headerDrop.forEach(
    (item, index) =>
        (item.onclick = () => {
            // console.log(contentDrop)
            if (isDrop) {
                console.log('is drop');
                arrows[index].innerHTML = ` <span><i class="fa fa-angle-down"
            aria-hidden="true"></i></span>`;
                isDrop = false;
                contentDrop[index].style.display = 'none';
            } else {
                isDrop = true;
                arrows[index].innerHTML = ` <span><i class="fa fa-angle-up"
            aria-hidden="true"></i></span>`;
                console.log('is up');
                contentDrop[index].style.display = 'block';
            }
        }),
);
