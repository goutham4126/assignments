let matrix = [
    ["", "", ""],
    ["", "", ""],
    ["", "", ""]
];

function CalculateCount() {
    let count = 0;

    for (let row of matrix) {
        for (let cell of row) {
            if (cell !== "") count++;
        }
    }

    return count;
}

function DisplayMatrix() {
    const boxes = [
        'box-1','box-2','box-3',
        'box-4','box-5','box-6',
        'box-7','box-8','box-9'
    ];

    let values = [];

    for (let row of matrix) {
        for (let cell of row) {
            values.push(cell);
        }
    }

    for (let i = 0; i < boxes.length; i++) {
        document.getElementById(boxes[i]).innerHTML = values[i];
    }
}

function Reset() {
    matrix = [
        ["", "", ""],
        ["", "", ""],
        ["", "", ""]
    ];

    DisplayMatrix();
}

function checkWinner() {
    const lines = [
        [[0,0],[0,1],[0,2]],
        [[1,0],[1,1],[1,2]],
        [[2,0],[2,1],[2,2]],
        [[0,0],[1,0],[2,0]],
        [[0,1],[1,1],[2,1]],
        [[0,2],[1,2],[2,2]],
        [[0,0],[1,1],[2,2]],
        [[0,2],[1,1],[2,0]],
    ];

    for (let line of lines) {
        const [[x1,y1],[x2,y2],[x3,y3]] = line;

        const v1 = matrix[x1][y1];
        const v2 = matrix[x2][y2];
        const v3 = matrix[x3][y3];

        if (v1 !== "" && v1 === v2 && v2 === v3) {
            alert(v1 + " wins!");
            return true;
        }
    }
    return false;
}


function TicTacToe(x, y) {

    if (matrix[x][y] !== "") return;

    let moves = CalculateCount();
    if (moves % 2 === 0) {
        matrix[x][y] = "O";  
    } else {
        matrix[x][y] = "X";
    }

    DisplayMatrix();
    checkWinner();
}
