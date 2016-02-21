(function () {

    angular.module("app-employees")
        .controller("employeeDetailController", employeeDetailController);

    function employeeDetailController($routeParams, $http) {
        var viewModel = this;

        viewModel.employeeInfo = {};

        viewModel.employeeId = $routeParams.employeeId;

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
    }

})();