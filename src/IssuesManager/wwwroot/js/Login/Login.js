var App = angular.module("root", ["DataServices", 'pascalprecht.translate']);

App.controller("loginController", ["$scope", "UserAPI", "$window", function ($scope, UserAPI, $window) {
    $scope.ResponseData = { Result : true }

    $scope.LoginHasError = function () { return !$scope.ResponseData.Result; };
    $scope.LoginHasSuccess = function () { return $scope.ResponseData.Result; };

    $scope.LoginClick = function () {
        UserAPI.Login($scope.UserName, $scope.password, $scope.remember, function (ResultData) {
            $scope.ResponseData = ResultData;

            if ($scope.ResponseData.Result) {
                $scope.Message = "· User logged in";
                $window.location.href = "/Landing";
            } else {
                $scope.Message = "· Something went bad";
                $scope.UserName = "";
                $scope.password = "";
                $scope.remember = false;
            }
        });
    }
}]);

App.controller("registerController", ["$scope", "UserAPI", function ($scope, UserAPI) {
    $scope.ResponseData = { Result: true }

    $scope.LoginHasError = function () { return !$scope.ResponseData.Result; };
    $scope.LoginHasSuccess = function () { return $scope.ResponseData.Result; };

    $scope.RegisterClick = function () {
        UserAPI.Register($scope.Name, $scope.Email, $scope.UserName, $scope.Password, $scope.RePassword, function (Result) {
            $scope.ResponseData = Result;

            if ($scope.ResponseData.Result) {
                $scope.Message = "· User registered";
            } else {
                $scope.Message = "· Something went bad";
                $scope.Name = "";
                $scope.Email = "";
                $scope.UserName = "";
                $scope.Password = "";
                $scope.RePassword = "";
            }
        });
    };
}]);

App.config(["$translateProvider", function ($translateProvider) {

    var translationsen = {
        LOGINTITLE: 'Log In',
        EMAILADDRESS: 'Email Address',
        PASSWORD: 'Password',
        REMEMBER: 'Remember me',
        LOGIN: "Login",
        REGISTER: "Sign in",
        YOURNAME: "Your Name",
        YOUREMAIL: "Your Email",
        USERNAME: "User Name",
        CONFIRMPASSWORD: "Retype Password",
        ENTERYOURNAME: "Enter your name",
        ENTERYOUREMAIL: "Enter your email",
        ENTERYOURUSERNAME: "Enter your Username",
        ENTERYOURPASSWORD: "Enter your Password",
        RETYPEYOURPASSWORD: "Retype your Password"
    };

    var translationes = {
        LOGINTITLE: 'Identifícate',
        EMAILADDRESS: 'Correo Electronico',
        PASSWORD: 'Contraseña',
        REMEMBER: 'Recuerdame',
        LOGIN: "Continuar",
        REGISTER: "Registrate",
        YOURNAME: "Tu nombre",
        YOUREMAIL: "Tu email",
        USERNAME: "Nombre de Usuario",
        CONFIRMPASSWORD: "Confirmar Contraseña",
        ENTERYOURNAME: "Introduce tu nombre",
        ENTERYOUREMAIL: "Introduce tu email",
        ENTERYOURUSERNAME: "Introduce tu usuario",
        ENTERYOURPASSWORD: "Introduce tu contraseña",
        RETYPEYOURPASSWORD: "Vuelve a introducir tu contraseña"
    }

    $translateProvider
        .translations('en', translationsen)
        .translations('es', translationes)
        .preferredLanguage('es');
}]);