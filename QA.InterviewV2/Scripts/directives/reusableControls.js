(function () {
    angular.module("reusableControls", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            templateUrl: "/../views/waitCursor.html"
        };
    }

})();