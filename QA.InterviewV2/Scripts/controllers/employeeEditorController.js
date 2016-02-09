(function () {

    angular.module("app-employees")
        .controller("employeeEditorController", employeeEditorController);

    function employeeEditorController($routeParams, $http, $location) {
        var viewModel = this;

        viewModel.employeeInfo = {};

        viewModel.employeeId = $routeParams.employeeId;

        viewModel.dependents = [];
        viewModel.errorMessage = "";
        viewModel.isBusy = true;

        $http.get("/api/employees/" + viewModel.employeeId)
            .then(function (response) {
                angular.copy(response.data, viewModel.employeeInfo);
            }, function (err) {
                viewModel.errorMessage = "Failed to Load Employee Info." + err;
            })
            .finally(function () {
                viewModel.isBusy = false;
            });

        viewModel.editEmployee = function () {
            viewModel.isBusy = true;
            viewModel.errorMessage = "";

            $http.patch("/api/employees/" + viewModel.employeeId, viewModel.employeeInfo)
                .then(function () {
                    $location.path("/");
                }, function (error) {
                    viewModel.errorMessage = "Failed to edit employee: " + error;
                })
                .finally(function () {
                    viewModel.isBusy = false;
                });
        };
    }

})();