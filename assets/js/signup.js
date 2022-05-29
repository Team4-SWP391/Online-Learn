const inputs = document.querySelectorAll('.signup_account-form');
const span = document.querySelectorAll('.signup_placeholder');
const app = document.querySelector('.app');

const btnSubmit = document.querySelector('.signup_account-submit button');
const form = document.querySelector('.signup_form');
const messageEmail = document.querySelector('.form_message-email');
const messagePass = document.querySelector('.form_message-pass');
const messageName = document.querySelector('.form_message-name');

app.addEventListener('click', function (e) {
    if (e.target.classList.contains('form_signup') || e.target.classList.contains('signup_placeholder')) {
        inputs[e.target.dataset.index].querySelector('.form_signup').focus();
        span[e.target.dataset.index].style.top = '5%';
        span[e.target.dataset.index].style.fontSize = '1rem';
    } else {
        inputs.forEach(function (input, index) {
            if (input.querySelector('.form_signup').value.length === 0) {
                span[index].style.top = '25%';
                span[index].style.fontSize = '1.2rem';
            }
        });
    }
});

const validateEmail = email => {
    return email.match(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/);
};
const validatePass = pass => {
    return pass.match(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/);
};

const validateName = name => {
    return name.match(/^([a-zA-Z ]){2,30}$/);
};

const fullname = inputs[0].querySelector('.form_signup');
const password = inputs[2].querySelector('.form_signup');
const email = inputs[1].querySelector('.form_signup');

const validateInfo = (callBack, element, messageElement) => {
    if (!callBack || element.value.length == 0) {
        messageElement.style.display = 'block';
    } else {
        messageElement.style.display = 'none';
    }
};

form.addEventListener('submit', e => {
    validateInfo(validateEmail(email.value), email, messageEmail);
    validateInfo(validatePass(password.value), password, messagePass);
    validateInfo(validateName(fullname.value), fullname, messageName);
    if (validateEmail(email.value) && validatePass(password.value) && validateName(fullname.value)) {
        form.submit();
    } else {
        e.preventDefault();
    }
});

inputs.forEach(function (input) {
    input.addEventListener('change', () => {
        validateInfo(validateName(fullname.value), fullname, messageName);
        validateInfo(validateEmail(email.value), email, messageEmail);
        validateInfo(validatePass(password.value), password, messagePass);
    });
});
