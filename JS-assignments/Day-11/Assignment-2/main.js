
let matrix=[
    ["","",""],
    ["","",""],
    ["","",""]
]

function CalculateCount()
{
    let count=0;

    for(let ele of matrix)
    {
        for(let x of ele)
        {
            if(x==="")
                count++;
        }
    }
    return count;
}


function DisplayMatrix()
{

    const arr1=['box-1','box-2','box-3','box-4','box-5','box-6','box-7','box-8','box-9']
    const arr2=[]
    for(let ele of matrix)
    {
        for(let x of ele)
        {
            arr2.push(x);
        }        
    }

    for(let i=0;i<arr1.length;i++)
    {
        document.getElementById(arr1[i]).innerHTML=arr2[i];
    }
}

function Reset()
{
    const arr=['box-1','box-2','box-3','box-4','box-5','box-6','box-7','box-8','box-9']

    for(let ele of arr)
    {
        document.getElementById(ele).innerHTML="";
    }
}

function TicTacToe(x,y)
{

    let count=CalculateCount();
    console.log(count);
    if(count%2===0)
    {
        matrix[x][y]="X";
        DisplayMatrix();
    }
    else
    {
        matrix[x][y]="O";
        DisplayMatrix();
    }
}