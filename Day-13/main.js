
function fetchAllPosts()
{  
    fetch("https://jsonplaceholder.typicode.com/posts")
    .then(res=>res.json())
    .then(data=>{
        const tablebody=document.getElementById("tablebody");
        tablebody.innerHTML="";
        data.forEach((post)=>
        {
            tablebody.innerHTML+=
            `
               <tr class="hover:bg-gray-50 transition">
                    <td class="p-3 border">${post.id}</td>
                    <td class="p-3 border">${post.title}</td>
                    <td class="p-3 border space-x-2">
                        <button 
                            onclick="DeletePost(${post.id})"
                            class="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600 transition">
                            Delete
                        </button>

                        <button 
                            onclick="GetPostById(${post.id})"
                            class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600 transition">
                            Get Post
                        </button>
                    </td>
                </tr>

            `
        }
    )
    });
}


function DeletePost(id)
{
     fetch(`https://jsonplaceholder.typicode.com/posts/${id}`,
    {
        method:"DELETE"
    }
    )
    .then(
        res=>{
            console.log(res)
            if(res.ok)
            {
                alert("deleted successfully");
            }
            else
            {
                alert("error deleting post");
            }
        }
    )
    .catch(err=> {
        console.log(err);
    }
    )
}

function GetPostById(id)
{
    fetch(`https://jsonplaceholder.typicode.com/posts/${id}`)
    .then(res=>res.json())
    .then(data=>alert(data.id));
}



    const addform=document.getElementById("formData");
    addform.addEventListener("submit",function(e){
        e.preventDefault();

        const data = {
            userId: document.getElementById("addUserId").value,
            title: document.getElementById("addTitle").value,
            body: document.getElementById("addBody").value
        };

        fetch("https://jsonplaceholder.typicode.com/posts",
            {
                method:"POST",
                headers:{
                    'content-type':'application/json'
                },
                body:JSON.stringify(data)
            }
        )
        .then(res=>res.json())
        .then(data=>alert(data));

        addform.reset()
    })


const updateform = document.getElementById("UpdateFormData");

updateform.addEventListener("submit", function (e) {
    e.preventDefault();

    const updateId = document.getElementById("updateId").value.trim();
    const updateUserId = document.getElementById("updateUserId").value.trim();
    const updateTitle = document.getElementById("updateTitle").value.trim();
    const updateBody = document.getElementById("updateBody").value.trim();

    if (!updateId) {
        alert("Post ID is required");
        return;
    }
    if (updateUserId && updateTitle && updateBody) {

        const putData = {
            id: updateId,
            userId: updateUserId,
            title: updateTitle,
            body: updateBody
        };

        fetch(`https://jsonplaceholder.typicode.com/posts/${updateId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(putData)
        })
        .then(res => res.json())
        .then(data => {
            console.log("PUT Response:", data);
            alert("Post updated successfully using PUT");
            updateform.reset();
        })
        .catch(err => console.error(err));
    }
    else {
        const patchData = {};

        if (updateUserId) patchData.userId = updateUserId;
        if (updateTitle) patchData.title = updateTitle;
        if (updateBody) patchData.body = updateBody;

        if (Object.keys(patchData).length === 0) {
            alert("Please enter at least one field to update");
            return;
        }

        fetch(`https://jsonplaceholder.typicode.com/posts/${updateId}`, {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(patchData)
        })
        .then(res => res.json())
        .then(data => {
            console.log("PATCH Response:", data);
            alert("Post updated successfully using PATCH");
            updateform.reset();
        })
        .catch(err => console.error(err));
    }
});

