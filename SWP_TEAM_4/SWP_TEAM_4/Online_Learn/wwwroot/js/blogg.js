let pointScroll = 'default'
document.onscroll = () => {
    // console.log(test.offsetTop)
    console.log(window.scrollY)
    const scrollValue = window.scrollY

    if (scrollValue >= 1050) {
        pointScroll = 'modify'
        console.log(pointScroll)
        test.classList.add('modify')
    } else {
        pointScroll = 'default'
        console.log(pointScroll)
        test.classList.remove('modify')

    }
}