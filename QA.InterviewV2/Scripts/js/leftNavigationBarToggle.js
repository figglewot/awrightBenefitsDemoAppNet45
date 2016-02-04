(function () {

    var $leftNavBarAndBody = $("#leftNavigationBar,#body");
    var $icon = $("#leftNavigationBarToggle i.fa");

    $("#leftNavigationBarToggle").on("click", function () {
        $leftNavBarAndBody.toggleClass("hide-sidebar");
        if ($leftNavBarAndBody.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-chevron-left");
            $icon.addClass("fa-chevron-right");
        } else {
            $icon.addClass("fa-chevron-left");
            $icon.removeClass("fa-chevron-right");
        }
    });
})();