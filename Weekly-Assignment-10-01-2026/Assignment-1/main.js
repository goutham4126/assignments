const form = document.getElementById("enquiryForm");
const successMsg = document.getElementById("successMsg");

form.addEventListener("submit", function (e) {
    e.preventDefault();

    let isValid = true;
    successMsg.textContent = "";

    document.querySelectorAll(".error").forEach(el => el.textContent = "");

    const name = document.getElementById("name");
    const email = document.getElementById("email");
    const phone = document.getElementById("phone");
    const requestType = document.getElementById("requestType");
    const policyType = document.getElementById("policyType");
    const message = document.getElementById("message");
    const rating = document.querySelector('input[name="rating"]:checked');

    if (name.value.trim() === "") {
        showError(name, "Name is required");
        isValid = false;
    }

    if (email.value.trim() === "") {
        showError(email, "Email is required");
        isValid = false;
    }

    if (!/^\d{10}$/.test(phone.value)) {
        showError(phone, "Mobile must be exactly 10 digits");
        isValid = false;
    }

    if (requestType.value === "") {
        showError(requestType, "Please select request type");
        isValid = false;
    }

    if (policyType.value === "") {
        showError(policyType, "Please select policy type");
        isValid = false;
    }

    if (message.value.trim().length < 10) {
        showError(message, "Message must be at least 10 characters");
        isValid = false;
    }

    if (!rating) {
        document.querySelector('.radio-group').nextElementSibling.textContent = "Please select rating";
        isValid = false;
    }

    if (isValid) {
        successMsg.textContent = "Thank you! Your enquiry has been successfully submitted.";
        form.reset();
    }
});

function showError(input, message) {
    const field = input.parentElement;
    field.querySelector(".error").textContent = message;
}
