(function () {
    angular.module("app-employees")
        .controller("employeesController", employeesController);

    function employeesController($http) {

        var viewModel = this;

        viewModel.employees = [];

        viewModel.newEmployee = {};

        viewModel.errorMessage = "";
        viewModel.isBusy = true;

        $http.get("/api/employees")
            .then(function (response) {
                angular.copy(response.data, viewModel.employees);
            }, function (error) {
                viewModel.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                viewModel.isBusy = false;
            });

        viewModel.addEmployee = function () {
            viewModel.isBusy = true;
            viewModel.errorMessage = "";

            $http.post("/api/employees", viewModel.newEmployee)
                .then(function (response) {
                    viewModel.employees.push(response.data);
                    viewModel.newEmployee = {};
                }, function (error) {
                    viewModel.errorMessage = "Failed to save new employee: " + error;
                })
                .finally(function () {
                    viewModel.isBusy = false;
                });
        };
    }
})();