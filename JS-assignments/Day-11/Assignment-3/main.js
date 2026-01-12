// Bubbling
function ButtonClick()
{
    console.log("Button clicked")
}
function DivClick()
{
    console.log("Div clicked")
}


// Capturing
const container = document.getElementById("container");
const button = document.getElementById("viewPolicy");

container.addEventListener("click", () => {
    console.log("Validating user...");
}, true);

button.addEventListener("click", () => {
    console.log("Showing policy details...");
}, true);


// Stop propogation
document.getElementById("deleteBtn").addEventListener("click", (event) => {
    event.stopPropagation();
    console.log("Deleting policy...");
});


const a = document.querySelector(".claim-row");
const b = document.querySelector(".approve-btn");

a.addEventListener("click", () => {
    console.log("Opening Claim Details");
});

b.addEventListener("click", (event) => {
    event.stopPropagation();  
    console.log("Claim Approved");
});