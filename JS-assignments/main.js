// document.getElementById("para").style.color="red";
// console.log("Hello")
// alert("Hello people");


// let s="Goutham";
// p=s.toLowerCase()

// document.writeln("hello")

// prompt("Enter your age:")
// function test() {
//   let y = 20;

// }
// console.log(y);   // ❌ Error: y is not defined

// console.log(Number(new Date("09-02-2005")));

// const sum=(a,b)=>
// {
//     return a+b;
// }
// // console.log(parseFloat("10.45"))
// console.log(sum(10,18));

// const x=Math.random()
// console.log(x.toString(36))
// console.log(x.toString(36).slice(2,5))
// console.log(typeof null)


const bentoData=[
    {
        id:"bento-1",
        content:"Content for bento-1",
    },
    {
        id:"bento-2",
        content:"Content for bento-2",
    },
    {
        id:"bento-3",
        content:"Content for bento-3",
    },
    {
        id:"bento-4",
        content:"Content for bento-4",
    },
    {
        id:"bento-5",
        content:"Content for bento-5",
    },
    {
        id:"bento-6",
        content:"Content for bento-6",
    },
]

bentoData.map((data)=>{
    document.getElementById(`${data.id}`).innerHTML=`${data.content}`
})




