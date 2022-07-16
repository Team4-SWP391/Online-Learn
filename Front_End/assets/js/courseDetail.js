let pointScroll = 'default'
document.onscroll = () => {
    // console.log(test.offsetTop)
    console.log(window.scrollY)
    const scrollValue = window.scrollY

    if(scrollValue >= 750) {
        pointScroll = 'modify'
        console.log(pointScroll)
        test.classList.add('modify')
    }else {
        pointScroll = 'default'
        console.log(pointScroll)
        test.classList.remove('modify')

    }
}


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

