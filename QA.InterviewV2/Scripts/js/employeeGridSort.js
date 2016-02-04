(function () {
    var $employeeIdSort = $("#employeeIdSort");
    var $employeeIdSortIcon = $("#employeeIdSort i.fa");

    var $employeeNameSort = $("#employeeNameSort");
    var $employeeNameSortIcon = $("#employeeNameSort i.fa");

    $employeeIdSort.on("click", function () {
        if ($employeeIdSortIcon.hasClass("fa-chevron-down")) {
            $employeeIdSortIcon.removeClass("fa-chevron-down");
            $employeeIdSortIcon.addClass("fa-chevron-up");
        } else {
            $employeeIdSortIcon.addClass("fa-chevron-down");
            $employeeIdSortIcon.removeClass("fa-chevron-up");
        }
    });

    $employeeNameSort.on("click", function () {
        if ($employeeNameSortIcon.hasClass("fa-chevron-down")) {
            $employeeNameSortIcon.removeClass("fa-chevron-down");
            $employeeNameSortIcon.addClass("fa-chevron-up");
        } else {
            $employeeNameSortIcon.addClass("fa-chevron-down");
            $employeeNameSortIcon.removeClass("fa-chevron-up");
        }
    });
})();