const customers = [
    { id: 1, name: "Goutham", age: 21, policyType: "Life Insurance", coverage: 5000000, premium: 30000 },
    { id: 2, name: "Rohit", age: 35, policyType: "Health Insurance", coverage: 500000, premium: 7500 },
    { id: 3, name: "Sneha", age: 28, policyType: "Vehicle Insurance", coverage: 100000, premium: 2500 },
    { id: 4, name: "Arjun", age: 48, policyType: "Home Insurance", coverage: 3000000, premium: 18000 },
    { id: 5, name: "Priya", age: 42, policyType: "Life Insurance", coverage: 5000000, premium: 30000 },
    { id: 6, name: "Karthik", age: 31, policyType: "Health Insurance", coverage: 500000, premium: 7500 }
];

// DOM Elements
const form = document.getElementById("enquiryForm");
const tableBody = document.getElementById("customerTableBody");
const successMsg = document.getElementById("successMsg");

const totalCustomersEl = document.getElementById("totalCustomers");
const totalPoliciesEl = document.getElementById("totalPolicies");
const totalCoverageEl = document.getElementById("totalCoverage");

const searchInput = document.getElementById("searchInput");
const policyFilter = document.getElementById("policyFilter");

// Calculate Premium
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

// Render Table
function renderTable(list) {
    tableBody.innerHTML = "";

    list.forEach(c => {
        const row = document.createElement("tr");

        row.innerHTML = `
            <td class="border px-2">${c.name}</td>
            <td class="border px-2">${c.age}</td>
            <td class="border px-2">${c.policyType}</td>
            <td class="border px-2">₹${c.coverage.toLocaleString("en-IN")}</td>
            <td class="border px-2">₹${c.premium.toLocaleString("en-IN")}</td>
        `;

        tableBody.appendChild(row);
    });
}

// Update Stats
function updateStats() {
    const totalCustomers = customers.length;
    const totalPolicies = customers.length;

    const totalCoverage = customers.reduce((sum, c) => sum + Number(c.coverage), 0);

    totalCustomersEl.textContent = totalCustomers;
    totalPoliciesEl.textContent = totalPolicies;
    totalCoverageEl.textContent = "₹" + totalCoverage.toLocaleString("en-IN");
}

// Search & Filter
function applySearchAndFilter() {
    const searchText = searchInput.value.toLowerCase();
    const selectedPolicy = policyFilter.value;

    const filtered = customers.filter(c => {
        const matchesSearch =
            c.name.toLowerCase().includes(searchText) ||
            c.policyType.toLowerCase().includes(searchText);

        const matchesPolicy =
            selectedPolicy === "" || c.policyType === selectedPolicy;

        return matchesSearch && matchesPolicy;
    });

    renderTable(filtered);
}

// Events
searchInput.addEventListener("input", applySearchAndFilter);
policyFilter.addEventListener("change", applySearchAndFilter);

// Form Submit
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

    if (name.value.trim() === "") { showError(name, "Name required"); isValid = false; }
    if (age.value.trim() === "" || age.value <= 0) { showError(age, "Valid age required"); isValid = false; }
    if (email.value.trim() === "") { showError(email, "Email required"); isValid = false; }
    if (!/^\d{10}$/.test(phone.value)) { showError(phone, "Mobile must be 10 digits"); isValid = false; }
    if (requestType.value === "") { showError(requestType, "Select request type"); isValid = false; }
    if (policyType.value === "") { showError(policyType, "Select policy type"); isValid = false; }
    if (message.value.trim().length < 10) { showError(message, "Minimum 10 characters"); isValid = false; }

    if (!isValid) return;

    let coverage = 0;
    if (policyType.value === "Health Insurance") coverage = 500000;
    if (policyType.value === "Vehicle Insurance") coverage = 100000;
    if (policyType.value === "Life Insurance") coverage = 5000000;
    if (policyType.value === "Home Insurance") coverage = 3000000;

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
    applySearchAndFilter();
    updateStats();

    successMsg.textContent = "Thank you! Your enquiry has been successfully submitted.";
    form.reset();
});

// Error Handler
function showError(input, message) {
    input.parentElement.querySelector(".error").textContent = message;
}

// Initial Load
document.addEventListener("DOMContentLoaded", () => {
    applySearchAndFilter();
    updateStats();
});
