(function () {
    angular.module("reusableControls", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            templateUrl: "Scripts/views/waitCursor.html"
        };
    }

})();