function solve(params) {
    var nk = params[0].split(' ').map(Number),
        n = nk[0],
        k = nk[1],
        numbers = params[1].split(' ').map(Number),
        ksum = 0;

    for (var i = 0; i < k; i += 1) {
        numbers = numbers.map(function (number, index, array) {

            if (number === 0) {
                if (index === 0) {
                    return zeroGetMod(array[n - 1], array[1]);
                } else if (index === n - 1) {
                    return zeroGetMod(array[0], array[n - 2]);
                } else {
                    return zeroGetMod(array[index - 1], array[index + 1]);
                }
            } else if (number === 1) {
                if (index === 0) {
                    return oneGetSum(array[n - 1], array[1]);

                } else if (index === n - 1) {
                    return oneGetSum(array[0], array[n - 2]);


                } else {
                    return oneGetSum(array[index - 1], array[index + 1]);

                }
            } else if (!(number % 2)) { // number is even
                if (index === 0) {
                    return evenGetMax(array[n - 1], array[1]);

                } else if (index === n - 1) {
                    return evenGetMax(array[0], array[n - 2]);


                } else {
                    return evenGetMax(array[index - 1], array[index + 1]);

                }
            } else { //number is odd
                if (index === 0) {
                    return oddGetMin(array[n - 1], array[1]);

                } else if (index === n - 1) {
                    return oddGetMin(array[0], array[n - 2]);


                } else {
                    return oddGetMin(array[index - 1], array[index + 1]);

                }
            }
        });
    }

    function zeroGetMod(x, y) {
        return Math.abs(x - y);
    }

    function evenGetMax(x, y) {
        return x > y ? x : y;
    }

    function oneGetSum(x, y) {
        return x + y;
    }

    function oddGetMin(x, y) {
        return x < y ? x : y;
    }

    return numbers.reduce(function(prev, current){
        return prev + current;
    });
}

var tests = [
    ['5 1', '9 0 2 4 1'],
    ['10 3', '1 9 1 9 1 9 1 9 1 9']
];

tests.forEach(function (test) {
    console.log(solve(test));
});