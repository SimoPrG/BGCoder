/* globals module */
function solve() {
    function clear(node) {
        while (node.firstChild) {
            node.removeChild(node.firstChild);
        }
    }

    return function (selector, items) {
        // on the left
        var imageViewer = document.createElement('div');
        imageViewer.className = 'image-preview';
        imageViewer.style.cssText = 'display: inline-block; vertical-align: top; width: 60%; text-align: center;';

        var bigImageTitle = document.createElement('h3');
        bigImageTitle.innerHTML = items[0].title;

        imageViewer.appendChild(bigImageTitle);

        var bigImage = document.createElement('img');
        bigImage.style.cssText = 'width: 90%';
        bigImage.src = items[0].url;

        imageViewer.appendChild(bigImage);

        // on the right
        var imagePreviewer = document.createElement('div');
        imagePreviewer.style.cssText = 'display: inline-block; vertical-align: top; width: 40%; height: 600px; overflow: auto; text-align: center;';

        var input = document.createElement('input');
        input.id = 'image-preview-input-' + Math.random();
        input.addEventListener('input', function () {
            var imageContainers = ul.children;
            for (var i = 0, len = imageContainers.length; i < len; i += 1) {
                if (imageContainers[i].firstElementChild.innerHTML.toLowerCase().indexOf(input.value.toLowerCase()) >= 0) {
                    imageContainers[i].style.display = '';
                } else {
                    imageContainers[i].style.display = 'none';
                }
            }
        }, false);

        var label = document.createElement('label');
        label.setAttribute('for', input.id);
        label.style.display = 'block';
        label.innerHTML = 'Filter';

        imagePreviewer.appendChild(label);
        imagePreviewer.appendChild(input);

        var ul = document.createElement('ul');
        ul.style.cssText = 'list-style-type: none; margin: 0; padding: 0;';

        ul.addEventListener('mouseover', function (ev) {
            changeBackgroundColor(ev, 'grey');
        }, false);

        ul.addEventListener('mouseout', function (ev) {
            changeBackgroundColor(ev, '');
        }, false);

        ul.addEventListener('click', function (ev) {
            var imageContainer = ev.target;

            while (imageContainer.className.indexOf('image-container') < 0) {
                if (imageContainer.tagName === 'UL') {
                    return;
                }

                imageContainer = imageContainer.parentNode;
            }

            if (imageContainer) {
                var index = imageContainer.getAttribute('data-id');
                bigImageTitle.innerHTML = items[index].title;
                bigImage.src = items[index].url;
            }
        }, false);

        var li = document.createElement('li');
        li.className = 'image-container';
        li.style.cursor = 'pointer';

        var smallImageTitle = document.createElement('h4');
        var smallImage = document.createElement('img');
        smallImage.style.width = '95%';

        for (var i = 0, len = items.length; i < len; i += 1) {
            var currentSmallImageTitle = smallImageTitle.cloneNode(true);
            currentSmallImageTitle.innerHTML = items[i].title;

            var currentSmallImage = smallImage.cloneNode(true);
            currentSmallImage.src = items[i].url;

            var currentLi = li.cloneNode(true);
            currentLi.setAttribute('data-id', i);

            currentLi.appendChild(currentSmallImageTitle);
            currentLi.appendChild(currentSmallImage);

            ul.appendChild(currentLi);
        }

        imagePreviewer.appendChild(ul);

        var documentFragment = document.createDocumentFragment();

        documentFragment.appendChild(imageViewer);
        documentFragment.appendChild(imagePreviewer);

        var container = document.querySelector(selector);

        clear(container);

        container.appendChild(documentFragment);

        function changeBackgroundColor(ev, color) {
            var imageContainer = ev.target;

            while (imageContainer.className.indexOf('image-container') < 0) {
                if (imageContainer.tagName === 'UL') {
                    return;
                }

                imageContainer = imageContainer.parentNode;
            }

            if (imageContainer) {
                imageContainer.style.backgroundColor = color;
            }
        }
    };
}

module.exports = solve;