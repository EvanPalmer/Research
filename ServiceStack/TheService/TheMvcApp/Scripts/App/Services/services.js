angular.module('UserServices', ['ngResource'])
    .factory('Users', function ($resource) {
        return $resource('/UserInfo/Users');
    });