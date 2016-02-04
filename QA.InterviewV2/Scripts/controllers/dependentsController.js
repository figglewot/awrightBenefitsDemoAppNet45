(function () {
    angular.module("app-employees")
        .controller("dependentsController", dependentsController);

    function dependentsController($routeParams, $http) {

        var viewModel = this;

        viewModel.employeeId = $routeParams.employeeId;

        var dependentsRequestUrl = "/api/employees/" + viewModel.employeeId + "/dependents";
        var employeeRequestUrl = "/api/employees/" + viewModel.employeeId;

        viewModel.dependents = [];
        viewModel.newDependent = {};

        viewModel.employeeInfo = {};

        viewModel.errorMessage = "";
        viewModel.isBusy = true;

        $http.get(employeeRequestUrl)
            .then(function (response) {
                angular.copy(response.data, viewModel.employeeInfo);
            }, function (err) {
                viewModel.errorMessage = "Failed to Load Employee Info." + err;
            })
            .finally(function () {
                viewModel.isBusy = false;
            });

        $http.get(dependentsRequestUrl)
            .then(function (response) {
                angular.copy(response.data, viewModel.dependents);
            }, function (err) {
                viewModel.errorMessage = "Failed to load Dependents";
            })
            .finally(function () {
                viewModel.isBusy = false;
            });

        viewModel.addDependent = function () {
            viewModel.isBusy = true;
            $http.post(dependentsRequestUrl, viewModel.newDependent)
                .then(function (response) {
                    viewModel.dependents.push(response.data);
                    viewModel.newDependent = {};
                }, function (err) {
                    viewModel.errorMessage = "Failed to add dependent";
                })
                .finally(function () {
                    viewModel.isBusy = false;
                });
        }
    }
})();