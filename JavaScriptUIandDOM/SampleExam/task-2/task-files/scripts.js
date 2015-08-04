$.fn.tabs = function () {
    var $currentTab;
    this.addClass('tabs-container').on('click', '.tab-item', function () {
        if ($currentTab) {
            $currentTab.toggleClass('current').find('.tab-item-content').toggle();
        }

        $currentTab = $(this);
        $currentTab.toggleClass('current').find('.tab-item-content').toggle();

    }).find('.tab-item-content').hide();
};