var userApp = angular.module('UserInfo', ['ngRoute', 'UserServices'])

.config(function ($routeProvider, $provide, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: '/Scripts/App/Views/info-form.html',
        controller: 'UserInfoController'
    });
    
    $provide.factory('notify', ['$http', function (http) {
        var msgs = [];
        return function (msg) {
            msgs.push(msg);
            if (msgs.length == 3) {
                win.alert(msgs.join("\n"));
                msgs = [];
            }
        };
    }]);
});
