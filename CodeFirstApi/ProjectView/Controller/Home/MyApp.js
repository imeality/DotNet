
var App = angular.module('HealthPlusApp', ['ngRoute', 'toaster', 'ui.bootstrap']);
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
            templateUrl: "about.html",
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
            .when("/userdashboard", {
                templateUrl: "UserDashBoard.html",
                controller:"UserDashBoardController"
            })
            .when("/createprescription", {
                 templateUrl:"Prescription.html",
                controller: "createprescriptionctrl"
            })
    });
//Registration

App.controller('UserDataController', function ($scope,$window,$http) {
   
    $scope.MembershipType_Id = '1';
    $scope.Password = "123";
    $scope.ConfirmPasswords = "12";
    $scope.SaveData = function (data) {

        $scope.user = data;
        $http.post("http://localhost:51878/api/Users/AddUser", $scope.user).then(function (response) {
          
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

//login
App.controller('LogInDataController', function ($scope, $http, $window) {
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
            //   if (response.status == 200) {
            //    alert(response.data.access_token);
            alert("successfully login");
            // $window.location.href = "#!UserDashBoard";
            $http({
                method: 'GET',
                url: 'http://localhost:51878/api/Users/GetUserDashBoard',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'Authorization': 'Bearer ' + response.data.access_token
                }

            }).then(function success(response) {
                //  alert(response.status);
                console.log(response);
                console.log(response.data[0]);
                console.log(response.config.headers.Authorization);
                $scope.access_token = response.config.headers.Authorization;
                $scope.name = response.data[0];
                $scope.Mid = response.data[1];
                $scope.Email = response.data[2]
                $window.location.href = "#!userdashboard?Mid=" + $scope.Mid + "&access_token=" + $scope.access_token + "&name=" + $scope.name;
            }, function error() {
                alert(response);
            }
            );
        }, function error(response) {
            console.log(response.status);
            alert("UserName or password is invalid");
            //  $window.location.href = "#!home";
        });
    };
});


//After Login

App.controller('UserDashBoardController', function ($scope, $location,$uibModal,msgService) {
   // var name = $location.search().name;
   // alert("Account Number  is - " + $location.search()['name']);

    $scope.Mid = $location.search()['Mid'];
    $scope.name = $location.search()['name'];

    console.log($scope.Mid);
    msgService.setMsg($scope.name);

   
    $scope.open = function () {
        console.log('opening pop up');
        var modalInstance = $uibModal.open({
            templateUrl: 'PrescriptionForm.html',
        });
    }
    $scope.contactopen = function () {
        console.log('opening pop up');
        var modalInstance = $uibModal.open({
            templateUrl: 'ContactForm.html',
        });
    }
   
    });

//SendPrescription
App.controller('sendprescriptionctrl', function ($scope,$http,$window,msgService) {
    $scope.from_Prescription =  msgService.getmsg() ;
    $scope.SaveData = function () {

        var data ={
          
            To_Prescription: $scope.To_Prescription,
           Prescription_Info: $scope.Prescription_Info
        };
        console.log(data);
      //  GetIdByName
        $http.get("http://localhost:51878/api/Users/GetUserByName/" + $scope.from_Prescription).then(function (response) {
            console.log(response);

            console.log(response.data[0].User_Id);
            var from_Prescription = response.data[0].User_Id;

            //GetIdByEmail
            $http.get("http://localhost:51878/api/Users/GetUserByEmail/" + $scope.To_Prescription).then(function (response) {
                console.log(response);

                console.log(response.data[0].User_Id);
                var To_Prescription1 = response.data[0].User_Id;

                /*
                //AddPrescription
                $http.post("http://localhost:51878/api/Prescriptions/AddPrescription", $scope.user).then(function (response) {
                */
                $http.post("http://localhost:51878/api/Prescriptions/SendPrescription", data).then(function (response) {
                    console.log(response);
                    //  $window.location.href = "#!UserDashBoard.html";

                    /*  if ($scope.user.MembershipType_Id == 2 || $scope.user.MembershipType_Id == 3) {
                          $window.location.href = "http://localhost:53803/PaymentForm.html";
                      }
                      else {
                          $window.location.href = "http://localhost:53803/index.html";
                      }
                      */
                });
            });
        });
    };

});

//Contact
App.controller('contactctrl', function ($scope, $http, $window, msgService) {
    $scope.Name = msgService.getmsg();
    $scope.SaveData = function () {

        var data = {

            From_Contact: $scope.From_Contact,
            Message: $scope.Message
        };
        console.log(data);
               /*
                //AddPrescription
                $http.post("http://localhost:51878/api/Prescriptions/AddPrescription", $scope.user).then(function (response) {
                */
                $http.post("http://localhost:51878/api/Contacts/GetContact", data).then(function (response) {
                    console.log(response);
                   
            
        });
    };

});

App.service('msgService', function () {
    var message;
    this.setMsg = function (msg) {
        message = msg;
    };
    this.getmsg = function () {
        return message;
    };
}
);



