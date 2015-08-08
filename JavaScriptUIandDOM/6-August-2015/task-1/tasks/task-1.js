function solve() {
    return function (selector, isCaseSensitive) {
        isCaseSensitive = isCaseSensitive || false;

        function createElementWithClass(elementName, className) {
            var element = document.createElement(elementName);
            element.className = className;

            return element;
        }

        function clear(node) {
            while (node.firstChild) {
                node.removeChild(node.firstChild);
            }
        }

        function validateSelector(text) {
            if (typeof text !== 'string') {
                throw new TypeError('invalid selector');
            }
        }
        
        function validateBoolean(boolean) {
            if (typeof boolean !== 'boolean') {
                throw new TypeError('invalid isCaseSensitive');
            }
        }

        validateBoolean(isCaseSensitive);
        
        validateSelector(selector);
        // Add

        var itemsControl = createElementWithClass('div', 'items-control');

        var addControls = createElementWithClass('div', 'add-controls');

        var addControlsLabel = document.createElement('label');
        addControlsLabel.innerHTML = 'Enter text';
        addControlsLabel.setAttribute('for', 'add-controls-input');

        addControls.appendChild(addControlsLabel);

        var addControlsInput = document.createElement('input');
        addControlsInput.id = 'add-controls-input';

        addControls.appendChild(addControlsInput);

        var addControlsButton = createElementWithClass('button', 'button');
        addControlsButton.innerHTML = 'Add';

        var listItem = createElementWithClass('li', 'list-item');
        var listItemRemoveButton = createElementWithClass('button', 'button');
        var listItemText = document.createElement('strong');

        addControlsButton.addEventListener('click', function () {
            var currentListItem = listItem.cloneNode(true);
            var currentListItemRemoveButton = listItemRemoveButton.cloneNode(true);
            currentListItemRemoveButton.innerHTML = 'X';

            var currentListItemText = listItemText.cloneNode(true);
            currentListItemText.innerHTML = addControlsInput.value;

            currentListItem.appendChild(currentListItemRemoveButton);
            currentListItem.appendChild(currentListItemText);

            itemsList.appendChild(currentListItem);
        }, false);

        addControls.appendChild(addControlsButton);

        itemsControl.appendChild(addControls);

        // Search

        var searchControls = createElementWithClass('div', 'search-controls');

        var searchControlsLabel = document.createElement('label');
        searchControlsLabel.innerHTML = 'Search:';
        searchControlsLabel.setAttribute('for', 'search-controls-input');

        searchControls.appendChild(searchControlsLabel);

        var searchControlsInput = document.createElement('input');
        searchControlsInput.id = 'search-controls-input';
        searchControlsInput.addEventListener('input', function () {

            var listItems = itemsList.children;

            for (var i = 0, len = listItems.length; i < len; i += 1) {
                if (isCaseSensitive) {
                    if (listItems[i].querySelector('strong').innerHTML.indexOf(searchControlsInput.value) >= 0) {
                        listItems[i].style.display = '';
                    } else {
                        listItems[i].style.display = 'none';

                    }
                } else {
                    if (listItems[i].querySelector('strong').innerHTML.toLowerCase().indexOf(searchControlsInput.value.toLowerCase()) >= 0) {
                        listItems[i].style.display = '';
                    } else {
                        listItems[i].style.display = 'none';
                    }
                }
            }
        }, false);

        searchControls.appendChild(searchControlsInput);

        itemsControl.appendChild(searchControls);

        // Results

        var resultControls = createElementWithClass('div', 'result-controls');

        var itemsList = createElementWithClass('ul', 'items-list');
        itemsList.addEventListener('click', function (ev) {
            var listItemButton = ev.target;
            if (listItemButton.className.indexOf('button') < 0) {
                return;
            }

            var listItem = listItemButton.parentElement;

            listItem.parentElement.removeChild(listItem);
            
        }, false);

        resultControls.appendChild(itemsList);

        itemsControl.appendChild(resultControls);

        var selectedElement = document.querySelector(selector); // TODO: validate
        clear(selectedElement);

        selectedElement.appendChild(itemsControl);

    };
}

//module.exports = solve;