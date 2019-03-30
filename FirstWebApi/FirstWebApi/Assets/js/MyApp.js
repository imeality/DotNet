
    var App = angular.module('DemoApp', ['ngRoute']);
    App.config(function ($routeProvider) {
        $routeProvider
            .when("/signin", {
                templateUrl: "SendPrescription.html",
                controller: "PresCtrl"
            })
            .when("/signup", {
                templateUrl: "SignUp.html",
                controller: "UserDataController"

            });
    });

    App.controller('UserDataController', function ($scope, AddDataService) {

        //veriables with default values.

        $scope.submitText = "Save";

    $scope.submitted = false;

    $scope.message = '';

    $scope.isFormValid = false;

    $scope.Student = {

        Uid: '',

    Fname: '',

    Lname: '',

    Password: '',

    Contact: ''

    };
    $scope.SaveData = function (data) {
    $scope.user = data;

    AddDataService.SaveFormData($scope.user).then(function (d) {

        alert(d);

    if (d == 'Success') {

        //clear form after successful data registration

        alert("yes");

    }
    });

    }
  });

    App.factory('AddDataService', function ($http, $q) {

    var fac = {};

    fac.SaveFormData = function (data) {

    var defer = $q.defer();

    $http({

        url: 'http://localhost:55634/api/Users/PostUser',

    method: 'POST',

    data: data

    }).success(function (d) {

        //Callback after success

        defer.resolve(d);

    }).error(function (e) {

        //Callback after failed

        alert('ERROR!');

    defer.reject(e);

    });

    return defer.promise;

    }

    return fac;

    });

