function solve(params) {
    var i,
        row,
        move,
        from,
        to,
        len = params.length,
        rows = +params[0],
        board = [];

    for (row = 0; row < rows; row += 1) {
        board[row] = params[row + 2].split('');
    }

    for (i = rows + 3; i < len; i += 1) {
        move = params[i].split(' ');
        from = translatePosition(move[0]);
        to = translatePosition(move[1]);

        if (from.row === to.row && from.col === to.col) {
            console.log('no');
            continue;
        }

        switch (board[from.row][from.col]) {
            case '-':
                console.log('no');
                break;
            case 'R':
                if (isValidRockMove(from, to) && isPathFree(from, to)) {
                    console.log('yes');
                } else {
                    console.log('no');
                }
                break;
            case 'B':
                if (isValidBishopMove(from, to) && isPathFree(from, to)) {
                    console.log('yes');
                } else {
                    console.log('no');
                }
                break;
            case 'Q':
                debugger;
                if ((isValidBishopMove(from, to) || isValidRockMove(from, to)) && isPathFree(from, to)) {
                    console.log('yes');
                } else {
                    console.log('no');
                }
                break;
            default :
                console.log('no');
        }
    }

    function translatePosition(str) {
        return {row: rows - str[1], col: str.charCodeAt(0) - 97}
    }

    function isValidRockMove(from, to) {
        return from.row === to.row || from.col === to.col;
    }

    function isValidBishopMove(from, to) {
        return from.row - from.col === to.row - to.col || from.row + from.col === to.row + to.col;
    }

    function isPathFree(from, to) {
        var fr = from.row,
            fc = from.col,
            tr = to.row,
            tc = to.col;

        while(fr !== tr || fc !== tc) {
            if (board[tr][tc] !== '-') {
                return false;
            }

            if (tr > fr) {
                tr -= 1;
            } else if (tr < fr) {
                tr += 1;
            }

            if (tc > fc) {
                tc -= 1;
            } else if (tc < fc) {
                tc += 1;
            }
        }

        return true;
    }
}

var tests = [
    [
        '3',
        '4',
        '--R-',
        'B--B',
        'Q--Q',
        '12',
        'd1 b3',
        'a1 a3',
        'c3 b2',
        'a1 c1',
        'a1 b2',
        'a1 c3',
        'a2 b3',
        'd2 c1',
        'b1 b2',
        'c3 b1',
        'a2 a3',
        'd1 d3'
    ],
    [
        '5',
        '5',
        'Q---Q',
        '-----',
        '-B---',
        '--R--',
        'Q---Q',
        '10',
        'a1 a1',
        'a1 d4',
        'e1 b4',
        'a5 d2',
        'e5 b2',
        'b3 d5',
        'b3 a2',
        'b3 d1',
        'b3 a4',
        'c2 c5'
    ]
];

tests.forEach(function (test) {
    solve(test);
});