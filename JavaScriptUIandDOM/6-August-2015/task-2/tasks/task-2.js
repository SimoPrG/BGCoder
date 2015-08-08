function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // you are welcome :)
        var date = new Date();
        //console.log(date.getDayName());
        //console.log(date.getMonthName());

        this.wrap('<div class="datepicker-wrapper" />');
        this.addClass('datepicker');
        var $picker = $('<div />').addClass('picker');
        this.after($picker);

        var $controls = $('<div />').addClass('controls');

        var $btnLeft = $('<button />').html('<').addClass('btn');
        var $currentMonth = $('<span />').html(date.getMonthName());
        var $btnRight = $('<button />').html('>').addClass('btn');
        $controls.append($btnLeft).append($currentMonth).append($btnRight);
        $picker.append($controls);

        var $calendar = $('<table />').addClass('calendar');
        $picker.append($calendar);

        var $currentDateLink = $('<div />').addClass('current-date-link').html(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear());
        $picker.append($currentDateLink);

        return this;
    };
}

//module.exports = solve;