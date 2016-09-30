angular.module("DataServices", ["constants"])
    .service("UserAPI", ["UserController", "$http", function (UserController, $http) {
        this.Login = function (UserName, Password, ResultCallback) {
            var Result = { };

            $http.post(UserController, { UserName: UserName, Password: Password })
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