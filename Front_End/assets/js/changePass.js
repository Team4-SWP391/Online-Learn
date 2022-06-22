const form = document.getElementById('changepass-form');
const inputs = document.querySelectorAll('.changepass_form');
// const oldpass = inputs[1].querySelector('.pwform');
const newpass = inputs[1].querySelector('.pwform');
const cfnewpass = inputs[2].querySelector('.pwform');

function showError(input, message) {
    const formControl = input.parentElement
    const messageTag = formControl.querySelector('.form_message')
    messageTag.innerText = message
}
function showSuccess(input) {
    const formControl = input.parentElement
    const messageTag = formControl.querySelector('.form_message')
    messageTag.innerText = ''
}
const validatePass = pass => {
    return pass.match(/^([a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]){6,25}$/);
};
// Check required fields
function checkRequired(inputArr) {
    let isRequired = false
    inputArr.forEach(function (input) {
        if (input.value.trim() === '') {
            showError(input, `${getFieldName(input)} is required`)
            isRequired = true
        } else {
            showSuccess(input)
        }
    })
    return isRequired
}

// Check input length
function checkLength(input, min, max) {
    if (input.value.length < min) {
        showError(
            input,
            `${getFieldName(input)} must be at least ${min} characters`
        )
    } else if (input.value.length > max) {
        showError(
            input,
            `${getFieldName(input)} must be less than ${max} characters`
        )
    } else {
        showSuccess(input)
    }
}
// Check passwords match
function checkPasswordsMatch(input1, input2) {
    if (input1.value !== input2.value) {
        showError(input2, 'Passwords do not match')
    }
}
// Get fieldname
function getFieldName(input) {
    return input.name.charAt(0).toUpperCase() + input.name.slice(1)
}

form.addEventListener('submit', function (e) {
    if (!checkRequired([newpass, cfnewpass])) {
        checkLength(newpass, 6, 25)
        checkLength(cfnewpass, 6, 25)
        checkPasswordsMatch(newpass, cfnewpass)
    }
    if (validatePass(newpass.value)) {
        form.submit();
        show_alert();
    } else {
        e.preventDefault()
    }

})
function show_alert() {
    alert("Change password Successful!");
}