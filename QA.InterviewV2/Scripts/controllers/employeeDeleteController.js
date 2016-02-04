(function () {

    angular.module("app-employees")
        .controller("employeeDeleteController", employeeDeleteController);

    function employeeDeleteController($routeParams, $http, $location) {
        var viewModel = this;

        viewModel.employeeInfo = {};

        viewModel.employeeId = $routeParams.employeeId;

        viewModel.errorMessage = "";
        viewModel.isBusy = true;

        $http.delete("/api/employees/" + viewModel.employeeId)
            .then(function (response) {
                viewModel.ServerResponse = response;
                $location.path("#//");
            }, function(err) {
                viewModel.errorMessage = "Failed to Delete Employee" + err;
            })
            .finally(function() {
                viewModel.isBusy = false;
            });
    }

})();