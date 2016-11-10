var App = angular.module("root", ["DataServices", 'pascalprecht.translate', 'loading']);

App.controller("loginController", ["$scope", "UserAPI", "$window", "$translate", function ($scope, UserAPI, $window, $translate) {
    $scope.ResponseData = { Result: true }
    $scope.ShowLoginForm = true;
    $scope.loading = false;
    $scope.LoginHasError = function () { return !$scope.ResponseData.Result; };
    $scope.LoginHasSuccess = function () { return $scope.ResponseData.Result; };

    $scope.LoginClick = function () {

        $scope.ShowLoginForm = false;
        $scope.loading = true;

        UserAPI.Login($scope.UserName, $scope.password, $scope.remember, function (ResultData) {
            $scope.ResponseData = ResultData;

            if ($scope.ResponseData.Result) {

                $translate("USERLOGEDIN").then(function (translation) {
                    $scope.Message = translation;
                });

                $window.location.href = "/Landing";
            } else {
                $scope.loading = false;
                $scope.ShowLoginForm = true;

                $translate("SOMETHINGWENTBAD").then(function (translation) {
                    $scope.Message = translation;
                });
                $scope.remember = false;
            }
        });
    }
}]);

App.controller("registerController", ["$scope", "UserAPI", "$translate", function ($scope, UserAPI, $translate) {
    $scope.ResponseData = { Result: true }
    $scope.ShowRegisterForm = true;
    $scope.LoginHasError = function () { return !$scope.ResponseData.Result; };
    $scope.LoginHasSuccess = function () { return $scope.ResponseData.Result; };
    $scope.loading = false;
    $scope.RegisterClick = function () {

        $scope.loading = true;
        $scope.ShowRegisterForm = false;
        $scope.Message = "";
        UserAPI.Register($scope.Name, $scope.Email, $scope.UserName, $scope.Password, $scope.RePassword, function (Result) {
            $scope.ResponseData = Result;

            if ($scope.ResponseData.Result) {
                $scope.ShowRegisterForm = false;
                $scope.loading = false;
                $translate("USERREGISTERED").then(function (translation) {
                    $scope.Message = translation;
                });
            } else {
                $scope.ShowRegisterForm = true;
                $scope.loading = false;
                $translate("SOMETHINGWENTBAD").then(function (translation) {
                    $scope.Message = translation;
                });
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
        RETYPEYOURPASSWORD: "Retype your Password",
        USERLOGEDIN: "· User Loged In",
        SOMETHINGWENTBAD: "· Something Went Bad",
        USERREGISTERED: "· User Registered"
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
        RETYPEYOURPASSWORD: "Vuelve a introducir tu contraseña",
        USERLOGEDIN: "· Usuario Logeado",
        SOMETHINGWENTBAD: "· Algo ha funcionado mal",
        USERREGISTERED: "· Usuario registrado"
    }

    $translateProvider
        .translations('en', translationsen)
        .translations('es', translationes)
        .preferredLanguage('en');
}]);