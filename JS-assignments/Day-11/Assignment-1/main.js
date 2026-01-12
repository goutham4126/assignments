Task - 1
// document.getElementById("pageTitle").textContent="Customer Insurance Overview"



Task - 2
// const list= document.getElementsByTagName("li")
// for(let x of list)
// {
//     x.style.border="2px solid green";
// }
// console.log(document.getElementsByTagName("li").length)



Task - 3
// const policies= document.getElementsByClassName("policy")

// for(let policy of policies)
// {
//     policy.classList.add("highlight");
//     policy.style.color="blue";
// }



Task - 4
// const firstCustomer= document.querySelector(".customer");
// console.log(firstCustomer.textContent)
// const customers= document.querySelectorAll(".customer");
// for(let customer of customers)
// {
//     console.log(customer.textContent);
// }
// const customers= document.getElementById("customerList");
// customers.lastElementChild.classList.add("active");



Task - 5
// console.log(document.getElementsByTagName("form").length)
// console.log(document.getElementsByTagName("img").length)

// const links= document.getElementsByTagName("a");
// for(let link of links)
// {
//     link.innerText="More info";
// }



Task - 6
// const newcus = document.createElement("li");
// newcus.className = "customer";
// newcus.textContent = "srihith - house";
// document.getElementById("customerlist").appendChild(newcus);



Task - 7
// document.querySelector("input[type=text]").style.backgroundColor="yellow";
// document.querySelector("input[type=text]").placeholder="Enter full name";



Task - 8
// const activeCustomers= document.querySelectorAll(".customer.active")
// for(let c of activeCustomers)
// {
//     c.style.color="darkgreen";
//     c.textContent= c.textContent + " (Priority Customer)";
// }



Task - 9
// console.log(document.querySelectorAll("#customerList li"))
// console.log(document.querySelectorAll("#customerList > li"))



Task - 10
// const evenCustomers = document.querySelectorAll(".customer:nth-child(even)");
// console.log(evenCustomers);
// const oddCustomers = document.querySelectorAll(".customer:nth-child(odd)");
// console.log(oddCustomers);



Task - 11 
// const enquiryForm = document.forms["enquiryForm"];
// for(let i of enquiryForm.elements){
//       console.log(element.name);
// }
// enquiryForm.querySelector("button").disabled = true;



Task -12 
// const a = document.getElementsByClassName("policy");
// const b = document.querySelectorAll(".policy");
// const new_p = document.createElement("p");
// new_p.className="policy";
// new_p.textContent = "travel";
// document.body.appendChild(new_p);
// console.log(a.length);
// console.log(b.length);


Task -13  
// const customers = document.querySelectorAll(".customer");
// customers.forEach(customer => {
//   const text = customer.textContent.toLowerCase();
//   if (text.includes("life")) {
//     customer.style.backgroundColor = "lightgreen";
//   }

//   if (text.includes("vehicle")) {
//     customer.style.display = "none";
//   }
// });




Task -14 
// const customers = document.querySelectorAll(".customer");
// customers.forEach(customer => {
//   customer.addEventListener("click", function () {
//     const parentUl = this.closest("ul");
//     parentUl.style.border = "3px solid red";
//   });
// });



Task -15
// const remainingPolicies =
//   document.querySelectorAll("p.policy:not(:first-child)");

// remainingPolicies.forEach(policy => {
//   policy.style.fontStyle = "italic";
//   policy.textContent = "✔ " + policy.textContent;
// });