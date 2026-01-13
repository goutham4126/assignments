

// const username=document.getElementById("username");

// username.addEventListener("keydown",function (event){
//     document.getElementById("demo").innerHTML=event.target;
//     console.log(event)
// })

// window.addEventListener("load", function () {
//   document.getElementById("loader").innerHTML = "Page is fully loaded!";
// });


// const form=document.getElementById("userForm");


// const usernameInput=document.getElementById("username");
// usernameInput.addEventListener("input",(e)=>{
//     console.log(e.target.value);
// })

// form.addEventListener("submit",function(e){
//     e.preventDefault();

//     const username=document.getElementById("username").value;
//     if(username==="")
//     {
//         document.getElementById('username-error').innerHTML="Username is required";
//     }

    
//     const email=document.getElementById("email").value;
//     if(email==="")
//     {
//         document.getElementById('email-error').innerHTML="email is required";
//     }
//     console.log(username,email)
//     form.reset();
// })

const policiesData = [
  { id: 1, name: "Health Plus", type: "Health", premium: 12000, duration: 1, status: "Active" },
  { id: 2, name: "Life Secure", type: "Life", premium: 9000, duration: 10, status: "Inactive" },
  { id: 3, name: "Car Protect", type: "Vehicle", premium: 15000, duration: 1, status: "Active" },
  { id: 4, name: "Family Health", type: "Health", premium: 18000, duration: 2, status: "Active" }
];

// 1
async function fetchPolicies() {
  try {
    const response = await new Promise((resolve, reject) => {
      setTimeout(() => resolve(policiesData), 1000);
    });

    return response;
  } catch (error) {
    console.error("API Error:", error);
  }
}


// 2
function displayPolicies(policies) {
  policies.forEach(policy => {
    console.log(`
ID: ${policy.id}
Name: ${policy.name}
Type: ${policy.type}
Premium: ₹${policy.premium}
Duration: ${policy.duration} year(s)
Status: ${policy.status}
----------------------------`);
  });
}


// 3
function filterPolicies(type) {
  return policiesData.filter(policy => policy.type === type);
}
console.log(filterPolicies("Health"));


// 4
function calculateTotalPremium() {
  return policiesData
    .filter(p => p.status === "Active")
    .reduce((total, policy) => total + policy.premium, 0);
}


// 5
function applyDiscount() {
  return policiesData.map(policy => {
    if (policy.premium > 10000) {
      return {
        ...policy,
        premium: policy.premium * 0.9
      };
    }
    return policy;
  });
}

// 6
function approvePolicy(policyId, callback) {
  setTimeout(() => {
    const policy = policiesData.find(p => p.id === policyId);

    if (!policy) {
      callback("Invalid Policy ID", null);
    } else {
      callback(null, `Policy ${policy.name} Approved Successfully`);
    }
  }, 2000);
}

approvePolicy(1, (error, result) => {
  if (error) console.log(error);
  else console.log(result);
});


// 7
function purchasePolicy(policyId) {
  return new Promise((resolve, reject) => {
    const policy = policiesData.find(p => p.id === policyId);

    if (!policy) {
      reject("Policy not found");
    } else if (policy.status !== "Active") {
      reject("Policy is inactive");
    } else {
      resolve(`Policy ${policy.name} purchased successfully`);
    }
  });
}

purchasePolicy(3)
  .then(res => console.log(res))
  .catch(err => console.log(err));


// 8
function getPolicyById(id) {
  try {
    const policy = policiesData.find(p => p.id === id);

    if (!policy) throw "Invalid Policy ID";
    return policy;

  } catch (error) {
    console.error("Error:", error);
  }
}






