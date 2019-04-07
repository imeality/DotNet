
    var App = angular.module('DemoApp', ['ngRoute']);
    App.config(function ($routeProvider) {
        $routeProvider
            .when("/signin", {
                templateUrl: "PaymentForm.html",
               
            })
            .when("/signup", {
                templateUrl: "MembershipForm.html",
                controller: "UserDataController"

            });
        $routeProvider.when("/about", {
            templateUrl: "About.html",
        });

        $routeProvider.when("/home", {
            templateUrl: "Home.html",
        });
        $routeProvider.when("/IndividualMembership", {
            templateUrl: "IndividualMembership.html",
        });
        $routeProvider.when("/Employer", {
            templateUrl: "Employer.html",
        });
        $routeProvider.when("/Insurance", {
            templateUrl: "Insurance.html",
        });
        $routeProvider.when("/Memberships", {
            templateUrl: "Memberships.html",
        });
        $routeProvider.when("/Hospitals", {
            templateUrl: "Hospitals.html",
        });
        $routeProvider.when("/HealthPlus", {
            templateUrl: "HealthPlus.html",
        });
        $routeProvider.when("/LiveDoc", {
            templateUrl: "LiveDoc.html",
        });
    });

App.controller('UserDataController', function ($scope,$window, $http) {
   
    $scope.MembershipType_Id = '1';
    $scope.Password = "123";
    $scope.ConfirmPasswords = "12";
  
    $scope.SaveData = function (data) {
        $scope.user = data;
        $http.post("http://localhost:51878/api/Users/AddUser", $scope.user).then(function (response) {
            if ($scope.user.MembershipType_Id == 2 || $scope.user.MembershipType_Id == 3) {
                $window.location.href = "http://localhost:53803/PaymentForm.html";
            }
            else {
                $window.location.href = "http://localhost:53803/index.html";
            }
            console.log(response);
        });
    };
   
});

