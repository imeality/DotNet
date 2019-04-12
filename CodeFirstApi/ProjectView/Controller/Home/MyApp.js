
var App = angular.module('HealthPlusApp', ['ngRoute','toaster']);
    App.config(function ($routeProvider) {
        $routeProvider
            .when("/login", {
                templateUrl: "LogIn.html",
                controller: "LogInDataController"

            })
        .when("/signup", {
            templateUrl: "MembershipForm.html",
            controller: "UserDataController"

        })
        .when("/about", {
            templateUrl: "About.html",
        })

       .when("/home", {
            templateUrl: "Home.html",
        })
      .when("/IndividualMembership", {
            templateUrl: "IndividualMembership.html",
        })
      .when("/Employer", {
            templateUrl: "Employer.html",
        })
      .when("/Insurance", {
            templateUrl: "Insurance.html",
        })
       .when("/Memberships", {
            templateUrl: "Memberships.html",
        })
       .when("/Hospitals", {
            templateUrl: "Hospitals.html",
        })
       .when("/HealthPlus", {
            templateUrl: "HealthPlus.html",
        })
        .when("/LiveDoc", {
            templateUrl: "LiveDoc.html",
            })
            .when("/UserDashBoard", {
                templateUrl: "UserDashBoard.html",
            })
    });

App.controller('UserDataController', function ($scope,$window,toaster, $http) {
   
    $scope.MembershipType_Id = '1';
    $scope.Password = "123";
    $scope.ConfirmPasswords = "12";
    $scope.pop = function () {
        //toaster.toast.body='toast-top-center'
        toaster.pop('success', "title", 'Its address is https://google.com.', 5000, 'trustedHtml', function (toaster) {
            var match = toaster.body.match(/http[s]?:\/\/[^\s]+/);
            if (match) $window.open(match[0]);
            return true;
        });
    };
  
    $scope.SaveData = function (data) {

        $scope.user = data;
        $http.post("http://localhost:51878/api/Users/AddUser", $scope.user).then(function (response) {
            $scope.pop();
            $http.post("http://localhost:51878/api/Users/SendMail", $scope.user).then(function (response) {

                if ($scope.user.MembershipType_Id == 2 || $scope.user.MembershipType_Id == 3) {
                    $window.location.href = "http://localhost:53803/PaymentForm.html";
                }
                else {
                    $window.location.href = "http://localhost:53803/index.html";
                }
                console.log(response);
            });
        });
    };
   
});

App.controller('LogInDataController', function ($scope, $http,$window) {
    $scope.ValidData = function (data) { 
        $scope.user = data;

        var auth = 'UserName=' + $scope.user.UserName + '&' + 'Password=' + $scope.user.Password + '&grant_type=password';

        $http({
            method: "POST",
            url: 'http://localhost:51878/token',
            data: auth,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }

        }).then(function success(response) {
            console.log(response);
            $window.location.href="#!UserDashBoard"
    });
}
    });
