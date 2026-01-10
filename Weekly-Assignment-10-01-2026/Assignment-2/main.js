
const customers = [
    {
        id: 1,
        name: "Goutham",
        age: 21,
        policyType: "Life Insurance",
        coverage: 5000000,
        premium: 30000
    },
    {
        id: 2,
        name: "Rohit",
        age: 35,
        policyType: "Health Insurance",
        coverage: 500000,
        premium: 7500
    },
    {
        id: 3,
        name: "Sneha",
        age: 28,
        policyType: "Vehicle Insurance",
        coverage: 100000,
        premium: 2500
    },
    {
        id: 4,
        name: "Arjun",
        age: 48,
        policyType: "Home Insurance",
        coverage: 3000000,
        premium: 18000
    },
    {
        id: 5,
        name: "Priya",
        age: 42,
        policyType: "Life Insurance",
        coverage: 5000000,
        premium: 30000
    },
    {
        id: 6,
        name: "Karthik",
        age: 31,
        policyType: "Health Insurance",
        coverage: 500000,
        premium: 7500
    }
];



const form = document.getElementById("enquiryForm");
const tableBody = document.querySelector("tbody");
const successMsg = document.getElementById("successMsg");

function calculatePremium(age, policyType, coverage) {
    let base = 0;

    if (policyType === "Health Insurance") base = 3000;
    if (policyType === "Life Insurance") base = 5000;
    if (policyType === "Vehicle Insurance") base = 2000;
    if (policyType === "Home Insurance") base = 2500;

    if (age > 45) base += base * 0.2;

    base += Math.floor(coverage / 100000) * 500;

    return base;
}

function renderTable(list) {
    tableBody.innerHTML = "";

    list.forEach(c => {
        const row = document.createElement("tr");

        row.innerHTML = `
            <td class="border px-2">${c.name}</td>
            <td class="border px-2">${c.age}</td>
            <td class="border px-2">${c.policyType}</td>
            <td class="border px-2">${c.coverage}</td>
            <td class="border px-2">${c.premium}</td>
        `;

        tableBody.appendChild(row);
    });
}

renderTable(customers);

form.addEventListener("submit", function(e) {
    e.preventDefault();

    successMsg.textContent = "";
    document.querySelectorAll(".error").forEach(el => el.textContent = "");

    const name = document.getElementById("name");
    const age = document.getElementById("age");
    const email = document.getElementById("email");
    const phone = document.getElementById("phone");
    const requestType = document.getElementById("requestType");
    const policyType = document.getElementById("policyType");
    const message = document.getElementById("message");

    let isValid = true;

    if (name.value.trim() === "") {
        showError(name, "Name required");
        isValid = false;
    }

    if (age.value.trim() === "" || age.value <= 0) {
        showError(age, "Valid age required");
        isValid = false;
    }

    if (email.value.trim() === "") {
        showError(email, "Email required");
        isValid = false;
    }

    if (!/^\d{10}$/.test(phone.value)) {
        showError(phone, "Mobile must be 10 digits");
        isValid = false;
    }

    if (requestType.value === "") {
        showError(requestType, "Select request type");
        isValid = false;
    }

    if (policyType.value === "") {
        showError(policyType, "Select policy type");
        isValid = false;
    }

    if (message.value.trim().length < 10) {
        showError(message, "Minimum 10 characters");
        isValid = false;
    }

    if (!isValid) return;

    let coverage;

    if (policyType.value === "Health Insurance") {
        coverage = 500000;
    }
    else if (policyType.value === "Vehicle Insurance") {
        coverage = 100000;
    }
    else if (policyType.value === "Life Insurance") {
        coverage = 5000000;
    }
    else {
        coverage = 3000000;
    }


    const premium = calculatePremium(parseInt(age.value), policyType.value, coverage);

    const newCustomer = {
        id: customers.length + 1,
        name: name.value,
        age: age.value,
        policyType: policyType.value,
        coverage: coverage,
        premium: premium
    };

    customers.push(newCustomer);
    renderTable(customers);

    successMsg.textContent = "Thank you! Your enquiry has been successfully submitted.";
    form.reset();
});

function showError(input, message) {
    input.parentElement.querySelector(".error").textContent = message;
}
