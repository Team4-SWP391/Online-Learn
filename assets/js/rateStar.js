const rates = document.querySelectorAll('.rate');

rates.forEach(rate => {
    const stars = rate.querySelectorAll('.stars');
    rate.addEventListener('click', e => {
        const index = parseInt(e.target.dataset.star) + 1;
        console.log(stars);
        console.log(index);
        const check = e.target.classList.contains('fas');
        if (check) {
            for (let i = index; i < 5; i++) {
                stars[i].classList.remove('fas');
                stars[i].classList.add('fal');
            }
        } else {
            for (let i = 0; i < 5; i++) {
                stars[i].classList.remove('fal');
                stars[i].classList.add('fas');
            }
        }
    });
});
