let allUsers = [];

async function FetchDetails() {
  try {
    const res = await fetch("https://jsonplaceholder.typicode.com/users");
    const data = await res.json();

    allUsers = data.map(user => ({
      id: user.id,
      name: user.name,
      email: user.email,
      branch: user.address.city,
      balance: Math.floor(Math.random() * 40000) + 10000,
      transactions: []
    }));

    saveData();
    populateCityFilter(allUsers);
    displayUsers(allUsers);
  } catch (err) {
    alert("Failed to fetch data");
  }
}

function displayUsers(users) {
  const container = document.getElementById("dataCards");
  container.innerHTML = "";

  users.forEach(user => {
    const lowBalanceClass = user.balance < 5000 ? "border-2 border-red-500" : "";

    container.innerHTML += `
      <div class="bg-white shadow p-4 rounded mb-3 ${lowBalanceClass}">
        <p><b>ID:</b> ${user.id}</p>
        <p><b>Name:</b> ${user.name}</p>
        <p><b>Email:</b> ${user.email}</p>
        <p><b>Branch:</b> ${user.branch}</p>
        <p><b>Balance:</b> ₹${user.balance}</p>

        <div class="flex gap-2 mt-2">
          <button onclick="deposit(${user.id})" class="bg-green-600 text-white px-3 py-1 rounded">Deposit</button>
          <button onclick="withdraw(${user.id})" class="bg-yellow-500 text-white px-3 py-1 rounded">Withdraw</button>
          <button onclick="deleteAccount(${user.id})" class="bg-red-600 text-white px-3 py-1 rounded">Delete</button>
        </div>

        <button onclick="viewHistory(${user.id})" class="mt-2 text-blue-600 underline">View Transactions</button>
      </div>
    `;
  });
}

function deposit(id) {
  const amount = Number(prompt("Enter deposit amount:"));
  const user = allUsers.find(u => u.id === id);

  user.balance += amount;
  user.transactions.push({ type: "Deposit", amount, date: new Date().toLocaleString() });

  saveData();
  displayUsers(allUsers);
}

function withdraw(id) {
  const amount = Number(prompt("Enter withdrawal amount:"));
  const user = allUsers.find(u => u.id === id);

  if (user.balance - amount < 5000) {
    alert("Minimum balance ₹5000 required. ₹200 penalty applied!");
    user.balance -= 200;
  } else {
    user.balance -= amount;
    user.transactions.push({ type: "Withdraw", amount, date: new Date().toLocaleString() });
  }

  saveData();
  displayUsers(allUsers);
}

document.getElementById("accountForm").addEventListener("submit", e => {
  e.preventDefault();

  const newUser = {
    id: allUsers.length+1,
    name: username.value,
    email: email.value,
    branch: branch.value,
    balance: 10000,
    transactions: []
  };

  allUsers.push(newUser);
  saveData();
  populateCityFilter(allUsers);
  displayUsers(allUsers);
  e.target.reset();
});

function deleteAccount(id) {
  if (confirm("Delete this account?")) {
    allUsers = allUsers.filter(u => u.id !== id);
    saveData();
    displayUsers(allUsers);
  }
}

function viewHistory(id) {
  const user = allUsers.find(u => u.id === id);

  let history = user.transactions.map(t => `${t.type} ₹${t.amount} on ${t.date}`).join("\n");
  alert(history || "No transactions yet");
}

function populateCityFilter(users) {
  const cityFilter = document.getElementById("cityFilter");
  cityFilter.innerHTML = `<option value="">Filter by city</option>`;

  [...new Set(users.map(u => u.branch))].forEach(city => {
    const option = document.createElement("option");
    option.value = city;
    option.textContent = city;
    cityFilter.appendChild(option);
  });
}

function applyFilters() {
  const search = searchInput.value.toLowerCase();
  const city = cityFilter.value;

  const filtered = allUsers.filter(user =>
    user.name.toLowerCase().includes(search) &&
    (city === "" || user.branch === city)
  );

  displayUsers(filtered);
}

searchInput.addEventListener("input", applyFilters);
cityFilter.addEventListener("change", applyFilters);

sortBtn.addEventListener("click", () => {
  allUsers.sort((a, b) => b.balance - a.balance);
  displayUsers(allUsers);
});

function saveData() {
  localStorage.setItem("users", JSON.stringify(allUsers));
}

remove.addEventListener("click", () => {
  localStorage.removeItem("users");
  allUsers = [];
  displayUsers([]);
});

window.onload = () => {
  const data = JSON.parse(localStorage.getItem("users"));
  if (data) {
    allUsers = data;
    populateCityFilter(allUsers);
    displayUsers(allUsers);
  }
};

add.addEventListener("click", FetchDetails);
