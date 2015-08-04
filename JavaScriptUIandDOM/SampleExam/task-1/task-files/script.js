var createCalendar = (function() {
    var i,
        currentDay,
        currentWeek,
        prevDay,
        days = ['Sat', 'Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        dayHead = createElementWithClass('div', 'day-head'),
        day = createElementWithClass('div', 'day'),
        week = createElementWithClass('div', 'week'),
        event = createElementWithClass('span', 'event');

    function prepareEvents(events) {
        var preparedEvents = {};

        events.forEach(function (event) {
            preparedEvents[event.date] = event;
        });

        return preparedEvents;
    }

    function createElementWithClass(elementName, className) {
        var element = document.createElement(elementName);
        element.className = className;
        return element;
    }

    function isBlank(str) {
        return (!str || /^\s*$/.test(str));
    }

    function validateIfStringAndNotEmpty(str) {
        if (typeof str !== 'string') {
            throw new Error('id must be a string');
        }

        if (isBlank(str)) {
            throw new Error('id must not be empty or only white spaces');
        }
    }

    function validateIfArray(arr) {
        if (!(arr instanceof Array)) {
            throw new Error('events must be an array');
        }
    }

    function createDay(date, currentEvent) {
        var currentDayHead = dayHead.cloneNode(true),
            currentDayEvent = event.cloneNode(true),
            currentDay = day.cloneNode(true);

        currentDayHead.innerHTML = days[(date % 7)] + ' ' + date + ' June 2014';

        currentDay.appendChild(currentDayHead);

        if (currentEvent) {
            currentDayEvent.innerHTML = currentEvent.title + '<br>' + currentEvent.hour + '<br>' + currentEvent.duration;
            currentDay.appendChild(currentDayEvent);
        }

        return currentDay;
    }

    function createWeek(weekNumber, preparedEvents) {
        var currentDay,
            currentEvent,
            currentWeek = week.cloneNode(true);

        for (var i = weekNumber * 7 + 1; i <= weekNumber * 7 + 7; i += 1) {
            if (i > 30) {
                break;
            }

            currentEvent = preparedEvents[i];
            currentDay = createDay(i, currentEvent);
            currentWeek.appendChild(currentDay);
        }

        return currentWeek;
    }

    function createMonth(preparedEvents) {
        var documentFragment = document.createDocumentFragment();

        for (i = 0; i < 5; i += 1) {
            currentWeek = createWeek(i, preparedEvents);
            documentFragment.appendChild(currentWeek);
        }
        return documentFragment;
    }

    function selectDay(day) {

        prevDay = currentDay;
        currentDay = day;

        if (prevDay) {
            prevDay.style.backgroundColor = '';
        }

        currentDay.style.backgroundColor = 'darkgrey';
    }

    function onHoverChangeDayHeadBackgroundColor(ev, color) {
        var day = ev.target;
        if (day.className === 'day') {
            var dayHead = day.querySelector('.day-head');
            dayHead.style.backgroundColor = color;
        }
    }

    dayHead.style.textAlign = 'center';
    dayHead.style.fontWeight = 'bold';
    dayHead.style.backgroundColor = 'grey';
    dayHead.style.borderBottom = '1px solid black';

    day.style.display = 'inline-block';
    day.style.width = '150px';
    day.style.height = '150px';
    day.style.border = '1px solid black';

    event.style.float = 'left';
    event.style.margin = '10px';

    return function(selector, events) {
        var index,
            len,
            preparedEvents = prepareEvents(events),
            calendarContainers = document.querySelectorAll(selector);

        validateIfStringAndNotEmpty(selector);
        validateIfArray(events);

        for (index = 0, len = calendarContainers.length; index < len; index += 1) {
            calendarContainers[index].appendChild(createMonth(preparedEvents));

            calendarContainers[index].addEventListener('mouseover', function (ev) {
                onHoverChangeDayHeadBackgroundColor(ev, 'darkgrey');
            }, false);

            calendarContainers[index].addEventListener('mouseout', function (ev) {
                onHoverChangeDayHeadBackgroundColor(ev, 'grey');
            }, false);

            calendarContainers[index].addEventListener('click', function (ev) {
                var day = ev.target;
                if (day.className === 'day') {
                    selectDay(day);
                }
            }, false);
        }
    };
}());