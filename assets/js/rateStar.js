const rates = document.querySelectorAll('.rate');

rates.forEach(rate => {
    rate.addEventListener('click', e => {
        console.log(e.target.dataset.star);
    });
});
