const inputs = document.querySelectorAll('.signup_account-form');

const btnSubmit = document.querySelector('.signup_account-submit button');
const form = document.querySelector('.signup_form');
const fullname = inputs[0].querySelector('.form_signup');
const email = inputs[1].querySelector('.form_signup');
const password = inputs[2].querySelector('.form_signup');
const password2 = inputs[3].querySelector('.form_signup');
const existEmail = document.getElementById('existEmail');
const formMessage = document.querySelectorAll('.form_message');


//// Show input error message
//function showError(input, message) {
//	const formControl = input.parentElement
//	const messageTag = formControl.querySelector('.form_message')
//	messageTag.innerText = message
//}
//function showSuccess(input) {
//	const formControl = input.parentElement
//	const messageTag = formControl.querySelector('.form_message')
//	messageTag.innerText = ''
//}
//const validateEmail = email => {
//	return email.match(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/);
//};
//const validatePass = pass => {
//	return pass.match(/^([a-zA-Z0-9 ]){6,25}$/);
//};

//const validateName = name => {
//	return name.match(/^([a-zA-Z0-9 ]){2,30}$/);
//};
//// Check email is valid
//function checkEmail(input) {
//	const re =
//		/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
//	if (re.test(input.value.trim())) {
//		showSuccess(input)
//	} else {
//		if (existEmail.dataset.error != null) {
//			showError(input, 'Email is not valid')
//		} else {
//			showError(input, existEmail.dataset.error)
//		}
//	}
//}
// Check required fields
function checkRequired(inputArr) {
	let isRequired = false
	inputArr.forEach(function (input) {
		if (input.value.trim() === '') {
			isRequired = true
		} 
	})

	return isRequired
}

//// Check input length
//function checkLength(input, min, max) {
//	if (input.value.length < min) {
//		showError(
//			input,
//			`${getFieldName(input)} must be at least ${min} characters`
//		)
//	} else if (input.value.length > max) {
//		showError(
//			input,
//			`${getFieldName(input)} must be less than ${max} characters`
//		)
//	} else {
//		showSuccess(input)
//	}
//}
//// Check passwords match
//function checkPasswordsMatch(input1, input2) {
//	if (input1.value !== input2.value) {
//		showError(input2, 'Passwords do not match')
//	}
//}
//// Get fieldname
//function getFieldName(input) {
//	return input.name.charAt(0).toUpperCase() + input.name.slice(1)
//}
//function checkName(input) {
//	if (!validateName(fullname.value)) {
//		showError(input, 'Full Name must be letters')
//	}
//}
//// Event listeners
//form.addEventListener('submit', function (e) {

//	if (!checkRequired([fullname, email, password, password2])) {
//		checkLength(fullname, 2, 30)
//		checkLength(password, 6, 25)
//		checkEmail(email)
//		checkPasswordsMatch(password, password2)
//		checkName(fullname)
//	}
//	if (validateName(fullname.value) && validateEmail(email.value) && validatePass(password.value) && password.value === password2.value && !existEmail.value) {
//		form.submit();
//	} else {
//		e.preventDefault()
//	}
//})
const arrayMessage = Array.from(formMessage);

form.addEventListener('submit', function (e) {
	let valid = arrayMessage.every(checkErrorMessage);
	if (checkRequired([fullname, email, password, password2]) === false && valid === true) {
		show_alert();
    }
	form.submit();
})
function checkErrorMessage(a) {
	return a.innerHTML == '';
}

function show_alert() {
	alert("Register Successful!\n\nLogin to continue!");
}
const togglePassword = document.querySelector('#togglePassword');
togglePassword.addEventListener('click', function (e) {
	// toggle the type attribute
	const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
	password.setAttribute('type', type);
	// toggle the eye slash icon
	this.classList.toggle('fa-eye-slash');
});
const togglePassword2 = document.querySelector('#togglePassword2');
togglePassword2.addEventListener('click', function (e) {
	// toggle the type attribute
	const type = password2.getAttribute('type') === 'password' ? 'text' : 'password';
	password2.setAttribute('type', type);
	// toggle the eye slash icon
	this.classList.toggle('fa-eye-slash');
});
