(function () {
    angular.module("app-employees", ["reusableControls", "ngRoute"])
        .config(function($routeProvider, $locationProvider) {

            $routeProvider.when("/", {
                controller: "employeesController",
                controllerAs: "viewModel",
                templateUrl: "Scripts/views/employeesView.html"
            });

            $routeProvider.when("/addNewEmployee", {
                controller: "employeesController",
                controllerAs: "viewModel",
                templateUrl: "Scripts/views/addNewEmployeeView.html"
            });

            $routeProvider.when("/editEmployee/:employeeId", {
                controller: "employeeEditorController",
                controllerAs: "viewModel",
                templateUrl: "Scripts/views/employeeEditorView.html"
            });

            $routeProvider.when("/deleteEmployee/:employeeId", {
                controller: "employeeDeleteController",
                controllerAs: "viewModel",
                templateUrl: "Scripts/views/employeesView.html"
            });

            $routeProvider.when("/addDependents/:employeeId", {
                controller: "dependentsController",
                controllerAs: "viewModel",
                templateUrl: "Scripts/views/addDependentsView.html"
            });

            $routeProvider.when("/viewEmployeeDetails/:employeeId", {
                controller: "employeeDetailController",
                controllerAs: "viewModel",
                templateUrl: "Scripts/views/viewEmployeeDetailsView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

            $locationProvider.html5Mode(true);
        });
})();