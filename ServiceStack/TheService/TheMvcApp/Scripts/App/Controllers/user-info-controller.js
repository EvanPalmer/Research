userApp.controller('UserInfoController', function UserInfoController($scope, $route, $routeParams, $location, $http, Users) {
    $scope.save = function () {
        Users.save($scope.user, function (u, s) {
            $scope.users = Users.query();
        });
    };

    $scope.users = Users.query();
});