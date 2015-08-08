function solve() {
    return function () {
        /* globals $ */
        $.fn.gallery = function (cols) {
            cols = cols || 4;
            var $this = this,
                $galleryList = $this.children('.gallery-list'),
                imagesCount = $galleryList.children().length,
                $selected = $this.children('.selected').hide(),
                $currentImage = $selected.find('#current-image'),
                $previousImage = $selected.find('#previous-image'),
                $nextImage = $selected.find('#next-image'),
                $block = $('<div />').addClass('disabled-background');

            function setSelectedImages(currentDataInfo) {
                currentDataInfo = parseInt(currentDataInfo);
                var previousDataInfo = currentDataInfo - 1 < 1 ? imagesCount : currentDataInfo - 1;
                var nextDataInfo = currentDataInfo + 1 > imagesCount ? 1 : currentDataInfo + 1;

                function getSrc(dataInfo) {
                    return $galleryList.find('img[data-info=' + dataInfo + ']').attr('src');
                }

                $currentImage.attr('src', getSrc(currentDataInfo));
                $previousImage.attr('src', getSrc(previousDataInfo));
                $previousImage.attr('data-info', previousDataInfo);
                $nextImage.attr('src', getSrc(nextDataInfo));
                $nextImage.attr('data-info', nextDataInfo);
            }

            $this.addClass('gallery').on('click', 'img[data-info]', function (ev) {
                var currentDataInfo = $(ev.target).attr('data-info');
                setSelectedImages(currentDataInfo);
                $galleryList.addClass('blurred').append($block);
                $selected.show();
            }).find('.image-container').each(function (index) {
                if (!(index % cols)) {
                    $(this).addClass('clearfix');
                }
            });

            $currentImage.on('click', function () {
                $block = $galleryList.removeClass('blurred').detach('.disabled-background');
                $selected.hide();
            })
        };
    };
}

//module.exports = solve;