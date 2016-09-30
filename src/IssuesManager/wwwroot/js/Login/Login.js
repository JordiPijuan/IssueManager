var App = angular.module("root", ["DataServices", 'pascalprecht.translate']);

App.controller("loginController", ["$scope", "UserAPI", function ($scope, UserAPI) {
    $scope.UserName;
    $scope.Password;
    $scope.ResponseData = { Result : true }
    $scope.Message;


    $scope.LoginHasError = function () { return !$scope.ResponseData.Result; };
    $scope.LoginHasSuccess = function () { return $scope.ResponseData.Result; };

    $scope.LoginClick = function () {
        UserAPI.Login($scope.UserName, $scope.password, function (ResultData) {
            $scope.ResponseData = ResultData;

            if ($scope.ResponseData.Result) {
                $scope.Message = "· User logged in";
            } else {
                $scope.Message = "· Something went bad";
            }
        });
    }
}]);

App.config(["$translateProvider", function ($translateProvider) {

    var translationsen = {
        LOGINTITLE: 'Please login',
        EMAILADDRESS: 'Email Address',
        PASSWORD: 'Password',
        REMEMBER: 'Remember me',
        LOGIN: "Login"
    };

    var translationes = {
        LOGINTITLE: 'Identifícate',
        EMAILADDRESS: 'Correo Electronico',
        PASSWORD: 'Contraseña',
        REMEMBER: 'Recuerdame',
        LOGIN: "Continuar"
    }

    $translateProvider
        .translations('en', translationsen)
        .translations('es', translationes)
        .preferredLanguage('es');
}]);