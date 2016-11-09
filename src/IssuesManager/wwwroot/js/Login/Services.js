angular.module("DataServices", ["constants"])
    .service("UserAPI", ["UserController", "$http", function (UserController, $http) {
        this.Login = function (UserName, Password, Remember, ResultCallback) {
            var Result = {};

            $http.post(UserController + '/Login', { UserName: UserName, Password: Password, Remember: Remember })
                .then(function (response) {
                    Result = {
                        Test: "OK",
                        Result: response.data
                    };

                    ResultCallback(Result);
                },
                function (response) {
                    Result = {
                        Text: "Error",
                        Result: false
                    }

                    ResultCallback(Result);
                });
        };

        this.Register = function (Name, Email, UserName, Password, RePassword, ResultCallback) {
            $http.post(UserController + '/Register' , { Name: Name, Email: Email, UserName: UserName, Password: Password, RePassword: RePassword })
            .then(function (response) {
                Result = {
                    Test: "OK",
                    Result: response.data
                };

                ResultCallback(Result);
            },
            function (response) {
                Result = {
                    Text: "Error",
                    Result: false
                }

                ResultCallback(Result);
            });
        }
    }]);